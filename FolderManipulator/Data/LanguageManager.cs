﻿using FolderManipulator.Extensions;
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
    public class LanguageManager
    {
        public Action<LanguageType> OnLanguageChanged;

        private string languageFolder = "languages";
        private Dictionary<string, Dictionary<LanguageType, LanguageDataList>> formLanguageLists;
        private string[] formNames;

        private LanguageType currentLanguageType;

        private List<LanguageHandle> languageHandles;

        public LanguageManager(string[] formNames)
        {
            this.formNames = formNames;
            languageHandles = new List<LanguageHandle>();
        }

        public void ChangeLanguage(LanguageType language)
        {
            currentLanguageType = language;
            foreach (var handle in languageHandles)
            {
                handle.LoadLanguageListToForm(formLanguageLists[handle.FormName][language]);
            }
            OnLanguageChanged?.Invoke(language);
        }

        public LanguageHandle GetNewHandle(Form targetForm, MenuStrip menuStrip)
        {
            LanguageHandle languageHandle = new LanguageHandle(targetForm, menuStrip);
            languageHandles.Add(languageHandle);
            targetForm.FormClosed += delegate { if (languageHandles != null) languageHandles.Remove(languageHandle); };
            languageHandle.LoadLanguageListToForm(formLanguageLists[targetForm.Name][currentLanguageType]);
            return languageHandle;
        }

        public void LoadAllDataFromCSV()
        {
            if (formLanguageLists == null)
                formLanguageLists = new Dictionary<string, Dictionary<LanguageType, LanguageDataList>>();
            formLanguageLists.Clear();

            foreach (string formName in formNames)
            {
                formLanguageLists[formName] = LoadLanguageDataFromCSV(formName);
            }
        }

        private Dictionary<LanguageType, LanguageDataList> LoadLanguageDataFromCSV(string formName)
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

        public bool SaveAllDataToCSV()
        {
            bool success = true;
            foreach (string formName in formNames)
            {
                success &= SaveLanguageDataToCSV(formName);
            }
            return success;
        }

        private bool SaveLanguageDataToCSV(string formName)
        {
            bool success = true;
            foreach (LanguageType language in Enum.GetValues(typeof(LanguageType)))
            {
                success &= IOHandler.SaveCSV<LanguageData>(GetCSVPath(language, formName), formLanguageLists[formName][language].languageDatas);
            }
            return success;
        }

        public void MakeLanguageDataFromForms()
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

        private string GetCSVPath(LanguageType language, string formName)
        {
            string fileName = language.ToString().ToLower();
            fileName += "_" + formName + ".csv";
            return Path.Combine(languageFolder, fileName);
        }
    }
}
