using FolderManipulator.Analytics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.UI
{
    static class StatusManager
    {
        private static StatusStrip _statusStrip;
        private static ToolStripStatusLabel _mainStatusStripLabel;

        private static Task _currentTask;
        private static CancellationTokenSource _currentCancellationTokenSource;

        private static string _mainStatusMessage = "...";
        private static string _defaultStatusMessage;
        private static Color _defaultStatusStripColor;

        public static void Initialize(StatusStrip statusStrip)
        {
            _statusStrip = statusStrip;
            _defaultStatusStripColor = statusStrip.BackColor;

            _mainStatusStripLabel = _statusStrip.Items.OfType<ToolStripStatusLabel>().FirstOrDefault();
            _defaultStatusMessage = _mainStatusMessage;

            StatusMessageRegister.Initialize();
        }

        public static void ShowMessage(string messageOrID, StatusColorType colorType = StatusColorType.Default, DelayTimeType resetAfter = DelayTimeType.None, params object[] list)
        {
            StopCurrentDelayedMessage();

            if (!string.IsNullOrEmpty(messageOrID))
            {
                _mainStatusMessage = ErrorManager.GetErrorMessage(messageOrID, list);
                _mainStatusStripLabel.Text = _mainStatusMessage;
                AppConsole.WriteLine(messageOrID);
            }
            _statusStrip.BackColor = GetStatusColorFromType(colorType);

            if(resetAfter != DelayTimeType.None)
            {
                ResetStripDelayed(GetWaitTimeFromType(resetAfter));
            }
        }

        public static void ResetStrip()
        {
            ShowMessage(_defaultStatusMessage);
        }

        public static void ShowMessageDelayed(int delayMillis, string message, StatusColorType colorType = StatusColorType.Default)
        {
            if (delayMillis <= 0)
            {
                ShowMessage(message, colorType);
                return;
            }

            StopCurrentDelayedMessage();

            StartTaskToShowMessage(delayMillis, message, colorType);
        }

        public static void ResetStripDelayed(int delayMillis)
        {
            ShowMessageDelayed(delayMillis, _defaultStatusMessage, StatusColorType.Default);
        }

        #region Helpers
        private static void StartTaskToShowMessage(int delayMillis, string message, StatusColorType colorType)
        {
            _currentCancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = _currentCancellationTokenSource.Token;
            _currentTask = Task.Factory.StartNew(() =>
            {
                try
                {
                    Task.Delay(delayMillis, cancelToken).Wait(cancelToken);
                    ShowMessage(message, colorType);
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }, cancelToken);
        }

        public static void StopCurrentDelayedMessage()
        {
            //if (_currentTask != null && !_currentTask.IsCompleted)
            //{
            //}
            if (_currentCancellationTokenSource != null)
            {
                _currentCancellationTokenSource.Cancel();
                _currentCancellationTokenSource.Dispose();
                _currentCancellationTokenSource = null;
            }
        }
        #endregion

        #region EnumConverters
        public static Color GetStatusColorFromType(StatusColorType type)
        {
            switch (type)
            {
                case StatusColorType.Default:
                    break;
                case StatusColorType.Warning:
                    return Color.Yellow;
                case StatusColorType.Error:
                    return Color.IndianRed;
                case StatusColorType.Success:
                    return Color.LightGreen;
            }
            return _defaultStatusStripColor;
        }

        public static int GetWaitTimeFromType(DelayTimeType type)
        {
            int delayMillis = 0;
            switch (type)
            {
                case DelayTimeType.None:
                    delayMillis = 0;
                    break;
                case DelayTimeType.Short:
                    delayMillis = 1000;
                    break;
                case DelayTimeType.Medium:
                    delayMillis = 3000;
                    break;
                case DelayTimeType.Long:
                    delayMillis = 5000;
                    break;
            }
            return delayMillis;
        }
        #endregion
    }

    public enum StatusColorType
    {
        Default,
        Warning,
        Error,
        Success,
    }

    public enum DelayTimeType
    {
        None,
        Short,
        Medium,
        Long,
    }
}
