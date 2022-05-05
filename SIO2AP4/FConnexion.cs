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
    public partial class FConnexion : Form
    {
        public FConnexion()
        {
            InitializeComponent();

        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            /*Test id: LMartine mdp:password
                   id: Mdebrand mdp:1234
            */
            if(Modele.VerifLocal(txtlogin.Text,txtmdp.Text))
            {


                MessageBox.Show("Identification réussie en local");
                System.Threading.Thread x = new System.Threading.Thread(new System.Threading.ThreadStart(threadProc));
                x.Start();
                this.Close();
            }
            else
            {
                if (Modele.VerifWeb(txtlogin.Text, txtmdp.Text))
                {
                    MessageBox.Show("Identification réussie en web");
                    System.Threading.Thread x = new System.Threading.Thread(new System.Threading.ThreadStart(threadProc));
                    x.Start();
                    this.Close();
                }
                else 
                { 
                    MessageBox.Show("Identification refusée local et web"); 
                }
            }
        }
        public static void threadProc()
        {
            Application.Run(new FMenu());
        }
        private void FConnexion_Load(object sender, EventArgs e)
        {
            txtmdp.PasswordChar = 'x';
        }
    }
}
