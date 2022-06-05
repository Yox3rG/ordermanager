using FolderManipulator.FolderRelated;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Analytics
{
    public static class AppConsole
    {
        private static int logMaxLines = 50;
        private static Queue<string> logs = new Queue<string>();

        public static void WriteLine(string message, [CallerMemberName] string memberName = null, [CallerFilePath] string sourceFilePath = null)
        {
            Console.WriteLine(AddLog(message, className: Path.GetFileName(sourceFilePath), functionName: memberName));
        }

        public static void SaveLog()
        {
            IOHandler.Save($"logs_{DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss")}.json", logs);
        }

        public static void SaveLogAutomatic()
        {
            IOHandler.Save($"logs_automatic.json", logs);
        }

        private static string AddLog(string message, string className, string functionName)
        {
            while (logs.Count >= logMaxLines)
            {
                logs.Dequeue();
            }
            string logWithDate = $"[{DateTime.Now}] {className} -> {functionName}(): {message}";
            logs.Enqueue(logWithDate);
            return logWithDate;
        }
    }
}
