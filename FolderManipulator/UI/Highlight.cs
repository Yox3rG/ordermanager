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
    public class Highlight : IThreadAction
    {
        private Control control;
        private Color start;
        private Color end;
        private Color finish;
        private short cycleTime;
        private bool backColor;

        private short cycleTimeCounter = 0;
        private short cycleDirection = 1;

        public Highlight(Control control, Color start, Color end, Color finish, short cycleTime, bool backColor)
        {
            this.control = control;
            this.start = start;
            this.end = end;
            this.finish = finish;
            this.cycleTime = cycleTime;
            this.backColor = backColor;
        }

        public void Prepare()
        {
        }

        public void LoopStep()
        {
            if (cycleTimeCounter <= 0)
                cycleDirection = 1;
            if (cycleTimeCounter >= cycleTime)
                cycleDirection = -1;

            cycleTimeCounter += cycleDirection;
            float t = (float)cycleTimeCounter / cycleTime;

            var color = MathExtension.Lerp(start, end, t);
            if (backColor)
                control.BackColor = color;
            else
                control.ForeColor = color;
        }

        public void Finish()
        {
            if (backColor)
                control.BackColor = finish;
            else
                control.ForeColor = finish;
        }
    }
}
