using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiPruebaPoblacion.Models
{
    public partial class PoblacionContext : DbContext
    {
        public PoblacionContext()
        {
        }

        public PoblacionContext(DbContextOptions<PoblacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Zona> Zonas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Poblacion; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.CodPersona)
                    .HasName("PK__Alumnos__40188ACAF24FC49B");

                entity.ToTable("persona");

                entity.Property(e => e.CodPersona)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_persona");

                entity.Property(e => e.CodSector).HasColumnName("cod_sector");

                entity.Property(e => e.CodZona).HasColumnName("cod_zona");

                entity.Property(e => e.FecNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fec_nacimiento");

                entity.Property(e => e.NomPersona)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("nom_persona");

                entity.Property(e => e.Sueldo)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("sueldo");

                entity.HasOne(d => d.CodSectorNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.CodSector)
                    .HasConstraintName("fk_cod_sector");

                entity.HasOne(d => d.CodZonaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.CodZona)
                    .HasConstraintName("fk_zona");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.HasKey(e => e.CodSector)
                    .HasName("PK__sector__01C0D73CA52864E1");

                entity.ToTable("sector");

                entity.Property(e => e.CodSector)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_sector");

                entity.Property(e => e.DesSector)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("des_sector");
            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.HasKey(e => e.CodZona)
                    .HasName("PK__zona__88D8775722BD451D");

                entity.ToTable("zona");

                entity.Property(e => e.CodZona)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_zona");

                entity.Property(e => e.CodSector).HasColumnName("cod_sector");

                entity.Property(e => e.DesZona)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("des_zona");

                entity.HasOne(d => d.CodSectorNavigation)
                    .WithMany(p => p.Zonas)
                    .HasForeignKey(d => d.CodSector)
                    .HasConstraintName("FK__zona__cod_sector__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
