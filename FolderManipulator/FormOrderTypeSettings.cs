using FolderManipulator.Analytics;
using FolderManipulator.Data;
using FolderManipulator.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator
{
    public partial class form_ordertype_settings : Form
    {
        public form_ordertype_settings()
        {
            InitializeComponent();
        }

        public ListControl GetMainOrderTypeListControl()
        {
            return listbox_main_ordertype;
        }

        public ListControl GetSubOrderTypeListControl()
        {
            return listbox_sub_ordertype;
        }

        private void btn_delete_main_ordertype_Click(object sender, EventArgs e)
        {
            if (listbox_main_ordertype.SelectedItem == null)
            {
                StatusManager.ShowMessage("noOrderTypeSelected", StatusColorType.Warning, DelayTimeType.Short, "main", "delete");
                return;
            }

            string orderType = listbox_main_ordertype.SelectedItem.ToString();

            if (orderType == OrderTypes.noTypeName)
            {
                StatusManager.ShowMessage("cantManipulateType", StatusColorType.Warning, DelayTimeType.Short);
                return;
            }

            if (MessageBox.Show(ErrorManager.GetErrorMessage("doYouReallyDeleteType", "main", orderType), "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SettingsManager.Settings.DeleteOrderType(orderType, OrderCategory.Main);
            }
        }

        private void btn_delete_sub_ordertype_Click(object sender, EventArgs e)
        {
            if (listbox_sub_ordertype.SelectedItem == null)
            {
                StatusManager.ShowMessage("noOrderTypeSelected", StatusColorType.Warning, DelayTimeType.Short, "sub", "delete");
                return;
            }

            string orderType = listbox_sub_ordertype.SelectedItem.ToString();

            if (orderType == OrderTypes.noTypeName)
            {
                StatusManager.ShowMessage("cantManipulateType", StatusColorType.Warning, DelayTimeType.Short);
                return;
            }

            if (MessageBox.Show(ErrorManager.GetErrorMessage("doYouReallyDeleteType", "sub", orderType), "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SettingsManager.Settings.DeleteOrderType(orderType, OrderCategory.Sub);
            }
        }

        private void btn_add_main_ordertype_Click(object sender, EventArgs e)
        {
            if (txt_main_ordertype.Text == OrderTypes.noTypeName)
            {
                StatusManager.ShowMessage("cantManipulateType", StatusColorType.Warning, DelayTimeType.Short);
                return;
            }
            SettingsManager.Settings.AddNewOrderType(txt_main_ordertype.Text, OrderCategory.Main);
        }

        private void btn_add_sub_ordertype_Click(object sender, EventArgs e)
        {
            if (txt_sub_ordertype.Text == OrderTypes.noTypeName)
            {
                StatusManager.ShowMessage("cantManipulateType", StatusColorType.Warning, DelayTimeType.Short);
                return;
            }
            SettingsManager.Settings.AddNewOrderType(txt_sub_ordertype.Text, OrderCategory.Sub);
        }

        private void txt_main_ordertype_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_add_main_ordertype_Click(this, e);
            }
        }

        private void txt_sub_ordertype_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_add_sub_ordertype_Click(this, e);
            }
        }

        private void btn_finish_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
