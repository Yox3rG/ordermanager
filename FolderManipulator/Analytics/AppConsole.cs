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

        private static string AddLog(string message, string className, string functionName)
        {
            while (logs.Count >= logMaxLines)
            {
                logs.Dequeue();
            }
            string logWithDate = $"[{DateTime.Now}] {className}->{functionName}(): {message}";
            logs.Enqueue(logWithDate);
            return logWithDate;
        }
    }
}
