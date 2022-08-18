﻿using FolderManipulator.FolderRelated;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.Analytics
{
    [Serializable]
    public static class ErrorManager
    {
        public static List<ErrorMessage> ErrorMessages { get; set; }

        private const string errorFolder = "error";
        private const string errorFile = "errors.csv";

        public static bool AreErrorMessagesLoaded { get { return ErrorMessages != null; } }
        private static string ErrorsFilePath { get { return Path.Combine(errorFolder, errorFile); } }

        static ErrorManager()
        {
            LoadErrorListFromCSV(ErrorsFilePath);
        }

        public static string GetErrorMessage(string id, params object[] list)
        {
            if (ErrorMessages == null)
                return string.Format(id, list);

            string errorMessage;
            int errorIndex = ErrorMessages.FindIndex(x => x.ID == id);
            if (errorIndex >= 0)
            {
                errorMessage = string.Format(ErrorMessages[errorIndex].Message, list);
            }
            else
            {
                errorMessage = string.Format(id, list);
            }
            return errorMessage;
        }

        private static void LoadErrorListFromCSV(string path)
        {
            ErrorMessages = IOHandler.LoadCSV<ErrorMessage>(path);
        }
    }
}
