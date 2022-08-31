namespace FolderManipulator
{
    partial class form_settings
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
            this.panel_add_order_bottom = new System.Windows.Forms.Panel();
            this.lbl_drive_letter = new System.Windows.Forms.Label();
            this.txt_drive_letter = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_new_font_size = new System.Windows.Forms.Label();
            this.txt_new_font_size = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_edit_order_title = new System.Windows.Forms.Label();
            this.panel_add_order.SuspendLayout();
            this.table_layout_add_order.SuspendLayout();
            this.panel_add_order_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_add_order
            // 
            this.panel_add_order.Controls.Add(this.table_layout_add_order);
            this.panel_add_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_add_order.Location = new System.Drawing.Point(0, 0);
            this.panel_add_order.Name = "panel_add_order";
            this.panel_add_order.Size = new System.Drawing.Size(428, 515);
            this.panel_add_order.TabIndex = 37;
            // 
            // table_layout_add_order
            // 
            this.table_layout_add_order.ColumnCount = 1;
            this.table_layout_add_order.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_add_order.Controls.Add(this.panel_add_order_bottom, 0, 1);
            this.table_layout_add_order.Controls.Add(this.lbl_edit_order_title, 0, 0);
            this.table_layout_add_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_add_order.Location = new System.Drawing.Point(0, 0);
            this.table_layout_add_order.Name = "table_layout_add_order";
            this.table_layout_add_order.RowCount = 2;
            this.table_layout_add_order.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.table_layout_add_order.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout_add_order.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_layout_add_order.Size = new System.Drawing.Size(428, 515);
            this.table_layout_add_order.TabIndex = 35;
            // 
            // panel_add_order_bottom
            // 
            this.panel_add_order_bottom.Controls.Add(this.lbl_drive_letter);
            this.panel_add_order_bottom.Controls.Add(this.txt_drive_letter);
            this.panel_add_order_bottom.Controls.Add(this.btn_cancel);
            this.panel_add_order_bottom.Controls.Add(this.lbl_new_font_size);
            this.panel_add_order_bottom.Controls.Add(this.txt_new_font_size);
            this.panel_add_order_bottom.Controls.Add(this.btn_save);
            this.panel_add_order_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_add_order_bottom.Location = new System.Drawing.Point(3, 33);
            this.panel_add_order_bottom.Name = "panel_add_order_bottom";
            this.panel_add_order_bottom.Size = new System.Drawing.Size(422, 479);
            this.panel_add_order_bottom.TabIndex = 29;
            // 
            // lbl_drive_letter
            // 
            this.lbl_drive_letter.AutoSize = true;
            this.lbl_drive_letter.Location = new System.Drawing.Point(13, 37);
            this.lbl_drive_letter.Name = "lbl_drive_letter";
            this.lbl_drive_letter.Size = new System.Drawing.Size(79, 13);
            this.lbl_drive_letter.TabIndex = 37;
            this.lbl_drive_letter.Text = "Meghajtó Betű:";
            // 
            // txt_drive_letter
            // 
            this.txt_drive_letter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_drive_letter.Location = new System.Drawing.Point(98, 34);
            this.txt_drive_letter.Name = "txt_drive_letter";
            this.txt_drive_letter.Size = new System.Drawing.Size(178, 20);
            this.txt_drive_letter.TabIndex = 36;
            this.txt_drive_letter.TextChanged += new System.EventHandler(this.txt_drive_letter_TextChanged);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Location = new System.Drawing.Point(321, 60);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(92, 37);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_new_font_size
            // 
            this.lbl_new_font_size.AutoSize = true;
            this.lbl_new_font_size.Location = new System.Drawing.Point(13, 11);
            this.lbl_new_font_size.Name = "lbl_new_font_size";
            this.lbl_new_font_size.Size = new System.Drawing.Size(74, 13);
            this.lbl_new_font_size.TabIndex = 35;
            this.lbl_new_font_size.Text = "Új Font Méret:";
            // 
            // txt_new_font_size
            // 
            this.txt_new_font_size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_new_font_size.Location = new System.Drawing.Point(98, 8);
            this.txt_new_font_size.Name = "txt_new_font_size";
            this.txt_new_font_size.Size = new System.Drawing.Size(178, 20);
            this.txt_new_font_size.TabIndex = 0;
            this.txt_new_font_size.TextChanged += new System.EventHandler(this.txt_new_font_size_TextChanged);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(9, 60);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(92, 37);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Save Changes";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_edit_order_title
            // 
            this.lbl_edit_order_title.AutoSize = true;
            this.lbl_edit_order_title.Location = new System.Drawing.Point(16, 9);
            this.lbl_edit_order_title.Margin = new System.Windows.Forms.Padding(16, 9, 3, 3);
            this.lbl_edit_order_title.Name = "lbl_edit_order_title";
            this.lbl_edit_order_title.Size = new System.Drawing.Size(60, 13);
            this.lbl_edit_order_title.TabIndex = 27;
            this.lbl_edit_order_title.Text = "Beállítások";
            // 
            // form_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 515);
            this.Controls.Add(this.panel_add_order);
            this.Name = "form_settings";
            this.Text = "Settings";
            this.panel_add_order.ResumeLayout(false);
            this.table_layout_add_order.ResumeLayout(false);
            this.table_layout_add_order.PerformLayout();
            this.panel_add_order_bottom.ResumeLayout(false);
            this.panel_add_order_bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_add_order;
        private System.Windows.Forms.TableLayoutPanel table_layout_add_order;
        private System.Windows.Forms.Panel panel_add_order_bottom;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_new_font_size;
        private System.Windows.Forms.TextBox txt_new_font_size;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_edit_order_title;
        private System.Windows.Forms.Label lbl_drive_letter;
        private System.Windows.Forms.TextBox txt_drive_letter;
    }
}