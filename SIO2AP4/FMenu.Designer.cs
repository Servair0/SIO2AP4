
namespace SIO2AP4
{
    partial class FMenu
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
            this.lblBienvenue = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rapatriementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rapatriementVisiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDesVisitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBienvenue
            // 
            this.lblBienvenue.AutoSize = true;
            this.lblBienvenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenue.Location = new System.Drawing.Point(12, 34);
            this.lblBienvenue.Name = "lblBienvenue";
            this.lblBienvenue.Size = new System.Drawing.Size(57, 20);
            this.lblBienvenue.TabIndex = 0;
            this.lblBienvenue.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rapatriementToolStripMenuItem,
            this.visiteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rapatriementToolStripMenuItem
            // 
            this.rapatriementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rapatriementVisiteToolStripMenuItem});
            this.rapatriementToolStripMenuItem.Name = "rapatriementToolStripMenuItem";
            this.rapatriementToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.rapatriementToolStripMenuItem.Text = "Rapatriement";
            // 
            // rapatriementVisiteToolStripMenuItem
            // 
            this.rapatriementVisiteToolStripMenuItem.Name = "rapatriementVisiteToolStripMenuItem";
            this.rapatriementVisiteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rapatriementVisiteToolStripMenuItem.Text = "Rapatriement Visite";
            this.rapatriementVisiteToolStripMenuItem.Click += new System.EventHandler(this.rapatriementVisiteToolStripMenuItem_Click);
            // 
            // visiteToolStripMenuItem
            // 
            this.visiteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesVisitesToolStripMenuItem});
            this.visiteToolStripMenuItem.Name = "visiteToolStripMenuItem";
            this.visiteToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.visiteToolStripMenuItem.Text = "Visite ";
            // 
            // listeDesVisitesToolStripMenuItem
            // 
            this.listeDesVisitesToolStripMenuItem.Name = "listeDesVisitesToolStripMenuItem";
            this.listeDesVisitesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listeDesVisitesToolStripMenuItem.Text = "Liste des visites";
            this.listeDesVisitesToolStripMenuItem.Click += new System.EventHandler(this.listeDesVisitesToolStripMenuItem_Click);
            // 
            // FMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblBienvenue);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMenu";
            this.Text = "FMenu";
            this.Load += new System.EventHandler(this.FMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rapatriementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rapatriementVisiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeDesVisitesToolStripMenuItem;
    }
}