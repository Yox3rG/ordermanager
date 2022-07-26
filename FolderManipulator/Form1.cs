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

        private PersistentData persistentData;
        private HighlightManager normalHighlightManager;

        private OrderTreeViewHandleGroup treeViewHandleGroup = new OrderTreeViewHandleGroup();
        private const string _dummyOrderTypeName = "Other";
        private static List<Guid> checkedActineOrderIds = new List<Guid>();
        private static List<Guid> checkedPendingOrderIds = new List<Guid>();
        private static List<Guid> checkedFinishedOrderIds = new List<Guid>();
        private static int activeOrdersScrollbarValue = 0;
        private static int pendingOrdersScrollbarValue = 0;
        private static int finishedOrdersScrollbarValue = 0;

        private Dictionary<TreeView, TreeViewEventHandler> treeViewToAfterCheck = new Dictionary<TreeView, TreeViewEventHandler>();

        private Timer formOneSecondTimer;

        private List<TabPage> tabPages;
        private List<TabPage> tabPagesShownWhenNoSource;

        private Color checkedColor = Color.Aqua;

        public form_main()
        {
            InitializeComponent();
            treeViewToAfterCheck[tree_view_active] = tree_view_active_AfterCheck;
            treeViewToAfterCheck[tree_view_pending] = tree_view_pending_AfterCheck;
            treeViewToAfterCheck[tree_view_finished] = tree_view_finished_AfterCheck;
            treeViewHandleGroup.AddHandle(new OrderTreeViewHandle(tree_view_active, tree_view_active_AfterCheck, OrderListType.Active, new List<Guid>()));
            treeViewHandleGroup.AddHandle(new OrderTreeViewHandle(tree_view_pending, tree_view_pending_AfterCheck, OrderListType.Pending, new List<Guid>()));
            treeViewHandleGroup.AddHandle(new OrderTreeViewHandle(tree_view_finished, tree_view_finished_AfterCheck, OrderListType.Finished, new List<Guid>()));

            StatusManager.Initialize(status_strip);
            InitializeTabPages();
            InitializeOneSecondTimer();

            SetupManagers();
            SetupPersistentData();

            SubscribeToActions();
            InitializeContextMenus();

#if DEBUG
            //ShowMessage();
            StartDebugTimer();
#endif
        }

        #region Form UI
        private void form_main_Load(object sender, EventArgs e)
        {
        }

        private void form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Console.WriteLine(OrderManager.GetActiveOrders().Orders.Count);
            UnSubscribeFromActions();
        }

        private void form_main_Activated(object sender, EventArgs e)
        {
        }

        private void form_main_DeActivate(object sender, EventArgs e)
        {
        }
        #endregion

        #region Initialize
        private void SetupPersistentData()
        {
            persistentData = new PersistentData();

            if (!persistentData.LoadSourcePathFromLocal())
            {
                normalHighlightManager.StartHighlightControl(btn_choose_source);
                ShowTabs(sourceReady: false);
                return;
            }
            if (!persistentData.AcceptSourcePath())
            {
                normalHighlightManager.StartHighlightControl(btn_accept_source);
                ShowTabs(sourceReady: false);
                return;
            }

            HandleDataOnAcceptingSource();
            ShowTabs(sourceReady: true);
            //ShowTabs(sourceReady: false);
        }

        private void SetupManagers()
        {
            normalHighlightManager = new HighlightManager(cycleStart: Color.LightGray, cycleEnd: Color.CadetBlue, finish: Color.Transparent, 50, backColor: true);
        }

        private void InitializeTabPages()
        {
            tabPages = new List<TabPage>() {
                tab_page_active,
                tab_page_pending,
                tab_page_finished,
                tab_page_customize };
            tabPagesShownWhenNoSource = new List<TabPage>() {
                tab_page_customize };
        }

        private void InitializeOneSecondTimer()
        {
            formOneSecondTimer = new Timer();
            formOneSecondTimer.Interval = 1000;
            formOneSecondTimer.Start();
            formOneSecondTimer.Tick += new EventHandler(formDispatcherTimer_Tick);
        }

        private void InitializeContextMenus()
        {
            SpecialContextMenuItem[] contextMenuItemsOrderTreeView = new SpecialContextMenuItem[] {
                new SpecialContextMenuItem("Delete", delegate(Control owner)
                    {
                        OrderData order = ((TreeView)owner).GetCurrentSelectedItem<OrderData>();
                        if(order != null && MessageBox.Show($"Do you really want to delete [{order}]?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            OrderListType orderListType = treeViewHandleGroup.GetHandle((TreeView)owner).OrderListType;
                            OrderManager.RemoveOrder(orderListType, order);
                        }
                    }),
                new SpecialContextMenuItem("-", null),
                new SpecialContextMenuItem("Clear all Checked", delegate(Control owner)
                    {
                        ClearCheckedOrders(treeViewHandleGroup.GetHandle((TreeView)owner));
                    }),
            };
            SpecialContextMenu<OrderData> contextMenuActiveOrderTreeView = new SpecialContextMenu<OrderData>(tree_view_active, contextMenuItemsOrderTreeView);
            SpecialContextMenu<OrderData> contextMenuPendingOrderTreeView = new SpecialContextMenu<OrderData>(tree_view_pending, contextMenuItemsOrderTreeView);
            SpecialContextMenu<OrderData> contextMenuFinishedOrderTreeView = new SpecialContextMenu<OrderData>(tree_view_finished, contextMenuItemsOrderTreeView);
            tree_view_active.ContextMenu = contextMenuActiveOrderTreeView.Menu;
            tree_view_pending.ContextMenu = contextMenuPendingOrderTreeView.Menu;
            tree_view_finished.ContextMenu = contextMenuFinishedOrderTreeView.Menu;
        }

        private void SubscribeToActions()
        {
            persistentData.OnSourcePathAccepted += HandleDataOnAcceptingSource;
            persistentData.OnSourcePathChanged += RefreshSourceTreeView;

            SettingsManager.OnSettingsChanged += FinishChange;
            SettingsManager.OnCanInitiateChange += CanCreateChange;
            OrderManager.OnOrderListChanged += FinishChange;
            OrderManager.OnCanInitiateChange += CanCreateChange;

            OnOneSecondTimer += LoadAllIfDataIsOld;
        }

        private void UnSubscribeFromActions()
        {
            persistentData.OnSourcePathAccepted -= HandleDataOnAcceptingSource;
            persistentData.OnSourcePathChanged -= RefreshSourceTreeView;

            SettingsManager.OnSettingsChanged -= FinishChange;
            SettingsManager.OnCanInitiateChange -= CanCreateChange;
            OrderManager.OnOrderListChanged -= FinishChange;
            OrderManager.OnCanInitiateChange -= CanCreateChange;

            OnOneSecondTimer -= LoadAllIfDataIsOld;
        }

        private void formDispatcherTimer_Tick(object sender, EventArgs e)
        {
            OnOneSecondTimer?.Invoke();
        }
        #endregion

        private void FillSourceTreeView()
        {
            FolderStructure fs = new FolderStructure(
                persistentData.SourcePath);
            if (fs.IsValid)
            {
                fs.FillTreeView(tree_view_hierarchy);
            }
            else
            {
                tree_view_hierarchy.Nodes.Clear();
            }
            ShowAvailableDataObjectsInHierarchy();
        }

        private void ShowAvailableDataObjectsInHierarchy()
        {
            TreeNode baseNode = tree_view_hierarchy.Nodes.Add("AvailableData");
            Color existsColor = Color.ForestGreen;
            Color missingColor = Color.IndianRed;

            AddDataObjectLabel("Settings", persistentData.SettingsExist());
            AddDataObjectLabel(nameof(OrderListType.Active), persistentData.OrderListExist(OrderListType.Active));
            AddDataObjectLabel(nameof(OrderListType.Pending), persistentData.OrderListExist(OrderListType.Pending));
            AddDataObjectLabel(nameof(OrderListType.Finished), persistentData.OrderListExist(OrderListType.Finished));

            baseNode.Expand();

            void AddDataObjectLabel(string name, bool exists)
            {
                TreeNode node = baseNode.Nodes.Add(exists ? $"{name} exists" : $"{name} missing");
                node.BackColor = exists ? existsColor : missingColor;
            }
        }

        private void UpdateSourcePathLabel()
        {
            lbl_source.Text = persistentData.SourcePath == null ?
                "NULL" : persistentData.SourcePath;
        }

        private void RefreshSourceTreeView()
        {
            UpdateSourcePathLabel();
            FillSourceTreeView();
        }

        private void Btn_ChooseSourceFolder_Click(object sender, EventArgs e)
        {
            string selectedPath = null;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectedPath = fbd.SelectedPath;
                    normalHighlightManager.StopHighlightControl(btn_choose_source);
                    normalHighlightManager.StartHighlightControl(btn_accept_source);
                }
            }
            persistentData.SetSourcePath(selectedPath);
            ShowTabs(sourceReady: false);
        }

        private void button_accept_source_Click(object sender, EventArgs e)
        {
            if (persistentData.AcceptSourcePath())
            {
                normalHighlightManager.StopHighlightControl(btn_accept_source);
                StatusManager.ShowMessage($"Source accepted, loading data", StatusColorType.Success, DelayTimeType.Medium);
                ShowTabs(sourceReady: true);
            }
            else
            {
                StatusManager.ShowMessage($"Source can't be accepted, choose a valid source", StatusColorType.Error);
            }
        }

        private void HandleDataOnAcceptingSource()
        {
            LoadAll();
            RefreshAll();
            if (ServerHasMissingObjects())
            {
                SaveAll();
            }
            RefreshSourceTreeView();
        }

        #region Tabs
        private void ShowTabs(bool sourceReady)
        {
            tab_control.TabPages.Clear();
            List<TabPage> tabPagesToShow = sourceReady ? tabPages : tabPagesShownWhenNoSource;
            foreach (var tabPage in tabPagesToShow)
            {
                tab_control.TabPages.Add(tabPage);
            }

            if (tab_control.TabCount > 0)
                tab_control.SelectTab(0);
        }
        #endregion

        #region CheckedNodes
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

        private void SaveCheckedOrders(OrderTreeViewHandle treeViewHandle)
        {
            List<TreeNode> allNodes = treeViewHandle.TreeView.GetAllNodes();
            treeViewHandle.UpdateCheckedData(allNodes.Where(x => x.Checked && x.Tag is OrderData).Select(x => ((OrderData)x.Tag).Id).ToList());
        }

        private void LoadCheckedOrders(OrderTreeViewHandle treeViewHandle)
        {
            treeViewHandle.RemoveAfterCheckFunction();

            try
            {
                List<Guid> guids = treeViewHandle.GetCheckedData();
                bool[] unusedGuids = new bool[guids.Count];
                for (int i = 0; i < unusedGuids.Length; i++)
                {
                    unusedGuids[i] = true;
                }
                foreach (var node in treeViewHandle.TreeView.GetAllNodes())
                {
                    OrderData data = (OrderData)node.Tag;
                    if (data != null)
                    {
                        int guidIndex = guids.IndexOf(data.Id);
                        if (guidIndex >= 0)
                        {
                            node.Checked = true;
                            unusedGuids[guidIndex] = false;
                        }
                    }
                }
                for (int i = unusedGuids.Length - 1; i >= 0; i--)
                {
                    if (unusedGuids[i])
                    {
                        guids.RemoveAt(i);
                    }
                }
            }
            catch (Exception ex)
            {
                AppConsole.WriteLine(ex.Message);
            }
            finally
            {
                treeViewHandle.AddAfterCheckFunction();
            }
            ColorCheckedNodes(treeViewHandle.TreeView, checkedColor);
        }

        private void ClearCheckedOrders(OrderTreeViewHandle treeViewHandle)
        {
            treeViewHandle.RemoveAfterCheckFunction();

            try
            {
                foreach (var node in treeViewHandle.TreeView.GetAllNodes())
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
                treeViewHandle.AddAfterCheckFunction();
            }

            treeViewHandle.ClearCheckedData();
            ColorCheckedNodes(treeViewHandle.TreeView, checkedColor);
        }

        private void CheckAllChildren(OrderTreeViewHandle treeViewHandle, TreeViewEventArgs e)
        {
            bool newChecked = e.Node.Checked;
            treeViewHandle.RemoveAfterCheckFunction();

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
                treeViewHandle.AddAfterCheckFunction();
            }
            SaveCheckedOrders(treeViewHandle);
            ColorCheckedNodes(treeViewHandle.TreeView, checkedColor);
            //AppConsole.WriteLine(checkedOrderIds.ToString<Guid>());
        }
        #endregion

        #region ToolStrip
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
            if (!persistentData.ReleaseLock())
            {
                AppConsole.WriteLine($"Lock can't be deleted!");
            }
        }

        private void forceSaveObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAll();
            StatusManager.ResetStrip();
        }

        private void clearStatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatusManager.ResetStrip();
        }
        #endregion

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

        private void tree_view_active_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tree_view_active.SelectedNode = e.Node;
        }

        private void tree_view_pending_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tree_view_pending.SelectedNode = e.Node;
        }

        private void tree_view_finished_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tree_view_finished.SelectedNode = e.Node;
        }

        private void tree_view_active_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckAllChildren(treeViewHandleGroup.GetHandle(tree_view_active), e);
        }

        private void tree_view_pending_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckAllChildren(treeViewHandleGroup.GetHandle(tree_view_pending), e);
        }

        private void tree_view_finished_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckAllChildren(treeViewHandleGroup.GetHandle(tree_view_finished), e);
        }
        #endregion

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

        private void list_checked_files_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            list_checked_files.ItemCheck -= list_checked_files_ItemCheck;

            try
            {
                if (e.Index == 0)
                {
                    CheckState newCheckState = e.NewValue;

                    for (int i = 0; i < list_checked_files.Items.Count; i++)
                    {
                        list_checked_files.SetItemCheckState(i, newCheckState);
                    }
                }
                else
                {
                    int checkedCount = CheckedItemCount();
                    int allCount = list_checked_files.Items.Count - 1;

                    if (e.NewValue == CheckState.Checked)
                        checkedCount++;
                    if (e.NewValue == CheckState.Unchecked)
                        checkedCount--;

                    if (checkedCount == allCount)
                    {
                        SetSelectAllState(CheckState.Checked);
                    }
                    else if (checkedCount == 0)
                    {
                        SetSelectAllState(CheckState.Unchecked);
                    }
                    else
                    {
                        SetSelectAllState(CheckState.Indeterminate);
                    }
                }
            }
            catch (Exception ex)
            {
                AppConsole.WriteLine(ex.Message);
            }
            finally
            {
                list_checked_files.ItemCheck += list_checked_files_ItemCheck;
            }

            int CheckedItemCount()
            {
                int result = 0;
                for (int i = 1; i < list_checked_files.Items.Count; i++)
                {
                    if (list_checked_files.GetItemCheckState(i) == CheckState.Checked)
                    {
                        result++;
                    }
                }
                return result;
            }

            CheckState GetSelectAllState()
            {
                return list_checked_files.GetItemCheckState(0);
            }

            void SetSelectAllState(CheckState state)
            {
                list_checked_files.SetItemCheckState(0, state);
            }
        }

        private void RefreshTargetFolderContents()
        {
            string targetPath = txt_folder_target.Text;
            var checkedItems = list_checked_files.CheckedItems.OfType<string>().ToList();
            if (list_checked_files.GetItemCheckState(0) != CheckState.Unchecked)
                checkedItems.RemoveAt(0);
            list_checked_files.Items.Clear();

            if (System.IO.File.Exists(targetPath))
            {
                string directoryPath = Path.GetDirectoryName(targetPath);
                string fileName = Path.GetFileName(targetPath);

                LoadFilesFromTargetFolder(directoryPath);

                int selectedFileIndex = list_checked_files.Items.IndexOf(fileName);
                list_checked_files.SetItemChecked(selectedFileIndex, true);
            }

            if (System.IO.Directory.Exists(targetPath))
            {
                LoadFilesFromTargetFolder(targetPath);
            }

            list_checked_files.Items.Insert(0, "Select All");

            if (SettingsManager.Settings.KeepCheckedFilesAfterRefresh)
            {
                foreach (var checkedItem in checkedItems)
                {
                    int oldItemIndex = list_checked_files.Items.IndexOf(checkedItem);
                    if (oldItemIndex != -1)
                        list_checked_files.SetItemChecked(oldItemIndex, true);
                }
            }
        }

        private void LoadFilesFromTargetFolder(string targetPath)
        {
            string[] files = System.IO.Directory.GetFiles(targetPath);
            files = files.Select(x => x.Split(Path.DirectorySeparatorChar).Last()).ToArray();
            list_checked_files.Items.AddRange(files);
        }

        List<string> GetCheckedItemStrings()
        {
            List<string> checkedFileNames = new List<string>();
            for (int i = 1; i < list_checked_files.Items.Count; i++)
            {
                if (list_checked_files.GetItemCheckState(i) == CheckState.Checked)
                {
                    checkedFileNames.Add(list_checked_files.Items[i].ToString());
                }
            }
            return checkedFileNames;
        }
        #endregion

        #region Order
        private void btn_add_order_Click(object sender, EventArgs e)
        {
            List<string> checkedFileNames = GetCheckedItemStrings();
            if(checkedFileNames.Count <= 0)
            {
                StatusManager.ShowMessage("No file was selected for Add operation.", StatusColorType.Warning, DelayTimeType.Short);
                return;
            }

            OrderData[] orderDatas = CreateOrdersFromAddUI(checkedFileNames);
            OrderManager.AddNewOrder(orderDatas);
        }

        private OrderData[] CreateOrdersFromAddUI(List<string> selectedFileNames)
        {
            OrderData[] orders = new OrderData[selectedFileNames.Count];
            for (int i = 0; i < selectedFileNames.Count; i++)
            {
                string mainOrderType = "";
                if (drpd_main_ordertype.SelectedItem != null)
                    mainOrderType = drpd_main_ordertype.SelectedItem.ToString();
                string subOrderType = "";
                if (drpd_main_ordertype.SelectedItem != null)
                    subOrderType = drpd_sub_ordertype.SelectedItem.ToString();

                string fullPath = Path.Combine(txt_folder_target.Text, selectedFileNames[i]);
                string count = txt_count.Text;
                Int32.TryParse(count, out int countNumber);
                string description = txt_comment.Text;

                OrderData orderData = new OrderData(mainOrderType, subOrderType, fullPath, countNumber, description);
                orders[i] = orderData;
            }
            return orders;
        }

        #region Move Order Buttons
        private void btn_add_active_pending_Click(object sender, EventArgs e)
        {
            List<OrderData> orders = OrderManager.GetActiveOrders().GetOrders(treeViewHandleGroup.GetHandle(tree_view_active).GetCheckedData());
            OrderManager.MoveOrder(orders, OrderListType.Active, OrderListType.Pending);
        }

        private void btn_add_active_finished_Click(object sender, EventArgs e)
        {
            List<OrderData> orders = OrderManager.GetActiveOrders().GetOrders(treeViewHandleGroup.GetHandle(tree_view_active).GetCheckedData());
            OrderManager.MoveOrder(orders, OrderListType.Active, OrderListType.Finished);
        }

        private void btn_add_pending_active_Click(object sender, EventArgs e)
        {
            List<OrderData> orders = OrderManager.GetPendingOrders().GetOrders(treeViewHandleGroup.GetHandle(tree_view_pending).GetCheckedData());
            OrderManager.MoveOrder(orders, OrderListType.Pending, OrderListType.Active);
        }

        private void btn_add_pending_finished_Click(object sender, EventArgs e)
        {
            List<OrderData> orders = OrderManager.GetPendingOrders().GetOrders(treeViewHandleGroup.GetHandle(tree_view_pending).GetCheckedData());
            OrderManager.MoveOrder(orders, OrderListType.Pending, OrderListType.Finished);
        }

        private void btn_add_finished_active_Click(object sender, EventArgs e)
        {
            List<OrderData> orders = OrderManager.GetFinishedOrders().GetOrders(treeViewHandleGroup.GetHandle(tree_view_finished).GetCheckedData());
            OrderManager.MoveOrder(orders, OrderListType.Finished, OrderListType.Active);
        }

        private void btn_add_finished_pending_Click(object sender, EventArgs e)
        {
            List<OrderData> orders = OrderManager.GetFinishedOrders().GetOrders(treeViewHandleGroup.GetHandle(tree_view_finished).GetCheckedData());
            OrderManager.MoveOrder(orders, OrderListType.Finished, OrderListType.Pending);
        }
        #endregion

        private void RefreshOrders(bool expandAll = true)
        {
            treeViewHandleGroup.SaveCurrentScrollBarPosition();

            FillTreeViewWithOrders(tree_view_active, OrderManager.GetActiveOrders());
            FillTreeViewWithOrders(tree_view_pending, OrderManager.GetPendingOrders());
            FillTreeViewWithOrders(tree_view_finished, OrderManager.GetFinishedOrders());

            if (expandAll)
            {
                treeViewHandleGroup.ExpandAll();
            }

            LoadCheckedOrders(treeViewHandleGroup.GetHandle(tree_view_active));
            LoadCheckedOrders(treeViewHandleGroup.GetHandle(tree_view_pending));
            LoadCheckedOrders(treeViewHandleGroup.GetHandle(tree_view_finished));

            treeViewHandleGroup.ResetToSavedScrollBarPosition();
        }

        private void FillTreeViewWithOrders(TreeView treeView, OrderList orders)
        {
            treeView.Nodes.Clear();
            List<string> mainOrderTypes = SettingsManager.GetOrderTypes(OrderCategory.Main);
            AddStringNodesToNode(mainOrderTypes, treeView.Nodes);
            TreeNode dummy = treeView.Nodes.Add(_dummyOrderTypeName);

            foreach (var order in orders.Orders)
            {
                TreeNode grandParent = FindParent(order.MainOrderType, treeView.Nodes);
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
            if (!persistentData.IsSourceReady)
                return;

            DataState dataState = persistentData.GetDataState(showStatusMessage: true, OrderManager.GetActiveOrders(), OrderManager.GetPendingOrders(), OrderManager.GetFinishedOrders(), SettingsManager.Settings);
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
            if (!persistentData.CheckAndCreateLock())
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

        private void FinishChange(List<OrderList> list)
        {
            SaveAll();
            RefreshAll();
            persistentData.ReleaseLock();
        }

        private bool IsOnLatestUpdate()
        {
            DataState dataState = persistentData.GetDataState(showStatusMessage: true, OrderManager.GetActiveOrders(), OrderManager.GetPendingOrders(), OrderManager.GetFinishedOrders(), SettingsManager.Settings);
            if (dataState == DataState.Latest)
            {
                return true;
            }
            return false;
        }

        private bool ServerHasMissingObjects()
        {
            DataState dataState = persistentData.GetDataState(showStatusMessage: false, OrderManager.GetActiveOrders(), OrderManager.GetPendingOrders(), OrderManager.GetFinishedOrders(), SettingsManager.Settings);
            if (dataState == DataState.MissingFile || dataState == DataState.MissingObject)
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
            SettingsData settings = persistentData.LoadSettings();
            SettingsManager.InitializeSettings(settings);
            LoadAllOrders();
        }

        private void LoadAllOrders()
        {
            OrderList activeOrders = persistentData.LoadOrderList(OrderListType.Active);
            OrderList pendingOrders = persistentData.LoadOrderList(OrderListType.Pending);
            OrderList finishedOrders = persistentData.LoadOrderList(OrderListType.Finished);
            OrderManager.InitializeOrders(activeOrders, pendingOrders, finishedOrders);
        }

        private void SaveAll()
        {
            persistentData.AddOrderListToWaitingForSaveList(OrderManager.GetActiveOrders());
            persistentData.AddOrderListToWaitingForSaveList(OrderManager.GetPendingOrders());
            persistentData.AddOrderListToWaitingForSaveList(OrderManager.GetFinishedOrders());
            persistentData.AddSettingsToWaitingForSaveList(SettingsManager.Settings);
            persistentData.TrySaveWaitingItems();
        }
        #endregion

        #region Testing
#if DEBUG
        private void button1_Click(object sender, EventArgs e)
        {
            ShowTabs(sourceReady: true);
            //persistentData.StartTestTask();
            //StatusManager.ShowMessage("started delayed message", StatusColorType.Warning);
            //StatusManager.ShowMessageDelayed(1000, "time over", StatusColorType.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowTabs(sourceReady: false);
            //persistentData.StopTestTask();
            //StatusManager.StopCurrentDelayedMessage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //AppConsole.SaveLog();
        }

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
        }

        private void DebugSelectedNode()
        {
            DebugSelectedNode(null, null);
        }

        private void DebugSelectedNode(object sender, EventArgs e)
        {
            if (tree_view_active != null)
            {
                if (tree_view_active.SelectedNode == null)
                    Console.WriteLine($"[{nameof(DebugSelectedNode)}] Nothing selected");
                else
                    Console.WriteLine($"[{nameof(DebugSelectedNode)}] {tree_view_active.SelectedNode.Text}");
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
    }
}
