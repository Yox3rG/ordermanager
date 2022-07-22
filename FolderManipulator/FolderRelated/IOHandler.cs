using FolderManipulator.Analytics;
using System;
using System.IO;
using System.Text.Json;

namespace FolderManipulator.FolderRelated
{
    public static class IOHandler
    {
        public static Action OnLoadSuccessful;
        public static Action OnLoadFailed;

        public static Action OnSaveSuccessful;
        public static Action OnSaveFailed;

        public static T Load<T>(string path) where T : class
        {
            T settings;
            try
            {
                string jsonSettings = File.ReadAllText(path);
                settings = JsonSerializer.Deserialize<T>(jsonSettings);
            }
            catch (Exception e)
            {
                // TODO: Handle IO errors.
                AppConsole.WriteLine(e.Message);

                OnLoadFailed?.Invoke();
                return null;
            }

            OnLoadSuccessful?.Invoke();
            return settings;
        }

        public static bool Save<T>(string path, T data)
        {
            string json = JsonSerializer.Serialize(data);
            //Console.WriteLine(json);
            try
            {
                File.WriteAllText(path, json);
            }
            catch (Exception e)
            {
                // TODO: Handle IO errors.
                AppConsole.WriteLine(e.Message);

                OnSaveFailed?.Invoke();
                return false;
            }

            OnSaveSuccessful?.Invoke();
            return true;
        }

        public static bool CheckAndCreateLock(string path)
        {
            if (File.Exists(path))
            {
                return false;
            }

            try
            {
                File.Create(path).Dispose();
            }
            catch (Exception e)
            {
                AppConsole.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public static bool ReleaseLock(string path)
        {
            if (!File.Exists(path))
            {
                return true;
            }

            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {
                AppConsole.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}
