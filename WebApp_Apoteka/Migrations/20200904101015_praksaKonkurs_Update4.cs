using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class praksaKonkurs_Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_konkursPraksa_Praksa_KonkursID",
                table: "konkursPraksa",
                column: "KonkursID",
                principalTable: "Praksa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_konkursPraksa_Praksa_KonkursID",
                table: "konkursPraksa");
        }
    }
}
