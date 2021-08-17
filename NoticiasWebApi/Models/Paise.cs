using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NoticiasWebApi.Models
{
    [Table("PAISES")]
    public partial class Paise
    {
        public Paise()
        {
            Articulos = new HashSet<Articulo>();
        }

        [Key]
        public int PaisId { get; set; }
        [StringLength(100)]
        public string NombrePais { get; set; }

        [InverseProperty(nameof(Articulo.Pais))]
        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
