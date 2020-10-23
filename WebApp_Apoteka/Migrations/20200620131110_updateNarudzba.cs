using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class updateNarudzba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datum",
                table: "onlineNarudzba");

            migrationBuilder.AddColumn<DateTime>(
                name: "datumNarudzbe",
                table: "onlineNarudzba",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "datumPrimanja",
                table: "onlineNarudzba",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "datumSlanja",
                table: "onlineNarudzba",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "statusNarudzbe",
                table: "onlineNarudzba",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datumNarudzbe",
                table: "onlineNarudzba");

            migrationBuilder.DropColumn(
                name: "datumPrimanja",
                table: "onlineNarudzba");

            migrationBuilder.DropColumn(
                name: "datumSlanja",
                table: "onlineNarudzba");

            migrationBuilder.DropColumn(
                name: "statusNarudzbe",
                table: "onlineNarudzba");

            migrationBuilder.AddColumn<DateTime>(
                name: "datum",
                table: "onlineNarudzba",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
