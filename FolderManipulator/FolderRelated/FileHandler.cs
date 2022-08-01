using FolderManipulator.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.FolderRelated
{
    public static class FileHandler
    {
        public static void OpenFolderInExplorer(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo("explorer.exe", folderPath);
                    Process.Start(startInfo);
                }
                catch (Exception win32Exception)
                {
                    StatusManager.ShowMessage($"Can't start explorer! Error: {win32Exception.Message}", StatusColorType.Error, DelayTimeType.Medium);
                }
            }
            else
            {
                StatusManager.ShowMessage($"Directory [{folderPath}] does not exist!", StatusColorType.Warning, DelayTimeType.Medium);
            }
        }
    }
}
