using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasWebApi.Data
{
    public class AutoresDto
    {
        public int AutorId { get; set; }
        [StringLength(100)]
        public string NombreAutor { get; set; }
    }
}
