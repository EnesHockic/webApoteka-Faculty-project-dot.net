using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp_Apoteka.Models;
using Apoteka.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApp_Apoteka.Entity_Framework
{
    public class MojDbContext : IdentityDbContext<AppUser>
    {
        public MojDbContext(DbContextOptions opcije) : base(opcije)
        {

        }
        public MojDbContext()
        {

        }
        public DbSet<Lijek> Lijek { get; set; }
        public DbSet<Apotekar> Apotekar { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
        public DbSet<OnlineNarudzba> onlineNarudzba { get; set; }
        public DbSet<DetaljiOnlineNarudzbe> detaljiOnlineNarudzbe { get; set; }
        public DbSet<Usluga> usluga { get; set; }
        public DbSet<RezervacijaTermina> rezervacijaTermina { get; set; }
        public DbSet<Korisnik> korisnik { get; set; }
        public DbSet<Nabavka> nabavka { get; set; }
        public DbSet<StavkeNabavke> stavkaNabavke { get; set; }
        public DbSet<Kategorija> kategorija { get; set; }
        public DbSet<TipKorisnika> tipKorisnika { get; set; }
        public DbSet<Dobavljac> dobavljac { get; set; }
        public DbSet<KonkursPraksa> konkursPraksa { get; set; }
        public DbSet<Kosarica> kosarica{ get; set; }
        public DbSet<Clanak> clanak{ get; set; }
        public DbSet<Praksa> Praksa { get; set; }


        public string GetConnectionString()
        {

            return " Server= app.fit.ba,1431;Database=WebApoteka;Trusted_Connection=false;MultipleActiveResultSets=true;User=WebApotekaUser;Password=Dell12345;";
        }








        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DetaljiOnlineNarudzbe>()
                .HasKey(d => new { d.lijekID, d.onlineNarudzbaID });

            modelBuilder.Entity<RezervacijaTermina>()
                .HasKey(r => new { r.KorisnikID, r.UslugaID });
            modelBuilder.Entity<StavkeNabavke>()
                .HasKey(s => new { s.NabavkaID, s.LijekID });
            modelBuilder.Entity<KonkursPraksa>()
                .HasKey(s => new { s.KonkursID, s.KorisnikID });
        }

        //internal Korisnik FindByID(int? korisnikID)
        //{
        //    throw new NotImplementedException();
        //}

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer(@" Server= app.fit.ba,1431;

                                        Database=WebApoteka;

                                        Trusted_Connection=false;

                                        MultipleActiveResultSets=true;

                                        User=WebApotekaUser;

                                        Password=Dell12345
                                        "

                                    );

        }*/
        //zlaja
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        //{

        //    optionsBuilder.UseSqlServer(@" Server= DESKTOP-ND9VBEM\MSSQLSERVER_OLAP;

        //                                Database=WebApoteka;

        //                                Trusted_Connection=True;

        //                                MultipleActiveResultSets=true;"


        //                            );

        //} 
    }
}
