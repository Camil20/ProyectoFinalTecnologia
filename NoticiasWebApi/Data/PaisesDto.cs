using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasWebApi.Data
{
    public class PaisesDto
    {
        public int PaisId { get; set; }
        [StringLength(100)]
        public string NombrePais { get; set; }

    }
}
