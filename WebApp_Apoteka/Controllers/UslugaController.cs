using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_Apoteka.Controllers
{
    public class UslugaController : Controller
    {
        private MojDbContext db;
        private readonly UserManager<AppUser> userManager;
        public UslugaController(MojDbContext _db, UserManager<AppUser> userManager)
        {
            db = _db;
            this.userManager = userManager;
        }
        [Authorize(Roles = "Apotekar,Admin")]

        public IActionResult DodajUsluga(int id)
        {
            AddUslugaViewM model = new AddUslugaViewM();
            if (id != 0)
            {
                Usluga u = db.usluga.Find(id);
                model.ID = u.ID;
                model.BrojPacijenata = u.BrojPacijenata;
                model.Napomena = u.Napomena;
                model.Naziv = u.Naziv;
                model.DatumVrijeme = u.DatumVrijeme;
            }
           
            return View(model);
        }
        [Authorize(Roles = "Apotekar,Admin")]
        private bool ProvjeriVrijemeUsluge(DateTime d)
        {
            foreach (var i in db.usluga.ToList())
            {
                if (i.DatumVrijeme.Hour == d.Hour && i.DatumVrijeme.Minute == d.Minute && d.Month == i.DatumVrijeme.Month && d.Day ==  i.DatumVrijeme.Day && i.DatumVrijeme.Year == d.Year)
                {
                    return true;
                }
            }
            return false;
        }
        [Authorize(Roles = "Apotekar,Admin")]
        public IActionResult PohraniUslugu(AddUslugaViewM m)
        {
            if (ProvjeriVrijemeUsluge(m.DatumVrijeme) && (m.ID==0 || m.ID!=0) ) 
            {
                m.postoji = true;
                return View("DodajUsluga", m);
            }
            else if (m.DatumVrijeme  <= DateTime.Now && (m.ID == 0 || m.ID != 0))
            {
                m.neispravanDatum = true;
                return View("DodajUsluga", m);
            }
            //else if (ProvjeriVrijemeUsluge(m.DatumVrijeme) && m.ID != 0)
            //{
            //    m.postoji = true;
            //    return View("DodajUsluga", m);
            //}
            
            if (m.ID == 0 && ModelState.IsValid && m.BrojPacijenata <= 20)
            {
                Usluga u = new Usluga
                {
                    //ID = m.ID,
                    Naziv = m.Naziv,
                    DatumVrijeme = m.DatumVrijeme,
                    Napomena = m.Napomena,
                    BrojPacijenata = m.BrojPacijenata

                };
                db.usluga.Add(u);
                db.SaveChanges();
                return Redirect("PrikaziUsluge");
            }
            else if (m.ID != 0 && ModelState.IsValid && m.BrojPacijenata <= 20)
            {
                Usluga u = db.usluga.Find(m.ID);
                u.ID = m.ID;
                u.BrojPacijenata = m.BrojPacijenata;
                u.Napomena = m.Napomena;
                u.Naziv = m.Naziv;
                u.DatumVrijeme = m.DatumVrijeme;
                db.SaveChanges();
                return Redirect("PrikaziUsluge");
            }
            else
            {
                return View("DodajUsluga", m);
            }

            
        }
       
    
        [Authorize(Roles = "Apotekar,Admin,Korisnik")]
        public async Task<IActionResult> PrikaziUsluge(bool rezervisan, bool puno)
        {


            var user = await userManager.GetUserAsync(HttpContext.User);
            UslugaView model = new UslugaView
            {
                podaci = db.usluga.Select(m => new UslugaView.Podaci
                {
                    ID = m.ID,
                    Naziv = m.Naziv,
                    DatumVrijeme = m.DatumVrijeme,
                    Napomena = m.Napomena,
                    BrojPacijenata = m.BrojPacijenata,
                    

                }).ToList()
            };
            
            if (db.rezervacijaTermina.Where(w=>w.KorisnikID == user.Id).Count()>0)
            {
                model.postoji = true;
            }
            if (rezervisan)
            {
                model.Rezervisano = true;
            }
            if (puno)
            {
                model.BrojPacijenata = true;
            }

            return View(model);
        }
        [Authorize(Roles = "Korisnik")]
        public async Task<IActionResult> MojiTermini()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            UslugaView model = new UslugaView
            {
                podaci = db.rezervacijaTermina.Where(w=>w.KorisnikID == user.Id).Select(m => new UslugaView.Podaci
                {
                    ID = m.usluga.ID,
                    Naziv = m.usluga.Naziv,
                    DatumVrijeme = m.usluga.DatumVrijeme,
                    Napomena = m.usluga.Napomena,
                    BrojPacijenata = m.usluga.BrojPacijenata,
                    korisnikID = m.KorisnikID
                }).ToList()
            };
            
            if (model.podaci.Count == 0)
            {
                return Redirect("PrikaziUsluge");
            }
            return View(model);
        }
       
        [Authorize(Roles = "Apotekar,Admin")]
        public IActionResult Uklanjanje(int id)
        {
            Usluga usluga = db.usluga.Find(id); 
            db.usluga.Remove(usluga);
            db.SaveChanges();
            
            return Redirect("PrikaziUsluge");

        }
       
        [Authorize(Roles = "Korisnik")]
        public async Task<IActionResult> RezervisiTermin(int uslugaID)

        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (db.rezervacijaTermina.Where(w => w.KorisnikID == user.Id && w.UslugaID == uslugaID).Any())
            {
                bool rezervisano = true;
                return RedirectToAction("PrikaziUsluge", new { rezervisan = rezervisano }); //pop up ili neka poruka tipa vec ste rezervisali ovaj termin
            }
            if (db.rezervacijaTermina.Where(w => w.UslugaID == uslugaID).Count() == db.usluga.Where(w => w.ID == uslugaID).FirstOrDefault().BrojPacijenata)
            {
                bool brojPacijenta = true;
                return RedirectToAction("PrikaziUsluge", new { puno = brojPacijenta }); //nema vise slobodnih mjesta ili umjesto buttona da pise popunjeno
            }
            
            RezervacijaTermina rz = new RezervacijaTermina();
            rz.UslugaID = uslugaID;

            rz.KorisnikID = user.Id;
       
            rz.DatumVrijemeRezervacije = DateTime.Now;
            db.rezervacijaTermina.Add(rz);

            db.SaveChanges();
            return Redirect("PrikaziUsluge");
        }
        //public async Task<IActionResult> DodajTermin()
        //{
        //    var user = await userManager.GetUserAsync(HttpContext.User);
        //    return View("PrikaziUsluge", );
        //}
        [Authorize(Roles = "Apotekar,Admin")]
        public IActionResult PrikazRezervisanihTermina()
        {

            RezervacijaTerminaView rz = new RezervacijaTerminaView
            {
                podaci = db.rezervacijaTermina.Select(rz => new RezervacijaTerminaView.Podaci
                {
                    NazivUsluge = rz.usluga.Naziv,
                    ImePrezime = rz.korisnik.korisnik.Ime+ " " +rz.korisnik.korisnik.Prezime,
                    DatumRezervacije = rz.DatumVrijemeRezervacije,
                    UslugaID = rz.usluga.ID,
                    KorisnikID = rz.KorisnikID,
                }).ToList()
            };
            if (rz.podaci.Count ==0)
            {
                return Redirect("PrikaziUsluge");
            }
            return View(rz); 
        }
        [Authorize(Roles = "Korisnik")]
        public IActionResult ObrisiRezervaciju(int id, string korisnik)
        {

            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = db.GetConnectionString();
            sql.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            


            cmd.CommandText = "delete from rezervacijaTermina where UslugaID=" + id + " and KorisnikID= '" + korisnik + "'";

            cmd.ExecuteNonQuery();
            db.SaveChanges();
            if (User.IsInRole("Korisnik"))
            {
                return Redirect("MojiTermini");
            }
            else
            {
                return Redirect("PrikazRezervisanihTermina");
            }
            
        }
    }
}
