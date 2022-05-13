using FolderManipulator.Data;
using FolderManipulator.UI;
using FolderManipulator.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FolderManipulator.FolderRelated
{
    static class PersistentData
    {
        public static Action OnSourcePathChanged;

        public static Action OnSaveAllWaitingItems_Successful;
        public static Action OnSaveAllWaitingItems_PartialSuccess;
        public static Action OnSaveAllWaitingItems_Failed;

        private static string activeOrdersFileName = "active_orders.json";
        private static string finishedOrdersFileName = "finished_orders.json";
        private static string settingsFileName = "settings.json";
        private static string sourcePath;

        private static string localDataFileName = "local.json";

        private static float saveMinDelay = 1f;
        private static float saveMaxRandomDelayAfterMin = 4f;

        private static Task _savingTask;
        private static CancellationTokenSource _currentCancellationTokenSource;
        private static List<SavableDataWithPath> _itemsWaitingForSave = new List<SavableDataWithPath>();

        public static bool IsSourceReady { get; private set; } = false;

        public static string SourcePath { get { return sourcePath; } private set { } }

        public static string ActiveTasksPath
        {
            get { return GetCombinedPath(activeOrdersFileName); }
            private set { }
        }

        public static string FinishedTasksPath
        {
            get { return GetCombinedPath(finishedOrdersFileName); }
            private set { }
        }

        public static string SettingsPath
        {
            get { return GetCombinedPath(settingsFileName); }
            private set { }
        }

        public static double RandomSaveDelay
        {
            get
            {
                var rand = new Random();
                return rand.NextDouble() * saveMaxRandomDelayAfterMin + saveMinDelay;
            }
        }

        private static IEnumerable<string> GeneratedFileNames()
        {
            yield return GetCombinedPath(activeOrdersFileName);
            yield return GetCombinedPath(finishedOrdersFileName);
            yield return GetCombinedPath(settingsFileName);
        }

        static PersistentData()
        {
            CreateLocalDataFileIfNotPresent();

            using (var sr = new System.IO.StreamReader(localDataFileName))
            {
                sourcePath = sr.ReadLine();
                OnSourcePathChanged?.Invoke();
            }

            //System.Windows.Forms.MessageBox.Show(sourcePath);

            IsSourceReady = System.IO.Directory.Exists(sourcePath);

            CreateGeneratedFilesIfNotPresent();
        }

        public static string GetCombinedPath(string fileName)
        {
            if (IsSourceReady)
                return System.IO.Path.Combine(sourcePath, fileName);
            return null;
        }

        #region Settings
        // Add new types to
        // SaveWaitingItem()
        public static SettingsData LoadSettings()
        {
            SettingsData settings = IOHandler.Load<SettingsData>(SettingsPath);
            return settings;
        }

        public static void AddSettingsToWaitingForSaveList(SettingsData settings)
        {
            SavableDataWithPath dataWithPath = new SavableDataWithPath(SettingsPath, settings);
            AddDataToWaitingForSaveList(dataWithPath);
        }
        #endregion

        #region Orders
        // Add new types to
        // SaveWaitingItem()
        public static OrderList LoadOrders(OrderListType type)
        {
            OrderList orderList = IOHandler.Load<OrderList>(OrderListTypeToPath(type));
            return orderList;
        }

        public static void AddOrderListToWaitingForSaveList(OrderList orderList)
        {
            SavableDataWithPath dataWithPath = new SavableDataWithPath(OrderListTypeToPath(orderList.Type), orderList);
            AddDataToWaitingForSaveList(dataWithPath);
        }
        #endregion

        public static void AddDataToWaitingForSaveList(SavableDataWithPath dataWithPath)
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

        public static bool TrySaveWaitingItems(bool tryAgainOnFailAfterRandomTime = true)
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

        private static void StartTrySaveAllWaitingItemsTask()
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

        private static bool SaveAllWaitingItems()
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

        private static int failCounter = 0;
        private static bool SaveWaitingItem(SavableDataWithPath dataWithPath)
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
            if ((failCounter++) % 3 != 0) success = false;
            return success;
        }

        public static string OrderListTypeToPath(OrderListType type)
        {
            switch (type)
            {
                case OrderListType.Active:
                    return ActiveTasksPath;
                case OrderListType.Finished:
                    return FinishedTasksPath;
            }
            return null;
        }

        public static bool SetSourcePath(string path)
        {
            bool isCorrectPath = System.IO.Directory.Exists(path);

            if (isCorrectPath)
            {
                using (var sw = new System.IO.StreamWriter(localDataFileName))
                {
                    sw.WriteLine(path);
                }

                sourcePath = path;
                OnSourcePathChanged?.Invoke();
                IsSourceReady = true;

                CreateGeneratedFilesIfNotPresent();
                return true;
            }

            return false;
        }

        private static bool CreateGeneratedFilesIfNotPresent()
        {
            bool isSuccess = true;
            foreach (string path in GeneratedFileNames())
            {
                if (!CreateFileIfNotPresent(path))
                    isSuccess = false;
            }
            return isSuccess;
        }

        private static bool CreateFileIfNotPresent(string path)
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

        private static bool CreateLocalDataFileIfNotPresent()
        {
            if (!System.IO.File.Exists(localDataFileName))
            {
                System.IO.File.Create(localDataFileName);
                return true;
            }
            return false;
        }

        #region Testing
        private static Task _currentTask;
        public static void StartTestTask()
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

        public static void StopTestTask()
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
