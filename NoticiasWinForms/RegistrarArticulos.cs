using Newtonsoft.Json;
using NoticiasWebApi.Data;
using NoticiasWebApi.Models;
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
    public partial class RegistrarArticulos : Form
    {
        static readonly HttpClient httpClient = new HttpClient();


        public RegistrarArticulos()
        {
            InitializeComponent();

            httpClient.BaseAddress = new Uri("https://localhost:44340/");
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            //GestionArticulos ga = new GestionArticulos();
            //ga.ShowDialog();
        }

        private async Task<string> GetHttpArticulos()
        {
            WebRequest request = WebRequest.Create("https://localhost:44340/api/Articulos");
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async Task<string> GetHttpAutores()
        {
            WebRequest request = WebRequest.Create("https://localhost:44340/api/Autores");
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async Task<string> GetHttpCategorias()
        {
            WebRequest request = WebRequest.Create("https://localhost:44340/api/Categorias");
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return await sr.ReadToEndAsync();
        }


        private async Task<string> GetHttpFuentes()
        {
            WebRequest request = WebRequest.Create("https://localhost:44340/api/Fuentes");
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async Task<string> GetHttpPaises()
        {
            WebRequest request = WebRequest.Create("https://localhost:44340/api/Paises");
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return await sr.ReadToEndAsync();
        }



        private async void Autores()
        {
            string res = await GetHttpAutores();

            List<AutoresDto> ListAutores = JsonConvert.DeserializeObject<List<AutoresDto>>(res);

            var objAutor = new AutoresDto { AutorId = 0, NombreAutor = "Seleccionar" };
            ListAutores.Insert(0, objAutor);

            cbxAutor.DataSource = ListAutores;
            cbxAutor.DisplayMember = "NombreAutor";
            cbxAutor.ValueMember = "AutorId";

        }


        private async void Categorias()
        {
            string res = await GetHttpCategorias();

            List<CategoriasDto> ListCategorias = JsonConvert.DeserializeObject<List<CategoriasDto>>(res);

            var objCategoria = new CategoriasDto { CategoriaId = 0, NombreCategoria = "Seleccionar" };
            ListCategorias.Insert(0, objCategoria);

            cbxCategoria.DataSource = ListCategorias;
            cbxCategoria.DisplayMember = "NombreCategoria";
            cbxCategoria.ValueMember = "CategoriaId";

        }


        private async void Fuentes()
        {
            string res = await GetHttpFuentes();

            List<FuentesDto> ListFuentes = JsonConvert.DeserializeObject<List<FuentesDto>>(res);

            var objFuentes = new FuentesDto { FuenteId = 0, NombreFuente = "Seleccionar" };
            ListFuentes.Insert(0, objFuentes);

            cbxFuente.DataSource = ListFuentes;
            cbxFuente.DisplayMember = "NombreFuente";
            cbxFuente.ValueMember = "FuenteId";

        }


        private async void Paises()
        {
            string res = await GetHttpPaises();

            List<PaisesDto> ListPais = JsonConvert.DeserializeObject<List<PaisesDto>>(res);

            var objPaises = new PaisesDto { PaisId = 0, NombrePais = "Seleccionar" };
            ListPais.Insert(0, objPaises);

            cbxPais.DataSource = ListPais;
            cbxPais.DisplayMember = "NombrePais";
            cbxPais.ValueMember = "PaisId";
        }


        private void RegistrarArticulos_Load(object sender, EventArgs e)
        {
            Autores();
            Categorias();
            Fuentes();
            Paises();
        }

        void Clear()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            cbxAutor.SelectedIndex = 0;
            cbxCategoria.SelectedIndex = 0;
            cbxFuente.SelectedIndex = 0;
            cbxPais.SelectedIndex = 0;
        }

        private void Add()
        {
            var articles = new Articulo
            {

                Titulo = txtTitulo.Text,
                Descripcion = txtDescripcion.Text,
                Contenido = txtContenido.Text,
                Url = txtUrl.Text,
                UrlToImage = txtUrlToImage.Text,
                FechaPublicacion = DateTime.Now,
                AutorId = cbxAutor.SelectedIndex,
                CategoriaId = cbxCategoria.SelectedIndex,
                FuenteId = cbxFuente.SelectedIndex,
                PaisId = cbxPais.SelectedIndex

            };

            if (txtTitulo.Text.Length == 0 || txtDescripcion.Text.Length == 0)
            {
                MessageBox.Show("Campos requeridos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtContenido.Text.Length == 0)
            {
                MessageBox.Show("Campos requeridos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string json = JsonConvert.SerializeObject(articles);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync("/api/Articulos", content).Result;

                if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show("Artículo insertado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("¡Error al insertar el artìculo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Add();
            Clear();

        }
    }
}
