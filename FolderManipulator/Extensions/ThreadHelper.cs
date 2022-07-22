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
        private static Dictionary<string, CancellationTokenSource> _cancellationTokenSources = new Dictionary<string, CancellationTokenSource>();

        public static bool StartCancellableAsync(string name, IThreadAction threadAction)
        {
            if (threadAction == null)
                return false;
            if (_cancellationTokenSources.ContainsKey(name))
            {
                AppConsole.WriteLine("Already running ThreadAction needs to be stopped before starting the same one again.");
                return false;
            }

            _cancellationTokenSources.Add(name, new CancellationTokenSource());
            CancellationToken cancelToken = _cancellationTokenSources[name].Token;

            threadAction.Prepare();
            AsyncStepLoop(name, 1, threadAction, cancelToken);
            return true;
        }

        public static bool StopCancellableAsync(string name)
        {
            if(_cancellationTokenSources.TryGetValue(name, out CancellationTokenSource cancelToken))
            {
                cancelToken.Cancel();
                return true;
            }
            return false;
        }

        private static async void AsyncStepLoop(string name, int delay, IThreadAction action, CancellationToken cancellationToken)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                if(delay > 0)
                    await Task.Delay(delay);

                action.LoopStep();
            }

            action.Finish();
            _cancellationTokenSources[name].Dispose();
            _cancellationTokenSources.Remove(name);
            AppConsole.WriteLine($"Async action with name [{name}] stopped.");
        }
    }
}
