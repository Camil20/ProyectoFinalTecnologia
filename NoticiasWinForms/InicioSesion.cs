using Docker.DotNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoticiasWinForms
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();

            //NoticiasClient client = new NoticiasClient();

            //var auth = client.Authenticate("admin", "admin1");
            //var auth = client.Authenticate(txtUsuario.Text, txtContrasena.Text);
        }

        public void Loggin()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44340/");

            string username = txtUsuario.Text;
            string password = txtContrasena.Text;

            var formData = new MultipartFormDataContent("Upload..." + DateTime.Now.ToString(CultureInfo.InvariantCulture));
            formData.Add(new StringContent(username), "nombreUsuario");
            formData.Add(new StringContent(password), "contrasena");

            var response = httpClient.PostAsync("/api/InicioSesion/authenticate", formData).Result;
            var responseTest = response.Content.ReadAsStringAsync().Result;


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseObject = JsonConvert.DeserializeObject<AuthResponse>(responseTest);

            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                MessageBox.Show("VALOR INVALIDO");

            }
            else
            {
                throw new ApplicationException("Internal Server Error");
            }

        }


        public class AuthResponse
        {
            public string token { get; set; }
            public int expires_in { get; set; }
        }


        public class NoticiasClient
        {
            static HttpClient httpClient = new HttpClient();

            public NoticiasClient()
            {
                httpClient.BaseAddress = new Uri("https://localhost:44340/");
            }
            //public void Authenticate(string username, string password)
            //{

            //    var formData = new MultipartFormDataContent("Upload..." + DateTime.Now.ToString(CultureInfo.InvariantCulture));
            //    formData.Add(new StringContent(username), "nombreUsuario");
            //    formData.Add(new StringContent(password), "contrasena");

            //    var response = httpClient.PostAsync("/api/InicioSesion/authenticate", formData).Result;
            //    var responseTest = response.Content.ReadAsStringAsync().Result;

            //    try
            //    {
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            var responseObject = JsonConvert.DeserializeObject<AuthResponse>(responseTest);


            //            MenuPrincipal menu = new MenuPrincipal();
            //            menu.ShowDialog();

            //            //return responseObject;
            //        }
            //        else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //        {
            //            MessageBox.Show("Valor inválido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            //throw new UnauthorizedAccessException("Login Invalid");
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        throw new ApplicationException("Internal Server Error");
                    
            //    }
            //}
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            //   Loggin();

            if (txtUsuario.Text.Length == 0 || txtContrasena.Text.Length == 0)
            {
                MessageBox.Show("Campos requeridos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            else
            {
                //NoticiasClient client = new NoticiasClient();
                
                //dm var auth = client.Authenticate("admin", "admin1");
                authentic(txtUsuario.Text,txtContrasena.Text);
            }
            
            
        }

        //private void Authenticate(string text1, string text2)
        //{
        //    throw new NotImplementedException();
        //}

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

       
    
    private void authentic(string username, string password)
        {

            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://localhost:44340/");
            var formData = new MultipartFormDataContent("Upload..." + DateTime.Now.ToString(CultureInfo.InvariantCulture));
            formData.Add(new StringContent(username), "nombreUsuario");
            formData.Add(new StringContent(password), "contrasena");
       
            var response = httpClient.PostAsync("/api/InicioSesion/authenticate", formData).Result;
            var responseTest = response.Content.ReadAsStringAsync().Result;

            try
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseObject = JsonConvert.DeserializeObject<AuthResponse>(responseTest);


                    MenuPrincipal menu = new MenuPrincipal();
                    menu.ShowDialog();

                    //return responseObject;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Valor inválido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //throw new UnauthorizedAccessException("Login Invalid");
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Internal Server Error");

            }
        
        }

        private void InicioSesion_Load_1(object sender, EventArgs e)
        {

        }
    }
}
           

