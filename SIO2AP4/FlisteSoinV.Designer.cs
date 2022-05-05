namespace SIO2AP4
{
    partial class FlisteSoinV
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
            this.bsSoinVisite = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSoins = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAjout = new System.Windows.Forms.Button();
            this.btnModif = new System.Windows.Forms.Button();
            this.btnEffacer = new System.Windows.Forms.Button();
            this.bsVisite = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsSoinVisite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVisite)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSoins
            // 
            this.dgvSoins.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSoins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoins.Location = new System.Drawing.Point(23, 50);
            this.dgvSoins.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSoins.Name = "dgvSoins";
            this.dgvSoins.RowHeadersWidth = 51;
            this.dgvSoins.RowTemplate.Height = 24;
            this.dgvSoins.Size = new System.Drawing.Size(932, 411);
            this.dgvSoins.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Liste des soins pour cette visite :";
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(695, 490);
            this.btnAjout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(75, 23);
            this.btnAjout.TabIndex = 2;
            this.btnAjout.Text = "Ajouter";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // btnModif
            // 
            this.btnModif.Location = new System.Drawing.Point(789, 490);
            this.btnModif.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModif.Name = "btnModif";
            this.btnModif.Size = new System.Drawing.Size(75, 23);
            this.btnModif.TabIndex = 3;
            this.btnModif.Text = "Modif";
            this.btnModif.UseVisualStyleBackColor = true;
            this.btnModif.Click += new System.EventHandler(this.btnModif_Click);
            // 
            // btnEffacer
            // 
            this.btnEffacer.Location = new System.Drawing.Point(881, 490);
            this.btnEffacer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEffacer.Name = "btnEffacer";
            this.btnEffacer.Size = new System.Drawing.Size(75, 23);
            this.btnEffacer.TabIndex = 4;
            this.btnEffacer.Text = "Effacer";
            this.btnEffacer.UseVisualStyleBackColor = true;
            this.btnEffacer.Click += new System.EventHandler(this.btnEffacer_Click);
            // 
            // FlisteSoinV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 537);
            this.Controls.Add(this.btnEffacer);
            this.Controls.Add(this.btnModif);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSoins);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FlisteSoinV";
            this.Text = "FlisteSoinV";
            this.Load += new System.EventHandler(this.FlisteSoinV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsSoinVisite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVisite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsSoinVisite;
        private System.Windows.Forms.DataGridView dgvSoins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnModif;
        private System.Windows.Forms.Button btnEffacer;
        private System.Windows.Forms.BindingSource bsVisite;
    }
}