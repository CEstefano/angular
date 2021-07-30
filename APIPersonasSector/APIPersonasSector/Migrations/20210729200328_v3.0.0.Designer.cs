﻿// <auto-generated />
using System;
using APIPersonasSector;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIPersonasSector.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20210729200328_v3.0.0")]
    partial class v300
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIPersonasSector.Modelo.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SectorId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Sueldo")
                        .IsRequired()
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ZonaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fec_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.HasIndex("ZonaId");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("APIPersonasSector.Modelo.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("des_sector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("APIPersonasSector.Modelo.Zona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SectorId")
                        .HasColumnType("int");

                    b.Property<string>("des_zona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.ToTable("Zona");
                });

            modelBuilder.Entity("APIPersonasSector.Modelo.Persona", b =>
                {
                    b.HasOne("APIPersonasSector.Modelo.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("APIPersonasSector.Modelo.Zona", "Zona")
                        .WithMany()
                        .HasForeignKey("ZonaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sector");

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("APIPersonasSector.Modelo.Zona", b =>
                {
                    b.HasOne("APIPersonasSector.Modelo.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sector");
                });
#pragma warning restore 612, 618
        }
    }
}