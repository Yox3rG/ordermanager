using FolderManipulator.Analytics;
using FolderManipulator.Data;
using FolderManipulator.Extensions;
using FolderManipulator.FolderRelated;
using FolderManipulator.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FolderManipulator
{
    public partial class form_main : Form
    {
        private Action OnOneSecondTimer;

        private const string _dummyOrderTypeName = "Other";
        private static List<Guid> checkedOrderIds = new List<Guid>();
        private static int activeOrdersScrollbarValue = 0;
        private Timer formOneSecondTimer;

        public form_main()
        {
            InitializeComponent();
            InitializeOneSecondTimer();

            SubscribeToActions();

            UpdateSourcePathLabel();
            FillSourceTreeView();

#if DEBUG
            //ShowMessage();
            StartDebugTimer();
#endif
        }

        #region Form UI
        private void form_main_Load(object sender, EventArgs e)
        {
            LoadAll();
            StatusManager.Initialize(status_strip);

            InitializeContextMenus();

            RefreshOrders();
            RefreshOrderTypes();

            SetTab();
        }

        private void form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine(OrderManager.GetActiveOrders().Orders.Count);
            //SaveAll();
            UnSubscribeFromActions();
        }

        private void form_main_Activated(object sender, EventArgs e)
        {
            //RefreshAll();
        }

        private void form_main_DeActivate(object sender, EventArgs e)
        {
            //SaveAll();
        }
        #endregion

        private void InitializeOneSecondTimer()
        {
            formOneSecondTimer = new Timer();
            formOneSecondTimer.Interval = 1000;
            formOneSecondTimer.Start();
            formOneSecondTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        }

        private void InitializeContextMenus()
        {
            SpecialContextMenuItem[] contextMenuItemsOrderTreeView = new SpecialContextMenuItem[] {
                new SpecialContextMenuItem("Delete", delegate(Control owner)
                    {
                        OrderData order = ((TreeView)owner).GetCurrentSelectedItem<OrderData>();
                        if(order != null && MessageBox.Show($"Do you really want to delete [{order}]?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            OrderManager.RemoveActiveOrder(order); 
                        }
                    }),
                new SpecialContextMenuItem("-", null),
                new SpecialContextMenuItem("Clear all Checked", delegate(Control owner)
                    {
                        ClearCheckedOrders(((TreeView)owner));
                    }),
            };
            SpecialContextMenu<OrderData> contextMenuOrderTreeView = new SpecialContextMenu<OrderData>(tree_view_orders, contextMenuItemsOrderTreeView);
            tree_view_orders.ContextMenu = contextMenuOrderTreeView.Menu;
        }

        private void SubscribeToActions()
        {
            PersistentData.OnSourcePathChanged += UpdateSourcePathLabel;
            PersistentData.OnSourcePathChanged += RefreshSourceTreeView;

            SettingsManager.OnSettingsChanged += FinishChange;
            SettingsManager.OnCanInitiateChange += CanCreateChange;
            OrderManager.OnOrderListChanged += FinishChange;
            OrderManager.OnCanInitiateChange += CanCreateChange;

            OnOneSecondTimer +=
                delegate
                {
                    LoadAllIfDataIsOld();
                };
        }

        private void UnSubscribeFromActions()
        {
            PersistentData.OnSourcePathChanged -= UpdateSourcePathLabel;
            PersistentData.OnSourcePathChanged -= RefreshSourceTreeView;

            SettingsManager.OnSettingsChanged -= FinishChange;
            SettingsManager.OnCanInitiateChange -= CanCreateChange;
            OrderManager.OnOrderListChanged -= FinishChange;
            OrderManager.OnCanInitiateChange -= CanCreateChange;

            SettingsManager.OnSettingsChanged -= RefreshOrderTypes;
        }

        private void FillSourceTreeView()
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

        private void RefreshSourceTreeView()
        {
            FillSourceTreeView();
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
            OrderData[] orderDatas = CreateOrdersFromAddUI(selectedFiles);
            OrderManager.AddNewOrders(orderDatas);
        }

        private OrderData[] CreateOrdersFromAddUI(CheckedListBox.CheckedItemCollection selectedFiles)
        {
            OrderData[] orders = new OrderData[selectedFiles.Count];
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
                Int32.TryParse(count, out int countNumber);
                string description = txt_comment.Text;

                OrderData orderData = new OrderData(mainOrderType, subOrderType, fullPath, countNumber, description);
                orders[i] = orderData;
            }
            return orders;
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
            activeOrdersScrollbarValue = tree_view_orders.GetTreeViewScrollPosVertical();

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

            LoadCheckedOrders(tree_view_orders);
            tree_view_orders.SetTreeViewScrollPosVertical(activeOrdersScrollbarValue);
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
            SettingsManager.Settings.AddNewOrderType(txt_main_ordertype.Text, OrderCategory.Main);
        }

        private void btn_add_sub_ordertype_Click(object sender, EventArgs e)
        {
            SettingsManager.Settings.AddNewOrderType(txt_sub_ordertype.Text, OrderCategory.Sub);
        }

        private void btn_delete_main_ordertype_Click(object sender, EventArgs e)
        {
            SettingsManager.Settings.DeleteOrderType(listbox_main_ordertype.SelectedItem.ToString(), OrderCategory.Main);
        }

        private void btn_delete_sub_ordertype_Click(object sender, EventArgs e)
        {
            SettingsManager.Settings.DeleteOrderType(listbox_sub_ordertype.SelectedItem.ToString(), OrderCategory.Sub);
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

        #region DataManipulation
        private void LoadAllIfDataIsOld()
        {
            DataState dataState = PersistentData.GetDataState(OrderManager.GetActiveOrders(), OrderManager.GetPendingOrders(), OrderManager.GetFinishedOrders(), SettingsManager.Settings);
            if (dataState == DataState.NotLatest)
            {
                LoadAll();
                RefreshAll();
            }
        }

        private bool CanCreateChange()
        {
            if (!IsOnLatestUpdate())
            {
                StatusManager.ShowMessage($"Can't create change, local data is outdated", StatusColorType.Error, DelayTimeType.Medium);
                return false;
            }
            if (!PersistentData.CheckAndCreateLock())
            {
                StatusManager.ShowMessage($"Can't create change, can't create lock on server", StatusColorType.Error, DelayTimeType.Medium);
                return false;
            }
            return true;
        }

        private void FinishChange()
        {
            FinishChange(null);
        }

        private void FinishChange(OrderList list)
        {
            SaveAll();
            RefreshAll();
            PersistentData.ReleaseLock();
        }

        private bool IsOnLatestUpdate()
        {
            DataState dataState = PersistentData.GetDataState(OrderManager.GetActiveOrders(), OrderManager.GetPendingOrders(), OrderManager.GetFinishedOrders(), SettingsManager.Settings);
            if (dataState == DataState.Latest)
            {
                return true;
            }
            return false;
        }

        private void RefreshAll()
        {
            RefreshOrders();
            RefreshOrderTypes();
            RefreshTargetFolderContents();
            RefreshSourceTreeView();
        }

        private void LoadAll()
        {
            SettingsData settings = PersistentData.LoadSettings();
            SettingsManager.InitializeSettings(settings);
            LoadAllOrders();
        }

        private static void LoadAllOrders()
        {
            OrderList activeOrders = PersistentData.LoadOrderList(OrderListType.Active);
            OrderList pendingOrders = PersistentData.LoadOrderList(OrderListType.Pending);
            OrderList finishedOrders = PersistentData.LoadOrderList(OrderListType.Finished);
            OrderManager.InitializeOrders(activeOrders, pendingOrders, finishedOrders);
        }

        private void SaveAll()
        {
            PersistentData.AddOrderListToWaitingForSaveList(OrderManager.GetActiveOrders());
            PersistentData.AddOrderListToWaitingForSaveList(OrderManager.GetPendingOrders());
            PersistentData.AddOrderListToWaitingForSaveList(OrderManager.GetFinishedOrders());
            PersistentData.AddSettingsToWaitingForSaveList(SettingsManager.Settings);
            PersistentData.TrySaveWaitingItems();
        }
        #endregion

        private void SetTab(TabPage newSelected = null)
        {
            if (newSelected != null)
                tab_control.SelectedTab = newSelected;
            //if (tab_control.SelectedTab != tab_page_edit)
            //{
            //    tab_control.SelectedTab = tab_page_edit;
            //}
        }

        private void ColorCheckedNodes(TreeView treeview, Color color)
        {
            List<TreeNode> allNodes = treeview.GetAllNodes();
            foreach (var node in allNodes.Where(x => x.Checked))
            {
                node.BackColor = color;
            }
            foreach (var node in allNodes.Where(x => !x.Checked))
            {
                node.BackColor = Color.Empty;
            }
        }

        private void SaveCheckedOrders(TreeView treeview)
        {
            List<TreeNode> allNodes = treeview.GetAllNodes();
            checkedOrderIds = allNodes.Where(x => x.Checked && x.Tag is OrderData).Select(x => ((OrderData)x.Tag).Id).ToList();
        }

        private void LoadCheckedOrders(TreeView treeview)
        {
            tree_view_orders.AfterCheck -= tree_view_orders_AfterCheck;

            try
            {
                foreach (var node in treeview.GetAllNodes())
                {
                    OrderData data = (OrderData)node.Tag;
                    if (data != null && checkedOrderIds.Contains(data.Id))
                    {
                        node.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                AppConsole.WriteLine(ex.Message);
            }
            finally
            {
                tree_view_orders.AfterCheck += tree_view_orders_AfterCheck;
            }
            ColorCheckedNodes(tree_view_orders, Color.Aqua);
        }

        private void ClearCheckedOrders(TreeView treeview)
        {
            tree_view_orders.AfterCheck -= tree_view_orders_AfterCheck;

            try
            {
                foreach (var node in treeview.GetAllNodes())
                {
                    node.Checked = false;
                }
            }
            catch (Exception ex)
            {
                AppConsole.WriteLine(ex.Message);
            }
            finally
            {
                tree_view_orders.AfterCheck += tree_view_orders_AfterCheck;
            }

            checkedOrderIds.Clear();
            ColorCheckedNodes(tree_view_orders, Color.Aqua);
        }

        #region Testing
#if DEBUG
        private void StartDebugTimer()
        {
            return;
            Timer timer = new Timer();
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = 1000;
            timer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            OnOneSecondTimer?.Invoke();
            //RefreshAll();
            //DebugSelectedNode(sender, e);
        }

        private void DebugSelectedNode()
        {
            DebugSelectedNode(null, null);
        }

        private void DebugSelectedNode(object sender, EventArgs e)
        {
            if (tree_view_orders != null)
            {
                if (tree_view_orders.SelectedNode == null)
                    Console.WriteLine($"[{nameof(DebugSelectedNode)}] Nothing selected");
                else
                    Console.WriteLine($"[{nameof(DebugSelectedNode)}] {tree_view_orders.SelectedNode.Text}");
            }
        }
#endif

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
            PersistentData.StartTestTask();
            //StatusManager.ShowMessage("started delayed message", StatusColorType.Warning);
            //StatusManager.ShowMessageDelayed(1000, "time over", StatusColorType.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersistentData.StopTestTask();
            //StatusManager.StopCurrentDelayedMessage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppConsole.SaveLog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppConsole.SaveLog();
        }

        private void deleteLockToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!PersistentData.ReleaseLock())
            {
                AppConsole.WriteLine($"Lock can't be deleted!");
            }
        }

        #region TreeView UI
        private void tree_view_hierarchy_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //TreeNode selectedNode = (TreeNode)e.Item;
            //System.Collections.Specialized.StringCollection sCollection = new System.Collections.Specialized.StringCollection();
            //sCollection.Add(selectedNode.Text);
            //DataObject data = new DataObject();
            //data.SetFileDropList(sCollection);
            //DragDropEffects dropEffect = tree_view_hierarchy.DoDragDrop(data, DragDropEffects.All | DragDropEffects.Link);
        }

        private void tree_view_orders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tree_view_orders.SelectedNode = e.Node;
        }

        private void tree_view_orders_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool newChecked = e.Node.Checked;
            tree_view_orders.AfterCheck -= tree_view_orders_AfterCheck;

            try
            {
                foreach (var node in e.Node.GetAllNodes())
                {
                    node.Checked = newChecked;
                }
            }
            catch (Exception ex)
            {
                AppConsole.WriteLine(ex.Message);
            }
            finally
            {
                tree_view_orders.AfterCheck += tree_view_orders_AfterCheck;
            }
            SaveCheckedOrders(tree_view_orders);
            ColorCheckedNodes(tree_view_orders, Color.Aqua);
            AppConsole.WriteLine(checkedOrderIds.ToString<Guid>());
        }
        #endregion

        private void forceSaveObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAll();
            StatusManager.ResetStrip();
        }
    }
}
