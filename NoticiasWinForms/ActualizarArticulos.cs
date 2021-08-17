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
    public partial class ActualizarArticulos : Form
    {
        public ActualizarArticulos()
        {
            InitializeComponent();
        }

        private void ActualizarArticulos_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            GestionArticulos ga = new GestionArticulos();
            ga.ShowDialog();
        }
    }
}
