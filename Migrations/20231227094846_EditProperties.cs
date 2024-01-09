using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_aplicatieWeb.Migrations
{
    public partial class EditProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdInterventie",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "IdMedic",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "IdSpecializare",
                table: "Medic");

            migrationBuilder.DropColumn(
                name: "IdSpecializare",
                table: "Interventie");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdInterventie",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMedic",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSpecializare",
                table: "Medic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSpecializare",
                table: "Interventie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
