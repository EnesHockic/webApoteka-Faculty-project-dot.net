using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class UpdateV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kategorija",
                columns: table => new
                {
                    KategorijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKategorije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategorija", x => x.KategorijaID);
                });

            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tipKorisnika",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipKorisnika", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "usluga",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    DatumVrijeme = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    BrojPacijenata = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usluga", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lijek",
                columns: table => new
                {
                    LijekID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivLijeka = table.Column<string>(nullable: true),
                    InternacionalniGenerickiNaziv = table.Column<string>(nullable: true),
                    KvalitativniIKvantitativniSastav = table.Column<string>(nullable: true),
                    FarmaceutskiOblik = table.Column<string>(nullable: true),
                    NacinPrimjene = table.Column<string>(nullable: true),
                    NabavnaCijena = table.Column<double>(nullable: false),
                    ProdajnaCijena = table.Column<double>(nullable: false),
                    RokTrajanjaMjeseci = table.Column<int>(nullable: false),
                    NazivProizvodjaca = table.Column<string>(nullable: true),
                    SlikaLijeka = table.Column<string>(nullable: true),
                    KategorijaID = table.Column<int>(nullable: false),
                    DatumProizvodnje = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lijek", x => x.LijekID);
                    table.ForeignKey(
                        name: "FK_Lijek_kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "kategorija",
                        principalColumn: "KategorijaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apotekar",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(nullable: false),
                    MjestoRodjenjaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apotekar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Apotekar_Opstina_MjestoRodjenjaID",
                        column: x => x.MjestoRodjenjaID,
                        principalTable: "Opstina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dobavljac",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dobavljac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dobavljac_Opstina_GradID",
                        column: x => x.GradID,
                        principalTable: "Opstina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    OpstinaRodjenjaID = table.Column<int>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    TipKorisnikaID = table.Column<int>(nullable: false),
                    Bonovi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_korisnik_Opstina_OpstinaRodjenjaID",
                        column: x => x.OpstinaRodjenjaID,
                        principalTable: "Opstina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_korisnik_tipKorisnika_TipKorisnikaID",
                        column: x => x.TipKorisnikaID,
                        principalTable: "tipKorisnika",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: true),
                    ApotekarID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Apotekar_ApotekarID",
                        column: x => x.ApotekarID,
                        principalTable: "Apotekar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clanak",
                columns: table => new
                {
                    ClanakID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApotekarID = table.Column<string>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clanak", x => x.ClanakID);
                    table.ForeignKey(
                        name: "FK_clanak_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "konkursPraksa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<string>(nullable: true),
                    appUserId = table.Column<string>(nullable: true),
                    ZavrsenaSkola = table.Column<string>(nullable: true),
                    GodinaZavrsetka = table.Column<int>(nullable: false),
                    ImaRadnoIskustvo = table.Column<bool>(nullable: false),
                    RadnoIskustvo = table.Column<string>(nullable: true),
                    Prihvacena = table.Column<bool>(nullable: false),
                    Obrazlozenje = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_konkursPraksa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_konkursPraksa_AspNetUsers_appUserId",
                        column: x => x.appUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kosarica",
                columns: table => new
                {
                    KosaricaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<string>(nullable: true),
                    appUserId = table.Column<string>(nullable: true),
                    LijekID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kosarica", x => x.KosaricaID);
                    table.ForeignKey(
                        name: "FK_kosarica_Lijek_LijekID",
                        column: x => x.LijekID,
                        principalTable: "Lijek",
                        principalColumn: "LijekID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kosarica_AspNetUsers_appUserId",
                        column: x => x.appUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nabavka",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApotekarID = table.Column<string>(nullable: true),
                    datum = table.Column<DateTime>(nullable: false),
                    vrijednostNarudzbe = table.Column<double>(nullable: false),
                    statusNarudzbe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nabavka", x => x.ID);
                    table.ForeignKey(
                        name: "FK_nabavka_AspNetUsers_ApotekarID",
                        column: x => x.ApotekarID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "onlineNarudzba",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikID = table.Column<string>(nullable: true),
                    datum = table.Column<DateTime>(nullable: false),
                    vrijednostNarudzbe = table.Column<double>(nullable: false),
                    cijenaDostave = table.Column<double>(nullable: false),
                    gradDostaveID = table.Column<int>(nullable: false),
                    adresaDostave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_onlineNarudzba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_onlineNarudzba_Opstina_gradDostaveID",
                        column: x => x.gradDostaveID,
                        principalTable: "Opstina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_onlineNarudzba_AspNetUsers_korisnikID",
                        column: x => x.korisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rezervacijaTermina",
                columns: table => new
                {
                    UslugaID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<string>(nullable: false),
                    DatumVrijemeRezervacije = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervacijaTermina", x => new { x.KorisnikID, x.UslugaID });
                    table.ForeignKey(
                        name: "FK_rezervacijaTermina_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rezervacijaTermina_usluga_UslugaID",
                        column: x => x.UslugaID,
                        principalTable: "usluga",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stavkaNabavke",
                columns: table => new
                {
                    NabavkaID = table.Column<int>(nullable: false),
                    LijekID = table.Column<int>(nullable: false),
                    NabavnaCijenaLijeka = table.Column<double>(nullable: false),
                    kolicina = table.Column<int>(nullable: false),
                    ukupnaCijenaStavke = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stavkaNabavke", x => new { x.NabavkaID, x.LijekID });
                    table.ForeignKey(
                        name: "FK_stavkaNabavke_Lijek_LijekID",
                        column: x => x.LijekID,
                        principalTable: "Lijek",
                        principalColumn: "LijekID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stavkaNabavke_nabavka_NabavkaID",
                        column: x => x.NabavkaID,
                        principalTable: "nabavka",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detaljiOnlineNarudzbe",
                columns: table => new
                {
                    onlineNarudzbaID = table.Column<int>(nullable: false),
                    lijekID = table.Column<int>(nullable: false),
                    cijenaLijeka = table.Column<double>(nullable: false),
                    kolicina = table.Column<int>(nullable: false),
                    popust = table.Column<double>(nullable: false),
                    ukupnaCijenaStavke = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detaljiOnlineNarudzbe", x => new { x.lijekID, x.onlineNarudzbaID });
                    table.ForeignKey(
                        name: "FK_detaljiOnlineNarudzbe_Lijek_lijekID",
                        column: x => x.lijekID,
                        principalTable: "Lijek",
                        principalColumn: "LijekID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detaljiOnlineNarudzbe_onlineNarudzba_onlineNarudzbaID",
                        column: x => x.onlineNarudzbaID,
                        principalTable: "onlineNarudzba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apotekar_MjestoRodjenjaID",
                table: "Apotekar",
                column: "MjestoRodjenjaID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApotekarID",
                table: "AspNetUsers",
                column: "ApotekarID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KorisnikID",
                table: "AspNetUsers",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_clanak_AppUserId",
                table: "clanak",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_detaljiOnlineNarudzbe_onlineNarudzbaID",
                table: "detaljiOnlineNarudzbe",
                column: "onlineNarudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_dobavljac_GradID",
                table: "dobavljac",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_konkursPraksa_appUserId",
                table: "konkursPraksa",
                column: "appUserId");

            migrationBuilder.CreateIndex(
                name: "IX_korisnik_OpstinaRodjenjaID",
                table: "korisnik",
                column: "OpstinaRodjenjaID");

            migrationBuilder.CreateIndex(
                name: "IX_korisnik_TipKorisnikaID",
                table: "korisnik",
                column: "TipKorisnikaID");

            migrationBuilder.CreateIndex(
                name: "IX_kosarica_LijekID",
                table: "kosarica",
                column: "LijekID");

            migrationBuilder.CreateIndex(
                name: "IX_kosarica_appUserId",
                table: "kosarica",
                column: "appUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lijek_KategorijaID",
                table: "Lijek",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_nabavka_ApotekarID",
                table: "nabavka",
                column: "ApotekarID");

            migrationBuilder.CreateIndex(
                name: "IX_onlineNarudzba_gradDostaveID",
                table: "onlineNarudzba",
                column: "gradDostaveID");

            migrationBuilder.CreateIndex(
                name: "IX_onlineNarudzba_korisnikID",
                table: "onlineNarudzba",
                column: "korisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacijaTermina_UslugaID",
                table: "rezervacijaTermina",
                column: "UslugaID");

            migrationBuilder.CreateIndex(
                name: "IX_stavkaNabavke_LijekID",
                table: "stavkaNabavke",
                column: "LijekID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "clanak");

            migrationBuilder.DropTable(
                name: "detaljiOnlineNarudzbe");

            migrationBuilder.DropTable(
                name: "dobavljac");

            migrationBuilder.DropTable(
                name: "konkursPraksa");

            migrationBuilder.DropTable(
                name: "kosarica");

            migrationBuilder.DropTable(
                name: "rezervacijaTermina");

            migrationBuilder.DropTable(
                name: "stavkaNabavke");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "onlineNarudzba");

            migrationBuilder.DropTable(
                name: "usluga");

            migrationBuilder.DropTable(
                name: "Lijek");

            migrationBuilder.DropTable(
                name: "nabavka");

            migrationBuilder.DropTable(
                name: "kategorija");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Apotekar");

            migrationBuilder.DropTable(
                name: "korisnik");

            migrationBuilder.DropTable(
                name: "Opstina");

            migrationBuilder.DropTable(
                name: "tipKorisnika");
        }
    }
}
