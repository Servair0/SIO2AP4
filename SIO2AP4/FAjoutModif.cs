using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIO2AP4
{
    public partial class FAjoutModif : Form
    {
        public FAjoutModif()
        {
            InitializeComponent();
        }

        private void FAjoutModif_Load(object sender, EventArgs e)
        {
            if (Modele.Action == 1)
            {
                soins_visite s = Modele.ChoisiSoins;
                txtSoin.Text = s.soins.libel;
                txtDes.Text = s.soins.description;
                txtCoef.Text = s.soins.coefficient.ToString();
                if(s.realise == 1)
                {
                    cbReal.SelectedIndex= 0;
                }
                else { cbReal.SelectedIndex = 1; }
            }
            if (Modele.Lock == 1)
            {
                txtSoin.Enabled = false;
                txtDes.Enabled = false;
                txtCoef.Enabled = false;
            }
            cbReal.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            short choix = Convert.ToInt16(cbReal.SelectedIndex);
            try 
            {
                float coef = Convert.ToSingle(txtCoef.Text);
                if (Modele.Action == 1)
                {
                    Modele.ModifSoins(txtSoin.Text, txtDes.Text, coef, choix);
                    Form f = new FlisteSoinV();
                    f.Show();
                    Close();

                }
                if (Modele.Action == 0)
                {
                    Modele.AjoutSoins(txtSoin.Text, txtDes.Text, coef, choix);
                    Form f = new FlisteSoinV();
                    f.Show();
                    Close();

                }
            } 
            catch
            {
                MessageBox.Show("Vous ne pouvez pas effacer le coeficient doit être entier ou un chiffre à virgule");
            }
            


        }
    }
}
