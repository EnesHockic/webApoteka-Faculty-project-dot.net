using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class updateLijeka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumProizvodnje",
                table: "Lijek");

            migrationBuilder.DropColumn(
                name: "InternacionalniGenerickiNaziv",
                table: "Lijek");

            migrationBuilder.DropColumn(
                name: "SlikaLijeka",
                table: "Lijek");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumDodavanjaUPromet",
                table: "Lijek",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "Lijek",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumDodavanjaUPromet",
                table: "Lijek");

            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Lijek");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumProizvodnje",
                table: "Lijek",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InternacionalniGenerickiNaziv",
                table: "Lijek",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlikaLijeka",
                table: "Lijek",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
