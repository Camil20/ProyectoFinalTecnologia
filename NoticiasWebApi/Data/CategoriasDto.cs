using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasWebApi.Data
{
    public class CategoriasDto
    {
        public int CategoriaId { get; set; }
        [StringLength(100)]
        public string NombreCategoria { get; set; }
    }
}
