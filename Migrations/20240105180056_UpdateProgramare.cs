using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_aplicatieWeb.Migrations
{
    public partial class UpdateProgramare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPacient",
                table: "Programare");
        }

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
