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
        public static BackForeColor checkedOrderColor { get { return currentScheme.checkedOrderColor; } }
        public static BackForeColor notifiedOrderColor { get { return currentScheme.notifiedOrderColor; } }
        public static BackForeColor pendingOrderColor { get { return currentScheme.pendingOrderColor; } }

        public static BackForeColor selectedTreeViewNodeColor { get { return currentScheme.selectedTreeViewNodeColor; } }
        public static BackForeColor mainOrderTypeTreeViewNodeColor1 { get { return currentScheme.mainOrderTypeTreeViewNodeColor1; } }
        public static BackForeColor mainOrderTypeTreeViewNodeColor2 { get { return currentScheme.mainOrderTypeTreeViewNodeColor2; } }

        private static ColorScheme currentScheme;
        private static ColorScheme defaultScheme;
        private static ColorScheme pontjoScheme;


        static ColorManager()
        {
            //checkedOrderColor = Color.Aqua;
            //notifiedOrderColor = Color.PeachPuff;
            //pendingOrderColor = Color.Empty;
            //selectedTreeViewNodeColor = Color.FromArgb(128, Color.MidnightBlue);
            //mainOrderTypeTreeViewNodeColor1 = Color.FromArgb(64, Color.MediumSpringGreen);
            //mainOrderTypeTreeViewNodeColor2 = Color.FromArgb(64, Color.MediumSeaGreen);

            defaultScheme = new ColorScheme()
            {
                id = 0,
                checkedOrderColor               = new BackForeColor(Color.FromArgb(214, 214, 214),      Color.Black),
                notifiedOrderColor              = new BackForeColor(Color.PeachPuff,                    Color.White),
                pendingOrderColor               = new BackForeColor(Color.Empty,                        Color.White),
                selectedTreeViewNodeColor       = new BackForeColor(Color.FromArgb(200, 107, 107, 107), Color.White),
                mainOrderTypeTreeViewNodeColor1 = new BackForeColor(Color.FromArgb(200, 41, 173, 255),  Color.Black),
                mainOrderTypeTreeViewNodeColor2 = new BackForeColor(Color.FromArgb(200, 157, 216, 252), Color.Black),
            };

            pontjoScheme = new ColorScheme()
            {
                id = 1,
                checkedOrderColor               = new BackForeColor(Color.GreenYellow,                  Color.Black),
                notifiedOrderColor              = new BackForeColor(Color.PeachPuff,                    Color.White),
                pendingOrderColor               = new BackForeColor(Color.Empty,                        Color.White),
                selectedTreeViewNodeColor       = new BackForeColor(Color.FromArgb(200, 214, 255, 153), Color.Black),
                mainOrderTypeTreeViewNodeColor1 = new BackForeColor(Color.FromArgb(200, 255, 20, 147),  Color.White),
                mainOrderTypeTreeViewNodeColor2 = new BackForeColor(Color.FromArgb(200, 189, 0, 101),   Color.White),
            };

            SetColorScheme(0);
        }

        public static void SetColorScheme(int id)
        {
            switch (id)
            {
                case 0:
                    currentScheme = defaultScheme;
                    break;
                case 1:
                    currentScheme = pontjoScheme;
                    break;
                default:
                    currentScheme = defaultScheme;
                    break;
            }
        }

        public static int GetColorScheme()
        {
            return currentScheme.id;
        }
    }
}
