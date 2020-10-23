using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class praksaKonkurs_Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_konkursPraksa_AspNetUsers_appUserId",
                table: "konkursPraksa");

            migrationBuilder.DropIndex(
                name: "IX_konkursPraksa_appUserId",
                table: "konkursPraksa");

            migrationBuilder.DropColumn(
                name: "appUserId",
                table: "konkursPraksa");

            migrationBuilder.CreateIndex(
                name: "IX_konkursPraksa_KorisnikID",
                table: "konkursPraksa",
                column: "KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_konkursPraksa_AspNetUsers_KorisnikID",
                table: "konkursPraksa",
                column: "KorisnikID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_konkursPraksa_AspNetUsers_KorisnikID",
                table: "konkursPraksa");

            migrationBuilder.DropIndex(
                name: "IX_konkursPraksa_KorisnikID",
                table: "konkursPraksa");

            migrationBuilder.AddColumn<string>(
                name: "appUserId",
                table: "konkursPraksa",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_konkursPraksa_appUserId",
                table: "konkursPraksa",
                column: "appUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_konkursPraksa_AspNetUsers_appUserId",
                table: "konkursPraksa",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
