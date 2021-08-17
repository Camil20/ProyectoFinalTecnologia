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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

      

        private void btnAutores_Click(object sender, EventArgs e)
        {

        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            GestionArticulos ga = new GestionArticulos();
            ga.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            GestionCategorias gc = new GestionCategorias();
            gc.ShowDialog();
        }
    }
}
