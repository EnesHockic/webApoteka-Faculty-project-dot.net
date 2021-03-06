﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp_Apoteka.Entity_Framework;

namespace WebApp_Apoteka.Migrations
{
    [DbContext(typeof(MojDbContext))]
    [Migration("20200913092022_ClanakAddDatmObjave")]
    partial class ClanakAddDatmObjave
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Apoteka.Models.Apotekar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MjestoRodjenjaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MjestoRodjenjaID");

                    b.ToTable("Apotekar");
                });

            modelBuilder.Entity("Apoteka.Models.Opstina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Opstina");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("ApotekarID")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("ApotekarID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Clanak", b =>
                {
                    b.Property<int>("ClanakID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApotekarID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClanakID");

                    b.HasIndex("AppUserId");

                    b.ToTable("clanak");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.DetaljiOnlineNarudzbe", b =>
                {
                    b.Property<int>("lijekID")
                        .HasColumnType("int");

                    b.Property<int>("onlineNarudzbaID")
                        .HasColumnType("int");

                    b.Property<double>("cijenaLijeka")
                        .HasColumnType("float");

                    b.Property<int>("kolicina")
                        .HasColumnType("int");

                    b.Property<double>("popust")
                        .HasColumnType("float");

                    b.Property<double>("ukupnaCijenaStavke")
                        .HasColumnType("float");

                    b.HasKey("lijekID", "onlineNarudzbaID");

                    b.HasIndex("onlineNarudzbaID");

                    b.ToTable("detaljiOnlineNarudzbe");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Dobavljac", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("GradID");

                    b.ToTable("dobavljac");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Kategorija", b =>
                {
                    b.Property<int>("KategorijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivKategorije")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategorijaID");

                    b.ToTable("kategorija");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.KonkursPraksa", b =>
                {
                    b.Property<int>("KonkursID")
                        .HasColumnType("int");

                    b.Property<string>("KorisnikID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CVpath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MLpath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Obrazlozenje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Prihvacena")
                        .HasColumnType("bit");

                    b.HasKey("KonkursID", "KorisnikID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("konkursPraksa");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Bonovi")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpstinaRodjenjaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipKorisnikaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OpstinaRodjenjaID");

                    b.HasIndex("TipKorisnikaID");

                    b.ToTable("korisnik");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Kosarica", b =>
                {
                    b.Property<int>("KosaricaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KorisnikID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LijekID")
                        .HasColumnType("int");

                    b.Property<string>("appUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("kolicina")
                        .HasColumnType("int");

                    b.HasKey("KosaricaID");

                    b.HasIndex("LijekID");

                    b.HasIndex("appUserId");

                    b.ToTable("kosarica");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Lijek", b =>
                {
                    b.Property<int>("LijekID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumDodavanjaUPromet")
                        .HasColumnType("datetime2");

                    b.Property<string>("FarmaceutskiOblik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("KvalitativniIKvantitativniSastav")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NabavnaCijena")
                        .HasColumnType("float");

                    b.Property<string>("NacinPrimjene")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivLijeka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivProizvodjaca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProdajnaCijena")
                        .HasColumnType("float");

                    b.Property<int>("RokTrajanjaMjeseci")
                        .HasColumnType("int");

                    b.HasKey("LijekID");

                    b.HasIndex("KategorijaID");

                    b.ToTable("Lijek");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Nabavka", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApotekarID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumPrimanja")
                        .HasColumnType("datetime2");

                    b.Property<bool>("statusNarudzbe")
                        .HasColumnType("bit");

                    b.Property<double>("vrijednostNarudzbe")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("ApotekarID");

                    b.ToTable("nabavka");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.OnlineNarudzba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adresaDostave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("cijenaDostave")
                        .HasColumnType("float");

                    b.Property<DateTime>("datumNarudzbe")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumSlanja")
                        .HasColumnType("datetime2");

                    b.Property<int>("gradDostaveID")
                        .HasColumnType("int");

                    b.Property<string>("korisnikID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("statusNarudzbe")
                        .HasColumnType("bit");

                    b.Property<double>("vrijednostNarudzbe")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("gradDostaveID");

                    b.HasIndex("korisnikID");

                    b.ToTable("onlineNarudzba");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Praksa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naknada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Pocetak")
                        .HasColumnType("datetime2");

                    b.Property<string>("PozivOtvorenZa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefundiraniPutniTroskovi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Rok")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Stanje")
                        .HasColumnType("bit");

                    b.Property<string>("Trajanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uvod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Praksa");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.RezervacijaTermina", b =>
                {
                    b.Property<string>("KorisnikID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UslugaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumVrijemeRezervacije")
                        .HasColumnType("datetime2");

                    b.HasKey("KorisnikID", "UslugaID");

                    b.HasIndex("UslugaID");

                    b.ToTable("rezervacijaTermina");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.StavkeNabavke", b =>
                {
                    b.Property<int>("NabavkaID")
                        .HasColumnType("int");

                    b.Property<int>("LijekID")
                        .HasColumnType("int");

                    b.Property<double>("NabavnaCijenaLijeka")
                        .HasColumnType("float");

                    b.Property<int>("kolicina")
                        .HasColumnType("int");

                    b.Property<double>("ukupnaCijenaStavke")
                        .HasColumnType("float");

                    b.HasKey("NabavkaID", "LijekID");

                    b.HasIndex("LijekID");

                    b.ToTable("stavkaNabavke");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.TipKorisnika", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("tipKorisnika");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Usluga", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojPacijenata")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("usluga");
                });

            modelBuilder.Entity("Apoteka.Models.Apotekar", b =>
                {
                    b.HasOne("Apoteka.Models.Opstina", "MjestoRodjenja")
                        .WithMany()
                        .HasForeignKey("MjestoRodjenjaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.AppUser", b =>
                {
                    b.HasOne("Apoteka.Models.Apotekar", "apotekar")
                        .WithMany()
                        .HasForeignKey("ApotekarID");

                    b.HasOne("WebApp_Apoteka.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Clanak", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.DetaljiOnlineNarudzbe", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.Lijek", "lijek")
                        .WithMany()
                        .HasForeignKey("lijekID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.OnlineNarudzba", "onlineNarudzba")
                        .WithMany()
                        .HasForeignKey("onlineNarudzbaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Dobavljac", b =>
                {
                    b.HasOne("Apoteka.Models.Opstina", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.KonkursPraksa", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.Praksa", "Konkurs")
                        .WithMany()
                        .HasForeignKey("KonkursID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.AppUser", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Korisnik", b =>
                {
                    b.HasOne("Apoteka.Models.Opstina", "OpstinaRodjenja")
                        .WithMany()
                        .HasForeignKey("OpstinaRodjenjaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.TipKorisnika", "TipKorisnika")
                        .WithMany()
                        .HasForeignKey("TipKorisnikaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Kosarica", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.Lijek", "Lijek")
                        .WithMany()
                        .HasForeignKey("LijekID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.AppUser", "appUser")
                        .WithMany()
                        .HasForeignKey("appUserId");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Lijek", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Nabavka", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.AppUser", "Apotekar")
                        .WithMany()
                        .HasForeignKey("ApotekarID");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.OnlineNarudzba", b =>
                {
                    b.HasOne("Apoteka.Models.Opstina", "gradDostave")
                        .WithMany()
                        .HasForeignKey("gradDostaveID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.AppUser", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikID");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.RezervacijaTermina", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.AppUser", "korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.Usluga", "usluga")
                        .WithMany()
                        .HasForeignKey("UslugaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.StavkeNabavke", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.Lijek", "Lijek")
                        .WithMany()
                        .HasForeignKey("LijekID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.Nabavka", "Nabavka")
                        .WithMany()
                        .HasForeignKey("NabavkaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
