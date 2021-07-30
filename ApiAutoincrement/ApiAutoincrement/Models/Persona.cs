using System;
using System.Collections.Generic;

namespace ApiAutoincrement.Models
{
    public partial class Persona
    {
        public int CodPersona { get; set; }
        public string NomPersona { get; set; }
        public DateTime FecNacimiento { get; set; }
        public int? CodSector { get; set; }
        public int? CodZona { get; set; }
        public decimal Sueldo { get; set; }
        public virtual Sector CodSectorNavigation { get; set; }
        public virtual Zona CodZonaNavigation { get; set; }
    }
}
