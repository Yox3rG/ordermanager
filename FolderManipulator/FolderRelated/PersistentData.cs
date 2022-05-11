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

        public static Action OnOrderSaveSuccessful;
        public static Action OnOrderSaveFailed;

        private static string activeOrdersFileName = "active_orders.json";
        private static string finishedOrdersFileName = "finished_orders.json";
        private static string settingsFileName = "settings.json";
        private static string sourcePath;

        private static string localDataFileName = "local.json";

        private static float saveMinDelay = 1f;
        private static float saveMaxRandomDelayAfterMin = 4f;

        private static Task _savingTask;
        private static CancellationTokenSource _currentCancellationTokenSource;
        private static Task _currentTask;

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

        public static bool SaveSettings(SettingsData settings)
        {
            string jsonSettings = JsonSerializer.Serialize(settings);
            Console.WriteLine(jsonSettings);
            try
            {
                System.IO.File.WriteAllText(SettingsPath, jsonSettings);
                Console.WriteLine(settings);
            }
            catch (Exception e)
            {
                // TODO: Handle IO errors.
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public static SettingsData LoadSettings()
        {
            SettingsData settings;
            try
            {
                string jsonSettings = System.IO.File.ReadAllText(SettingsPath);
                settings = JsonSerializer.Deserialize<SettingsData>(jsonSettings);
            }
            catch (Exception e)
            {
                // TODO: Handle IO errors.
                Console.WriteLine(e.Message);
                return null;
            }
            return settings;
        }

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

        public static bool TrySaveOrders(OrderList orders, bool tryAgainOnFailAfterRandomTime = true)
        {
            try
            {
                _currentCancellationTokenSource?.Cancel();
            }
            catch (ObjectDisposedException ex) { }

            if (!SaveOrders(orders) && tryAgainOnFailAfterRandomTime)
            {
                StartTrySaveOrdersTask(orders);
                return false;
            }
            return true;
        }

        private static void StartTrySaveOrdersTask(OrderList orders)
        {
            _currentCancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = _currentCancellationTokenSource.Token;
            _savingTask = Task.Run(async () =>
            {
                try
                {
                    do
                    {
                        await Task.Delay(TimeSpan.FromSeconds(RandomSaveDelay), cancelToken);
                    }
                    while (!SaveOrders(orders));
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

        private static int failCounter = 0;
        private static bool SaveOrders(OrderList orders)
        {
            bool success = IOHandler.Save<OrderList>(OrderListTypeToPath(orders.Type), orders);
            if ((failCounter++) % 3 != 0) success = false;

            if (success)
            {
                OnOrderSaveSuccessful?.Invoke();
                AppConsole.WriteLine("Save successful!");
            }
            else
            {
                OnOrderSaveFailed?.Invoke();
                AppConsole.WriteLine("Save failed!");
            }
            return success;
        }

        public static OrderList LoadOrders(OrderListType type)
        {
            OrderList orderList = IOHandler.Load<OrderList>(OrderListTypeToPath(type));
            return orderList;
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
    }
}
