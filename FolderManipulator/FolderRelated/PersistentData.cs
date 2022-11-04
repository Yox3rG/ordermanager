using FolderManipulator.Analytics;
using FolderManipulator.Data;
using FolderManipulator.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FolderManipulator.FolderRelated
{
    class PersistentData
    {
        public Action OnSourcePathChanged;
        public Action OnSourcePathAccepted;

        public Action OnSaveAllWaitingItems_Successful;
        public Action OnSaveAllWaitingItems_PartialSuccess;
        public Action OnSaveAllWaitingItems_Failed;

        private string activeOrdersFileName = "active_orders.json";
        private string pendingOrdersFileName = "pending_orders.json";
        private string finishedOrdersFileName = "finished_orders.json";
        private string settingsFileName = "settings.json";
        private string lockFileName = "lock.lock";
        private string archiveFolderName = "Archive";
        private string archiveFilePrefix = "archived_orders";
        private string archiveFileSuffix = ".json";
        private string sourcePath;

        private string localDataFileName = "local.json";
        private string localBackupFolderName = "backup";

        private float saveMinDelay = 1f;
        private float saveMaxRandomDelayAfterMin = 4f;

        private Task _savingTask;
        private CancellationTokenSource _currentCancellationTokenSource;
        private List<SavableDataWithPath> _itemsWaitingForSave = new List<SavableDataWithPath>();
        private List<SavableDataWithPath> _itemsWaitingForLocalSave = new List<SavableDataWithPath>();

        private int _maxLocalBackupIndex = 2;
        private int _currentLocalBackupIndex = 0;

        public bool IsSourceReady { get; private set; } = false;

        public string SourcePath { get { return sourcePath; } private set { } }

        public string ActiveTasksPath
        {
            get { return GetCombinedPath(activeOrdersFileName); }
            private set { }
        }

        public string PendingTasksPath
        {
            get { return GetCombinedPath(pendingOrdersFileName); }
            private set { }
        }

        public string FinishedTasksPath
        {
            get { return GetCombinedPath(finishedOrdersFileName); }
            private set { }
        }

        public string SettingsPath
        {
            get { return GetCombinedPath(settingsFileName); }
            private set { }
        }

        public string LockPath
        {
            get { return GetCombinedPath(lockFileName); }
            private set { }
        }

        public double RandomSaveDelay
        {
            get
            {
                var rand = new Random();
                return rand.NextDouble() * saveMaxRandomDelayAfterMin + saveMinDelay;
            }
        }

        private IEnumerable<string> GeneratedFileNames()
        {
            yield return GetCombinedPath(activeOrdersFileName);
            yield return GetCombinedPath(pendingOrdersFileName);
            yield return GetCombinedPath(finishedOrdersFileName);
            yield return GetCombinedPath(settingsFileName);
        }

        public PersistentData()
        {
        }

        public bool LoadSourcePathFromLocal()
        {
            LocalSettingsData localSettings = IOHandler.Load<LocalSettingsData>(localDataFileName);
            SettingsManager.InitializeLocalSettings(localSettings);
            return SetSourcePath(SettingsManager.LocalSettings.SourcePath);
        }

        public string GetCombinedPath(string fileName)
        {
            if (sourcePath != null && fileName != null)
                return System.IO.Path.Combine(sourcePath, fileName);
            return null;
        }

        public string GetCombinedPath(string folder, string fileName)
        {
            if (folder != null && fileName != null)
                return System.IO.Path.Combine(folder, fileName);
            return null;
        }

        public string GetCombinedArchivePath(string archiveFilePrefix)
        {
            if (sourcePath != null)
            {
                string archiveFolderPath = System.IO.Path.Combine(sourcePath, archiveFolderName);
                int year = DateTime.Now.Year;
                int lastMonth = DateTime.Now.Month - 1;
                if (lastMonth == 0)
                {
                    year--;
                    lastMonth = 12;
                }
                string yearAndLastMonth = year.ToString() + '_' + lastMonth;
                return System.IO.Path.Combine(archiveFolderPath, archiveFilePrefix + '_' + yearAndLastMonth + archiveFileSuffix);
            }

            return null;
        }

        public bool DoesArchiveForLastMonthExists()
        {
            bool exists = System.IO.File.Exists(GetCombinedArchivePath(archiveFilePrefix));
            return exists;
        }  

        public bool ArchiveOrderList(OrderList orderList)
        {
            CreateFolderIfNotPresent(System.IO.Path.Combine(sourcePath, archiveFolderName), out _);

            OrderListType oldType = orderList.Type;
            orderList.Type = OrderListType.Archived;

            bool success = true;
            success &= IOHandler.Save(GetCombinedArchivePath(archiveFilePrefix), orderList);

            orderList.Type = oldType;

            AppConsole.WriteLine($"archiveOrder", list: (success ? "succesfull" : "failed"));
            return success;
        }

        public DataState GetDataState(bool showStatusMessage, OrderList oldActiveOrders, OrderList oldPendingOrders, OrderList oldFinishedOrders, SettingsData oldSettings)
        {
            bool isEveryObjectPresent = true;
            bool isDataOnLatestUpdate = true;

            SettingsData settings = LoadSettings();
            if (settings == null)
            {
                MissingObjectError(DataType.Settings);
            }
            OrderList activeOrders = LoadOrderList(OrderListType.Active);
            if (activeOrders == null)
            {
                MissingObjectError(DataType.ActiveOrders);
            }
            OrderList pendingOrders = LoadOrderList(OrderListType.Pending);
            if (pendingOrders == null)
            {
                MissingObjectError(DataType.PendingOrders);
            }
            OrderList finishedOrders = LoadOrderList(OrderListType.Finished);
            if (finishedOrders == null)
            {
                MissingObjectError(DataType.FinishedOrders);
            }

            if (!isEveryObjectPresent)
            {
                return DataState.MissingObject;
            }

            isDataOnLatestUpdate &= oldSettings.UpdateID.Equals(settings.UpdateID);
            isDataOnLatestUpdate &= activeOrders.UpdateID.Equals(oldActiveOrders.UpdateID);
            isDataOnLatestUpdate &= pendingOrders.UpdateID.Equals(oldPendingOrders.UpdateID);
            isDataOnLatestUpdate &= finishedOrders.UpdateID.Equals(oldFinishedOrders.UpdateID);

            return isDataOnLatestUpdate ? DataState.Latest : DataState.NotLatest;

            void MissingObjectError(DataType dataType)
            {
                isEveryObjectPresent = false;
                if (showStatusMessage)
                {
                    StatusManager.ShowMessage($"unableToSyncServer", StatusColorType.Error, DelayTimeType.Short, list: dataType);
                }
            }
        }

        public bool CheckAndCreateLock()
        {
            return IOHandler.CheckAndCreateLock(LockPath);
        }

        public bool ReleaseLock()
        {
            return IOHandler.ReleaseLock(LockPath);
        }

        #region Settings
        // Add new types to
        // SaveWaitingItem()
        public bool SettingsExist()
        {
            return LoadSettings() != null;
        }

        public SettingsData LoadSettings()
        {
            SettingsData settings = IOHandler.Load<SettingsData>(SettingsPath);
            return settings;
        }

        public void AddSettingsToWaitingForSaveList(SettingsData settings)
        {
            SavableDataWithPath dataWithPath = new SavableDataWithPath(SettingsPath, settings);
            AddDataToWaitingForSaveList(dataWithPath);
        }

        public bool SaveLocalSettings()
        {
            AppConsole.WriteLine($"trySaveLocalSettings");
            return IOHandler.Save<LocalSettingsData>(localDataFileName, SettingsManager.LocalSettings);
        }
        #endregion

        #region Orders
        // Add new types to
        // SaveWaitingItem()
        public bool OrderListExist(OrderListType type)
        {
            return LoadOrderList(type) != null;
        }

        public OrderList LoadOrderList(OrderListType type)
        {
            OrderList orderList = IOHandler.Load<OrderList>(OrderListTypeToFullPath(type));
            return orderList;
        }

        public void AddOrderListToWaitingForSaveList(OrderList orderList)
        {
            SavableDataWithPath dataWithPath = new SavableDataWithPath(OrderListTypeToFullPath(orderList.Type), orderList);
            AddDataToWaitingForSaveList(dataWithPath);
        }
        #endregion

        #region SaveToServer
        public void AddDataToWaitingForSaveList(SavableDataWithPath dataWithPath)
        {
            int existingIndex = _itemsWaitingForSave.IndexOf(x => x.path.Equals(dataWithPath.path));
            if (existingIndex == -1)
            {
                _itemsWaitingForSave.Add(dataWithPath);
            }
            else
            {
                _itemsWaitingForSave.RemoveAt(existingIndex);
                _itemsWaitingForSave.Insert(existingIndex, dataWithPath);
            }
        }

        public bool TrySaveWaitingItems(bool tryAgainOnFailAfterRandomTime = true)
        {
            try
            {
                _currentCancellationTokenSource?.Cancel();
            }
            catch (Exception ex)
            {
                AppConsole.WriteLine("CancellationToken disposed already!");
            }

            if (!SaveAllWaitingItems() && tryAgainOnFailAfterRandomTime)
            {
                StartTrySaveAllWaitingItemsTask();
                return false;
            }
            return true;
        }

        private void StartTrySaveAllWaitingItemsTask()
        {
            _currentCancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = _currentCancellationTokenSource.Token;
            _savingTask = Task.Run(async () =>
            {
                try
                {
                    do
                    {
                        if (cancelToken.IsCancellationRequested)
                        {
                            cancelToken.ThrowIfCancellationRequested();
                        }
                        await Task.Delay(TimeSpan.FromSeconds(RandomSaveDelay), cancelToken);
                        if (cancelToken.IsCancellationRequested)
                        {
                            cancelToken.ThrowIfCancellationRequested();
                        }
                    }
                    while (!SaveAllWaitingItems());
                }
                catch (OperationCanceledException ex)
                {
                    AppConsole.WriteLine("SaveTask cancelled!");
                }
                finally
                {
                    _currentCancellationTokenSource.Dispose();
                }
            }, cancelToken);
        }

        private bool SaveAllWaitingItems()
        {
            int successCount = 0;
            int waitingCount = _itemsWaitingForSave.Count;
            while (_itemsWaitingForSave.Count > 0)
            {
                bool success = SaveWaitingItem(_itemsWaitingForSave[0]);
                if (success)
                {
                    successCount++;
                    _itemsWaitingForSave.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }
            AppConsole.WriteLine($"CurrentList: {_itemsWaitingForSave.ToString<SavableDataWithPath>()}");

            if (successCount == waitingCount)
            {
                OnSaveAllWaitingItems_Successful?.Invoke();
                AppConsole.WriteLine("Save successful!");
            }
            else if (successCount == 0)
            {
                OnSaveAllWaitingItems_Failed?.Invoke();
                AppConsole.WriteLine("Save failed!");
            }
            else
            {
                OnSaveAllWaitingItems_PartialSuccess?.Invoke();
                AppConsole.WriteLine("Save partially successful!");
            }
            return successCount == waitingCount;
        }

        private bool SaveWaitingItem(SavableDataWithPath dataWithPath)
        {
            bool success = false;
            if (dataWithPath.data is SettingsData)
            {
                success = IOHandler.Save(dataWithPath.path, dataWithPath.data as SettingsData);
            }
            else if (dataWithPath.data is OrderList)
            {
                success = IOHandler.Save(dataWithPath.path, dataWithPath.data as OrderList);
            }
            return success;
        }
        #endregion

        #region Local Backup
        public void AddDataToLocalWaitingForSaveList(SettingsData settings)
        {
            SavableDataWithPath dataWithPath = new SavableDataWithPath(GetCombinedPath(localBackupFolderName, _currentLocalBackupIndex.ToString() + '_' + settingsFileName), settings);
            AddDataToLocalSaveWaitingList(dataWithPath);
        }

        public void AddDataToLocalWaitingForSaveList(OrderList orderList)
        {
            SavableDataWithPath dataWithPath = new SavableDataWithPath(OrderListTypeToLocalPath(orderList.Type), orderList);
            AddDataToLocalSaveWaitingList(dataWithPath);
        }

        public void AddDataToLocalSaveWaitingList(SavableDataWithPath dataWithPath)
        {
            _itemsWaitingForLocalSave.Add(dataWithPath);
        }

        public bool SaveWaitingLocalBackupData()
        {
            CreateFolderIfNotPresent(localBackupFolderName, out _);

            bool success = true;
            foreach (SavableDataWithPath dataWithPath in _itemsWaitingForLocalSave)
            {
                if (dataWithPath.data is SettingsData)
                {
                    success &= IOHandler.Save(dataWithPath.path, dataWithPath.data as SettingsData);
                }
                else if (dataWithPath.data is OrderList)
                {
                    success &= IOHandler.Save(dataWithPath.path, dataWithPath.data as OrderList);
                }
            }

            if (++_currentLocalBackupIndex > _maxLocalBackupIndex)
            {
                _currentLocalBackupIndex = 0;
            }
            _itemsWaitingForLocalSave.Clear();
            AppConsole.WriteLine($"Local backup", list: (success ? "succesfull" : "failed"));
            return success;
        }
        #endregion

        public string OrderListTypeToFullPath(OrderListType type)
        {
            switch (type)
            {
                case OrderListType.Active:
                    return ActiveTasksPath;
                case OrderListType.Pending:
                    return PendingTasksPath;
                case OrderListType.Finished:
                    return FinishedTasksPath;
            }
            return null;
        }

        public string OrderListTypeToLocalPath(OrderListType type)
        {
            switch (type)
            {
                case OrderListType.Active:
                    return GetCombinedPath(localBackupFolderName, _currentLocalBackupIndex.ToString() + '_' + activeOrdersFileName);
                case OrderListType.Pending:
                    return GetCombinedPath(localBackupFolderName, _currentLocalBackupIndex.ToString() + '_' + pendingOrdersFileName);
                case OrderListType.Finished:
                    return GetCombinedPath(localBackupFolderName, _currentLocalBackupIndex.ToString() + '_' + finishedOrdersFileName);
            }
            return null;
        }

        public bool SetSourcePath(string path)
        {
            if (path == null)
                return false;

            bool isCorrectPath = System.IO.Directory.Exists(path);

            if (isCorrectPath)
            {
                sourcePath = path;
                OnSourcePathChanged?.Invoke();

                IsSourceReady = false;
                return true;
            }

            return false;
        }

        public bool AcceptSourcePath()
        {
            bool isCorrectPath = System.IO.Directory.Exists(sourcePath);
            if (isCorrectPath)
            {
                SettingsManager.LocalSettings.SourcePath = sourcePath;
                IOHandler.Save<LocalSettingsData>(localDataFileName, SettingsManager.LocalSettings);

                IsSourceReady = true;
                //CreateGeneratedFilesIfNotPresent();
                OnSourcePathAccepted?.Invoke();

                return true;
            }
            return false;
        }

        private bool CreateGeneratedFilesIfNotPresent()
        {
            bool isSuccess = true;
            foreach (string path in GeneratedFileNames())
            {
                if (!CreateFileIfNotPresent(path))
                    isSuccess = false;
            }
            return isSuccess;
        }

        private bool CreateFileIfNotPresent(string path)
        {
            try
            {
                if (path != null && !System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path);
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public void CreateLocalDataFileIfNotPresent(out bool fileCreated)
        {
            if (!System.IO.File.Exists(localDataFileName))
            {
                System.IO.File.Create(localDataFileName);
                fileCreated = true;
            }
            else
            {
                fileCreated = false;
            }
        }

        public void CreateFolderIfNotPresent(string path, out bool fileCreated)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
                fileCreated = true;
            }
            else
            {
                fileCreated = false;
            }
        }

        #region Testing
        private Task _currentTask;
        public void StartTestTask()
        {
            _currentCancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = _currentCancellationTokenSource.Token;
            StatusManager.ShowMessage("Task starting.");
            _currentTask = Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(5000, cancelToken);
                    StatusManager.ShowMessage("Task finished.");
                    Console.WriteLine("Task finished!");
                }
                catch (OperationCanceledException ex)
                {
                    StatusManager.ShowMessage("Task cancelled.", StatusColorType.Error);
                    Console.WriteLine("Task cancelled!");
                }
                finally
                {
                    _currentCancellationTokenSource.Dispose();
                }
            }, cancelToken);
        }

        public void StopTestTask()
        {
            try
            {
                _currentCancellationTokenSource?.Cancel();
            }
            catch (ObjectDisposedException ex) { }
        }
        #endregion
    }
}
