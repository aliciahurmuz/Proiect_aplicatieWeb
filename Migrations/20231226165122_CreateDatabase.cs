using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_aplicatieWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interventie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdSpecializare = table.Column<int>(type: "int", nullable: false),
                    SpecializareId = table.Column<int>(type: "int", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interventie_Specializare_SpecializareId",
                        column: x => x.SpecializareId,
                        principalTable: "Specializare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdSpecializare = table.Column<int>(type: "int", nullable: false),
                    SpecializareId = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medic_Specializare_SpecializareId",
                        column: x => x.SpecializareId,
                        principalTable: "Specializare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPacient = table.Column<int>(type: "int", nullable: false),
                    PacientId = table.Column<int>(type: "int", nullable: false),
                    IdMedic = table.Column<int>(type: "int", nullable: false),
                    MedicId = table.Column<int>(type: "int", nullable: false),
                    IdInterventie = table.Column<int>(type: "int", nullable: false),
                    InterventieId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programare_Interventie_InterventieId",
                        column: x => x.InterventieId,
                        principalTable: "Interventie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Programare_Medic_MedicId",
                        column: x => x.MedicId,
                        principalTable: "Medic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Programare_Pacient_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interventie_SpecializareId",
                table: "Interventie",
                column: "SpecializareId");

            migrationBuilder.CreateIndex(
                name: "IX_Medic_SpecializareId",
                table: "Medic",
                column: "SpecializareId");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_InterventieId",
                table: "Programare",
                column: "InterventieId");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_MedicId",
                table: "Programare",
                column: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_PacientId",
                table: "Programare",
                column: "PacientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");

            migrationBuilder.DropTable(
                name: "Interventie");

            migrationBuilder.DropTable(
                name: "Medic");

            migrationBuilder.DropTable(
                name: "Pacient");

            migrationBuilder.DropTable(
                name: "Specializare");
        }
    }
}
