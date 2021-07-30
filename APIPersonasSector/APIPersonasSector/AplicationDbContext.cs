using APIPersonasSector.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPersonasSector
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Sector> Sector { get; set; }
        public DbSet<Zona> Zona { get; set; }
        public DbSet<Persona> Persona { get; set; }
        
        
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }
    }
}
