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
            this.btn_add = new System.Windows.Forms.Button();
            this.split_container_edit = new System.Windows.Forms.SplitContainer();
            this.btn_add_active_finished = new System.Windows.Forms.Button();
            this.btn_add_active_pending = new System.Windows.Forms.Button();
            this.tree_view_active = new System.Windows.Forms.TreeView();
            this.lbl_main_ordertype = new System.Windows.Forms.Label();
            this.drpd_main_ordertype = new System.Windows.Forms.ComboBox();
            this.lbl_sub_ordertype = new System.Windows.Forms.Label();
            this.drpd_sub_ordertype = new System.Windows.Forms.ComboBox();
            this.btn_choose_folder = new System.Windows.Forms.Button();
            this.lbl_folder = new System.Windows.Forms.Label();
            this.txt_folder_target = new System.Windows.Forms.TextBox();
            this.checked_list_files = new System.Windows.Forms.CheckedListBox();
            this.lbl_count = new System.Windows.Forms.Label();
            this.txt_count = new System.Windows.Forms.TextBox();
            this.lbl_comment = new System.Windows.Forms.Label();
            this.txt_comment = new System.Windows.Forms.TextBox();
            this.tab_control = new System.Windows.Forms.TabControl();
            this.tab_page_active = new System.Windows.Forms.TabPage();
            this.tab_page_pending = new System.Windows.Forms.TabPage();
            this.btn_add_pending_finished = new System.Windows.Forms.Button();
            this.tree_view_pending = new System.Windows.Forms.TreeView();
            this.tab_page_finished = new System.Windows.Forms.TabPage();
            this.btn_add_finished_pending = new System.Windows.Forms.Button();
            this.btn_add_finished_active = new System.Windows.Forms.Button();
            this.tree_view_finished = new System.Windows.Forms.TreeView();
            this.tab_page_customize = new System.Windows.Forms.TabPage();
            this.btn_accept_source = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_drag_drop = new System.Windows.Forms.TextBox();
            this.btn_delete_sub_ordertype = new System.Windows.Forms.Button();
            this.btn_delete_main_ordertype = new System.Windows.Forms.Button();
            this.txt_sub_ordertype = new System.Windows.Forms.TextBox();
            this.btn_add_sub_ordertype = new System.Windows.Forms.Button();
            this.listbox_sub_ordertype = new System.Windows.Forms.ListBox();
            this.txt_main_ordertype = new System.Windows.Forms.TextBox();
            this.btn_add_main_ordertype = new System.Windows.Forms.Button();
            this.listbox_main_ordertype = new System.Windows.Forms.ListBox();
            this.tree_view_hierarchy = new System.Windows.Forms.TreeView();
            this.lbl_source = new System.Windows.Forms.Label();
            this.btn_choose_source = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.menu_strip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceSaveObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearStatusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status_strip = new System.Windows.Forms.StatusStrip();
            this.label_status_strip_main = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_add_pending_active = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.split_container_edit)).BeginInit();
            this.split_container_edit.Panel1.SuspendLayout();
            this.split_container_edit.Panel2.SuspendLayout();
            this.split_container_edit.SuspendLayout();
            this.tab_control.SuspendLayout();
            this.tab_page_active.SuspendLayout();
            this.tab_page_pending.SuspendLayout();
            this.tab_page_finished.SuspendLayout();
            this.tab_page_customize.SuspendLayout();
            this.menu_strip.SuspendLayout();
            this.status_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(190, 385);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(92, 37);
            this.btn_add.TabIndex = 34;
            this.btn_add.Text = "Hozzáadás";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_order_Click);
            // 
            // split_container_edit
            // 
            this.split_container_edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_container_edit.Location = new System.Drawing.Point(3, 3);
            this.split_container_edit.Name = "split_container_edit";
            // 
            // split_container_edit.Panel1
            // 
            this.split_container_edit.Panel1.AutoScroll = true;
            this.split_container_edit.Panel1.Controls.Add(this.btn_add_active_finished);
            this.split_container_edit.Panel1.Controls.Add(this.btn_add_active_pending);
            this.split_container_edit.Panel1.Controls.Add(this.tree_view_active);
            // 
            // split_container_edit.Panel2
            // 
            this.split_container_edit.Panel2.Controls.Add(this.lbl_main_ordertype);
            this.split_container_edit.Panel2.Controls.Add(this.drpd_main_ordertype);
            this.split_container_edit.Panel2.Controls.Add(this.lbl_sub_ordertype);
            this.split_container_edit.Panel2.Controls.Add(this.drpd_sub_ordertype);
            this.split_container_edit.Panel2.Controls.Add(this.btn_choose_folder);
            this.split_container_edit.Panel2.Controls.Add(this.lbl_folder);
            this.split_container_edit.Panel2.Controls.Add(this.txt_folder_target);
            this.split_container_edit.Panel2.Controls.Add(this.checked_list_files);
            this.split_container_edit.Panel2.Controls.Add(this.lbl_count);
            this.split_container_edit.Panel2.Controls.Add(this.txt_count);
            this.split_container_edit.Panel2.Controls.Add(this.lbl_comment);
            this.split_container_edit.Panel2.Controls.Add(this.txt_comment);
            this.split_container_edit.Panel2.Controls.Add(this.btn_add);
            this.split_container_edit.Size = new System.Drawing.Size(787, 471);
            this.split_container_edit.SplitterDistance = 486;
            this.split_container_edit.TabIndex = 5;
            // 
            // btn_add_active_finished
            // 
            this.btn_add_active_finished.Location = new System.Drawing.Point(115, 375);
            this.btn_add_active_finished.Name = "btn_add_active_finished";
            this.btn_add_active_finished.Size = new System.Drawing.Size(92, 37);
            this.btn_add_active_finished.TabIndex = 7;
            this.btn_add_active_finished.Text = "Add to Finished";
            this.btn_add_active_finished.UseVisualStyleBackColor = true;
            this.btn_add_active_finished.Click += new System.EventHandler(this.btn_add_active_finished_Click);
            // 
            // btn_add_active_pending
            // 
            this.btn_add_active_pending.Location = new System.Drawing.Point(17, 375);
            this.btn_add_active_pending.Name = "btn_add_active_pending";
            this.btn_add_active_pending.Size = new System.Drawing.Size(92, 37);
            this.btn_add_active_pending.TabIndex = 6;
            this.btn_add_active_pending.Text = "Add to Pending";
            this.btn_add_active_pending.UseVisualStyleBackColor = true;
            this.btn_add_active_pending.Click += new System.EventHandler(this.btn_add_active_pending_Click);
            // 
            // tree_view_active
            // 
            this.tree_view_active.CheckBoxes = true;
            this.tree_view_active.HideSelection = false;
            this.tree_view_active.Location = new System.Drawing.Point(17, 21);
            this.tree_view_active.Name = "tree_view_active";
            this.tree_view_active.Size = new System.Drawing.Size(345, 348);
            this.tree_view_active.TabIndex = 5;
            this.tree_view_active.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_view_active_AfterCheck);
            this.tree_view_active.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tree_view_orders_ItemDrag);
            this.tree_view_active.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_view_active_NodeMouseClick);
            // 
            // lbl_main_ordertype
            // 
            this.lbl_main_ordertype.AutoSize = true;
            this.lbl_main_ordertype.Location = new System.Drawing.Point(9, 12);
            this.lbl_main_ordertype.Name = "lbl_main_ordertype";
            this.lbl_main_ordertype.Size = new System.Drawing.Size(38, 13);
            this.lbl_main_ordertype.TabIndex = 14;
            this.lbl_main_ordertype.Text = "Típus:";
            // 
            // drpd_main_ordertype
            // 
            this.drpd_main_ordertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpd_main_ordertype.FormattingEnabled = true;
            this.drpd_main_ordertype.Location = new System.Drawing.Point(81, 9);
            this.drpd_main_ordertype.Name = "drpd_main_ordertype";
            this.drpd_main_ordertype.Size = new System.Drawing.Size(121, 21);
            this.drpd_main_ordertype.TabIndex = 20;
            // 
            // lbl_sub_ordertype
            // 
            this.lbl_sub_ordertype.AutoSize = true;
            this.lbl_sub_ordertype.Location = new System.Drawing.Point(9, 39);
            this.lbl_sub_ordertype.Name = "lbl_sub_ordertype";
            this.lbl_sub_ordertype.Size = new System.Drawing.Size(43, 13);
            this.lbl_sub_ordertype.TabIndex = 12;
            this.lbl_sub_ordertype.Text = "Altípus:";
            // 
            // drpd_sub_ordertype
            // 
            this.drpd_sub_ordertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpd_sub_ordertype.FormattingEnabled = true;
            this.drpd_sub_ordertype.Location = new System.Drawing.Point(81, 36);
            this.drpd_sub_ordertype.Name = "drpd_sub_ordertype";
            this.drpd_sub_ordertype.Size = new System.Drawing.Size(121, 21);
            this.drpd_sub_ordertype.TabIndex = 22;
            // 
            // btn_choose_folder
            // 
            this.btn_choose_folder.Location = new System.Drawing.Point(81, 63);
            this.btn_choose_folder.Name = "btn_choose_folder";
            this.btn_choose_folder.Size = new System.Drawing.Size(121, 23);
            this.btn_choose_folder.TabIndex = 24;
            this.btn_choose_folder.Text = "Válassz Mappát";
            this.btn_choose_folder.UseVisualStyleBackColor = true;
            this.btn_choose_folder.Click += new System.EventHandler(this.btn_choose_folder_Click);
            // 
            // lbl_folder
            // 
            this.lbl_folder.AutoSize = true;
            this.lbl_folder.Location = new System.Drawing.Point(9, 95);
            this.lbl_folder.Name = "lbl_folder";
            this.lbl_folder.Size = new System.Drawing.Size(43, 13);
            this.lbl_folder.TabIndex = 10;
            this.lbl_folder.Text = "Mappa:";
            // 
            // txt_folder_target
            // 
            this.txt_folder_target.AllowDrop = true;
            this.txt_folder_target.Location = new System.Drawing.Point(81, 92);
            this.txt_folder_target.Name = "txt_folder_target";
            this.txt_folder_target.Size = new System.Drawing.Size(201, 20);
            this.txt_folder_target.TabIndex = 26;
            this.txt_folder_target.TextChanged += new System.EventHandler(this.txt_folder_target_TextChanged);
            this.txt_folder_target.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_folder_target_DragDrop);
            this.txt_folder_target.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_folder_target_DragEnter);
            // 
            // checked_list_files
            // 
            this.checked_list_files.FormattingEnabled = true;
            this.checked_list_files.Items.AddRange(new object[] {
            "empty"});
            this.checked_list_files.Location = new System.Drawing.Point(81, 118);
            this.checked_list_files.Name = "checked_list_files";
            this.checked_list_files.Size = new System.Drawing.Size(201, 199);
            this.checked_list_files.TabIndex = 28;
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(9, 326);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(63, 13);
            this.lbl_count.TabIndex = 6;
            this.lbl_count.Text = "Darabszám:";
            // 
            // txt_count
            // 
            this.txt_count.Location = new System.Drawing.Point(81, 323);
            this.txt_count.Name = "txt_count";
            this.txt_count.Size = new System.Drawing.Size(105, 20);
            this.txt_count.TabIndex = 30;
            // 
            // lbl_comment
            // 
            this.lbl_comment.AutoSize = true;
            this.lbl_comment.Location = new System.Drawing.Point(9, 352);
            this.lbl_comment.Name = "lbl_comment";
            this.lbl_comment.Size = new System.Drawing.Size(66, 13);
            this.lbl_comment.TabIndex = 4;
            this.lbl_comment.Text = "Megjegyzés:";
            // 
            // txt_comment
            // 
            this.txt_comment.Location = new System.Drawing.Point(81, 349);
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(201, 20);
            this.txt_comment.TabIndex = 32;
            // 
            // tab_control
            // 
            this.tab_control.Controls.Add(this.tab_page_active);
            this.tab_control.Controls.Add(this.tab_page_pending);
            this.tab_control.Controls.Add(this.tab_page_finished);
            this.tab_control.Controls.Add(this.tab_page_customize);
            this.tab_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_control.Location = new System.Drawing.Point(0, 24);
            this.tab_control.Name = "tab_control";
            this.tab_control.SelectedIndex = 0;
            this.tab_control.Size = new System.Drawing.Size(801, 503);
            this.tab_control.TabIndex = 6;
            // 
            // tab_page_active
            // 
            this.tab_page_active.Controls.Add(this.split_container_edit);
            this.tab_page_active.Location = new System.Drawing.Point(4, 22);
            this.tab_page_active.Name = "tab_page_active";
            this.tab_page_active.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_active.Size = new System.Drawing.Size(793, 477);
            this.tab_page_active.TabIndex = 0;
            this.tab_page_active.Text = "Aktív";
            this.tab_page_active.UseVisualStyleBackColor = true;
            // 
            // tab_page_pending
            // 
            this.tab_page_pending.Controls.Add(this.btn_add_pending_active);
            this.tab_page_pending.Controls.Add(this.btn_add_pending_finished);
            this.tab_page_pending.Controls.Add(this.tree_view_pending);
            this.tab_page_pending.Location = new System.Drawing.Point(4, 22);
            this.tab_page_pending.Name = "tab_page_pending";
            this.tab_page_pending.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_pending.Size = new System.Drawing.Size(793, 477);
            this.tab_page_pending.TabIndex = 1;
            this.tab_page_pending.Text = "Függőben";
            this.tab_page_pending.UseVisualStyleBackColor = true;
            // 
            // btn_add_pending_finished
            // 
            this.btn_add_pending_finished.Location = new System.Drawing.Point(116, 379);
            this.btn_add_pending_finished.Name = "btn_add_pending_finished";
            this.btn_add_pending_finished.Size = new System.Drawing.Size(92, 37);
            this.btn_add_pending_finished.TabIndex = 7;
            this.btn_add_pending_finished.Text = "Add to Finished";
            this.btn_add_pending_finished.UseVisualStyleBackColor = true;
            this.btn_add_pending_finished.Click += new System.EventHandler(this.btn_add_pending_finished_Click);
            // 
            // tree_view_pending
            // 
            this.tree_view_pending.CheckBoxes = true;
            this.tree_view_pending.Location = new System.Drawing.Point(18, 25);
            this.tree_view_pending.Name = "tree_view_pending";
            this.tree_view_pending.Size = new System.Drawing.Size(345, 348);
            this.tree_view_pending.TabIndex = 6;
            this.tree_view_pending.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_view_pending_AfterCheck);
            this.tree_view_pending.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_view_pending_NodeMouseClick);
            // 
            // tab_page_finished
            // 
            this.tab_page_finished.Controls.Add(this.btn_add_finished_pending);
            this.tab_page_finished.Controls.Add(this.btn_add_finished_active);
            this.tab_page_finished.Controls.Add(this.tree_view_finished);
            this.tab_page_finished.Location = new System.Drawing.Point(4, 22);
            this.tab_page_finished.Name = "tab_page_finished";
            this.tab_page_finished.Size = new System.Drawing.Size(793, 477);
            this.tab_page_finished.TabIndex = 3;
            this.tab_page_finished.Text = "Kész";
            this.tab_page_finished.UseVisualStyleBackColor = true;
            // 
            // btn_add_finished_pending
            // 
            this.btn_add_finished_pending.Location = new System.Drawing.Point(116, 374);
            this.btn_add_finished_pending.Name = "btn_add_finished_pending";
            this.btn_add_finished_pending.Size = new System.Drawing.Size(92, 37);
            this.btn_add_finished_pending.TabIndex = 10;
            this.btn_add_finished_pending.Text = "Add to Pending";
            this.btn_add_finished_pending.UseVisualStyleBackColor = true;
            this.btn_add_finished_pending.Click += new System.EventHandler(this.btn_add_finished_pending_Click);
            // 
            // btn_add_finished_active
            // 
            this.btn_add_finished_active.Location = new System.Drawing.Point(18, 374);
            this.btn_add_finished_active.Name = "btn_add_finished_active";
            this.btn_add_finished_active.Size = new System.Drawing.Size(92, 37);
            this.btn_add_finished_active.TabIndex = 9;
            this.btn_add_finished_active.Text = "Add to Active";
            this.btn_add_finished_active.UseVisualStyleBackColor = true;
            this.btn_add_finished_active.Click += new System.EventHandler(this.btn_add_finished_active_Click);
            // 
            // tree_view_finished
            // 
            this.tree_view_finished.CheckBoxes = true;
            this.tree_view_finished.HideSelection = false;
            this.tree_view_finished.Location = new System.Drawing.Point(18, 20);
            this.tree_view_finished.Name = "tree_view_finished";
            this.tree_view_finished.Size = new System.Drawing.Size(345, 348);
            this.tree_view_finished.TabIndex = 8;
            this.tree_view_finished.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_view_finished_AfterCheck);
            this.tree_view_finished.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_view_finished_NodeMouseClick);
            // 
            // tab_page_customize
            // 
            this.tab_page_customize.Controls.Add(this.btn_accept_source);
            this.tab_page_customize.Controls.Add(this.button3);
            this.tab_page_customize.Controls.Add(this.button2);
            this.tab_page_customize.Controls.Add(this.button1);
            this.tab_page_customize.Controls.Add(this.txt_drag_drop);
            this.tab_page_customize.Controls.Add(this.btn_delete_sub_ordertype);
            this.tab_page_customize.Controls.Add(this.btn_delete_main_ordertype);
            this.tab_page_customize.Controls.Add(this.txt_sub_ordertype);
            this.tab_page_customize.Controls.Add(this.btn_add_sub_ordertype);
            this.tab_page_customize.Controls.Add(this.listbox_sub_ordertype);
            this.tab_page_customize.Controls.Add(this.txt_main_ordertype);
            this.tab_page_customize.Controls.Add(this.btn_add_main_ordertype);
            this.tab_page_customize.Controls.Add(this.listbox_main_ordertype);
            this.tab_page_customize.Controls.Add(this.tree_view_hierarchy);
            this.tab_page_customize.Controls.Add(this.lbl_source);
            this.tab_page_customize.Controls.Add(this.btn_choose_source);
            this.tab_page_customize.Controls.Add(this.label2);
            this.tab_page_customize.Location = new System.Drawing.Point(4, 22);
            this.tab_page_customize.Name = "tab_page_customize";
            this.tab_page_customize.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_customize.Size = new System.Drawing.Size(793, 477);
            this.tab_page_customize.TabIndex = 2;
            this.tab_page_customize.Text = "Testreszabás";
            this.tab_page_customize.UseVisualStyleBackColor = true;
            // 
            // btn_accept_source
            // 
            this.btn_accept_source.Location = new System.Drawing.Point(17, 354);
            this.btn_accept_source.Name = "btn_accept_source";
            this.btn_accept_source.Size = new System.Drawing.Size(226, 23);
            this.btn_accept_source.TabIndex = 21;
            this.btn_accept_source.Text = "Accept Source Folder";
            this.btn_accept_source.UseVisualStyleBackColor = true;
            this.btn_accept_source.Click += new System.EventHandler(this.button_accept_source_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(589, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(589, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_drag_drop
            // 
            this.txt_drag_drop.AllowDrop = true;
            this.txt_drag_drop.Location = new System.Drawing.Point(544, 17);
            this.txt_drag_drop.Name = "txt_drag_drop";
            this.txt_drag_drop.Size = new System.Drawing.Size(226, 20);
            this.txt_drag_drop.TabIndex = 17;
            this.txt_drag_drop.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_drag_drop_DragDrop);
            this.txt_drag_drop.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_drag_drop_DragEnter);
            // 
            // btn_delete_sub_ordertype
            // 
            this.btn_delete_sub_ordertype.Location = new System.Drawing.Point(403, 217);
            this.btn_delete_sub_ordertype.Name = "btn_delete_sub_ordertype";
            this.btn_delete_sub_ordertype.Size = new System.Drawing.Size(120, 23);
            this.btn_delete_sub_ordertype.TabIndex = 16;
            this.btn_delete_sub_ordertype.Text = "Altípus Törlése";
            this.btn_delete_sub_ordertype.UseVisualStyleBackColor = true;
            this.btn_delete_sub_ordertype.Click += new System.EventHandler(this.btn_delete_sub_ordertype_Click);
            // 
            // btn_delete_main_ordertype
            // 
            this.btn_delete_main_ordertype.Location = new System.Drawing.Point(261, 217);
            this.btn_delete_main_ordertype.Name = "btn_delete_main_ordertype";
            this.btn_delete_main_ordertype.Size = new System.Drawing.Size(120, 23);
            this.btn_delete_main_ordertype.TabIndex = 15;
            this.btn_delete_main_ordertype.Text = "Típus Törlése";
            this.btn_delete_main_ordertype.UseVisualStyleBackColor = true;
            this.btn_delete_main_ordertype.Click += new System.EventHandler(this.btn_delete_main_ordertype_Click);
            // 
            // txt_sub_ordertype
            // 
            this.txt_sub_ordertype.Location = new System.Drawing.Point(403, 17);
            this.txt_sub_ordertype.Name = "txt_sub_ordertype";
            this.txt_sub_ordertype.Size = new System.Drawing.Size(120, 20);
            this.txt_sub_ordertype.TabIndex = 14;
            // 
            // btn_add_sub_ordertype
            // 
            this.btn_add_sub_ordertype.Location = new System.Drawing.Point(403, 45);
            this.btn_add_sub_ordertype.Name = "btn_add_sub_ordertype";
            this.btn_add_sub_ordertype.Size = new System.Drawing.Size(120, 23);
            this.btn_add_sub_ordertype.TabIndex = 13;
            this.btn_add_sub_ordertype.Text = "Altípus Hozzáadása";
            this.btn_add_sub_ordertype.UseVisualStyleBackColor = true;
            this.btn_add_sub_ordertype.Click += new System.EventHandler(this.btn_add_sub_ordertype_Click);
            // 
            // listbox_sub_ordertype
            // 
            this.listbox_sub_ordertype.FormattingEnabled = true;
            this.listbox_sub_ordertype.Location = new System.Drawing.Point(403, 77);
            this.listbox_sub_ordertype.Name = "listbox_sub_ordertype";
            this.listbox_sub_ordertype.Size = new System.Drawing.Size(120, 134);
            this.listbox_sub_ordertype.TabIndex = 12;
            // 
            // txt_main_ordertype
            // 
            this.txt_main_ordertype.Location = new System.Drawing.Point(261, 17);
            this.txt_main_ordertype.Name = "txt_main_ordertype";
            this.txt_main_ordertype.Size = new System.Drawing.Size(120, 20);
            this.txt_main_ordertype.TabIndex = 11;
            // 
            // btn_add_main_ordertype
            // 
            this.btn_add_main_ordertype.Location = new System.Drawing.Point(261, 45);
            this.btn_add_main_ordertype.Name = "btn_add_main_ordertype";
            this.btn_add_main_ordertype.Size = new System.Drawing.Size(120, 23);
            this.btn_add_main_ordertype.TabIndex = 10;
            this.btn_add_main_ordertype.Text = "Típus Hozzáadása";
            this.btn_add_main_ordertype.UseVisualStyleBackColor = true;
            this.btn_add_main_ordertype.Click += new System.EventHandler(this.btn_add_main_ordertype_Click);
            // 
            // listbox_main_ordertype
            // 
            this.listbox_main_ordertype.FormattingEnabled = true;
            this.listbox_main_ordertype.Location = new System.Drawing.Point(261, 77);
            this.listbox_main_ordertype.Name = "listbox_main_ordertype";
            this.listbox_main_ordertype.Size = new System.Drawing.Size(120, 134);
            this.listbox_main_ordertype.TabIndex = 9;
            // 
            // tree_view_hierarchy
            // 
            this.tree_view_hierarchy.Location = new System.Drawing.Point(17, 77);
            this.tree_view_hierarchy.Name = "tree_view_hierarchy";
            this.tree_view_hierarchy.Size = new System.Drawing.Size(226, 271);
            this.tree_view_hierarchy.TabIndex = 8;
            this.tree_view_hierarchy.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tree_view_hierarchy_ItemDrag);
            // 
            // lbl_source
            // 
            this.lbl_source.AutoSize = true;
            this.lbl_source.Location = new System.Drawing.Point(64, 50);
            this.lbl_source.Name = "lbl_source";
            this.lbl_source.Size = new System.Drawing.Size(10, 13);
            this.lbl_source.TabIndex = 7;
            this.lbl_source.Text = "-";
            // 
            // btn_choose_source
            // 
            this.btn_choose_source.Location = new System.Drawing.Point(17, 15);
            this.btn_choose_source.Name = "btn_choose_source";
            this.btn_choose_source.Size = new System.Drawing.Size(226, 23);
            this.btn_choose_source.TabIndex = 5;
            this.btn_choose_source.Text = "Choose Source Folder";
            this.btn_choose_source.UseVisualStyleBackColor = true;
            this.btn_choose_source.Click += new System.EventHandler(this.Btn_ChooseSourceFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current:";
            // 
            // menu_strip
            // 
            this.menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu_strip.Location = new System.Drawing.Point(0, 0);
            this.menu_strip.Name = "menu_strip";
            this.menu_strip.Size = new System.Drawing.Size(801, 24);
            this.menu_strip.TabIndex = 7;
            this.menu_strip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forceSaveObjectsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // forceSaveObjectsToolStripMenuItem
            // 
            this.forceSaveObjectsToolStripMenuItem.Name = "forceSaveObjectsToolStripMenuItem";
            this.forceSaveObjectsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.forceSaveObjectsToolStripMenuItem.Text = "Force Save Objects";
            this.forceSaveObjectsToolStripMenuItem.Click += new System.EventHandler(this.forceSaveObjectsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLogToolStripMenuItem,
            this.deleteLockToolStripMenuItem,
            this.clearStatusBarToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.helpToolStripMenuItem.Text = "Help?";
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveLogToolStripMenuItem.Text = "Save Log";
            this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
            // 
            // deleteLockToolStripMenuItem
            // 
            this.deleteLockToolStripMenuItem.Name = "deleteLockToolStripMenuItem";
            this.deleteLockToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.deleteLockToolStripMenuItem.Text = "Delete Lock";
            this.deleteLockToolStripMenuItem.Click += new System.EventHandler(this.deleteLockToolStripMenuItem_Click_1);
            // 
            // clearStatusBarToolStripMenuItem
            // 
            this.clearStatusBarToolStripMenuItem.Name = "clearStatusBarToolStripMenuItem";
            this.clearStatusBarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.clearStatusBarToolStripMenuItem.Text = "Clear StatusBar";
            this.clearStatusBarToolStripMenuItem.Click += new System.EventHandler(this.clearStatusBarToolStripMenuItem_Click);
            // 
            // status_strip
            // 
            this.status_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_status_strip_main});
            this.status_strip.Location = new System.Drawing.Point(0, 527);
            this.status_strip.Name = "status_strip";
            this.status_strip.Size = new System.Drawing.Size(801, 22);
            this.status_strip.TabIndex = 8;
            this.status_strip.Text = "statusStrip1";
            // 
            // label_status_strip_main
            // 
            this.label_status_strip_main.Name = "label_status_strip_main";
            this.label_status_strip_main.Size = new System.Drawing.Size(16, 17);
            this.label_status_strip_main.Text = "...";
            // 
            // btn_add_pending_active
            // 
            this.btn_add_pending_active.Location = new System.Drawing.Point(18, 379);
            this.btn_add_pending_active.Name = "btn_add_pending_active";
            this.btn_add_pending_active.Size = new System.Drawing.Size(92, 37);
            this.btn_add_pending_active.TabIndex = 8;
            this.btn_add_pending_active.Text = "Add to Active";
            this.btn_add_pending_active.UseVisualStyleBackColor = true;
            this.btn_add_pending_active.Click += new System.EventHandler(this.btn_add_pending_active_Click);
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 549);
            this.Controls.Add(this.tab_control);
            this.Controls.Add(this.menu_strip);
            this.Controls.Add(this.status_strip);
            this.MainMenuStrip = this.menu_strip;
            this.Name = "form_main";
            this.Text = "PontJo";
            this.Activated += new System.EventHandler(this.form_main_Activated);
            this.Deactivate += new System.EventHandler(this.form_main_DeActivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_main_FormClosing);
            this.Load += new System.EventHandler(this.form_main_Load);
            this.split_container_edit.Panel1.ResumeLayout(false);
            this.split_container_edit.Panel2.ResumeLayout(false);
            this.split_container_edit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_container_edit)).EndInit();
            this.split_container_edit.ResumeLayout(false);
            this.tab_control.ResumeLayout(false);
            this.tab_page_active.ResumeLayout(false);
            this.tab_page_pending.ResumeLayout(false);
            this.tab_page_finished.ResumeLayout(false);
            this.tab_page_customize.ResumeLayout(false);
            this.tab_page_customize.PerformLayout();
            this.menu_strip.ResumeLayout(false);
            this.menu_strip.PerformLayout();
            this.status_strip.ResumeLayout(false);
            this.status_strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.SplitContainer split_container_edit;
        private System.Windows.Forms.TabControl tab_control;
        private System.Windows.Forms.TabPage tab_page_active;
        private System.Windows.Forms.TabPage tab_page_pending;
        private System.Windows.Forms.MenuStrip menu_strip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label lbl_comment;
        private System.Windows.Forms.TextBox txt_comment;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.TextBox txt_count;
        private System.Windows.Forms.Button btn_choose_folder;
        private System.Windows.Forms.Label lbl_folder;
        private System.Windows.Forms.TextBox txt_folder_target;
        private System.Windows.Forms.ComboBox drpd_main_ordertype;
        private System.Windows.Forms.CheckedListBox checked_list_files;
        private System.Windows.Forms.Label lbl_sub_ordertype;
        private System.Windows.Forms.TabPage tab_page_customize;
        private System.Windows.Forms.Label lbl_source;
        private System.Windows.Forms.Button btn_choose_source;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.TextBox txt_drag_drop;
        private System.Windows.Forms.StatusStrip status_strip;
        private System.Windows.Forms.ToolStripStatusLabel label_status_strip_main;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceSaveObjectsToolStripMenuItem;
        private System.Windows.Forms.TabPage tab_page_finished;
        private System.Windows.Forms.Button btn_accept_source;
        private System.Windows.Forms.ToolStripMenuItem clearStatusBarToolStripMenuItem;
        private System.Windows.Forms.Button btn_add_active_finished;
        private System.Windows.Forms.Button btn_add_finished_pending;
        private System.Windows.Forms.Button btn_add_finished_active;
        private System.Windows.Forms.TreeView tree_view_finished;
        private System.Windows.Forms.Button btn_add_pending_active;
    }
}

