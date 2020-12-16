
namespace Pos.App.Desktop.Modules.User
{
    partial class UserRoleView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridPanel = new MetroFramework.Controls.MetroPanel();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtSearchBox = new MetroFramework.Controls.MetroTextBox();
            this.DataFormPanel = new MetroFramework.Controls.MetroPanel();
            this.cmbActive = new MetroFramework.Controls.MetroComboBox();
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.txtRoleId = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
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
            this.GridPanel.Controls.Add(this.metroGrid1);
            this.GridPanel.Controls.Add(this.metroLabel1);
            this.GridPanel.Controls.Add(this.txtSearchBox);
            this.GridPanel.HorizontalScrollbarBarColor = true;
            this.GridPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.GridPanel.HorizontalScrollbarSize = 10;
            this.GridPanel.Location = new System.Drawing.Point(23, 150);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(677, 277);
            this.GridPanel.TabIndex = 2;
            this.GridPanel.VerticalScrollbarBarColor = true;
            this.GridPanel.VerticalScrollbarHighlightOnWheel = false;
            this.GridPanel.VerticalScrollbarSize = 10;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(9, 38);
            this.metroGrid1.MultiSelect = false;
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(655, 229);
            this.metroGrid1.TabIndex = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(344, 8);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(78, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Search here";
            // 
            // txtSearchBox
            // 
            // 
            // 
            // 
            this.txtSearchBox.CustomButton.Image = null;
            this.txtSearchBox.CustomButton.Location = new System.Drawing.Point(216, 1);
            this.txtSearchBox.CustomButton.Name = "";
            this.txtSearchBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSearchBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearchBox.CustomButton.TabIndex = 1;
            this.txtSearchBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearchBox.CustomButton.UseSelectable = true;
            this.txtSearchBox.CustomButton.Visible = false;
            this.txtSearchBox.Lines = new string[0];
            this.txtSearchBox.Location = new System.Drawing.Point(428, 7);
            this.txtSearchBox.MaxLength = 32767;
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.PasswordChar = '\0';
            this.txtSearchBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearchBox.SelectedText = "";
            this.txtSearchBox.SelectionLength = 0;
            this.txtSearchBox.SelectionStart = 0;
            this.txtSearchBox.ShortcutsEnabled = true;
            this.txtSearchBox.Size = new System.Drawing.Size(238, 23);
            this.txtSearchBox.TabIndex = 8;
            this.txtSearchBox.UseSelectable = true;
            this.txtSearchBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearchBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // DataFormPanel
            // 
            this.DataFormPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataFormPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataFormPanel.Controls.Add(this.cmbActive);
            this.DataFormPanel.Controls.Add(this.txtName);
            this.DataFormPanel.Controls.Add(this.txtRoleId);
            this.DataFormPanel.Controls.Add(this.metroLabel2);
            this.DataFormPanel.Controls.Add(this.metroLabel7);
            this.DataFormPanel.Controls.Add(this.metroLabel4);
            this.DataFormPanel.HorizontalScrollbarBarColor = true;
            this.DataFormPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.DataFormPanel.HorizontalScrollbarSize = 10;
            this.DataFormPanel.Location = new System.Drawing.Point(23, 61);
            this.DataFormPanel.Name = "DataFormPanel";
            this.DataFormPanel.Size = new System.Drawing.Size(677, 87);
            this.DataFormPanel.TabIndex = 3;
            this.DataFormPanel.VerticalScrollbarBarColor = true;
            this.DataFormPanel.VerticalScrollbarHighlightOnWheel = false;
            this.DataFormPanel.VerticalScrollbarSize = 10;
            // 
            // cmbActive
            // 
            this.cmbActive.FormattingEnabled = true;
            this.cmbActive.ItemHeight = 23;
            this.cmbActive.Location = new System.Drawing.Point(87, 44);
            this.cmbActive.Name = "cmbActive";
            this.cmbActive.Size = new System.Drawing.Size(237, 29);
            this.cmbActive.TabIndex = 3;
            this.cmbActive.UseSelectable = true;
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.CustomButton.Image = null;
            this.txtName.CustomButton.Location = new System.Drawing.Point(209, 1);
            this.txtName.CustomButton.Name = "";
            this.txtName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtName.CustomButton.TabIndex = 1;
            this.txtName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtName.CustomButton.UseSelectable = true;
            this.txtName.CustomButton.Visible = false;
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(428, 14);
            this.txtName.MaxLength = 32767;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.ShortcutsEnabled = true;
            this.txtName.Size = new System.Drawing.Size(231, 23);
            this.txtName.TabIndex = 2;
            this.txtName.UseSelectable = true;
            this.txtName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtRoleId
            // 
            // 
            // 
            // 
            this.txtRoleId.CustomButton.Image = null;
            this.txtRoleId.CustomButton.Location = new System.Drawing.Point(215, 1);
            this.txtRoleId.CustomButton.Name = "";
            this.txtRoleId.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRoleId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRoleId.CustomButton.TabIndex = 1;
            this.txtRoleId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRoleId.CustomButton.UseSelectable = true;
            this.txtRoleId.CustomButton.Visible = false;
            this.txtRoleId.Lines = new string[0];
            this.txtRoleId.Location = new System.Drawing.Point(87, 14);
            this.txtRoleId.MaxLength = 32767;
            this.txtRoleId.Name = "txtRoleId";
            this.txtRoleId.PasswordChar = '\0';
            this.txtRoleId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRoleId.SelectedText = "";
            this.txtRoleId.SelectionLength = 0;
            this.txtRoleId.SelectionStart = 0;
            this.txtRoleId.ShortcutsEnabled = true;
            this.txtRoleId.Size = new System.Drawing.Size(237, 23);
            this.txtRoleId.TabIndex = 1;
            this.txtRoleId.UseSelectable = true;
            this.txtRoleId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRoleId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(350, 16);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(45, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Name";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(10, 49);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(44, 19);
            this.metroLabel7.TabIndex = 2;
            this.metroLabel7.Text = "Active";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(10, 16);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(50, 19);
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = "Role Id";
            // 
            // UserRoleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 450);
            this.Controls.Add(this.GridPanel);
            this.Controls.Add(this.DataFormPanel);
            this.Name = "UserRoleView";
            this.Resizable = true;
            this.Text = "User Role";
            this.GridPanel.ResumeLayout(false);
            this.GridPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.DataFormPanel.ResumeLayout(false);
            this.DataFormPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel GridPanel;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtSearchBox;
        private MetroFramework.Controls.MetroPanel DataFormPanel;
        private MetroFramework.Controls.MetroComboBox cmbActive;
        private MetroFramework.Controls.MetroTextBox txtRoleId;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}