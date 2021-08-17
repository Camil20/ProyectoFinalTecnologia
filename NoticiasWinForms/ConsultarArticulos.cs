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
    public partial class ConsultarArticulos : Form
    {
        string url = "https://localhost:44340/api/Articulos";

        static HttpClient httpClient = new HttpClient();
        List<ArticulosDto> Articles;
        public ConsultarArticulos()
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

        private async Task<List<ArticulosDto>> GetArticles()
        {
            string response = await GetHttp();

            Articles = JsonConvert.DeserializeObject<List<ArticulosDto>>(response);

            return Articles;
        }

        private async void LoadDtg()
        {
            await GetArticles();

            var list = (from a in Articles
                        where a.Titulo.ToLower().Contains(txtBuscar.Text.ToLower())
                        select new
                        {
                            IdArticulo = a.ArticuloId,                      
                            Titulo = a.Titulo,
                            Descripcion = a.Descripcion,
                            Contenido = a.Contenido,
                            Url = a.Url,
                            UrlImagen = a.UrlToImage,
                            Fecha_Publicacion = a.FechaPublicacion,
                            Nombre_Autor = a.NombreAutor,
                            Nombre_Categoria = a.NombreCategoria,
                            Nombre_Pais = a.NombrePais,
                            Nombre_Fuente = a.NombreFuente,
                        }).ToList();

            dtgConsultar.DataSource = list;
            dtgConsultar.Columns[0].Visible = false;
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
        //    LoadDtg();
        }

        private void Consultar_Load(object sender, EventArgs e)
        {
            LoadDtg();
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            LoadDtg();
        }
    }
}
