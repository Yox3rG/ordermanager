using FolderManipulator.Extensions;
using FolderManipulator.FolderRelated;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.Data
{
    public static class LanguageManager
    {
        public static Action<LanguageType> OnLanguageChanged;

        private static string languageFolder = "languages";
        private static Dictionary<string, Dictionary<LanguageType, LanguageDataList>> formLanguageLists;
        private static string[] formNames = new string[] {
            nameof(form_main),
            nameof(form_ordertype_settings),
            nameof(form_settings),
            nameof(form_edit_order)
        };

        private static LanguageType currentLanguageType;
        private static List<LanguageHandle> languageHandles;

        public static LanguageType DefaultLanguage { get { return LanguageType.English; } }
        public static LanguageType CurrentLanguage
        {
            get
            {
                return currentLanguageType;
            }
            set
            {
                currentLanguageType = value;
                foreach (var handle in languageHandles)
                {
                    handle.LoadLanguageListToForm(formLanguageLists[handle.FormName][currentLanguageType]);
                }
                OnLanguageChanged?.Invoke(currentLanguageType);
            }
        }

        public static bool AreLanguagesLoaded
        {
            get
            {
                if (formLanguageLists == null)
                    return false;
                foreach (var dictionaryName in formLanguageLists.Keys)
                {
                    if (formLanguageLists[dictionaryName] == null)
                        return false;
                    foreach (var languageName in formLanguageLists[dictionaryName].Keys)
                    {
                        if (formLanguageLists[dictionaryName][languageName].languageDatas == null)
                            return false;
                    }
                }
                return true;
            }
        }

        static LanguageManager()
        {
            languageHandles = new List<LanguageHandle>();
        }

        public static LanguageHandle GetNewHandle(Form targetForm, MenuStrip menuStrip)
        {
            LanguageHandle languageHandle = new LanguageHandle(targetForm, menuStrip);
            languageHandles.Add(languageHandle);
            targetForm.FormClosed += delegate { if (languageHandles != null) languageHandles.Remove(languageHandle); };
            languageHandle.LoadLanguageListToForm(formLanguageLists[targetForm.Name][currentLanguageType]);
            return languageHandle;
        }

        public static void LoadAllDataFromCSV()
        {
            if (formLanguageLists == null)
                formLanguageLists = new Dictionary<string, Dictionary<LanguageType, LanguageDataList>>();
            formLanguageLists.Clear();

            foreach (string formName in formNames)
            {
                formLanguageLists[formName] = LoadLanguageDataFromCSV(formName);
            }
        }

        private static Dictionary<LanguageType, LanguageDataList> LoadLanguageDataFromCSV(string formName)
        {
            var languageLists = new Dictionary<LanguageType, LanguageDataList>();

            foreach (LanguageType language in Enum.GetValues(typeof(LanguageType)))
            {
                LanguageDataList languageDataList = new LanguageDataList(language);
                languageDataList.languageDatas = IOHandler.LoadCSV<LanguageData>(GetCSVPath(language, formName));

                languageLists[language] = languageDataList;
            }

            return languageLists;
        }

        public static bool SaveAllDataToCSV()
        {
            bool success = true;
            foreach (string formName in formNames)
            {
                success &= SaveLanguageDataToCSV(formName);
            }
            return success;
        }

        private static bool SaveLanguageDataToCSV(string formName)
        {
            bool success = true;
            foreach (LanguageType language in Enum.GetValues(typeof(LanguageType)))
            {
                success &= IOHandler.SaveCSV<LanguageData>(GetCSVPath(language, formName), formLanguageLists[formName][language].languageDatas);
            }
            return success;
        }

        public static void MakeLanguageDataFromForms()
        {
            if (formLanguageLists == null)
                formLanguageLists = new Dictionary<string, Dictionary<LanguageType, LanguageDataList>>();
            formLanguageLists.Clear();

            foreach (var handle in languageHandles)
            {
                formLanguageLists.Add(handle.FormName, new Dictionary<LanguageType, LanguageDataList>());
                formLanguageLists[handle.FormName][LanguageType.English] = handle.MakeLangugaeListsFromCurrentFormData(LanguageType.English);
                formLanguageLists[handle.FormName][LanguageType.Hungarian] = handle.MakeLangugaeListsFromCurrentFormData(LanguageType.Hungarian);
            }
        }

        private static string GetCSVPath(LanguageType language, string formName)
        {
            string fileName = language.ToString().ToLower();
            fileName += "_" + formName + ".csv";
            return Path.Combine(languageFolder, fileName);
        }
    }
}
