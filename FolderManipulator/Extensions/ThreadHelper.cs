using FolderManipulator.Analytics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.Extensions
{
    public static class ThreadHelper
    {
        private static Dictionary<Control, CancellationTokenSource> _highlightCancellationTokenSources = new Dictionary<Control, CancellationTokenSource>();

        public static void BlinkHighlightControl(Control control, bool backColor)
        {
            _highlightCancellationTokenSources.Add(control, new CancellationTokenSource());
            CancellationToken cancelToken = _highlightCancellationTokenSources[control].Token;

            SoftBlinkStep(control, Color.CadetBlue, Color.LightGray, 50, backColor, cancelToken);
            
            //_highlightTask = Task.Factory.StartNew(() =>
            //{
            //    try
            //    {
            //        Task.Delay(1, cancelToken).Wait(cancelToken);
            //        ShowMessage(message, colorType);
            //    }
            //    catch (OperationCanceledException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}, cancelToken);
        }

        public static void StopBlinkHighlightControl(Control control)
        {
            if(_highlightCancellationTokenSources.TryGetValue(control, out CancellationTokenSource cancelToken))
                cancelToken.Cancel();
        }

        public static async void SoftBlinkStep(Control control, Color aColor, Color bColor, short cycleTimeMs, bool backColor, CancellationToken cancellationToken)
        {
            short cycleTimeCounter = 0;
            short cycleDirection = 1;
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                await Task.Delay(1);
                if (cycleTimeCounter <= 0)
                    cycleDirection = 1;
                if (cycleTimeCounter >= cycleTimeMs)
                    cycleDirection = -1;

                cycleTimeCounter += cycleDirection;
                float t = (float)cycleTimeCounter / cycleTimeMs;

                var color = MathExtension.Lerp(aColor, bColor, t);
                if (backColor) 
                    control.BackColor = color;
                else 
                    control.ForeColor = color;
            }

            if (backColor)
                control.BackColor = bColor;
            else
                control.ForeColor = bColor;

            _highlightCancellationTokenSources[control].Dispose();
            _highlightCancellationTokenSources.Remove(control);
            AppConsole.WriteLine("Blink stopped.");
        }

        public static async void SoftBlinkForever(Control control, Color aColor, Color bColor, short cycleTimeMs, bool backColor)
        {
            short cycleTimeCounter = 0;
            short cycleDirection = 1;
            while (true)
            {
                await Task.Delay(1);
                if (cycleTimeCounter <= 0)
                    cycleDirection = 1;
                if (cycleTimeCounter >= cycleTimeMs)
                    cycleDirection = -1;

                cycleTimeCounter += cycleDirection;
                float t = (float)cycleTimeCounter / cycleTimeMs;

                var color = MathExtension.Lerp(aColor, bColor, t);
                if (backColor) control.BackColor = color; else control.ForeColor = color;
            }
        }
    }
}
