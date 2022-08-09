using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.Extensions
{
    public static class FormExtension
    {
        public static List<Control> GetControls(this Control form)
        {
            List<Control> controlList = new List<Control>();

            foreach (Control childControl in form.Controls)
            {
                controlList.AddRange(GetControls(childControl));
                controlList.Add(childControl);
            }
            return controlList;
        }

        public static List<Control> GetControls(this Form form)
        {
            List<Control> controlList = new List<Control>();

            foreach (Control childControl in form.Controls)
            {
                controlList.AddRange(GetControls(childControl));
                controlList.Add(childControl);
            }
            return controlList;
        }

        public static List<ToolStripItem> GetToolStripItems(this MenuStrip toolstrip)
        {
            List<ToolStripItem> controlList = new List<ToolStripItem>();


            foreach (ToolStripItem childToolStrip in toolstrip.Items)
            {
                controlList.AddRange(GetToolStripItems(childToolStrip));
                controlList.Add(childToolStrip);
            }
            return controlList;
        }

        public static List<ToolStripItem> GetToolStripItems(this ToolStripItem toolstrip)
        {
            List<ToolStripItem> controlList = new List<ToolStripItem>();

            if (toolstrip is ToolStripDropDownItem)
            {
                foreach (ToolStripItem childToolStrip in (toolstrip as ToolStripDropDownItem).DropDownItems)
                {
                    controlList.AddRange(GetToolStripItems(childToolStrip));
                    controlList.Add(childToolStrip);
                }
            }
            return controlList;
        }
    }
}
