using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class praksaKonkursUpdateV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naknada",
                table: "Praksa");

            migrationBuilder.DropColumn(
                name: "Pocetak",
                table: "Praksa");

            migrationBuilder.DropColumn(
                name: "PozivOtvorenZa",
                table: "Praksa");

            migrationBuilder.DropColumn(
                name: "RefundiraniPutniTroskovi",
                table: "Praksa");

            migrationBuilder.DropColumn(
                name: "Trajanje",
                table: "Praksa");

            migrationBuilder.DropColumn(
                name: "Uvod",
                table: "Praksa");

            migrationBuilder.AddColumn<string>(
                name: "Sadrzaj",
                table: "Praksa",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sadrzaj",
                table: "Praksa");

            migrationBuilder.AddColumn<string>(
                name: "Naknada",
                table: "Praksa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Pocetak",
                table: "Praksa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PozivOtvorenZa",
                table: "Praksa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefundiraniPutniTroskovi",
                table: "Praksa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trajanje",
                table: "Praksa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uvod",
                table: "Praksa",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
