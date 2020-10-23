using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class praksaKonkurs_Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_konkursPraksa",
                table: "konkursPraksa");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "konkursPraksa");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikID",
                table: "konkursPraksa",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KonkursID",
                table: "konkursPraksa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_konkursPraksa",
                table: "konkursPraksa",
                columns: new[] { "KonkursID", "KorisnikID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_konkursPraksa",
                table: "konkursPraksa");

            migrationBuilder.DropColumn(
                name: "KonkursID",
                table: "konkursPraksa");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikID",
                table: "konkursPraksa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "konkursPraksa",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_konkursPraksa",
                table: "konkursPraksa",
                column: "ID");
        }
    }
}
