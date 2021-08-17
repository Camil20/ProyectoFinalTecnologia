using Newtonsoft.Json;
using NoticiasWebApi.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoticiasWinForms
{
    public partial class ConsultarCategorias : Form
    {
        string url = "https://localhost:44340/api/Categorias";

        static HttpClient httpClient = new HttpClient();
        List<CategoriasDto> Categories;
        public ConsultarCategorias()
        {
            InitializeComponent();
        }

        private async Task<string> GetHttp()
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            StreamReader stream = new StreamReader(response.GetResponseStream());

            return await stream.ReadToEndAsync();
        }

        private async Task<List<CategoriasDto>> GetCategories()
        {
            string response = await GetHttp();

            Categories = JsonConvert.DeserializeObject<List<CategoriasDto>>(response);

            return Categories;
        }
        private async void LoadDtg()
        {
            await GetCategories();

            var list = (from a in Categories
                        where a.NombreCategoria.ToLower().Contains(txtBuscar.Text.ToLower())
                        select new
                        {
                            CategoriaId = a.CategoriaId,
                            Nombre = a.NombreCategoria                   
                        }).ToList();

            dtgConsultarCtg.DataSource = list;
            dtgConsultarCtg.Columns[0].Visible = false;
        }
        private void ConsultarCategoriascs_Load(object sender, EventArgs e)
        {
            LoadDtg();
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            LoadDtg();
        }
    }
}
