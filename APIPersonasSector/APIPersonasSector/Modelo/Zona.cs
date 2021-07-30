using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIPersonasSector.Modelo
{
    public class Zona
    {

        public int Id { get; set; }
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
        [Required]
        public string des_zona { get; set; }

    }
}
