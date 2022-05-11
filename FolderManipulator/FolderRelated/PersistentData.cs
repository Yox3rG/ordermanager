using FolderManipulator.Data;
using FolderManipulator.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        public static bool TrySaveOrders(OrderList orders, bool tryAgainOnFailAfterRandomTime = true)
        {
            if (_savingTask != null && !_savingTask.IsCompleted)
                return false;
            if (!SaveOrders(orders))
            {
                _savingTask = TrySaveOrdersTask(orders);
                return false;
            }
            return true;
        }

        private static async Task TrySaveOrdersTask(OrderList orders)
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(RandomSaveDelay));

                if (SaveOrders(orders))
                {
                    break;
                }
            }
        }

        private static bool SaveOrders(OrderList orders)
        {
            bool success = IOHandler.Save<OrderList>(OrderListTypeToPath(orders.Type), orders);
            if (success)
                OnOrderSaveSuccessful?.Invoke();
            else
                OnOrderSaveFailed?.Invoke();
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
