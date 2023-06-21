using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.UI
{
    public class ColorScheme
    {
        public int id;

        public BackForeColor checkedOrderColor;
        public BackForeColor notifiedOrderColor;
        public BackForeColor pendingOrderColor;

        public BackForeColor selectedTreeViewNodeColor;
        public BackForeColor mainOrderTypeTreeViewNodeColor1;
        public BackForeColor mainOrderTypeTreeViewNodeColor2;
    }

    public struct BackForeColor
    {
        public Color backColor;
        public Color foreColor;

        public BackForeColor(Color backColor, Color foreColor)
        {
            this.backColor = backColor;
            this.foreColor = foreColor;
        }
    }
}
