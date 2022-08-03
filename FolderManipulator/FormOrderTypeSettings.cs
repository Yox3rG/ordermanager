using FolderManipulator.Data;
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
    public partial class FormOrderTypeSettings : Form
    {
        public FormOrderTypeSettings()
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
            SettingsManager.Settings.DeleteOrderType(listbox_main_ordertype.SelectedItem.ToString(), OrderCategory.Main);
        }

        private void btn_delete_sub_ordertype_Click(object sender, EventArgs e)
        {
            SettingsManager.Settings.DeleteOrderType(listbox_sub_ordertype.SelectedItem.ToString(), OrderCategory.Sub);
        }

        private void btn_add_main_ordertype_Click(object sender, EventArgs e)
        {
            SettingsManager.Settings.AddNewOrderType(txt_main_ordertype.Text, OrderCategory.Main);
        }

        private void btn_add_sub_ordertype_Click(object sender, EventArgs e)
        {
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
