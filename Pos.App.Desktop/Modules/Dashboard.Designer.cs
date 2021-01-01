
namespace Pos.App.Desktop.Modules
{
    partial class Dashboard
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
            this.Modules = new System.Windows.Forms.MenuStrip();
            this.UserTile = new MetroFramework.Controls.MetroTile();
            this.TransactionTile = new MetroFramework.Controls.MetroTile();
            this.IncomeTile = new MetroFramework.Controls.MetroTile();
            this.ExpenseTile = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // Modules
            // 
            this.Modules.Location = new System.Drawing.Point(20, 60);
            this.Modules.Name = "Modules";
            this.Modules.Size = new System.Drawing.Size(1068, 24);
            this.Modules.TabIndex = 0;
            this.Modules.Text = "menuStrip1";
            // 
            // UserTile
            // 
            this.UserTile.ActiveControl = null;
            this.UserTile.Location = new System.Drawing.Point(22, 100);
            this.UserTile.Name = "UserTile";
            this.UserTile.Size = new System.Drawing.Size(194, 75);
            this.UserTile.TabIndex = 1;
            this.UserTile.Text = "Total Users";
            this.UserTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.UserTile.UseSelectable = true;
            // 
            // TransactionTile
            // 
            this.TransactionTile.ActiveControl = null;
            this.TransactionTile.Location = new System.Drawing.Point(221, 100);
            this.TransactionTile.Name = "TransactionTile";
            this.TransactionTile.Size = new System.Drawing.Size(194, 75);
            this.TransactionTile.TabIndex = 1;
            this.TransactionTile.Text = "Total Transactions";
            this.TransactionTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.TransactionTile.UseSelectable = true;
            // 
            // IncomeTile
            // 
            this.IncomeTile.ActiveControl = null;
            this.IncomeTile.Location = new System.Drawing.Point(420, 100);
            this.IncomeTile.Name = "IncomeTile";
            this.IncomeTile.Size = new System.Drawing.Size(268, 75);
            this.IncomeTile.TabIndex = 1;
            this.IncomeTile.Text = "Total Income";
            this.IncomeTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.IncomeTile.UseSelectable = true;
            // 
            // ExpenseTile
            // 
            this.ExpenseTile.ActiveControl = null;
            this.ExpenseTile.Location = new System.Drawing.Point(694, 100);
            this.ExpenseTile.Name = "ExpenseTile";
            this.ExpenseTile.Size = new System.Drawing.Size(268, 75);
            this.ExpenseTile.TabIndex = 1;
            this.ExpenseTile.Text = "Total Expense";
            this.ExpenseTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.ExpenseTile.UseSelectable = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 450);
            this.Controls.Add(this.ExpenseTile);
            this.Controls.Add(this.IncomeTile);
            this.Controls.Add(this.TransactionTile);
            this.Controls.Add(this.UserTile);
            this.Controls.Add(this.Modules);
            this.MainMenuStrip = this.Modules;
            this.Name = "Dashboard";
            this.Resizable = false;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Modules;
        private MetroFramework.Controls.MetroTile UserTile;
        private MetroFramework.Controls.MetroTile TransactionTile;
        private MetroFramework.Controls.MetroTile IncomeTile;
        private MetroFramework.Controls.MetroTile ExpenseTile;
    }
}