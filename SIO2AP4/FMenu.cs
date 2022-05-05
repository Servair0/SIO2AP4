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
    public partial class FMenu : Form
    {
        public FMenu()
        {
            InitializeComponent();
        }

        private void FMenu_Load(object sender, EventArgs e)
        {
            lblBienvenue.Text = "Bienvenue " + Modele.PersonneConnecte.prenom + " " + Modele.PersonneConnecte.nom;
            //Import des visites / Liste des visites
        }

        private void rapatriementVisiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Modele.VerifVisite())
            {
                // Initialise la variable de la messageBox
                string message = "Le rapatriement des visites va supprimer les anciennes données, voulez-vous vraiment faire cela ?";
                string caption = "Attention";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // affiche la messageBox
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (Modele.chargerlesVisites())
                    {
                        MessageBox.Show("Les visites ont bien chargé");
                    }
                    else
                    {
                        MessageBox.Show("Les visites ont mal chargé");
                    }
                }

            }
           
        }

        private void listeDesVisitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Modele.listeVisite().Count > 0) 
            {
                Form f = new FlisteV();
                f.Show();
            }
            else
            {
                MessageBox.Show("Il a aucune visite qui a été chargé");
            }
        }
    }
}
