namespace FolderManipulator
{
    partial class form_ordertype_settings
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_main_ordertype = new System.Windows.Forms.Panel();
            this.lbl_main_order_type_title = new System.Windows.Forms.Label();
            this.txt_main_ordertype = new System.Windows.Forms.TextBox();
            this.btn_add_main_ordertype = new System.Windows.Forms.Button();
            this.listbox_main_ordertype = new System.Windows.Forms.ListBox();
            this.btn_delete_main_ordertype = new System.Windows.Forms.Button();
            this.panel_sub_ordertype = new System.Windows.Forms.Panel();
            this.lbl_sub_order_type_title = new System.Windows.Forms.Label();
            this.txt_sub_ordertype = new System.Windows.Forms.TextBox();
            this.btn_add_sub_ordertype = new System.Windows.Forms.Button();
            this.btn_delete_sub_ordertype = new System.Windows.Forms.Button();
            this.listbox_sub_ordertype = new System.Windows.Forms.ListBox();
            this.btn_finish = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_main_ordertype.SuspendLayout();
            this.panel_sub_ordertype.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_finish, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 558);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel_main_ordertype, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel_sub_ordertype, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(268, 502);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel_main_ordertype
            // 
            this.panel_main_ordertype.Controls.Add(this.lbl_main_order_type_title);
            this.panel_main_ordertype.Controls.Add(this.txt_main_ordertype);
            this.panel_main_ordertype.Controls.Add(this.btn_add_main_ordertype);
            this.panel_main_ordertype.Controls.Add(this.listbox_main_ordertype);
            this.panel_main_ordertype.Controls.Add(this.btn_delete_main_ordertype);
            this.panel_main_ordertype.Location = new System.Drawing.Point(3, 3);
            this.panel_main_ordertype.Name = "panel_main_ordertype";
            this.panel_main_ordertype.Size = new System.Drawing.Size(126, 477);
            this.panel_main_ordertype.TabIndex = 0;
            // 
            // lbl_main_order_type_title
            // 
            this.lbl_main_order_type_title.AutoSize = true;
            this.lbl_main_order_type_title.Location = new System.Drawing.Point(3, 13);
            this.lbl_main_order_type_title.Name = "lbl_main_order_type_title";
            this.lbl_main_order_type_title.Size = new System.Drawing.Size(89, 13);
            this.lbl_main_order_type_title.TabIndex = 16;
            this.lbl_main_order_type_title.Text = "Típus hozzáadás";
            // 
            // txt_main_ordertype
            // 
            this.txt_main_ordertype.Location = new System.Drawing.Point(3, 38);
            this.txt_main_ordertype.Name = "txt_main_ordertype";
            this.txt_main_ordertype.Size = new System.Drawing.Size(120, 20);
            this.txt_main_ordertype.TabIndex = 0;
            this.txt_main_ordertype.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_main_ordertype_KeyUp);
            // 
            // btn_add_main_ordertype
            // 
            this.btn_add_main_ordertype.Location = new System.Drawing.Point(3, 64);
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
            this.listbox_main_ordertype.Location = new System.Drawing.Point(3, 95);
            this.listbox_main_ordertype.Name = "listbox_main_ordertype";
            this.listbox_main_ordertype.Size = new System.Drawing.Size(120, 134);
            this.listbox_main_ordertype.TabIndex = 2;
            // 
            // btn_delete_main_ordertype
            // 
            this.btn_delete_main_ordertype.Location = new System.Drawing.Point(3, 235);
            this.btn_delete_main_ordertype.Name = "btn_delete_main_ordertype";
            this.btn_delete_main_ordertype.Size = new System.Drawing.Size(120, 23);
            this.btn_delete_main_ordertype.TabIndex = 3;
            this.btn_delete_main_ordertype.Text = "Típus Törlése";
            this.btn_delete_main_ordertype.UseVisualStyleBackColor = true;
            this.btn_delete_main_ordertype.Click += new System.EventHandler(this.btn_delete_main_ordertype_Click);
            // 
            // panel_sub_ordertype
            // 
            this.panel_sub_ordertype.Controls.Add(this.lbl_sub_order_type_title);
            this.panel_sub_ordertype.Controls.Add(this.txt_sub_ordertype);
            this.panel_sub_ordertype.Controls.Add(this.btn_add_sub_ordertype);
            this.panel_sub_ordertype.Controls.Add(this.btn_delete_sub_ordertype);
            this.panel_sub_ordertype.Controls.Add(this.listbox_sub_ordertype);
            this.panel_sub_ordertype.Location = new System.Drawing.Point(135, 3);
            this.panel_sub_ordertype.Name = "panel_sub_ordertype";
            this.panel_sub_ordertype.Size = new System.Drawing.Size(126, 477);
            this.panel_sub_ordertype.TabIndex = 1;
            // 
            // lbl_sub_order_type_title
            // 
            this.lbl_sub_order_type_title.AutoSize = true;
            this.lbl_sub_order_type_title.Location = new System.Drawing.Point(3, 13);
            this.lbl_sub_order_type_title.Name = "lbl_sub_order_type_title";
            this.lbl_sub_order_type_title.Size = new System.Drawing.Size(94, 13);
            this.lbl_sub_order_type_title.TabIndex = 17;
            this.lbl_sub_order_type_title.Text = "Altípus hozzáadás";
            // 
            // txt_sub_ordertype
            // 
            this.txt_sub_ordertype.Location = new System.Drawing.Point(3, 38);
            this.txt_sub_ordertype.Name = "txt_sub_ordertype";
            this.txt_sub_ordertype.Size = new System.Drawing.Size(120, 20);
            this.txt_sub_ordertype.TabIndex = 0;
            this.txt_sub_ordertype.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_sub_ordertype_KeyUp);
            // 
            // btn_add_sub_ordertype
            // 
            this.btn_add_sub_ordertype.Location = new System.Drawing.Point(3, 64);
            this.btn_add_sub_ordertype.Name = "btn_add_sub_ordertype";
            this.btn_add_sub_ordertype.Size = new System.Drawing.Size(120, 23);
            this.btn_add_sub_ordertype.TabIndex = 1;
            this.btn_add_sub_ordertype.Text = "Altípus Hozzáadása";
            this.btn_add_sub_ordertype.UseVisualStyleBackColor = true;
            this.btn_add_sub_ordertype.Click += new System.EventHandler(this.btn_add_sub_ordertype_Click);
            // 
            // btn_delete_sub_ordertype
            // 
            this.btn_delete_sub_ordertype.Location = new System.Drawing.Point(3, 235);
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
            this.listbox_sub_ordertype.Location = new System.Drawing.Point(3, 95);
            this.listbox_sub_ordertype.Name = "listbox_sub_ordertype";
            this.listbox_sub_ordertype.Size = new System.Drawing.Size(120, 134);
            this.listbox_sub_ordertype.TabIndex = 2;
            // 
            // btn_finish
            // 
            this.btn_finish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_finish.Location = new System.Drawing.Point(3, 511);
            this.btn_finish.Name = "btn_finish";
            this.btn_finish.Size = new System.Drawing.Size(268, 44);
            this.btn_finish.TabIndex = 0;
            this.btn_finish.Text = "Finish";
            this.btn_finish.UseVisualStyleBackColor = true;
            this.btn_finish.Click += new System.EventHandler(this.btn_finish_Click);
            // 
            // form_ordertype_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 558);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "form_ordertype_settings";
            this.Text = "OrderTypeSettings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel_main_ordertype.ResumeLayout(false);
            this.panel_main_ordertype.PerformLayout();
            this.panel_sub_ordertype.ResumeLayout(false);
            this.panel_sub_ordertype.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel_sub_ordertype;
        private System.Windows.Forms.TextBox txt_sub_ordertype;
        private System.Windows.Forms.Button btn_add_sub_ordertype;
        private System.Windows.Forms.Button btn_delete_sub_ordertype;
        private System.Windows.Forms.ListBox listbox_sub_ordertype;
        private System.Windows.Forms.Panel panel_main_ordertype;
        private System.Windows.Forms.TextBox txt_main_ordertype;
        private System.Windows.Forms.Button btn_add_main_ordertype;
        private System.Windows.Forms.ListBox listbox_main_ordertype;
        private System.Windows.Forms.Button btn_delete_main_ordertype;
        private System.Windows.Forms.Button btn_finish;
        private System.Windows.Forms.Label lbl_main_order_type_title;
        private System.Windows.Forms.Label lbl_sub_order_type_title;
    }
}