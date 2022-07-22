using FolderManipulator.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.UI
{
    public class HighlightManager
    {
        private Color cycleStart;
        private Color cycleEnd;
        private Color finish;
        private short cycleTime;
        private bool backColor;

        public HighlightManager(Color cycleStart, Color cycleEnd, Color finish, short cycleTime, bool backColor)
        {
            this.cycleStart = cycleStart;
            this.cycleEnd = cycleEnd;
            this.finish = finish;
            this.cycleTime = cycleTime;
            this.backColor = backColor;
        }

        public void StartHighlightControl(Control control)
        {
            Highlight highlight = new Highlight(control, cycleStart, cycleEnd, finish, cycleTime, backColor);
            ThreadHelper.StartCancellableAsync(control.Name, highlight);
        }

        public void StopHighlightControl(Control control)
        {
            ThreadHelper.StopCancellableAsync(control.Name);
        }
    }
}
