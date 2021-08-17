using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NoticiasWebApi.Models
{
    [Table("USUARIOS")]
    public partial class Usuario
    {
        public Usuario()
        {
            Autores = new HashSet<Autore>();
        }

        [Key]
        public int UsuarioId { get; set; }
        [StringLength(250)]
        public string NombreCompleto { get; set; }
        [StringLength(50)]
        public string NombreUsuario { get; set; }
        [StringLength(400)]
        public string Contrasena { get; set; }

        [InverseProperty(nameof(Autore.Usuario))]
        public virtual ICollection<Autore> Autores { get; set; }
    }
}
