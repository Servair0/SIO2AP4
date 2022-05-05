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
    public partial class FlisteV : Form
    {
        public FlisteV()
        {
            InitializeComponent();
        }

        private void FlisteV_Load(object sender, EventArgs e)
        {
            //Modele.listeVisite();
            bsVisite.DataSource = Modele.listeVUP();
            dgvVisite.DataSource = bsVisite;
            dgvVisite.Columns[0].Visible = false;
            dgvVisite.Columns[1].Visible = false;
        }

        private void btnCompteRendu_Click(object sender, EventArgs e)
        {
            
            System.Type type = bsVisite.Current.GetType();
            Modele.Visitechoisi = Modele.GetVisitebyid((int)type.GetProperty("id").GetValue(bsVisite.Current, null));
            Form f = new FormCompteRendu();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Type type = bsVisite.Current.GetType();
            Modele.Visitechoisi = Modele.GetVisitebyid((int)type.GetProperty("id").GetValue(bsVisite.Current, null));
            Form f = new FlisteSoinV();
            f.Show();
        }
    }
}
