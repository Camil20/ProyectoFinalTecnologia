using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoticiasWinForms
{
    class ArticuloDto1
    {
        public int ArticuloId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        
        public DateTime? FechaPublicacion { get; set; }
        public string Contenido { get; set; }
        public string NombreAutor { get; set; }
        public string NombreCategoria { get; set; }
        public string NombreFuente { get; set; }
        public string NombrePais { get; set; }
    }
}
