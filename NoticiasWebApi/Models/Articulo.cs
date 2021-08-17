using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NoticiasWebApi.Models
{
    [Table("ARTICULOS")]
    public partial class Articulo
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaPublicacion { get; set; }
        public string Contenido { get; set; }
        public int? AutorId { get; set; }
        public int? CategoriaId { get; set; }
        public int? PaisId { get; set; }
        public int? FuenteId { get; set; }

        [ForeignKey(nameof(AutorId))]
        [InverseProperty(nameof(Autore.Articulos))]
        public virtual Autore Autor { get; set; }
        [ForeignKey(nameof(CategoriaId))]
        [InverseProperty("Articulos")]
        public virtual Categoria Categoria { get; set; }
        [ForeignKey(nameof(FuenteId))]
        [InverseProperty("Articulos")]
        public virtual Fuente Fuente { get; set; }
        [ForeignKey(nameof(PaisId))]
        [InverseProperty(nameof(Paise.Articulos))]
        public virtual Paise Pais { get; set; }
    }
}
