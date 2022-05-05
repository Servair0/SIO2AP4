namespace SIO2AP4
{
    partial class FAjoutModif
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.txtSoin = new System.Windows.Forms.TextBox();
            this.txtCoef = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbReal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(5, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nom du soin :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(11, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(20, 234);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Coeficient :";
            // 
            // txtDes
            // 
            this.txtDes.Location = new System.Drawing.Point(94, 65);
            this.txtDes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(573, 156);
            this.txtDes.TabIndex = 5;
            // 
            // txtSoin
            // 
            this.txtSoin.Location = new System.Drawing.Point(94, 27);
            this.txtSoin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSoin.Name = "txtSoin";
            this.txtSoin.Size = new System.Drawing.Size(180, 20);
            this.txtSoin.TabIndex = 6;
            // 
            // txtCoef
            // 
            this.txtCoef.Location = new System.Drawing.Point(94, 234);
            this.txtCoef.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCoef.Name = "txtCoef";
            this.txtCoef.Size = new System.Drawing.Size(93, 20);
            this.txtCoef.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(610, 234);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(226, 236);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Realisé :";
            // 
            // cbReal
            // 
            this.cbReal.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbReal.FormattingEnabled = true;
            this.cbReal.Items.AddRange(new object[] {
            "Non",
            "Oui"});
            this.cbReal.Location = new System.Drawing.Point(286, 234);
            this.cbReal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbReal.Name = "cbReal";
            this.cbReal.Size = new System.Drawing.Size(92, 21);
            this.cbReal.TabIndex = 10;
            // 
            // FAjoutModif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 273);
            this.Controls.Add(this.cbReal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCoef);
            this.Controls.Add(this.txtSoin);
            this.Controls.Add(this.txtDes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FAjoutModif";
            this.Text = "AjoutModif";
            this.Load += new System.EventHandler(this.FAjoutModif_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.TextBox txtSoin;
        private System.Windows.Forms.TextBox txtCoef;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbReal;
    }
}