using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_aplicatieWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProgramare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPacient",
                table: "Programare");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPacient",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
