
namespace SIO2AP4
{
    partial class FlisteV
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
            this.dgvVisite = new System.Windows.Forms.DataGridView();
            this.lblVisite = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCompteRendu = new System.Windows.Forms.Button();
            this.bsVisite = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVisite)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVisite
            // 
            this.dgvVisite.AllowUserToAddRows = false;
            this.dgvVisite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisite.Location = new System.Drawing.Point(12, 58);
            this.dgvVisite.Name = "dgvVisite";
            this.dgvVisite.ReadOnly = true;
            this.dgvVisite.RowHeadersWidth = 51;
            this.dgvVisite.Size = new System.Drawing.Size(776, 380);
            this.dgvVisite.TabIndex = 0;
            // 
            // lblVisite
            // 
            this.lblVisite.AutoSize = true;
            this.lblVisite.Location = new System.Drawing.Point(12, 19);
            this.lblVisite.Name = "lblVisite";
            this.lblVisite.Size = new System.Drawing.Size(82, 13);
            this.lblVisite.TabIndex = 1;
            this.lblVisite.Text = "Liste des Visites";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(805, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Affiche soins";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCompteRendu
            // 
            this.btnCompteRendu.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCompteRendu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompteRendu.Location = new System.Drawing.Point(805, 105);
            this.btnCompteRendu.Name = "btnCompteRendu";
            this.btnCompteRendu.Size = new System.Drawing.Size(104, 23);
            this.btnCompteRendu.TabIndex = 4;
            this.btnCompteRendu.Text = "Comte rendu";
            this.btnCompteRendu.UseVisualStyleBackColor = false;
            this.btnCompteRendu.Click += new System.EventHandler(this.btnCompteRendu_Click);
            // 
            // FlisteV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 483);
            this.Controls.Add(this.btnCompteRendu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblVisite);
            this.Controls.Add(this.dgvVisite);
            this.Name = "FlisteV";
            this.Text = "FlisteV";
            this.Load += new System.EventHandler(this.FlisteV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVisite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsVisite;
        private System.Windows.Forms.DataGridView dgvVisite;
        private System.Windows.Forms.Label lblVisite;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCompteRendu;
    }
}