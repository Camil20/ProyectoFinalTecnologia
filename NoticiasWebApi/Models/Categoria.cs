using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NoticiasWebApi.Models
{
    [Table("CATEGORIAS")]
    public partial class Categoria
    {
        public Categoria()
        {
            Articulos = new HashSet<Articulo>();
        }

        [Key]
        public int CategoriaId { get; set; }
        [StringLength(100)]
        public string NombreCategoria { get; set; }

        [InverseProperty(nameof(Articulo.Categoria))]
        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
