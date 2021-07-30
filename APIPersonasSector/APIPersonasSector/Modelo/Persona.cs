using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIPersonasSector.Modelo
{
    public class Persona
    {
        
        public int Id { get; set; }
        [Required]
        public  string nombre { get; set; }
        [Required]
        public DateTime fec_nacimiento { get; set; }
        [Required]
        public int SectorId { get; set; }
        [Required]
        public int ZonaId { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Sueldo { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual Zona Zona { get; set; }

    }
}
