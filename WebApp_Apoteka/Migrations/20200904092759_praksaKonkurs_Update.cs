using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class praksaKonkurs_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GodinaZavrsetka",
                table: "konkursPraksa");

            migrationBuilder.DropColumn(
                name: "ImaRadnoIskustvo",
                table: "konkursPraksa");

            migrationBuilder.DropColumn(
                name: "RadnoIskustvo",
                table: "konkursPraksa");

            migrationBuilder.DropColumn(
                name: "ZavrsenaSkola",
                table: "konkursPraksa");

            migrationBuilder.AddColumn<string>(
                name: "CVpath",
                table: "konkursPraksa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MLpath",
                table: "konkursPraksa",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVpath",
                table: "konkursPraksa");

            migrationBuilder.DropColumn(
                name: "MLpath",
                table: "konkursPraksa");

            migrationBuilder.AddColumn<int>(
                name: "GodinaZavrsetka",
                table: "konkursPraksa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ImaRadnoIskustvo",
                table: "konkursPraksa",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RadnoIskustvo",
                table: "konkursPraksa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZavrsenaSkola",
                table: "konkursPraksa",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
