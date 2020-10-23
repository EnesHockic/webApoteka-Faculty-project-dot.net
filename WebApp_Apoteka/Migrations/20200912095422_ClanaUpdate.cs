using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class ClanaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naslov",
                table: "clanak",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sadrzaj",
                table: "clanak",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlikaPath",
                table: "clanak",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naslov",
                table: "clanak");

            migrationBuilder.DropColumn(
                name: "Sadrzaj",
                table: "clanak");

            migrationBuilder.DropColumn(
                name: "SlikaPath",
                table: "clanak");
        }
    }
}
