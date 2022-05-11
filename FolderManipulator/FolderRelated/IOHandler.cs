using FolderManipulator.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
                string jsonSettings = System.IO.File.ReadAllText(path);
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
                System.IO.File.WriteAllText(path, json);
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
    }
}
