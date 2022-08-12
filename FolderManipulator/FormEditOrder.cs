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
    public partial class form_edit_order : Form
    {
        public Action<Size> OnCloseSendSize;

        private OrderListType orderListType;
        private OrderData targetOrderData;
        private ToolTip toolTip;

        public form_edit_order()
        {
            InitializeComponent();
        }

        public void SetTarget(OrderListType orderListType, OrderData orderData)
        {
            this.orderListType = orderListType;
            this.targetOrderData = orderData;
            FillData(orderListType, orderData);
        }

        public void FillData(OrderListType orderListType, OrderData orderData)
        {
            toolTip = new ToolTip();

            // Editable
            List<string> mainOrderTypes = SettingsManager.Settings.GetMainOrderTypeList();
            FillDropDown(drpd_new_main_ordertype, orderData.MainOrderType, mainOrderTypes);

            List<string> subOrderTypes = SettingsManager.Settings.GetSubOrderTypeList();
            FillDropDown(drpd_new_sub_ordertype, orderData.SubOrderType, subOrderTypes);

            txt_new_count.Text = orderData.Count.ToString();
            txt_new_comment.Text = orderData.Description;

            // Const
            drpd_main_ordertype.Items.Clear();
            drpd_main_ordertype.Items.Add(orderData.MainOrderType);
            drpd_main_ordertype.SelectedIndex = 0;
            drpd_main_ordertype.Enabled = false;

            drpd_sub_ordertype.Items.Clear();
            drpd_sub_ordertype.Items.Add(orderData.SubOrderType);
            drpd_sub_ordertype.SelectedIndex = 0;
            drpd_sub_ordertype.Enabled = false;

            txt_folder.Text = orderData.FullPath;
            txt_folder.Enabled = false;
            toolTip.SetToolTip(lbl_folder, txt_folder.Text);

            txt_count.Text = orderData.Count.ToString();
            txt_count.Enabled = false;

            txt_comment.Text = orderData.Description.ToString();
            txt_comment.Enabled = false;
            toolTip.SetToolTip(lbl_comment, txt_comment.Text);

            txt_birth_date.Text = orderData.BirthDate.ToString();
            txt_birth_date.Enabled = false;

            txt_finished_date.Text = orderData.FinishedDate.ToString();
            txt_finished_date.Enabled = false;

            txt_status.Text = orderData.State.ToString();
            txt_status.Enabled = false;

            txt_id.Text = orderData.Id.ToString();
            txt_id.Enabled = false;
            toolTip.SetToolTip(lbl_id, txt_id.Text);
        }

        private void FillDropDown(ComboBox targetControl, string orderDataType, List<string> orderTypes)
        {
            targetControl.DataSource = null;
            targetControl.DataSource = orderTypes;
            if (orderTypes.Contains(orderDataType))
            {
                targetControl.SelectedItem = orderDataType;
            }
            else
            {
                targetControl.SelectedIndex = 0;
            }
        }

        private bool IsOrderEdited()
        {
            bool isNotEdited = true;
            isNotEdited &= drpd_main_ordertype.SelectedItem.ToString().Equals(drpd_new_main_ordertype.SelectedItem.ToString());
            isNotEdited &= drpd_sub_ordertype.SelectedItem.ToString().Equals(drpd_new_sub_ordertype.SelectedItem.ToString());
            isNotEdited &= txt_count.Text.Equals(txt_new_count.Text);
            isNotEdited &= txt_comment.Text.Equals(txt_new_comment.Text);

            return !isNotEdited;
        }

        private OrderEditData GetOrderEditDataFromFields()
        {
            string mainOrderType = drpd_new_main_ordertype.SelectedItem.ToString();
            string subOrderType = drpd_new_sub_ordertype.SelectedItem.ToString();
            Int32.TryParse(txt_new_count.Text, out int count);
            string description = txt_new_comment.Text;

            OrderEditData orderEditData = new OrderEditData(mainOrderType, subOrderType, count, description);
            return orderEditData;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (IsOrderEdited())
            {
                if (OrderManager.EditOrder(orderListType, targetOrderData, GetOrderEditDataFromFields()))
                {
                    Close();
                }
                else
                {
                    StatusManager.ShowMessage("cantEditOrder", StatusColorType.Error, DelayTimeType.Medium);
                    MessageBox.Show(ErrorManager.GetErrorMessage("cantEditOrder"));
                }
            }
            else
            {
                Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormEditOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnCloseSendSize?.Invoke(Size);
        }
    }
}
