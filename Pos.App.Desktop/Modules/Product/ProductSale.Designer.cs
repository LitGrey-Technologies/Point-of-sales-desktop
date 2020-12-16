
namespace Pos.App.Desktop.Modules.Product
{
    partial class ProductSale
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridPanel = new MetroFramework.Controls.MetroPanel();
            this.txtNoOfItems = new MetroFramework.Controls.MetroLabel();
            this.txtTotalAmount = new MetroFramework.Controls.MetroLabel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFormPanel = new MetroFramework.Controls.MetroPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cmbCustomer = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtUnitPrice = new MetroFramework.Controls.MetroTextBox();
            this.txtQty = new MetroFramework.Controls.MetroTextBox();
            this.cmbProduct = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.GridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.DataFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridPanel
            // 
            this.GridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GridPanel.Controls.Add(this.txtNoOfItems);
            this.GridPanel.Controls.Add(this.txtTotalAmount);
            this.GridPanel.Controls.Add(this.metroButton2);
            this.GridPanel.Controls.Add(this.metroGrid1);
            this.GridPanel.HorizontalScrollbarBarColor = true;
            this.GridPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.GridPanel.HorizontalScrollbarSize = 10;
            this.GridPanel.Location = new System.Drawing.Point(23, 170);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(673, 259);
            this.GridPanel.TabIndex = 8;
            this.GridPanel.VerticalScrollbarBarColor = true;
            this.GridPanel.VerticalScrollbarHighlightOnWheel = false;
            this.GridPanel.VerticalScrollbarSize = 10;
            // 
            // txtNoOfItems
            // 
            this.txtNoOfItems.AutoSize = true;
            this.txtNoOfItems.Location = new System.Drawing.Point(10, 232);
            this.txtNoOfItems.Name = "txtNoOfItems";
            this.txtNoOfItems.Size = new System.Drawing.Size(78, 19);
            this.txtNoOfItems.TabIndex = 15;
            this.txtNoOfItems.Tag = "";
            this.txtNoOfItems.Text = "No of items";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.AutoSize = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(222, 232);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(87, 19);
            this.txtTotalAmount.TabIndex = 14;
            this.txtTotalAmount.Text = "Total Amount";
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(555, 230);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(105, 23);
            this.metroButton2.TabIndex = 13;
            this.metroButton2.Text = "Generate Invoice";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click_1);
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.qty,
            this.price,
            this.Amount,
            this.VendorName});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle5;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(9, 11);
            this.metroGrid1.MultiSelect = false;
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(651, 213);
            this.metroGrid1.TabIndex = 10;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "ProductName";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // VendorName
            // 
            this.VendorName.HeaderText = "VendorName";
            this.VendorName.Name = "VendorName";
            this.VendorName.ReadOnly = true;
            // 
            // DataFormPanel
            // 
            this.DataFormPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataFormPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataFormPanel.Controls.Add(this.linkLabel1);
            this.DataFormPanel.Controls.Add(this.metroButton1);
            this.DataFormPanel.Controls.Add(this.metroLabel5);
            this.DataFormPanel.Controls.Add(this.cmbCustomer);
            this.DataFormPanel.Controls.Add(this.metroLabel2);
            this.DataFormPanel.Controls.Add(this.metroLabel3);
            this.DataFormPanel.Controls.Add(this.txtUnitPrice);
            this.DataFormPanel.Controls.Add(this.txtQty);
            this.DataFormPanel.Controls.Add(this.cmbProduct);
            this.DataFormPanel.Controls.Add(this.metroLabel4);
            this.DataFormPanel.HorizontalScrollbarBarColor = true;
            this.DataFormPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.DataFormPanel.HorizontalScrollbarSize = 10;
            this.DataFormPanel.Location = new System.Drawing.Point(23, 63);
            this.DataFormPanel.Name = "DataFormPanel";
            this.DataFormPanel.Size = new System.Drawing.Size(673, 104);
            this.DataFormPanel.TabIndex = 9;
            this.DataFormPanel.VerticalScrollbarBarColor = true;
            this.DataFormPanel.VerticalScrollbarHighlightOnWheel = false;
            this.DataFormPanel.VerticalScrollbarSize = 10;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(428, 73);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(95, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Add new customer";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(590, 73);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 12;
            this.metroButton1.Text = "Add";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(341, 14);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(65, 19);
            this.metroLabel5.TabIndex = 11;
            this.metroLabel5.Text = "Unit Price";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.ItemHeight = 23;
            this.cmbCustomer.Location = new System.Drawing.Point(428, 38);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(236, 29);
            this.cmbCustomer.TabIndex = 6;
            this.cmbCustomer.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(341, 46);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Customer";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(10, 46);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(30, 19);
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "Qty";
            // 
            // txtUnitPrice
            // 
            // 
            // 
            // 
            this.txtUnitPrice.CustomButton.Image = null;
            this.txtUnitPrice.CustomButton.Location = new System.Drawing.Point(215, 1);
            this.txtUnitPrice.CustomButton.Name = "";
            this.txtUnitPrice.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUnitPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUnitPrice.CustomButton.TabIndex = 1;
            this.txtUnitPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUnitPrice.CustomButton.UseSelectable = true;
            this.txtUnitPrice.CustomButton.Visible = false;
            this.txtUnitPrice.Lines = new string[0];
            this.txtUnitPrice.Location = new System.Drawing.Point(428, 10);
            this.txtUnitPrice.MaxLength = 32767;
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.PasswordChar = '\0';
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUnitPrice.SelectedText = "";
            this.txtUnitPrice.SelectionLength = 0;
            this.txtUnitPrice.SelectionStart = 0;
            this.txtUnitPrice.ShortcutsEnabled = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(237, 23);
            this.txtUnitPrice.TabIndex = 10;
            this.txtUnitPrice.UseSelectable = true;
            this.txtUnitPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUnitPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtQty
            // 
            // 
            // 
            // 
            this.txtQty.CustomButton.Image = null;
            this.txtQty.CustomButton.Location = new System.Drawing.Point(215, 1);
            this.txtQty.CustomButton.Name = "";
            this.txtQty.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtQty.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQty.CustomButton.TabIndex = 1;
            this.txtQty.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQty.CustomButton.UseSelectable = true;
            this.txtQty.CustomButton.Visible = false;
            this.txtQty.Lines = new string[0];
            this.txtQty.Location = new System.Drawing.Point(98, 44);
            this.txtQty.MaxLength = 32767;
            this.txtQty.Name = "txtQty";
            this.txtQty.PasswordChar = '\0';
            this.txtQty.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQty.SelectedText = "";
            this.txtQty.SelectionLength = 0;
            this.txtQty.SelectionStart = 0;
            this.txtQty.ShortcutsEnabled = true;
            this.txtQty.Size = new System.Drawing.Size(237, 23);
            this.txtQty.TabIndex = 10;
            this.txtQty.UseSelectable = true;
            this.txtQty.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtQty.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cmbProduct
            // 
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.ItemHeight = 23;
            this.cmbProduct.Location = new System.Drawing.Point(98, 9);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(237, 29);
            this.cmbProduct.TabIndex = 4;
            this.cmbProduct.UseSelectable = true;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(10, 14);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(55, 19);
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = "Product";
            // 
            // ProductSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 450);
            this.Controls.Add(this.GridPanel);
            this.Controls.Add(this.DataFormPanel);
            this.Name = "ProductSale";
            this.Text = "Product Sale";
            this.GridPanel.ResumeLayout(false);
            this.GridPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.DataFormPanel.ResumeLayout(false);
            this.DataFormPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel GridPanel;
        private MetroFramework.Controls.MetroLabel txtNoOfItems;
        private MetroFramework.Controls.MetroLabel txtTotalAmount;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorName;
        private MetroFramework.Controls.MetroPanel DataFormPanel;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cmbCustomer;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtUnitPrice;
        private MetroFramework.Controls.MetroTextBox txtQty;
        private MetroFramework.Controls.MetroComboBox cmbProduct;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}