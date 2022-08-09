namespace FolderManipulator
{
    partial class form_edit_order
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
            this.panel_add_order = new System.Windows.Forms.Panel();
            this.table_layout_add_order = new System.Windows.Forms.TableLayoutPanel();
            this.panel_add_order_top = new System.Windows.Forms.Panel();
            this.lbl_new_sub_ordertype = new System.Windows.Forms.Label();
            this.drpd_new_sub_ordertype = new System.Windows.Forms.ComboBox();
            this.lbl_new_main_ordertype = new System.Windows.Forms.Label();
            this.drpd_new_main_ordertype = new System.Windows.Forms.ComboBox();
            this.lbl_main_ordertype = new System.Windows.Forms.Label();
            this.drpd_main_ordertype = new System.Windows.Forms.ComboBox();
            this.lbl_sub_ordertype = new System.Windows.Forms.Label();
            this.drpd_sub_ordertype = new System.Windows.Forms.ComboBox();
            this.lbl_folder = new System.Windows.Forms.Label();
            this.txt_folder = new System.Windows.Forms.TextBox();
            this.panel_add_order_bottom = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_id = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.lbl_finished_date = new System.Windows.Forms.Label();
            this.txt_finished_date = new System.Windows.Forms.TextBox();
            this.lbl_birth_date = new System.Windows.Forms.Label();
            this.txt_birth_date = new System.Windows.Forms.TextBox();
            this.lbl_new_comment = new System.Windows.Forms.Label();
            this.txt_new_comment = new System.Windows.Forms.TextBox();
            this.lbl_new_count = new System.Windows.Forms.Label();
            this.txt_new_count = new System.Windows.Forms.TextBox();
            this.lbl_count = new System.Windows.Forms.Label();
            this.txt_count = new System.Windows.Forms.TextBox();
            this.lbl_comment = new System.Windows.Forms.Label();
            this.txt_comment = new System.Windows.Forms.TextBox();
            this.btn_edit = new System.Windows.Forms.Button();
            this.lbl_edit_order_title = new System.Windows.Forms.Label();
            this.panel_add_order.SuspendLayout();
            this.table_layout_add_order.SuspendLayout();
            this.panel_add_order_top.SuspendLayout();
            this.panel_add_order_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_add_order
            // 
            this.panel_add_order.Controls.Add(this.table_layout_add_order);
            this.panel_add_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_add_order.Location = new System.Drawing.Point(0, 0);
            this.panel_add_order.Name = "panel_add_order";
            this.panel_add_order.Size = new System.Drawing.Size(427, 441);
            this.panel_add_order.TabIndex = 36;
            // 
            // table_layout_add_order
            // 
            this.table_layout_add_order.ColumnCount = 1;
            this.table_layout_add_order.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_add_order.Controls.Add(this.panel_add_order_top, 0, 1);
            this.table_layout_add_order.Controls.Add(this.panel_add_order_bottom, 0, 2);
            this.table_layout_add_order.Controls.Add(this.lbl_edit_order_title, 0, 0);
            this.table_layout_add_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_add_order.Location = new System.Drawing.Point(0, 0);
            this.table_layout_add_order.Name = "table_layout_add_order";
            this.table_layout_add_order.RowCount = 3;
            this.table_layout_add_order.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.table_layout_add_order.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.table_layout_add_order.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_add_order.Size = new System.Drawing.Size(427, 441);
            this.table_layout_add_order.TabIndex = 35;
            // 
            // panel_add_order_top
            // 
            this.panel_add_order_top.Controls.Add(this.lbl_new_sub_ordertype);
            this.panel_add_order_top.Controls.Add(this.drpd_new_sub_ordertype);
            this.panel_add_order_top.Controls.Add(this.lbl_new_main_ordertype);
            this.panel_add_order_top.Controls.Add(this.drpd_new_main_ordertype);
            this.panel_add_order_top.Controls.Add(this.lbl_main_ordertype);
            this.panel_add_order_top.Controls.Add(this.drpd_main_ordertype);
            this.panel_add_order_top.Controls.Add(this.lbl_sub_ordertype);
            this.panel_add_order_top.Controls.Add(this.drpd_sub_ordertype);
            this.panel_add_order_top.Controls.Add(this.lbl_folder);
            this.panel_add_order_top.Controls.Add(this.txt_folder);
            this.panel_add_order_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_add_order_top.Location = new System.Drawing.Point(3, 33);
            this.panel_add_order_top.Name = "panel_add_order_top";
            this.panel_add_order_top.Size = new System.Drawing.Size(421, 137);
            this.panel_add_order_top.TabIndex = 0;
            // 
            // lbl_new_sub_ordertype
            // 
            this.lbl_new_sub_ordertype.AutoSize = true;
            this.lbl_new_sub_ordertype.Location = new System.Drawing.Point(13, 87);
            this.lbl_new_sub_ordertype.Name = "lbl_new_sub_ordertype";
            this.lbl_new_sub_ordertype.Size = new System.Drawing.Size(56, 13);
            this.lbl_new_sub_ordertype.TabIndex = 30;
            this.lbl_new_sub_ordertype.Text = "Új Altípus:";
            // 
            // drpd_new_sub_ordertype
            // 
            this.drpd_new_sub_ordertype.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drpd_new_sub_ordertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpd_new_sub_ordertype.FormattingEnabled = true;
            this.drpd_new_sub_ordertype.Location = new System.Drawing.Point(98, 84);
            this.drpd_new_sub_ordertype.Name = "drpd_new_sub_ordertype";
            this.drpd_new_sub_ordertype.Size = new System.Drawing.Size(177, 21);
            this.drpd_new_sub_ordertype.TabIndex = 31;
            // 
            // lbl_new_main_ordertype
            // 
            this.lbl_new_main_ordertype.AutoSize = true;
            this.lbl_new_main_ordertype.Location = new System.Drawing.Point(13, 33);
            this.lbl_new_main_ordertype.Name = "lbl_new_main_ordertype";
            this.lbl_new_main_ordertype.Size = new System.Drawing.Size(51, 13);
            this.lbl_new_main_ordertype.TabIndex = 28;
            this.lbl_new_main_ordertype.Text = "Új Típus:";
            // 
            // drpd_new_main_ordertype
            // 
            this.drpd_new_main_ordertype.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drpd_new_main_ordertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpd_new_main_ordertype.FormattingEnabled = true;
            this.drpd_new_main_ordertype.Location = new System.Drawing.Point(98, 30);
            this.drpd_new_main_ordertype.Name = "drpd_new_main_ordertype";
            this.drpd_new_main_ordertype.Size = new System.Drawing.Size(177, 21);
            this.drpd_new_main_ordertype.TabIndex = 29;
            // 
            // lbl_main_ordertype
            // 
            this.lbl_main_ordertype.AutoSize = true;
            this.lbl_main_ordertype.Location = new System.Drawing.Point(13, 6);
            this.lbl_main_ordertype.Name = "lbl_main_ordertype";
            this.lbl_main_ordertype.Size = new System.Drawing.Size(38, 13);
            this.lbl_main_ordertype.TabIndex = 14;
            this.lbl_main_ordertype.Text = "Típus:";
            // 
            // drpd_main_ordertype
            // 
            this.drpd_main_ordertype.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drpd_main_ordertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpd_main_ordertype.Enabled = false;
            this.drpd_main_ordertype.FormattingEnabled = true;
            this.drpd_main_ordertype.Location = new System.Drawing.Point(98, 3);
            this.drpd_main_ordertype.Name = "drpd_main_ordertype";
            this.drpd_main_ordertype.Size = new System.Drawing.Size(177, 21);
            this.drpd_main_ordertype.TabIndex = 20;
            // 
            // lbl_sub_ordertype
            // 
            this.lbl_sub_ordertype.AutoSize = true;
            this.lbl_sub_ordertype.Location = new System.Drawing.Point(13, 60);
            this.lbl_sub_ordertype.Name = "lbl_sub_ordertype";
            this.lbl_sub_ordertype.Size = new System.Drawing.Size(43, 13);
            this.lbl_sub_ordertype.TabIndex = 12;
            this.lbl_sub_ordertype.Text = "Altípus:";
            // 
            // drpd_sub_ordertype
            // 
            this.drpd_sub_ordertype.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drpd_sub_ordertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpd_sub_ordertype.Enabled = false;
            this.drpd_sub_ordertype.FormattingEnabled = true;
            this.drpd_sub_ordertype.Location = new System.Drawing.Point(98, 57);
            this.drpd_sub_ordertype.Name = "drpd_sub_ordertype";
            this.drpd_sub_ordertype.Size = new System.Drawing.Size(177, 21);
            this.drpd_sub_ordertype.TabIndex = 22;
            // 
            // lbl_folder
            // 
            this.lbl_folder.AutoSize = true;
            this.lbl_folder.Location = new System.Drawing.Point(13, 114);
            this.lbl_folder.Name = "lbl_folder";
            this.lbl_folder.Size = new System.Drawing.Size(43, 13);
            this.lbl_folder.TabIndex = 10;
            this.lbl_folder.Text = "Mappa:";
            // 
            // txt_folder
            // 
            this.txt_folder.AllowDrop = true;
            this.txt_folder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_folder.Enabled = false;
            this.txt_folder.Location = new System.Drawing.Point(98, 111);
            this.txt_folder.Name = "txt_folder";
            this.txt_folder.Size = new System.Drawing.Size(314, 20);
            this.txt_folder.TabIndex = 26;
            // 
            // panel_add_order_bottom
            // 
            this.panel_add_order_bottom.Controls.Add(this.btn_cancel);
            this.panel_add_order_bottom.Controls.Add(this.lbl_id);
            this.panel_add_order_bottom.Controls.Add(this.txt_id);
            this.panel_add_order_bottom.Controls.Add(this.lbl_status);
            this.panel_add_order_bottom.Controls.Add(this.txt_status);
            this.panel_add_order_bottom.Controls.Add(this.lbl_finished_date);
            this.panel_add_order_bottom.Controls.Add(this.txt_finished_date);
            this.panel_add_order_bottom.Controls.Add(this.lbl_birth_date);
            this.panel_add_order_bottom.Controls.Add(this.txt_birth_date);
            this.panel_add_order_bottom.Controls.Add(this.lbl_new_comment);
            this.panel_add_order_bottom.Controls.Add(this.txt_new_comment);
            this.panel_add_order_bottom.Controls.Add(this.lbl_new_count);
            this.panel_add_order_bottom.Controls.Add(this.txt_new_count);
            this.panel_add_order_bottom.Controls.Add(this.lbl_count);
            this.panel_add_order_bottom.Controls.Add(this.txt_count);
            this.panel_add_order_bottom.Controls.Add(this.lbl_comment);
            this.panel_add_order_bottom.Controls.Add(this.txt_comment);
            this.panel_add_order_bottom.Controls.Add(this.btn_edit);
            this.panel_add_order_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_add_order_bottom.Location = new System.Drawing.Point(3, 176);
            this.panel_add_order_bottom.Name = "panel_add_order_bottom";
            this.panel_add_order_bottom.Size = new System.Drawing.Size(421, 262);
            this.panel_add_order_bottom.TabIndex = 29;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Location = new System.Drawing.Point(320, 216);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(92, 37);
            this.btn_cancel.TabIndex = 47;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(13, 194);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(21, 13);
            this.lbl_id.TabIndex = 45;
            this.lbl_id.Text = "ID:";
            // 
            // txt_id
            // 
            this.txt_id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_id.Enabled = false;
            this.txt_id.Location = new System.Drawing.Point(98, 191);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(314, 20);
            this.txt_id.TabIndex = 46;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(13, 168);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(45, 13);
            this.lbl_status.TabIndex = 43;
            this.lbl_status.Text = "Státusz:";
            // 
            // txt_status
            // 
            this.txt_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_status.Enabled = false;
            this.txt_status.Location = new System.Drawing.Point(98, 165);
            this.txt_status.Name = "txt_status";
            this.txt_status.Size = new System.Drawing.Size(314, 20);
            this.txt_status.TabIndex = 44;
            // 
            // lbl_finished_date
            // 
            this.lbl_finished_date.AutoSize = true;
            this.lbl_finished_date.Location = new System.Drawing.Point(13, 142);
            this.lbl_finished_date.Name = "lbl_finished_date";
            this.lbl_finished_date.Size = new System.Drawing.Size(47, 13);
            this.lbl_finished_date.TabIndex = 41;
            this.lbl_finished_date.Text = "Lezárás:";
            // 
            // txt_finished_date
            // 
            this.txt_finished_date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_finished_date.Enabled = false;
            this.txt_finished_date.Location = new System.Drawing.Point(98, 139);
            this.txt_finished_date.Name = "txt_finished_date";
            this.txt_finished_date.Size = new System.Drawing.Size(314, 20);
            this.txt_finished_date.TabIndex = 42;
            // 
            // lbl_birth_date
            // 
            this.lbl_birth_date.AutoSize = true;
            this.lbl_birth_date.Location = new System.Drawing.Point(13, 116);
            this.lbl_birth_date.Name = "lbl_birth_date";
            this.lbl_birth_date.Size = new System.Drawing.Size(62, 13);
            this.lbl_birth_date.TabIndex = 39;
            this.lbl_birth_date.Text = "Keletkezés:";
            // 
            // txt_birth_date
            // 
            this.txt_birth_date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_birth_date.Enabled = false;
            this.txt_birth_date.Location = new System.Drawing.Point(98, 113);
            this.txt_birth_date.Name = "txt_birth_date";
            this.txt_birth_date.Size = new System.Drawing.Size(314, 20);
            this.txt_birth_date.TabIndex = 40;
            // 
            // lbl_new_comment
            // 
            this.lbl_new_comment.AutoSize = true;
            this.lbl_new_comment.Location = new System.Drawing.Point(13, 89);
            this.lbl_new_comment.Name = "lbl_new_comment";
            this.lbl_new_comment.Size = new System.Drawing.Size(79, 13);
            this.lbl_new_comment.TabIndex = 37;
            this.lbl_new_comment.Text = "Új Megjegyzés:";
            // 
            // txt_new_comment
            // 
            this.txt_new_comment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_new_comment.Location = new System.Drawing.Point(98, 86);
            this.txt_new_comment.Name = "txt_new_comment";
            this.txt_new_comment.Size = new System.Drawing.Size(314, 20);
            this.txt_new_comment.TabIndex = 38;
            // 
            // lbl_new_count
            // 
            this.lbl_new_count.AutoSize = true;
            this.lbl_new_count.Location = new System.Drawing.Point(13, 37);
            this.lbl_new_count.Name = "lbl_new_count";
            this.lbl_new_count.Size = new System.Drawing.Size(76, 13);
            this.lbl_new_count.TabIndex = 35;
            this.lbl_new_count.Text = "Új Darabszám:";
            // 
            // txt_new_count
            // 
            this.txt_new_count.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_new_count.Location = new System.Drawing.Point(98, 34);
            this.txt_new_count.Name = "txt_new_count";
            this.txt_new_count.Size = new System.Drawing.Size(177, 20);
            this.txt_new_count.TabIndex = 36;
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(13, 11);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(63, 13);
            this.lbl_count.TabIndex = 6;
            this.lbl_count.Text = "Darabszám:";
            // 
            // txt_count
            // 
            this.txt_count.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_count.Enabled = false;
            this.txt_count.Location = new System.Drawing.Point(98, 8);
            this.txt_count.Name = "txt_count";
            this.txt_count.Size = new System.Drawing.Size(177, 20);
            this.txt_count.TabIndex = 30;
            // 
            // lbl_comment
            // 
            this.lbl_comment.AutoSize = true;
            this.lbl_comment.Location = new System.Drawing.Point(13, 63);
            this.lbl_comment.Name = "lbl_comment";
            this.lbl_comment.Size = new System.Drawing.Size(66, 13);
            this.lbl_comment.TabIndex = 4;
            this.lbl_comment.Text = "Megjegyzés:";
            // 
            // txt_comment
            // 
            this.txt_comment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_comment.Enabled = false;
            this.txt_comment.Location = new System.Drawing.Point(98, 60);
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(314, 20);
            this.txt_comment.TabIndex = 32;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(16, 216);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(92, 37);
            this.btn_edit.TabIndex = 34;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // lbl_edit_order_title
            // 
            this.lbl_edit_order_title.AutoSize = true;
            this.lbl_edit_order_title.Location = new System.Drawing.Point(16, 9);
            this.lbl_edit_order_title.Margin = new System.Windows.Forms.Padding(16, 9, 3, 3);
            this.lbl_edit_order_title.Name = "lbl_edit_order_title";
            this.lbl_edit_order_title.Size = new System.Drawing.Size(116, 13);
            this.lbl_edit_order_title.TabIndex = 27;
            this.lbl_edit_order_title.Text = "Rendelés szerkesztése";
            // 
            // form_edit_order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 441);
            this.Controls.Add(this.panel_add_order);
            this.Name = "form_edit_order";
            this.Text = "Edit Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditOrder_FormClosing);
            this.panel_add_order.ResumeLayout(false);
            this.table_layout_add_order.ResumeLayout(false);
            this.table_layout_add_order.PerformLayout();
            this.panel_add_order_top.ResumeLayout(false);
            this.panel_add_order_top.PerformLayout();
            this.panel_add_order_bottom.ResumeLayout(false);
            this.panel_add_order_bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_add_order;
        private System.Windows.Forms.TableLayoutPanel table_layout_add_order;
        private System.Windows.Forms.Panel panel_add_order_top;
        private System.Windows.Forms.Label lbl_edit_order_title;
        private System.Windows.Forms.Label lbl_main_ordertype;
        private System.Windows.Forms.ComboBox drpd_main_ordertype;
        private System.Windows.Forms.Label lbl_sub_ordertype;
        private System.Windows.Forms.ComboBox drpd_sub_ordertype;
        private System.Windows.Forms.Label lbl_folder;
        private System.Windows.Forms.TextBox txt_folder;
        private System.Windows.Forms.Panel panel_add_order_bottom;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.TextBox txt_count;
        private System.Windows.Forms.Label lbl_comment;
        private System.Windows.Forms.TextBox txt_comment;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Label lbl_new_sub_ordertype;
        private System.Windows.Forms.ComboBox drpd_new_sub_ordertype;
        private System.Windows.Forms.Label lbl_new_main_ordertype;
        private System.Windows.Forms.ComboBox drpd_new_main_ordertype;
        private System.Windows.Forms.Label lbl_new_comment;
        private System.Windows.Forms.TextBox txt_new_comment;
        private System.Windows.Forms.Label lbl_new_count;
        private System.Windows.Forms.TextBox txt_new_count;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.TextBox txt_status;
        private System.Windows.Forms.Label lbl_finished_date;
        private System.Windows.Forms.TextBox txt_finished_date;
        private System.Windows.Forms.Label lbl_birth_date;
        private System.Windows.Forms.TextBox txt_birth_date;
        private System.Windows.Forms.Button btn_cancel;
    }
}