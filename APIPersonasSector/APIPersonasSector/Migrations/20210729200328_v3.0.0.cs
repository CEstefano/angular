using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIPersonasSector.Migrations
{
    public partial class v300 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    des_sector = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    des_zona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zona_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fec_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    ZonaId = table.Column<int>(type: "int", nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Zona_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_SectorId",
                table: "Persona",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ZonaId",
                table: "Persona",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zona_SectorId",
                table: "Zona",
                column: "SectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Zona");

            migrationBuilder.DropTable(
                name: "Sector");
        }
    }
}
