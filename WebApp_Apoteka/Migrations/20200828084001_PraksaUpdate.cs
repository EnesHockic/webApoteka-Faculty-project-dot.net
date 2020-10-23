using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class PraksaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datumPrimanja",
                table: "onlineNarudzba");

            migrationBuilder.CreateTable(
                name: "Praksa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Uvod = table.Column<string>(nullable: true),
                    PozivOtvorenZa = table.Column<string>(nullable: true),
                    Rok = table.Column<DateTime>(nullable: false),
                    Pocetak = table.Column<DateTime>(nullable: false),
                    Trajanje = table.Column<string>(nullable: true),
                    Naknada = table.Column<string>(nullable: true),
                    RefundiraniPutniTroskovi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Praksa", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Praksa");

            migrationBuilder.AddColumn<DateTime>(
                name: "datumPrimanja",
                table: "onlineNarudzba",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
