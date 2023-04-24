using FolderManipulator.Data;
using FolderManipulator.FolderRelated;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.Analytics
{
    public static class ErrorManager
    {
        private static Dictionary<LanguageType, List<ErrorMessage>> errorMessageDictionary;

        private const string errorFolder = "error";
        private static Dictionary<LanguageType, string> errorFileNames;

        private const LanguageType defaultLanguage = LanguageType.English;

        public static bool AreErrorMessagesLoaded
        {
            get
            {
                if (errorMessageDictionary == null)
                    return false;
                foreach (var language in errorMessageDictionary.Keys)
                {
                    if (errorMessageDictionary[language] == null)
                        return false;
                }
                return true;
            }
        }

        static ErrorManager()
        {
            errorFileNames = new Dictionary<LanguageType, string>() {
                { LanguageType.English, "english_errors.csv" },
                { LanguageType.Hungarian, "hungarian_errors.csv" }
            };
            errorMessageDictionary = new Dictionary<LanguageType, List<ErrorMessage>>();
            foreach (var language in errorFileNames.Keys)
            {
                errorMessageDictionary[language] = LoadErrorListFromCSV(GetErrorFilePath(language));
            }
        }

        public static string GetDefaultErrorMessage(string id, params object[] list)
        {
            return GetErrorMessage(id, LanguageManager.DefaultLanguage, list);
        }

        public static string GetCurrentErrorMessage(string id, params object[] list)
        {
            return GetErrorMessage(id, LanguageManager.CurrentLanguage, list);
        }

        public static string GetErrorMessage(string id, LanguageType language, params object[] list)
        {
            if (errorMessageDictionary == null || !errorMessageDictionary.ContainsKey(language))
                return string.Format(id, list);
            if (errorMessageDictionary[language] == null)
            {
                return "There is a problem with the installation, language files not found." +
                    "Please reinstall the application!\n" +
                    "Original error message: [" + string.Format(id, list) + "]";
            }

            string errorMessage;
            int errorIndex = errorMessageDictionary[language].FindIndex(x => x.ID == id);
            if (errorIndex >= 0)
            {
                errorMessage = string.Format(errorMessageDictionary[language][errorIndex].Message, list);
            }
            else
            {
                errorMessage = string.Format(id, list);
            }
            return errorMessage;
        }

        private static List<ErrorMessage> LoadErrorListFromCSV(string path)
        {
            return IOHandler.LoadCSV<ErrorMessage>(path);
        }

        private static string GetErrorFilePath(LanguageType language)
        {
            return Path.Combine(errorFolder, errorFileNames[language]);
        }
    }
}
