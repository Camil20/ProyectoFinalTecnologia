using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoticiasWinForms
{
    public partial class GestionArticulos : Form
    {
        public GestionArticulos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuPrincipal mp = new MenuPrincipal();
            mp.ShowDialog();
        }

        private void btnRegistrarArticulo_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrarArticulos ra = new RegistrarArticulos();
            ra.ShowDialog();

                
        }

        private void GestionArticulos_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultarArticulo_Click(object sender, EventArgs e)
        {
            ConsultarArticulos ca = new ConsultarArticulos();
            ca.ShowDialog();
        }

        private void btnActualizarArticulo_Click(object sender, EventArgs e)
        {
            ActualizarArticulos aa = new ActualizarArticulos();
            aa.ShowDialog();
        }
    }
}
