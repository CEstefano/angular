using appTarjeta.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appTarjeta
{
    //mapaear modelo con la base de datos : Sintaxis : = DBset <Modeloclase> Nombre de la base de g¡datos{get : dset}
    public class AplicationDbContext : DbContext
    {
        public DbSet<TarjetaCredito> TarjetaCredito { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
