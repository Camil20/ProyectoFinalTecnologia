
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasWebApi.Data
{
    public class ArticulosDto
    {
        public int ArticuloId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaPublicacion { get; set; }
        public string Contenido { get; set; }
        public string NombreAutor { get; set; }
        public string NombreCategoria { get; set; }
        public string NombreFuente { get; set; }
        public string NombrePais { get; set; }

    }
}
