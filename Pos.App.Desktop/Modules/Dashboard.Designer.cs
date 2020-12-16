
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
            this.ShellPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Modules
            // 
            this.Modules.Location = new System.Drawing.Point(20, 60);
            this.Modules.Name = "Modules";
            this.Modules.Size = new System.Drawing.Size(760, 24);
            this.Modules.TabIndex = 0;
            this.Modules.Text = "menuStrip1";
            // 
            // ShellPanel
            // 
            this.ShellPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShellPanel.Location = new System.Drawing.Point(20, 84);
            this.ShellPanel.Name = "ShellPanel";
            this.ShellPanel.Size = new System.Drawing.Size(760, 346);
            this.ShellPanel.TabIndex = 1;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShellPanel);
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
        private System.Windows.Forms.Panel ShellPanel;
    }
}