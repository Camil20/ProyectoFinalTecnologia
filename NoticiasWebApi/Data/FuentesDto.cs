using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasWebApi.Data
{
    public class FuentesDto
    {
        public int FuenteId { get; set; }
        [StringLength(100)]
        public string NombreFuente { get; set; }

    }
}
