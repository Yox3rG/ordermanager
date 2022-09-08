namespace FolderManipulator
{
    partial class form_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_main));
            this.btn_add = new System.Windows.Forms.Button();
            this.table_layout_active_orders = new System.Windows.Forms.TableLayoutPanel();
            this.tree_view_active = new System.Windows.Forms.TreeView();
            this.table_layout_active_order_buttons = new System.Windows.Forms.TableLayoutPanel();
            this.btn_add_active_pending = new System.Windows.Forms.Button();
            this.btn_add_active_finished = new System.Windows.Forms.Button();
            this.panel_add_order = new System.Windows.Forms.Panel();
            this.table_layout_add_order = new System.Windows.Forms.TableLayoutPanel();
            this.panel_add_order_top = new System.Windows.Forms.Panel();
            this.lbl_add_order_title = new System.Windows.Forms.Label();
            this.lbl_main_ordertype = new System.Windows.Forms.Label();
            this.drpd_main_ordertype = new System.Windows.Forms.ComboBox();
            this.lbl_sub_ordertype = new System.Windows.Forms.Label();
            this.drpd_sub_ordertype = new System.Windows.Forms.ComboBox();
            this.btn_choose_folder = new System.Windows.Forms.Button();
            this.lbl_folder = new System.Windows.Forms.Label();
            this.txt_folder_target = new System.Windows.Forms.TextBox();
            this.list_checked_files = new System.Windows.Forms.CheckedListBox();
            this.panel_add_order_bottom = new System.Windows.Forms.Panel();
            this.lbl_count = new System.Windows.Forms.Label();
            this.txt_count = new System.Windows.Forms.TextBox();
            this.lbl_comment = new System.Windows.Forms.Label();
            this.txt_comment = new System.Windows.Forms.TextBox();
            this.tab_control = new System.Windows.Forms.TabControl();
            this.tab_page_active = new System.Windows.Forms.TabPage();
            this.table_layout_active_orders_page = new System.Windows.Forms.TableLayoutPanel();
            this.tab_page_pending = new System.Windows.Forms.TabPage();
            this.table_layout_pending_orders = new System.Windows.Forms.TableLayoutPanel();
            this.tree_view_pending = new System.Windows.Forms.TreeView();
            this.table_layout_pending_order_buttons = new System.Windows.Forms.TableLayoutPanel();
            this.btn_add_pending_active = new System.Windows.Forms.Button();
            this.btn_add_pending_finished = new System.Windows.Forms.Button();
            this.btn_set_notified = new System.Windows.Forms.Button();
            this.btn_reset_notified = new System.Windows.Forms.Button();
            this.tab_page_finished = new System.Windows.Forms.TabPage();
            this.table_layout_finished_orders = new System.Windows.Forms.TableLayoutPanel();
            this.tree_view_finished = new System.Windows.Forms.TreeView();
            this.table_layout_finished_order_buttons = new System.Windows.Forms.TableLayoutPanel();
            this.btn_add_finished_pending = new System.Windows.Forms.Button();
            this.btn_add_finished_active = new System.Windows.Forms.Button();
            this.tab_page_archive = new System.Windows.Forms.TabPage();
            this.table_layout_archive = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_archive_name = new System.Windows.Forms.Label();
            this.tree_view_archive = new System.Windows.Forms.TreeView();
            this.tab_page_customize = new System.Windows.Forms.TabPage();
            this.panel_choose_source = new System.Windows.Forms.Panel();
            this.btn_choose_source = new System.Windows.Forms.Button();
            this.lbl_const_current = new System.Windows.Forms.Label();
            this.lbl_source = new System.Windows.Forms.Label();
            this.tree_view_hierarchy = new System.Windows.Forms.TreeView();
            this.btn_accept_source = new System.Windows.Forms.Button();
            this.panel_main_ordertype = new System.Windows.Forms.Panel();
            this.txt_main_ordertype = new System.Windows.Forms.TextBox();
            this.btn_add_main_ordertype = new System.Windows.Forms.Button();
            this.listbox_main_ordertype = new System.Windows.Forms.ListBox();
            this.btn_delete_main_ordertype = new System.Windows.Forms.Button();
            this.panel_sub_ordertype = new System.Windows.Forms.Panel();
            this.txt_sub_ordertype = new System.Windows.Forms.TextBox();
            this.btn_add_sub_ordertype = new System.Windows.Forms.Button();
            this.btn_delete_sub_ordertype = new System.Windows.Forms.Button();
            this.listbox_sub_ordertype = new System.Windows.Forms.ListBox();
            this.image_list_tabs = new System.Windows.Forms.ImageList(this.components);
            this.toolstrip_menu = new System.Windows.Forms.MenuStrip();
            this.toolstrip_item_file = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_force_save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstrip_item_edit_ordertype = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_edit_source_path = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_edit_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_view = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_language = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_language_english = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_language_hungarian = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_add_panel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_save_logs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_delete_lock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip_item_clear_status = new System.Windows.Forms.ToolStripMenuItem();
            this.status_strip = new System.Windows.Forms.StatusStrip();
            this.label_status_strip_main = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_customer_name = new System.Windows.Forms.Label();
            this.txt_customer_name = new System.Windows.Forms.TextBox();
            this.table_layout_active_orders.SuspendLayout();
            this.table_layout_active_order_buttons.SuspendLayout();
            this.panel_add_order.SuspendLayout();
            this.table_layout_add_order.SuspendLayout();
            this.panel_add_order_top.SuspendLayout();
            this.panel_add_order_bottom.SuspendLayout();
            this.tab_control.SuspendLayout();
            this.tab_page_active.SuspendLayout();
            this.table_layout_active_orders_page.SuspendLayout();
            this.tab_page_pending.SuspendLayout();
            this.table_layout_pending_orders.SuspendLayout();
            this.table_layout_pending_order_buttons.SuspendLayout();
            this.tab_page_finished.SuspendLayout();
            this.table_layout_finished_orders.SuspendLayout();
            this.table_layout_finished_order_buttons.SuspendLayout();
            this.tab_page_archive.SuspendLayout();
            this.table_layout_archive.SuspendLayout();
            this.tab_page_customize.SuspendLayout();
            this.panel_choose_source.SuspendLayout();
            this.panel_main_ordertype.SuspendLayout();
            this.panel_sub_ordertype.SuspendLayout();
            this.toolstrip_menu.SuspendLayout();
            this.status_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(6, 91);
            this.btn_add.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(92, 37);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "Hozzáadás";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_order_Click);
            // 
            // table_layout_active_orders
            // 
            this.table_layout_active_orders.ColumnCount = 2;
            this.table_layout_active_orders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.table_layout_active_orders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_active_orders.Controls.Add(this.tree_view_active, 1, 0);
            this.table_layout_active_orders.Controls.Add(this.table_layout_active_order_buttons, 0, 0);
            this.table_layout_active_orders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_active_orders.Location = new System.Drawing.Point(2, 3);
            this.table_layout_active_orders.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.table_layout_active_orders.Name = "table_layout_active_orders";
            this.table_layout_active_orders.RowCount = 1;
            this.table_layout_active_orders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_active_orders.Size = new System.Drawing.Size(468, 476);
            this.table_layout_active_orders.TabIndex = 8;
            // 
            // tree_view_active
            // 
            this.tree_view_active.CheckBoxes = true;
            this.tree_view_active.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_view_active.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tree_view_active.HideSelection = false;
            this.tree_view_active.ItemHeight = 15;
            this.tree_view_active.Location = new System.Drawing.Point(102, 3);
            this.tree_view_active.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tree_view_active.Name = "tree_view_active";
            this.tree_view_active.Size = new System.Drawing.Size(364, 470);
            this.tree_view_active.TabIndex = 5;
            this.tree_view_active.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_view_active_AfterCheck);
            this.tree_view_active.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.orderTreeViewDrawNode);
            this.tree_view_active.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tree_view_active_ItemDrag);
            this.tree_view_active.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_view_active_NodeMouseClick);
            // 
            // table_layout_active_order_buttons
            // 
            this.table_layout_active_order_buttons.ColumnCount = 1;
            this.table_layout_active_order_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.table_layout_active_order_buttons.Controls.Add(this.btn_add_active_pending, 0, 0);
            this.table_layout_active_order_buttons.Controls.Add(this.btn_add_active_finished, 0, 1);
            this.table_layout_active_order_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_active_order_buttons.Location = new System.Drawing.Point(0, 0);
            this.table_layout_active_order_buttons.Margin = new System.Windows.Forms.Padding(0);
            this.table_layout_active_order_buttons.Name = "table_layout_active_order_buttons";
            this.table_layout_active_order_buttons.RowCount = 3;
            this.table_layout_active_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table_layout_active_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table_layout_active_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_active_order_buttons.Size = new System.Drawing.Size(100, 476);
            this.table_layout_active_order_buttons.TabIndex = 6;
            // 
            // btn_add_active_pending
            // 
            this.btn_add_active_pending.Location = new System.Drawing.Point(2, 3);
            this.btn_add_active_pending.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_add_active_pending.Name = "btn_add_active_pending";
            this.btn_add_active_pending.Size = new System.Drawing.Size(92, 34);
            this.btn_add_active_pending.TabIndex = 0;
            this.btn_add_active_pending.Text = "Add to Pending";
            this.btn_add_active_pending.UseVisualStyleBackColor = true;
            this.btn_add_active_pending.Click += new System.EventHandler(this.btn_add_active_pending_Click);
            // 
            // btn_add_active_finished
            // 
            this.btn_add_active_finished.Location = new System.Drawing.Point(2, 43);
            this.btn_add_active_finished.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_add_active_finished.Name = "btn_add_active_finished";
            this.btn_add_active_finished.Size = new System.Drawing.Size(92, 34);
            this.btn_add_active_finished.TabIndex = 1;
            this.btn_add_active_finished.Text = "Add to Finished";
            this.btn_add_active_finished.UseVisualStyleBackColor = true;
            this.btn_add_active_finished.Click += new System.EventHandler(this.btn_add_active_finished_Click);
            // 
            // panel_add_order
            // 
            this.panel_add_order.Controls.Add(this.table_layout_add_order);
            this.panel_add_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_add_order.Location = new System.Drawing.Point(474, 3);
            this.panel_add_order.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_add_order.MaximumSize = new System.Drawing.Size(320, 0);
            this.panel_add_order.Name = "panel_add_order";
            this.panel_add_order.Size = new System.Drawing.Size(296, 476);
            this.panel_add_order.TabIndex = 35;
            // 
            // table_layout_add_order
            // 
            this.table_layout_add_order.ColumnCount = 1;
            this.table_layout_add_order.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_add_order.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_layout_add_order.Controls.Add(this.panel_add_order_top, 0, 0);
            this.table_layout_add_order.Controls.Add(this.list_checked_files, 0, 1);
            this.table_layout_add_order.Controls.Add(this.panel_add_order_bottom, 0, 2);
            this.table_layout_add_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_add_order.Location = new System.Drawing.Point(0, 0);
            this.table_layout_add_order.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.table_layout_add_order.Name = "table_layout_add_order";
            this.table_layout_add_order.RowCount = 3;
            this.table_layout_add_order.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.table_layout_add_order.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_add_order.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.table_layout_add_order.Size = new System.Drawing.Size(296, 476);
            this.table_layout_add_order.TabIndex = 35;
            // 
            // panel_add_order_top
            // 
            this.panel_add_order_top.Controls.Add(this.lbl_add_order_title);
            this.panel_add_order_top.Controls.Add(this.lbl_main_ordertype);
            this.panel_add_order_top.Controls.Add(this.drpd_main_ordertype);
            this.panel_add_order_top.Controls.Add(this.lbl_sub_ordertype);
            this.panel_add_order_top.Controls.Add(this.drpd_sub_ordertype);
            this.panel_add_order_top.Controls.Add(this.btn_choose_folder);
            this.panel_add_order_top.Controls.Add(this.lbl_folder);
            this.panel_add_order_top.Controls.Add(this.txt_folder_target);
            this.panel_add_order_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_add_order_top.Location = new System.Drawing.Point(2, 3);
            this.panel_add_order_top.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_add_order_top.Name = "panel_add_order_top";
            this.panel_add_order_top.Size = new System.Drawing.Size(292, 135);
            this.panel_add_order_top.TabIndex = 0;
            // 
            // lbl_add_order_title
            // 
            this.lbl_add_order_title.AutoSize = true;
            this.lbl_add_order_title.Location = new System.Drawing.Point(2, 9);
            this.lbl_add_order_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_add_order_title.Name = "lbl_add_order_title";
            this.lbl_add_order_title.Size = new System.Drawing.Size(112, 13);
            this.lbl_add_order_title.TabIndex = 27;
            this.lbl_add_order_title.Text = "Rendelés hozzáadása";
            // 
            // lbl_main_ordertype
            // 
            this.lbl_main_ordertype.AutoSize = true;
            this.lbl_main_ordertype.Location = new System.Drawing.Point(2, 31);
            this.lbl_main_ordertype.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_main_ordertype.Name = "lbl_main_ordertype";
            this.lbl_main_ordertype.Size = new System.Drawing.Size(38, 13);
            this.lbl_main_ordertype.TabIndex = 14;
            this.lbl_main_ordertype.Text = "Típus:";
            // 
            // drpd_main_ordertype
            // 
            this.drpd_main_ordertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpd_main_ordertype.FormattingEnabled = true;
            this.drpd_main_ordertype.Location = new System.Drawing.Point(94, 28);
            this.drpd_main_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.drpd_main_ordertype.Name = "drpd_main_ordertype";
            this.drpd_main_ordertype.Size = new System.Drawing.Size(192, 21);
            this.drpd_main_ordertype.TabIndex = 0;
            this.drpd_main_ordertype.SelectedIndexChanged += new System.EventHandler(this.drpd_main_ordertype_SelectedIndexChanged);
            // 
            // lbl_sub_ordertype
            // 
            this.lbl_sub_ordertype.AutoSize = true;
            this.lbl_sub_ordertype.Location = new System.Drawing.Point(2, 58);
            this.lbl_sub_ordertype.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_sub_ordertype.Name = "lbl_sub_ordertype";
            this.lbl_sub_ordertype.Size = new System.Drawing.Size(43, 13);
            this.lbl_sub_ordertype.TabIndex = 12;
            this.lbl_sub_ordertype.Text = "Altípus:";
            // 
            // drpd_sub_ordertype
            // 
            this.drpd_sub_ordertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpd_sub_ordertype.FormattingEnabled = true;
            this.drpd_sub_ordertype.Location = new System.Drawing.Point(94, 55);
            this.drpd_sub_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.drpd_sub_ordertype.Name = "drpd_sub_ordertype";
            this.drpd_sub_ordertype.Size = new System.Drawing.Size(192, 21);
            this.drpd_sub_ordertype.TabIndex = 1;
            this.drpd_sub_ordertype.SelectedIndexChanged += new System.EventHandler(this.drpd_sub_ordertype_SelectedIndexChanged);
            // 
            // btn_choose_folder
            // 
            this.btn_choose_folder.Location = new System.Drawing.Point(94, 82);
            this.btn_choose_folder.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_choose_folder.Name = "btn_choose_folder";
            this.btn_choose_folder.Size = new System.Drawing.Size(192, 23);
            this.btn_choose_folder.TabIndex = 2;
            this.btn_choose_folder.Text = "Válassz Mappát";
            this.btn_choose_folder.UseVisualStyleBackColor = true;
            this.btn_choose_folder.Click += new System.EventHandler(this.btn_choose_folder_Click);
            // 
            // lbl_folder
            // 
            this.lbl_folder.AutoSize = true;
            this.lbl_folder.Location = new System.Drawing.Point(2, 114);
            this.lbl_folder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_folder.Name = "lbl_folder";
            this.lbl_folder.Size = new System.Drawing.Size(43, 13);
            this.lbl_folder.TabIndex = 10;
            this.lbl_folder.Text = "Mappa:";
            // 
            // txt_folder_target
            // 
            this.txt_folder_target.AllowDrop = true;
            this.txt_folder_target.Location = new System.Drawing.Point(94, 111);
            this.txt_folder_target.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_folder_target.Name = "txt_folder_target";
            this.txt_folder_target.Size = new System.Drawing.Size(192, 20);
            this.txt_folder_target.TabIndex = 3;
            this.txt_folder_target.TextChanged += new System.EventHandler(this.txt_folder_target_TextChanged);
            this.txt_folder_target.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_folder_target_DragDrop);
            this.txt_folder_target.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_folder_target_DragEnter);
            // 
            // list_checked_files
            // 
            this.list_checked_files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_checked_files.CheckOnClick = true;
            this.list_checked_files.FormattingEnabled = true;
            this.list_checked_files.Items.AddRange(new object[] {
            "empty"});
            this.list_checked_files.Location = new System.Drawing.Point(19, 144);
            this.list_checked_files.Margin = new System.Windows.Forms.Padding(19, 3, 5, 3);
            this.list_checked_files.Name = "list_checked_files";
            this.list_checked_files.Size = new System.Drawing.Size(272, 184);
            this.list_checked_files.TabIndex = 0;
            this.list_checked_files.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.list_checked_files_ItemCheck);
            // 
            // panel_add_order_bottom
            // 
            this.panel_add_order_bottom.Controls.Add(this.lbl_customer_name);
            this.panel_add_order_bottom.Controls.Add(this.txt_customer_name);
            this.panel_add_order_bottom.Controls.Add(this.lbl_count);
            this.panel_add_order_bottom.Controls.Add(this.txt_count);
            this.panel_add_order_bottom.Controls.Add(this.lbl_comment);
            this.panel_add_order_bottom.Controls.Add(this.txt_comment);
            this.panel_add_order_bottom.Controls.Add(this.btn_add);
            this.panel_add_order_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_add_order_bottom.Location = new System.Drawing.Point(2, 342);
            this.panel_add_order_bottom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_add_order_bottom.Name = "panel_add_order_bottom";
            this.panel_add_order_bottom.Size = new System.Drawing.Size(292, 131);
            this.panel_add_order_bottom.TabIndex = 29;
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(2, 11);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(63, 13);
            this.lbl_count.TabIndex = 6;
            this.lbl_count.Text = "Darabszám:";
            // 
            // txt_count
            // 
            this.txt_count.Location = new System.Drawing.Point(94, 8);
            this.txt_count.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_count.Name = "txt_count";
            this.txt_count.Size = new System.Drawing.Size(192, 20);
            this.txt_count.TabIndex = 0;
            this.txt_count.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_count_KeyUp);
            // 
            // lbl_comment
            // 
            this.lbl_comment.AutoSize = true;
            this.lbl_comment.Location = new System.Drawing.Point(2, 63);
            this.lbl_comment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_comment.Name = "lbl_comment";
            this.lbl_comment.Size = new System.Drawing.Size(66, 13);
            this.lbl_comment.TabIndex = 4;
            this.lbl_comment.Text = "Megjegyzés:";
            // 
            // txt_comment
            // 
            this.txt_comment.Location = new System.Drawing.Point(94, 60);
            this.txt_comment.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(192, 20);
            this.txt_comment.TabIndex = 1;
            this.txt_comment.TextChanged += new System.EventHandler(this.txt_comment_TextChanged);
            this.txt_comment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_comment_KeyUp);
            // 
            // tab_control
            // 
            this.tab_control.Controls.Add(this.tab_page_active);
            this.tab_control.Controls.Add(this.tab_page_pending);
            this.tab_control.Controls.Add(this.tab_page_finished);
            this.tab_control.Controls.Add(this.tab_page_archive);
            this.tab_control.Controls.Add(this.tab_page_customize);
            this.tab_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_control.ImageList = this.image_list_tabs;
            this.tab_control.Location = new System.Drawing.Point(0, 24);
            this.tab_control.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tab_control.Name = "tab_control";
            this.tab_control.SelectedIndex = 0;
            this.tab_control.Size = new System.Drawing.Size(784, 515);
            this.tab_control.TabIndex = 1;
            // 
            // tab_page_active
            // 
            this.tab_page_active.Controls.Add(this.table_layout_active_orders_page);
            this.tab_page_active.ImageIndex = 0;
            this.tab_page_active.Location = new System.Drawing.Point(4, 23);
            this.tab_page_active.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tab_page_active.Name = "tab_page_active";
            this.tab_page_active.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tab_page_active.Size = new System.Drawing.Size(776, 488);
            this.tab_page_active.TabIndex = 0;
            this.tab_page_active.Text = "Aktív";
            this.tab_page_active.UseVisualStyleBackColor = true;
            // 
            // table_layout_active_orders_page
            // 
            this.table_layout_active_orders_page.ColumnCount = 2;
            this.table_layout_active_orders_page.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_active_orders_page.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.table_layout_active_orders_page.Controls.Add(this.panel_add_order, 0, 0);
            this.table_layout_active_orders_page.Controls.Add(this.table_layout_active_orders, 0, 0);
            this.table_layout_active_orders_page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_active_orders_page.Location = new System.Drawing.Point(2, 3);
            this.table_layout_active_orders_page.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.table_layout_active_orders_page.Name = "table_layout_active_orders_page";
            this.table_layout_active_orders_page.RowCount = 1;
            this.table_layout_active_orders_page.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_active_orders_page.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 482F));
            this.table_layout_active_orders_page.Size = new System.Drawing.Size(772, 482);
            this.table_layout_active_orders_page.TabIndex = 6;
            // 
            // tab_page_pending
            // 
            this.tab_page_pending.Controls.Add(this.table_layout_pending_orders);
            this.tab_page_pending.ImageIndex = 1;
            this.tab_page_pending.Location = new System.Drawing.Point(4, 23);
            this.tab_page_pending.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tab_page_pending.Name = "tab_page_pending";
            this.tab_page_pending.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tab_page_pending.Size = new System.Drawing.Size(776, 488);
            this.tab_page_pending.TabIndex = 1;
            this.tab_page_pending.Text = "Kész";
            this.tab_page_pending.UseVisualStyleBackColor = true;
            // 
            // table_layout_pending_orders
            // 
            this.table_layout_pending_orders.ColumnCount = 2;
            this.table_layout_pending_orders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.table_layout_pending_orders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_pending_orders.Controls.Add(this.tree_view_pending, 1, 0);
            this.table_layout_pending_orders.Controls.Add(this.table_layout_pending_order_buttons, 0, 0);
            this.table_layout_pending_orders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_pending_orders.Location = new System.Drawing.Point(2, 3);
            this.table_layout_pending_orders.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.table_layout_pending_orders.Name = "table_layout_pending_orders";
            this.table_layout_pending_orders.RowCount = 1;
            this.table_layout_pending_orders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_pending_orders.Size = new System.Drawing.Size(772, 482);
            this.table_layout_pending_orders.TabIndex = 11;
            // 
            // tree_view_pending
            // 
            this.tree_view_pending.CheckBoxes = true;
            this.tree_view_pending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_view_pending.Location = new System.Drawing.Point(106, 6);
            this.tree_view_pending.Margin = new System.Windows.Forms.Padding(6);
            this.tree_view_pending.Name = "tree_view_pending";
            this.tree_view_pending.Size = new System.Drawing.Size(660, 470);
            this.tree_view_pending.TabIndex = 6;
            this.tree_view_pending.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.orderTreeViewDrawNode);
            this.tree_view_pending.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_view_pending_NodeMouseClick);
            // 
            // table_layout_pending_order_buttons
            // 
            this.table_layout_pending_order_buttons.ColumnCount = 2;
            this.table_layout_pending_order_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.table_layout_pending_order_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_pending_order_buttons.Controls.Add(this.btn_add_pending_active, 0, 0);
            this.table_layout_pending_order_buttons.Controls.Add(this.btn_add_pending_finished, 0, 1);
            this.table_layout_pending_order_buttons.Controls.Add(this.btn_set_notified, 0, 2);
            this.table_layout_pending_order_buttons.Controls.Add(this.btn_reset_notified, 0, 3);
            this.table_layout_pending_order_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_pending_order_buttons.Location = new System.Drawing.Point(2, 3);
            this.table_layout_pending_order_buttons.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.table_layout_pending_order_buttons.Name = "table_layout_pending_order_buttons";
            this.table_layout_pending_order_buttons.RowCount = 5;
            this.table_layout_pending_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table_layout_pending_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table_layout_pending_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table_layout_pending_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table_layout_pending_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table_layout_pending_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_layout_pending_order_buttons.Size = new System.Drawing.Size(96, 476);
            this.table_layout_pending_order_buttons.TabIndex = 6;
            // 
            // btn_add_pending_active
            // 
            this.btn_add_pending_active.Location = new System.Drawing.Point(2, 3);
            this.btn_add_pending_active.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_add_pending_active.Name = "btn_add_pending_active";
            this.btn_add_pending_active.Size = new System.Drawing.Size(92, 34);
            this.btn_add_pending_active.TabIndex = 0;
            this.btn_add_pending_active.Text = "Add to Active";
            this.btn_add_pending_active.UseVisualStyleBackColor = true;
            this.btn_add_pending_active.Click += new System.EventHandler(this.btn_add_pending_active_Click);
            // 
            // btn_add_pending_finished
            // 
            this.btn_add_pending_finished.Location = new System.Drawing.Point(2, 43);
            this.btn_add_pending_finished.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_add_pending_finished.Name = "btn_add_pending_finished";
            this.btn_add_pending_finished.Size = new System.Drawing.Size(92, 34);
            this.btn_add_pending_finished.TabIndex = 1;
            this.btn_add_pending_finished.Text = "Add to Finished";
            this.btn_add_pending_finished.UseVisualStyleBackColor = true;
            this.btn_add_pending_finished.Click += new System.EventHandler(this.btn_add_pending_finished_Click);
            // 
            // btn_set_notified
            // 
            this.btn_set_notified.Location = new System.Drawing.Point(2, 83);
            this.btn_set_notified.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_set_notified.Name = "btn_set_notified";
            this.btn_set_notified.Size = new System.Drawing.Size(92, 34);
            this.btn_set_notified.TabIndex = 2;
            this.btn_set_notified.Text = "Notify";
            this.btn_set_notified.UseVisualStyleBackColor = true;
            this.btn_set_notified.Click += new System.EventHandler(this.btn_set_notified_Click);
            // 
            // btn_reset_notified
            // 
            this.btn_reset_notified.Location = new System.Drawing.Point(2, 123);
            this.btn_reset_notified.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_reset_notified.Name = "btn_reset_notified";
            this.btn_reset_notified.Size = new System.Drawing.Size(92, 34);
            this.btn_reset_notified.TabIndex = 3;
            this.btn_reset_notified.Text = "Reset Notify";
            this.btn_reset_notified.UseVisualStyleBackColor = true;
            this.btn_reset_notified.Click += new System.EventHandler(this.btn_reset_notified_Click);
            // 
            // tab_page_finished
            // 
            this.tab_page_finished.Controls.Add(this.table_layout_finished_orders);
            this.tab_page_finished.ImageIndex = 2;
            this.tab_page_finished.Location = new System.Drawing.Point(4, 23);
            this.tab_page_finished.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tab_page_finished.Name = "tab_page_finished";
            this.tab_page_finished.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tab_page_finished.Size = new System.Drawing.Size(776, 488);
            this.tab_page_finished.TabIndex = 3;
            this.tab_page_finished.Text = "Teljesített";
            this.tab_page_finished.UseVisualStyleBackColor = true;
            // 
            // table_layout_finished_orders
            // 
            this.table_layout_finished_orders.ColumnCount = 2;
            this.table_layout_finished_orders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.table_layout_finished_orders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_finished_orders.Controls.Add(this.tree_view_finished, 1, 0);
            this.table_layout_finished_orders.Controls.Add(this.table_layout_finished_order_buttons, 0, 0);
            this.table_layout_finished_orders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_finished_orders.Location = new System.Drawing.Point(2, 3);
            this.table_layout_finished_orders.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.table_layout_finished_orders.Name = "table_layout_finished_orders";
            this.table_layout_finished_orders.RowCount = 1;
            this.table_layout_finished_orders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_finished_orders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 482F));
            this.table_layout_finished_orders.Size = new System.Drawing.Size(772, 482);
            this.table_layout_finished_orders.TabIndex = 12;
            // 
            // tree_view_finished
            // 
            this.tree_view_finished.CheckBoxes = true;
            this.tree_view_finished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_view_finished.HideSelection = false;
            this.tree_view_finished.Location = new System.Drawing.Point(106, 6);
            this.tree_view_finished.Margin = new System.Windows.Forms.Padding(6);
            this.tree_view_finished.Name = "tree_view_finished";
            this.tree_view_finished.Size = new System.Drawing.Size(660, 470);
            this.tree_view_finished.TabIndex = 0;
            this.tree_view_finished.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_view_finished_AfterCheck);
            this.tree_view_finished.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.orderTreeViewDrawNode);
            this.tree_view_finished.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_view_finished_NodeMouseClick);
            // 
            // table_layout_finished_order_buttons
            // 
            this.table_layout_finished_order_buttons.ColumnCount = 1;
            this.table_layout_finished_order_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.table_layout_finished_order_buttons.Controls.Add(this.btn_add_finished_pending, 0, 1);
            this.table_layout_finished_order_buttons.Controls.Add(this.btn_add_finished_active, 0, 0);
            this.table_layout_finished_order_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_finished_order_buttons.Location = new System.Drawing.Point(2, 3);
            this.table_layout_finished_order_buttons.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.table_layout_finished_order_buttons.Name = "table_layout_finished_order_buttons";
            this.table_layout_finished_order_buttons.RowCount = 3;
            this.table_layout_finished_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table_layout_finished_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table_layout_finished_order_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table_layout_finished_order_buttons.Size = new System.Drawing.Size(96, 476);
            this.table_layout_finished_order_buttons.TabIndex = 6;
            // 
            // btn_add_finished_pending
            // 
            this.btn_add_finished_pending.Location = new System.Drawing.Point(2, 43);
            this.btn_add_finished_pending.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_add_finished_pending.Name = "btn_add_finished_pending";
            this.btn_add_finished_pending.Size = new System.Drawing.Size(92, 34);
            this.btn_add_finished_pending.TabIndex = 1;
            this.btn_add_finished_pending.Text = "Add to Pending";
            this.btn_add_finished_pending.UseVisualStyleBackColor = true;
            this.btn_add_finished_pending.Click += new System.EventHandler(this.btn_add_finished_pending_Click);
            // 
            // btn_add_finished_active
            // 
            this.btn_add_finished_active.Location = new System.Drawing.Point(2, 3);
            this.btn_add_finished_active.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_add_finished_active.Name = "btn_add_finished_active";
            this.btn_add_finished_active.Size = new System.Drawing.Size(92, 34);
            this.btn_add_finished_active.TabIndex = 0;
            this.btn_add_finished_active.Text = "Add to Active";
            this.btn_add_finished_active.UseVisualStyleBackColor = true;
            this.btn_add_finished_active.Click += new System.EventHandler(this.btn_add_finished_active_Click);
            // 
            // tab_page_archive
            // 
            this.tab_page_archive.Controls.Add(this.table_layout_archive);
            this.tab_page_archive.ImageIndex = 3;
            this.tab_page_archive.Location = new System.Drawing.Point(4, 23);
            this.tab_page_archive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tab_page_archive.Name = "tab_page_archive";
            this.tab_page_archive.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tab_page_archive.Size = new System.Drawing.Size(776, 488);
            this.tab_page_archive.TabIndex = 4;
            this.tab_page_archive.Text = "Archívum";
            this.tab_page_archive.UseVisualStyleBackColor = true;
            // 
            // table_layout_archive
            // 
            this.table_layout_archive.ColumnCount = 1;
            this.table_layout_archive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_archive.Controls.Add(this.lbl_archive_name, 0, 0);
            this.table_layout_archive.Controls.Add(this.tree_view_archive, 0, 1);
            this.table_layout_archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_archive.Location = new System.Drawing.Point(2, 3);
            this.table_layout_archive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.table_layout_archive.Name = "table_layout_archive";
            this.table_layout_archive.RowCount = 3;
            this.table_layout_archive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_layout_archive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_archive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_layout_archive.Size = new System.Drawing.Size(772, 482);
            this.table_layout_archive.TabIndex = 11;
            // 
            // lbl_archive_name
            // 
            this.lbl_archive_name.AutoSize = true;
            this.lbl_archive_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_archive_name.Location = new System.Drawing.Point(2, 0);
            this.lbl_archive_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_archive_name.Name = "lbl_archive_name";
            this.lbl_archive_name.Size = new System.Drawing.Size(768, 13);
            this.lbl_archive_name.TabIndex = 10;
            this.lbl_archive_name.Text = "Drag and Drop archived files to see the orders!";
            // 
            // tree_view_archive
            // 
            this.tree_view_archive.AllowDrop = true;
            this.tree_view_archive.CheckBoxes = true;
            this.tree_view_archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_view_archive.HideSelection = false;
            this.tree_view_archive.Location = new System.Drawing.Point(2, 23);
            this.tree_view_archive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tree_view_archive.Name = "tree_view_archive";
            this.tree_view_archive.Size = new System.Drawing.Size(768, 436);
            this.tree_view_archive.TabIndex = 9;
            this.tree_view_archive.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.orderTreeViewDrawNode);
            this.tree_view_archive.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeview_archive_DragDrop);
            this.tree_view_archive.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeview_archive_DragEnter);
            // 
            // tab_page_customize
            // 
            this.tab_page_customize.Controls.Add(this.panel_choose_source);
            this.tab_page_customize.Controls.Add(this.panel_main_ordertype);
            this.tab_page_customize.Controls.Add(this.panel_sub_ordertype);
            this.tab_page_customize.ImageIndex = 4;
            this.tab_page_customize.Location = new System.Drawing.Point(4, 23);
            this.tab_page_customize.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tab_page_customize.Name = "tab_page_customize";
            this.tab_page_customize.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tab_page_customize.Size = new System.Drawing.Size(776, 488);
            this.tab_page_customize.TabIndex = 2;
            this.tab_page_customize.Text = "Forrás";
            this.tab_page_customize.UseVisualStyleBackColor = true;
            // 
            // panel_choose_source
            // 
            this.panel_choose_source.Controls.Add(this.btn_choose_source);
            this.panel_choose_source.Controls.Add(this.lbl_const_current);
            this.panel_choose_source.Controls.Add(this.lbl_source);
            this.panel_choose_source.Controls.Add(this.tree_view_hierarchy);
            this.panel_choose_source.Controls.Add(this.btn_accept_source);
            this.panel_choose_source.Location = new System.Drawing.Point(0, 0);
            this.panel_choose_source.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_choose_source.Name = "panel_choose_source";
            this.panel_choose_source.Size = new System.Drawing.Size(238, 477);
            this.panel_choose_source.TabIndex = 22;
            // 
            // btn_choose_source
            // 
            this.btn_choose_source.Location = new System.Drawing.Point(6, 6);
            this.btn_choose_source.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_choose_source.Name = "btn_choose_source";
            this.btn_choose_source.Size = new System.Drawing.Size(226, 23);
            this.btn_choose_source.TabIndex = 0;
            this.btn_choose_source.Text = "Choose Source Folder";
            this.btn_choose_source.UseVisualStyleBackColor = true;
            this.btn_choose_source.Click += new System.EventHandler(this.Btn_ChooseSourceFolder_Click);
            // 
            // lbl_const_current
            // 
            this.lbl_const_current.AutoSize = true;
            this.lbl_const_current.Location = new System.Drawing.Point(12, 39);
            this.lbl_const_current.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_const_current.Name = "lbl_const_current";
            this.lbl_const_current.Size = new System.Drawing.Size(44, 13);
            this.lbl_const_current.TabIndex = 6;
            this.lbl_const_current.Text = "Current:";
            // 
            // lbl_source
            // 
            this.lbl_source.AutoSize = true;
            this.lbl_source.Location = new System.Drawing.Point(62, 39);
            this.lbl_source.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_source.Name = "lbl_source";
            this.lbl_source.Size = new System.Drawing.Size(10, 13);
            this.lbl_source.TabIndex = 7;
            this.lbl_source.Text = "-";
            // 
            // tree_view_hierarchy
            // 
            this.tree_view_hierarchy.Location = new System.Drawing.Point(6, 66);
            this.tree_view_hierarchy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tree_view_hierarchy.Name = "tree_view_hierarchy";
            this.tree_view_hierarchy.Size = new System.Drawing.Size(226, 271);
            this.tree_view_hierarchy.TabIndex = 8;
            this.tree_view_hierarchy.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tree_view_hierarchy_ItemDrag);
            // 
            // btn_accept_source
            // 
            this.btn_accept_source.Location = new System.Drawing.Point(6, 343);
            this.btn_accept_source.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_accept_source.Name = "btn_accept_source";
            this.btn_accept_source.Size = new System.Drawing.Size(226, 23);
            this.btn_accept_source.TabIndex = 1;
            this.btn_accept_source.Text = "Accept Source Folder";
            this.btn_accept_source.UseVisualStyleBackColor = true;
            this.btn_accept_source.Click += new System.EventHandler(this.button_accept_source_Click);
            // 
            // panel_main_ordertype
            // 
            this.panel_main_ordertype.Controls.Add(this.txt_main_ordertype);
            this.panel_main_ordertype.Controls.Add(this.btn_add_main_ordertype);
            this.panel_main_ordertype.Controls.Add(this.listbox_main_ordertype);
            this.panel_main_ordertype.Controls.Add(this.btn_delete_main_ordertype);
            this.panel_main_ordertype.Location = new System.Drawing.Point(242, 0);
            this.panel_main_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_main_ordertype.Name = "panel_main_ordertype";
            this.panel_main_ordertype.Size = new System.Drawing.Size(126, 477);
            this.panel_main_ordertype.TabIndex = 23;
            this.panel_main_ordertype.Visible = false;
            // 
            // txt_main_ordertype
            // 
            this.txt_main_ordertype.Location = new System.Drawing.Point(2, 9);
            this.txt_main_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_main_ordertype.Name = "txt_main_ordertype";
            this.txt_main_ordertype.Size = new System.Drawing.Size(120, 20);
            this.txt_main_ordertype.TabIndex = 0;
            this.txt_main_ordertype.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_main_ordertype_KeyUp);
            // 
            // btn_add_main_ordertype
            // 
            this.btn_add_main_ordertype.Location = new System.Drawing.Point(2, 35);
            this.btn_add_main_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_add_main_ordertype.Name = "btn_add_main_ordertype";
            this.btn_add_main_ordertype.Size = new System.Drawing.Size(120, 23);
            this.btn_add_main_ordertype.TabIndex = 1;
            this.btn_add_main_ordertype.Text = "Típus Hozzáadása";
            this.btn_add_main_ordertype.UseVisualStyleBackColor = true;
            this.btn_add_main_ordertype.Click += new System.EventHandler(this.btn_add_main_ordertype_Click);
            // 
            // listbox_main_ordertype
            // 
            this.listbox_main_ordertype.FormattingEnabled = true;
            this.listbox_main_ordertype.Location = new System.Drawing.Point(2, 66);
            this.listbox_main_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listbox_main_ordertype.Name = "listbox_main_ordertype";
            this.listbox_main_ordertype.Size = new System.Drawing.Size(120, 134);
            this.listbox_main_ordertype.TabIndex = 2;
            // 
            // btn_delete_main_ordertype
            // 
            this.btn_delete_main_ordertype.Location = new System.Drawing.Point(2, 206);
            this.btn_delete_main_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_delete_main_ordertype.Name = "btn_delete_main_ordertype";
            this.btn_delete_main_ordertype.Size = new System.Drawing.Size(120, 23);
            this.btn_delete_main_ordertype.TabIndex = 3;
            this.btn_delete_main_ordertype.Text = "Típus Törlése";
            this.btn_delete_main_ordertype.UseVisualStyleBackColor = true;
            this.btn_delete_main_ordertype.Click += new System.EventHandler(this.btn_delete_main_ordertype_Click);
            // 
            // panel_sub_ordertype
            // 
            this.panel_sub_ordertype.Controls.Add(this.txt_sub_ordertype);
            this.panel_sub_ordertype.Controls.Add(this.btn_add_sub_ordertype);
            this.panel_sub_ordertype.Controls.Add(this.btn_delete_sub_ordertype);
            this.panel_sub_ordertype.Controls.Add(this.listbox_sub_ordertype);
            this.panel_sub_ordertype.Location = new System.Drawing.Point(374, 0);
            this.panel_sub_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_sub_ordertype.Name = "panel_sub_ordertype";
            this.panel_sub_ordertype.Size = new System.Drawing.Size(126, 477);
            this.panel_sub_ordertype.TabIndex = 23;
            this.panel_sub_ordertype.Visible = false;
            // 
            // txt_sub_ordertype
            // 
            this.txt_sub_ordertype.Location = new System.Drawing.Point(2, 9);
            this.txt_sub_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_sub_ordertype.Name = "txt_sub_ordertype";
            this.txt_sub_ordertype.Size = new System.Drawing.Size(120, 20);
            this.txt_sub_ordertype.TabIndex = 0;
            this.txt_sub_ordertype.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_sub_ordertype_KeyUp);
            // 
            // btn_add_sub_ordertype
            // 
            this.btn_add_sub_ordertype.Location = new System.Drawing.Point(2, 35);
            this.btn_add_sub_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_add_sub_ordertype.Name = "btn_add_sub_ordertype";
            this.btn_add_sub_ordertype.Size = new System.Drawing.Size(120, 23);
            this.btn_add_sub_ordertype.TabIndex = 1;
            this.btn_add_sub_ordertype.Text = "Altípus Hozzáadása";
            this.btn_add_sub_ordertype.UseVisualStyleBackColor = true;
            this.btn_add_sub_ordertype.Click += new System.EventHandler(this.btn_add_sub_ordertype_Click);
            // 
            // btn_delete_sub_ordertype
            // 
            this.btn_delete_sub_ordertype.Location = new System.Drawing.Point(2, 206);
            this.btn_delete_sub_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_delete_sub_ordertype.Name = "btn_delete_sub_ordertype";
            this.btn_delete_sub_ordertype.Size = new System.Drawing.Size(120, 23);
            this.btn_delete_sub_ordertype.TabIndex = 3;
            this.btn_delete_sub_ordertype.Text = "Altípus Törlése";
            this.btn_delete_sub_ordertype.UseVisualStyleBackColor = true;
            this.btn_delete_sub_ordertype.Click += new System.EventHandler(this.btn_delete_sub_ordertype_Click);
            // 
            // listbox_sub_ordertype
            // 
            this.listbox_sub_ordertype.FormattingEnabled = true;
            this.listbox_sub_ordertype.Location = new System.Drawing.Point(2, 66);
            this.listbox_sub_ordertype.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listbox_sub_ordertype.Name = "listbox_sub_ordertype";
            this.listbox_sub_ordertype.Size = new System.Drawing.Size(120, 134);
            this.listbox_sub_ordertype.TabIndex = 2;
            // 
            // image_list_tabs
            // 
            this.image_list_tabs.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.image_list_tabs.ImageSize = new System.Drawing.Size(16, 16);
            this.image_list_tabs.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolstrip_menu
            // 
            this.toolstrip_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstrip_item_file,
            this.toolstrip_item_edit,
            this.toolstrip_item_view,
            this.toolstrip_item_help});
            this.toolstrip_menu.Location = new System.Drawing.Point(0, 0);
            this.toolstrip_menu.Name = "toolstrip_menu";
            this.toolstrip_menu.Size = new System.Drawing.Size(784, 24);
            this.toolstrip_menu.TabIndex = 0;
            this.toolstrip_menu.Text = "menuStrip1";
            // 
            // toolstrip_item_file
            // 
            this.toolstrip_item_file.Name = "toolstrip_item_file";
            this.toolstrip_item_file.Size = new System.Drawing.Size(37, 20);
            this.toolstrip_item_file.Text = "File";
            // 
            // toolstrip_item_edit
            // 
            this.toolstrip_item_edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstrip_item_force_save,
            this.toolStripMenuItem1,
            this.toolstrip_item_edit_ordertype,
            this.toolstrip_item_edit_source_path,
            this.toolstrip_item_edit_settings});
            this.toolstrip_item_edit.Name = "toolstrip_item_edit";
            this.toolstrip_item_edit.Size = new System.Drawing.Size(39, 20);
            this.toolstrip_item_edit.Text = "Edit";
            // 
            // toolstrip_item_force_save
            // 
            this.toolstrip_item_force_save.Name = "toolstrip_item_force_save";
            this.toolstrip_item_force_save.Size = new System.Drawing.Size(173, 22);
            this.toolstrip_item_force_save.Text = "Force Save Objects";
            this.toolstrip_item_force_save.Click += new System.EventHandler(this.forceSaveObjectsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(170, 6);
            // 
            // toolstrip_item_edit_ordertype
            // 
            this.toolstrip_item_edit_ordertype.Name = "toolstrip_item_edit_ordertype";
            this.toolstrip_item_edit_ordertype.Size = new System.Drawing.Size(173, 22);
            this.toolstrip_item_edit_ordertype.Text = "Edit OrderTypes";
            this.toolstrip_item_edit_ordertype.Click += new System.EventHandler(this.editOrderTypesToolStripMenuItem_Click);
            // 
            // toolstrip_item_edit_source_path
            // 
            this.toolstrip_item_edit_source_path.Name = "toolstrip_item_edit_source_path";
            this.toolstrip_item_edit_source_path.Size = new System.Drawing.Size(173, 22);
            this.toolstrip_item_edit_source_path.Text = "Edit Source Path";
            this.toolstrip_item_edit_source_path.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolstrip_item_edit_settings
            // 
            this.toolstrip_item_edit_settings.Name = "toolstrip_item_edit_settings";
            this.toolstrip_item_edit_settings.Size = new System.Drawing.Size(173, 22);
            this.toolstrip_item_edit_settings.Text = "Settings";
            this.toolstrip_item_edit_settings.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolstrip_item_view
            // 
            this.toolstrip_item_view.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstrip_item_language,
            this.toolstrip_item_add_panel});
            this.toolstrip_item_view.Name = "toolstrip_item_view";
            this.toolstrip_item_view.Size = new System.Drawing.Size(44, 20);
            this.toolstrip_item_view.Text = "View";
            // 
            // toolstrip_item_language
            // 
            this.toolstrip_item_language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstrip_item_language_english,
            this.toolstrip_item_language_hungarian});
            this.toolstrip_item_language.Name = "toolstrip_item_language";
            this.toolstrip_item_language.Size = new System.Drawing.Size(160, 22);
            this.toolstrip_item_language.Text = "Language";
            // 
            // toolstrip_item_language_english
            // 
            this.toolstrip_item_language_english.Name = "toolstrip_item_language_english";
            this.toolstrip_item_language_english.Size = new System.Drawing.Size(114, 22);
            this.toolstrip_item_language_english.Text = "English";
            this.toolstrip_item_language_english.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // toolstrip_item_language_hungarian
            // 
            this.toolstrip_item_language_hungarian.Name = "toolstrip_item_language_hungarian";
            this.toolstrip_item_language_hungarian.Size = new System.Drawing.Size(114, 22);
            this.toolstrip_item_language_hungarian.Text = "Magyar";
            this.toolstrip_item_language_hungarian.Click += new System.EventHandler(this.magyarToolStripMenuItem_Click);
            // 
            // toolstrip_item_add_panel
            // 
            this.toolstrip_item_add_panel.Name = "toolstrip_item_add_panel";
            this.toolstrip_item_add_panel.Size = new System.Drawing.Size(160, 22);
            this.toolstrip_item_add_panel.Text = "Show Add Panel";
            this.toolstrip_item_add_panel.Click += new System.EventHandler(this.toolstrip_item_add_panel_Click);
            // 
            // toolstrip_item_help
            // 
            this.toolstrip_item_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstrip_item_save_logs,
            this.toolstrip_item_delete_lock,
            this.toolstrip_item_clear_status});
            this.toolstrip_item_help.Name = "toolstrip_item_help";
            this.toolstrip_item_help.Size = new System.Drawing.Size(49, 20);
            this.toolstrip_item_help.Text = "Help?";
            // 
            // toolstrip_item_save_logs
            // 
            this.toolstrip_item_save_logs.Name = "toolstrip_item_save_logs";
            this.toolstrip_item_save_logs.Size = new System.Drawing.Size(153, 22);
            this.toolstrip_item_save_logs.Text = "Save Log";
            this.toolstrip_item_save_logs.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
            // 
            // toolstrip_item_delete_lock
            // 
            this.toolstrip_item_delete_lock.Name = "toolstrip_item_delete_lock";
            this.toolstrip_item_delete_lock.Size = new System.Drawing.Size(153, 22);
            this.toolstrip_item_delete_lock.Text = "Delete Lock";
            this.toolstrip_item_delete_lock.Click += new System.EventHandler(this.deleteLockToolStripMenuItem_Click_1);
            // 
            // toolstrip_item_clear_status
            // 
            this.toolstrip_item_clear_status.Name = "toolstrip_item_clear_status";
            this.toolstrip_item_clear_status.Size = new System.Drawing.Size(153, 22);
            this.toolstrip_item_clear_status.Text = "Clear StatusBar";
            this.toolstrip_item_clear_status.Click += new System.EventHandler(this.clearStatusBarToolStripMenuItem_Click);
            // 
            // status_strip
            // 
            this.status_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_status_strip_main});
            this.status_strip.Location = new System.Drawing.Point(0, 539);
            this.status_strip.Name = "status_strip";
            this.status_strip.Size = new System.Drawing.Size(784, 22);
            this.status_strip.TabIndex = 8;
            this.status_strip.Text = "statusStrip1";
            // 
            // label_status_strip_main
            // 
            this.label_status_strip_main.Name = "label_status_strip_main";
            this.label_status_strip_main.Size = new System.Drawing.Size(16, 17);
            this.label_status_strip_main.Text = "...";
            // 
            // lbl_customer_name
            // 
            this.lbl_customer_name.AutoSize = true;
            this.lbl_customer_name.Location = new System.Drawing.Point(2, 37);
            this.lbl_customer_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_customer_name.Name = "lbl_customer_name";
            this.lbl_customer_name.Size = new System.Drawing.Size(30, 13);
            this.lbl_customer_name.TabIndex = 8;
            this.lbl_customer_name.Text = "Név:";
            // 
            // txt_customer_name
            // 
            this.txt_customer_name.Location = new System.Drawing.Point(94, 34);
            this.txt_customer_name.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_customer_name.Name = "txt_customer_name";
            this.txt_customer_name.Size = new System.Drawing.Size(192, 20);
            this.txt_customer_name.TabIndex = 7;
            this.txt_customer_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_customer_name_KeyUp);
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tab_control);
            this.Controls.Add(this.toolstrip_menu);
            this.Controls.Add(this.status_strip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.toolstrip_menu;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "form_main";
            this.Text = "Order Manager";
            this.Activated += new System.EventHandler(this.form_main_Activated);
            this.Deactivate += new System.EventHandler(this.form_main_DeActivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_main_FormClosing);
            this.Load += new System.EventHandler(this.form_main_Load);
            this.table_layout_active_orders.ResumeLayout(false);
            this.table_layout_active_order_buttons.ResumeLayout(false);
            this.panel_add_order.ResumeLayout(false);
            this.table_layout_add_order.ResumeLayout(false);
            this.panel_add_order_top.ResumeLayout(false);
            this.panel_add_order_top.PerformLayout();
            this.panel_add_order_bottom.ResumeLayout(false);
            this.panel_add_order_bottom.PerformLayout();
            this.tab_control.ResumeLayout(false);
            this.tab_page_active.ResumeLayout(false);
            this.table_layout_active_orders_page.ResumeLayout(false);
            this.tab_page_pending.ResumeLayout(false);
            this.table_layout_pending_orders.ResumeLayout(false);
            this.table_layout_pending_order_buttons.ResumeLayout(false);
            this.tab_page_finished.ResumeLayout(false);
            this.table_layout_finished_orders.ResumeLayout(false);
            this.table_layout_finished_order_buttons.ResumeLayout(false);
            this.tab_page_archive.ResumeLayout(false);
            this.table_layout_archive.ResumeLayout(false);
            this.table_layout_archive.PerformLayout();
            this.tab_page_customize.ResumeLayout(false);
            this.panel_choose_source.ResumeLayout(false);
            this.panel_choose_source.PerformLayout();
            this.panel_main_ordertype.ResumeLayout(false);
            this.panel_main_ordertype.PerformLayout();
            this.panel_sub_ordertype.ResumeLayout(false);
            this.panel_sub_ordertype.PerformLayout();
            this.toolstrip_menu.ResumeLayout(false);
            this.toolstrip_menu.PerformLayout();
            this.status_strip.ResumeLayout(false);
            this.status_strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TabControl tab_control;
        private System.Windows.Forms.TabPage tab_page_active;
        private System.Windows.Forms.TabPage tab_page_pending;
        private System.Windows.Forms.MenuStrip toolstrip_menu;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_file;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_edit;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_view;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_help;
        private System.Windows.Forms.Label lbl_comment;
        private System.Windows.Forms.TextBox txt_comment;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.TextBox txt_count;
        private System.Windows.Forms.Button btn_choose_folder;
        private System.Windows.Forms.Label lbl_folder;
        private System.Windows.Forms.TextBox txt_folder_target;
        private System.Windows.Forms.ComboBox drpd_main_ordertype;
        private System.Windows.Forms.CheckedListBox list_checked_files;
        private System.Windows.Forms.Label lbl_sub_ordertype;
        private System.Windows.Forms.TabPage tab_page_customize;
        private System.Windows.Forms.Label lbl_source;
        private System.Windows.Forms.Button btn_choose_source;
        private System.Windows.Forms.Label lbl_const_current;
        private System.Windows.Forms.Button btn_add_active_pending;
        private System.Windows.Forms.TreeView tree_view_active;
        private System.Windows.Forms.TreeView tree_view_hierarchy;
        private System.Windows.Forms.TextBox txt_main_ordertype;
        private System.Windows.Forms.Button btn_add_main_ordertype;
        private System.Windows.Forms.ListBox listbox_main_ordertype;
        private System.Windows.Forms.Label lbl_main_ordertype;
        private System.Windows.Forms.ComboBox drpd_sub_ordertype;
        private System.Windows.Forms.TextBox txt_sub_ordertype;
        private System.Windows.Forms.Button btn_add_sub_ordertype;
        private System.Windows.Forms.ListBox listbox_sub_ordertype;
        private System.Windows.Forms.Button btn_delete_sub_ordertype;
        private System.Windows.Forms.Button btn_delete_main_ordertype;
        private System.Windows.Forms.Button btn_add_pending_finished;
        private System.Windows.Forms.TreeView tree_view_pending;
        private System.Windows.Forms.StatusStrip status_strip;
        private System.Windows.Forms.ToolStripStatusLabel label_status_strip_main;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_save_logs;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_delete_lock;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_force_save;
        private System.Windows.Forms.TabPage tab_page_finished;
        private System.Windows.Forms.Button btn_accept_source;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_clear_status;
        private System.Windows.Forms.Button btn_add_active_finished;
        private System.Windows.Forms.TreeView tree_view_finished;
        private System.Windows.Forms.Button btn_add_pending_active;
        private System.Windows.Forms.TabPage tab_page_archive;
        private System.Windows.Forms.TreeView tree_view_archive;
        private System.Windows.Forms.Label lbl_archive_name;
        private System.Windows.Forms.TableLayoutPanel table_layout_archive;
        private System.Windows.Forms.TableLayoutPanel table_layout_active_orders;
        private System.Windows.Forms.TableLayoutPanel table_layout_active_order_buttons;
        private System.Windows.Forms.Panel panel_add_order;
        private System.Windows.Forms.TableLayoutPanel table_layout_pending_orders;
        private System.Windows.Forms.TableLayoutPanel table_layout_pending_order_buttons;
        private System.Windows.Forms.TableLayoutPanel table_layout_finished_orders;
        private System.Windows.Forms.TableLayoutPanel table_layout_finished_order_buttons;
        private System.Windows.Forms.Panel panel_choose_source;
        private System.Windows.Forms.Panel panel_sub_ordertype;
        private System.Windows.Forms.Panel panel_main_ordertype;
        private System.Windows.Forms.TableLayoutPanel table_layout_add_order;
        private System.Windows.Forms.Panel panel_add_order_top;
        private System.Windows.Forms.Label lbl_add_order_title;
        private System.Windows.Forms.Panel panel_add_order_bottom;
        private System.Windows.Forms.TableLayoutPanel table_layout_active_orders_page;
        private System.Windows.Forms.Button btn_set_notified;
        private System.Windows.Forms.Button btn_reset_notified;
        private System.Windows.Forms.Button btn_add_finished_pending;
        private System.Windows.Forms.Button btn_add_finished_active;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_edit_ordertype;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_edit_source_path;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_edit_settings;
        private System.Windows.Forms.ImageList image_list_tabs;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_language;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_language_english;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_language_hungarian;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_item_add_panel;
        private System.Windows.Forms.Label lbl_customer_name;
        private System.Windows.Forms.TextBox txt_customer_name;
    }
}

