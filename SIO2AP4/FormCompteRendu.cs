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
    public partial class FormCompteRendu : Form
    {
        public FormCompteRendu()
        {
            InitializeComponent();
        }

        private void FormCompteRendu_Load(object sender, EventArgs e)
        {
            visite V = Modele.Visitechoisi;
            txtNom.Text = V.patient1.personne.nom;
            txtPrenom.Text = V.patient1.personne.prenom;
            txtDate.Text=V.date_prevue.ToString();
            txtDurée.Text = V.duree.ToString();
            txtcompterendu.Text=V.compte_rendu_infirmiere;
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            Modele.ModifVisite(Dtpreel.Value, txtcompterendu.Text);
            Close();
            
        }
    }
}
