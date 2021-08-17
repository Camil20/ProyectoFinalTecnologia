using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NoticiasWebApi.Models
{
    [Table("FUENTES")]
    public partial class Fuente
    {
        public Fuente()
        {
            Articulos = new HashSet<Articulo>();
        }

        [Key]
        public int FuenteId { get; set; }
        [StringLength(100)]
        public string NombreFuente { get; set; }

        [InverseProperty(nameof(Articulo.Fuente))]
        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
