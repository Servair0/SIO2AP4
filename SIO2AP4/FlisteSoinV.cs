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
    public partial class FlisteSoinV : Form
    {
        public FlisteSoinV()
        {
            InitializeComponent();
        }

        private void FlisteSoinV_Load(object sender, EventArgs e)
        {
            bsSoinVisite.DataSource = Modele.listesoinsV();
            dgvSoins.DataSource = bsSoinVisite;
            dgvSoins.Columns[0].Visible = false;
        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            Modele.Action = 0;

            Modele.Lock = 0;

            Form f = new FAjoutModif();
            f.Show();
            Close();
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if ((short)bsSoinVisite.Current.GetType().GetProperty("prevu").GetValue(bsSoinVisite.Current, null) == 0)
            {
                Modele.Action = 1;

                Modele.Lock = 0;

                System.Type type = bsSoinVisite.Current.GetType();
                Modele.ChoisiSoins = Modele.Getsoins_visitebyid((int)type.GetProperty("id_soins").GetValue(bsSoinVisite.Current, null));
                Form f = new FAjoutModif();
                f.Show();
                Close();
            }
            else
            {
                Modele.Action = 1;
                Modele.Lock = 1;
                System.Type type = bsSoinVisite.Current.GetType();
                Modele.ChoisiSoins = Modele.Getsoins_visitebyid((int)type.GetProperty("id_soins").GetValue(bsSoinVisite.Current, null));
                Form f = new FAjoutModif();
                f.Show();
                Close();
            }
          
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            if ((short)bsSoinVisite.Current.GetType().GetProperty("prevu").GetValue(bsSoinVisite.Current, null) == 0)
            {
                Modele.Action = 1;
                System.Type type = bsSoinVisite.Current.GetType();
                Modele.ChoisiSoins = Modele.Getsoins_visitebyid((int)type.GetProperty("id_soins").GetValue(bsSoinVisite.Current, null));
                Modele.Supp();
                bsSoinVisite.DataSource = Modele.listesoinsV();

            }
            else
            {
                MessageBox.Show("Vous ne pouvez pas effacer ce soin");
            }
        }
    }
}
