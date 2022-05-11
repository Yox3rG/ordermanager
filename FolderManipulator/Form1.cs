using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderManipulator.Data;
using FolderManipulator.FolderRelated;
using FolderManipulator.UI;

namespace FolderManipulator
{
    public partial class form_main : Form
    {
        private const string _dummyOrderTypeName = "Other";

        public form_main()
        {
            InitializeComponent();

            SubscribeToActions();

            UpdateSourcePathLabel();
            FillTreeView();
            //ShowMessage();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void form_main_Load(object sender, EventArgs e)
        {
            SettingsData settings = PersistentData.LoadSettings();
            SettingsManager.InitializeSettings(settings);
            OrderList activeOrders = PersistentData.LoadOrders(OrderListType.Active);
            OrderManager.InitializeOrders(activeOrders, null);
            StatusManager.Initialize(status_strip);

            RefreshOrders();
            RefreshOrderTypes();

            SetTab();
        }

        private void form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine(OrderManager.GetActiveOrders().Orders.Count);
            SaveAll();
            UnSubscribeFromActions();
        }

        private void form_main_Activated(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void form_main_DeActivate(object sender, EventArgs e)
        {
            //SaveAll();
        }

        private void SubscribeToActions()
        {
            PersistentData.OnSourcePathChanged += UpdateSourcePathLabel;
            PersistentData.OnSourcePathChanged += RefreshTreeView;

            SettingsManager.OnSettingsChanged += RefreshOrderTypes;
        }

        private void UnSubscribeFromActions()
        {
            PersistentData.OnSourcePathChanged -= UpdateSourcePathLabel;
            PersistentData.OnSourcePathChanged -= RefreshTreeView;

            SettingsManager.OnSettingsChanged -= RefreshOrderTypes;
        }

        private void FillTreeView()
        {
            if (PersistentData.IsSourceReady)
            {
                FolderStructure fs = new FolderStructure(
                    PersistentData.SourcePath);

                fs.FillTreeView(tree_view_hierarchy);
            }
            else
            {
                MessageBox.Show("source is not ready");
            }
        }

        private void UpdateSourcePathLabel()
        {
            lbl_source.Text = PersistentData.SourcePath == null ?
                "NULL" : PersistentData.SourcePath;
        }

        private void RefreshTreeView()
        {
            FillTreeView();
        }

        private void Btn_ChooseSourceFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    PersistentData.SetSourcePath(fbd.SelectedPath);
                }
            }
        }

        #region TargetFolder
        private void btn_choose_folder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txt_folder_target.Text = fbd.SelectedPath;
                }
            }
        }

        private void txt_folder_target_TextChanged(object sender, EventArgs e)
        {
            RefreshTargetFolderContents();
        }

        private void RefreshTargetFolderContents()
        {
            string targetPath = txt_folder_target.Text;
            var checkedItems = checked_list_files.CheckedItems.OfType<string>().ToList();
            checked_list_files.Items.Clear();

            if (System.IO.File.Exists(targetPath))
            {
                string directoryPath = Path.GetDirectoryName(targetPath);
                string fileName = Path.GetFileName(targetPath);

                LoadFilesFromTargetFolder(directoryPath);

                int selectedFileIndex = checked_list_files.Items.IndexOf(fileName);
                checked_list_files.SetItemChecked(selectedFileIndex, true);
            }

            if (System.IO.Directory.Exists(targetPath))
            {
                LoadFilesFromTargetFolder(targetPath);
            }

            if (SettingsManager.Settings.KeepCheckedFilesAfterRefresh)
            {
                foreach (var checkedItem in checkedItems)
                {
                    int oldItemIndex = checked_list_files.Items.IndexOf(checkedItem);
                    if (oldItemIndex != -1)
                        checked_list_files.SetItemChecked(oldItemIndex, true);
                }
            }
        }

        private void LoadFilesFromTargetFolder(string targetPath)
        {
            string[] files = System.IO.Directory.GetFiles(targetPath);
            files = files.Select(x => x.Split(Path.DirectorySeparatorChar).Last()).ToArray();
            checked_list_files.Items.AddRange(files);
        }
        #endregion

        #region Order
        private void btn_add_order_Click(object sender, EventArgs e)
        {
            var selectedFiles = checked_list_files.CheckedItems;
            for (int i = 0; i < selectedFiles.Count; i++)
            {
                string mainOrderType = "";
                if (drpd_main_ordertype.SelectedItem != null)
                    mainOrderType = drpd_main_ordertype.SelectedItem.ToString();
                string subOrderType = "";
                if (drpd_main_ordertype.SelectedItem != null)
                    subOrderType = drpd_sub_ordertype.SelectedItem.ToString();

                string fullPath = Path.Combine(txt_folder_target.Text, selectedFiles[i].ToString());
                string count = txt_count.Text;
                string description = txt_comment.Text;
                OrderData orderData = new OrderData(mainOrderType, subOrderType, fullPath, count, description);
                OrderManager.AddNewOrder(orderData);

            }
            RefreshOrders();
            SaveAll();
        }

        private void btn_refresh_orders_Click(object sender, EventArgs e)
        {
            RefreshOrders();
            StatusManager.ShowMessage("Refereshed orders!", StatusColorType.Warning, resetAfter: DelayTimeType.Short);
        }

        private void btn_refresh_overview_Click(object sender, EventArgs e)
        {
            RefreshOrders();
        }

        private void RefreshOrders(bool expandAll = true)
        {
            tree_view_orders.Nodes.Clear();
            tree_view_overview.Nodes.Clear();
            List<string> mainOrderTypes = SettingsManager.GetOrderTypes(OrderCategory.Main);
            AddStringNodesToNode(mainOrderTypes, tree_view_orders.Nodes);
            TreeNode dummy = tree_view_orders.Nodes.Add(_dummyOrderTypeName);

            OrderList orders = OrderManager.GetActiveOrders();
            foreach (var order in orders.Orders)
            {
                TreeNode grandParent = FindParent(order.MainOrderType, tree_view_orders.Nodes);
                if (grandParent == null)
                    grandParent = dummy;

                if (order.SubOrderType == null)
                    order.SubOrderType = _dummyOrderTypeName;
                TreeNode parent = FindParent(order.SubOrderType, grandParent.Nodes);
                if (parent == null)
                {
                    parent = CreateTreeNode(order.SubOrderType);
                    grandParent.Nodes.Add(parent);
                }

                TreeNode node = CreateTreeNode(order.ToString());
                node.Tag = order;

                parent.Nodes.Add(node);
            }

            CopyTreeNodes(tree_view_orders, tree_view_overview);

            if (expandAll)
            {
                tree_view_orders.ExpandAll();
                tree_view_overview.ExpandAll();
            }
        }

        public void CopyTreeNodes(TreeView from, TreeView to)
        {
            TreeNode newTn;
            foreach (TreeNode tn in from.Nodes)
            {
                newTn = CreateTreeNode(tn.Text);
                CopyChildren(newTn, tn);
                to.Nodes.Add(newTn);
            }
        }

        public void CopyChildren(TreeNode parent, TreeNode original)
        {
            TreeNode newTn;
            foreach (TreeNode tn in original.Nodes)
            {
                newTn = CreateTreeNode(tn.Name);
                parent.Nodes.Add(newTn);
                CopyChildren(newTn, tn);
            }
        }

        private TreeNode FindParent(string name, TreeNodeCollection nodes)
        {
            int mainOrderIndex = nodes.IndexOfKey(name); //.Find(order.MainOrderType, searchAllChildren: false);

            if (mainOrderIndex == -1)
                return null;

            return nodes[mainOrderIndex];
        }

        private void AddStringNodesToNode(List<string> strings, TreeNodeCollection parent)
        {
            foreach (string orderType in strings)
            {
                TreeNode node = CreateTreeNode(orderType);

                parent.Add(node);
            }
        }

        private static TreeNode CreateTreeNode(string name)
        {
            TreeNode node = new TreeNode(name);
            node.Name = name;
            return node;
        }
        #endregion

        #region OrderType
        private void btn_add_main_ordertype_Click(object sender, EventArgs e)
        {
            SettingsManager.AddNewOrderType(txt_main_ordertype.Text, OrderCategory.Main);
        }

        private void btn_add_sub_ordertype_Click(object sender, EventArgs e)
        {
            SettingsManager.AddNewOrderType(txt_sub_ordertype.Text, OrderCategory.Sub);
        }

        private void btn_delete_main_ordertype_Click(object sender, EventArgs e)
        {
            SettingsManager.DeleteOrderType(listbox_main_ordertype.SelectedItem.ToString(), OrderCategory.Main);
        }

        private void btn_delete_sub_ordertype_Click(object sender, EventArgs e)
        {
            SettingsManager.DeleteOrderType(listbox_sub_ordertype.SelectedItem.ToString(), OrderCategory.Sub);
        }

        private void RefreshOrderTypes()
        {
            listbox_main_ordertype.DataSource = null;
            listbox_main_ordertype.DataSource = SettingsManager.Settings.mainOrderTypes.list;
            drpd_main_ordertype.DataSource = null;
            drpd_main_ordertype.DataSource = SettingsManager.Settings.mainOrderTypes.list;
            listbox_sub_ordertype.DataSource = null;
            listbox_sub_ordertype.DataSource = SettingsManager.Settings.subOrderTypes.list;
            drpd_sub_ordertype.DataSource = null;
            drpd_sub_ordertype.DataSource = SettingsManager.Settings.subOrderTypes.list;
        }
        #endregion

        #region DragAndDrop
        private void tree_view_orders_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode selectedNode = (TreeNode)e.Item;
            System.Collections.Specialized.StringCollection sCollection = new System.Collections.Specialized.StringCollection();
            sCollection.Add(((OrderData)selectedNode.Tag).FullPath);
            DataObject data = new DataObject();
            data.SetFileDropList(sCollection);
            DragDropEffects dropEffect = tree_view_hierarchy.DoDragDrop(data, DragDropEffects.All | DragDropEffects.Link);
        }

        private void txt_folder_target_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("DragEnter");
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                Console.WriteLine("None :(");
                e.Effect = DragDropEffects.None;
            }
        }

        private void txt_folder_target_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null)
            {
                txt_folder_target.Text = string.Join(";", files);
                return;
            }

            string s = e.Data.GetData(DataFormats.Text).ToString();
            txt_folder_target.Text = s;
        }
        #endregion

        private void RefreshAll()
        {
            RefreshOrders();
            RefreshOrderTypes();
            RefreshTargetFolderContents();
            RefreshTreeView();
        }

        private void SaveAll()
        {
            PersistentData.TrySaveOrders(OrderManager.GetActiveOrders());
            PersistentData.SaveSettings(SettingsManager.Settings);
        }

        private void SetTab(TabPage newSelected = null)
        {
            if (newSelected != null)
                tab_control.SelectedTab = newSelected;
            //if (tab_control.SelectedTab != tab_page_edit)
            //{
            //    tab_control.SelectedTab = tab_page_edit;
            //}
        }



        #region Testing
        private void tree_view_hierarchy_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //TreeNode selectedNode = (TreeNode)e.Item;
            //System.Collections.Specialized.StringCollection sCollection = new System.Collections.Specialized.StringCollection();
            //sCollection.Add(selectedNode.Text);
            //DataObject data = new DataObject();
            //data.SetFileDropList(sCollection);
            //DragDropEffects dropEffect = tree_view_hierarchy.DoDragDrop(data, DragDropEffects.All | DragDropEffects.Link);
        }

        private void txt_drag_drop_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("DragEnter");
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                Console.WriteLine("None :(");
                e.Effect = DragDropEffects.None;
            }
        }

        private void txt_drag_drop_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null)
            {
                txt_drag_drop.Text = string.Join(";", files);
                return;
            }

            string s = e.Data.GetData(DataFormats.Text).ToString();
            txt_drag_drop.Text = s;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            StatusManager.ShowMessage("started delayed message", StatusColorType.Warning);
            StatusManager.ShowMessageDelayed(1000, "time over", StatusColorType.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StatusManager.StopCurrentDelayedMessage();
        }
    }
}
