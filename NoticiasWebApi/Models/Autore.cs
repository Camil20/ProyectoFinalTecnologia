using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NoticiasWebApi.Models
{
    [Table("AUTORES")]
    public partial class Autore
    {
        public Autore()
        {
            Articulos = new HashSet<Articulo>();
        }

        [Key]
        public int AutorId { get; set; }
        [StringLength(100)]
        public string NombreAutor { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        [InverseProperty("Autores")]
        public virtual Usuario Usuario { get; set; }
        [InverseProperty(nameof(Articulo.Autor))]
        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
