using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.UI
{
    public static class ColorManager
    {
        public static Color checkedOrderColor;
        public static Color notifiedOrderColor;
        public static Color pendingOrderColor;

        public static Color selectedTreeViewNodeColor;
        public static Color mainOrderTypeTreeViewNodeColor1;
        public static Color mainOrderTypeTreeViewNodeColor2;

        static ColorManager()
        {
            checkedOrderColor = Color.Aqua;
            notifiedOrderColor = Color.PeachPuff;
            pendingOrderColor = Color.Empty;
            selectedTreeViewNodeColor = Color.FromArgb(128, Color.MidnightBlue);
            mainOrderTypeTreeViewNodeColor1 = Color.FromArgb(64, Color.MediumSpringGreen);
            mainOrderTypeTreeViewNodeColor2 = Color.FromArgb(64, Color.MediumSeaGreen);
        }
    }
}
