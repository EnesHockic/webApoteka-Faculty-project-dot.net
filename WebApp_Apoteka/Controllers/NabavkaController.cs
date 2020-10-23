using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Schema;
using OfficeOpenXml;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_Apoteka.Controllers
{
    [Authorize(Roles = "Apotekar,Admin")]

    public class NabavkaController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        private MojDbContext db;

        public NabavkaController(MojDbContext _db, UserManager<AppUser> userManager)
        {
            db = _db;
            this.userManager = userManager;
        }
        // GET: /<controller>/
        public IActionResult NabavkaHome()
        {
            return View();
        }
        public async Task<IActionResult> OpcijeNarucivanja()
        {
            bool postoji = false;
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (db.nabavka.Where(w => w.ApotekarID == user.Id).ToList().Count > 0)
            {
                postoji = true;

            }
            ViewData["postoji"] = postoji;
            return View();
        }
        private bool ProvjeriKosaricu(LijekKolicinaView lk, string user)
        {
            foreach (var i in lk.podaci)
            {
                if (db.kosarica.Where(w=>w.LijekID == i.lijekID).Any())
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<IActionResult> PrikaziStanje(bool pronadjen)
        {

            var user = await userManager.GetUserAsync(HttpContext.User);
            LijekKolicinaView lk = new LijekKolicinaView
            {
                podaci = db.Lijek.Select(s => new LijekKolicinaView.Podaci
                {
                    lijekID = s.LijekID,
                    nabavnaCijenaLijeka = s.NabavnaCijena,
                    nazivLijeka = s.NazivLijeka,
                    kolicina = s.Kolicina
                }).ToList()
            };
            lk.pronadjen = pronadjen;
            int stanjeKosarice = db.kosarica.Where(w => w.KorisnikID == user.Id).ToList().Count();
           
            ViewData["stanjeKosarice"] = stanjeKosarice;

            return View(lk);
        }
        public async Task<IActionResult> PregledKosariceNabavke()
        {

            var user = await userManager.GetUserAsync(HttpContext.User);
            KosaricaView kw = new KosaricaView
            {

                podaci = db.kosarica.Where(s => s.KorisnikID == user.Id).Select(k => new KosaricaView.Podaci
                {

                    KosaricaID = k.KosaricaID,
                    NazivLijeka = k.Lijek.NazivLijeka,
                    Kolicina = k.kolicina,
                    Cijena = k.Lijek.NabavnaCijena

                }).ToList()
            };


            return View(kw);


        }
        public async Task<IActionResult> NabavnaKosarica(int lijekID, int kolicina)
        {

            var user = await userManager.GetUserAsync(HttpContext.User);
            Kosarica k = new Kosarica();
            k.LijekID = lijekID;
            k.kolicina = kolicina;
            k.KorisnikID = user.Id;

            db.Add(k);
            db.SaveChanges();

            return PartialView("PrikaziStanje");
        }
        
        public async Task<IActionResult> PrikaziLijek(int lijekID)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (db.kosarica.Where(w=>w.LijekID == lijekID && w.KorisnikID == user.Id).Any())
            {
                LijekKolicinaView lk2 = db.Lijek.Where(w => w.LijekID == lijekID).Select(s => new LijekKolicinaView
                {
                    lijekID = s.LijekID,

                    nabavnaCijenaLijeka = s.NabavnaCijena,
                    nazivLijeka = s.NazivLijeka,
                    kolicina = db.kosarica.Where(w => w.LijekID == lijekID && w.KorisnikID == user.Id).FirstOrDefault().kolicina

                }).FirstOrDefault();

                return PartialView("AjaxPrikazLijeka", lk2);
            }
            LijekKolicinaView lk = db.Lijek.Where(w => w.LijekID == lijekID).Select(s => new LijekKolicinaView
            {
                lijekID = s.LijekID,

                nabavnaCijenaLijeka = s.NabavnaCijena,
                nazivLijeka = s.NazivLijeka,

            }).FirstOrDefault();

            return PartialView("AjaxPrikazLijeka", lk);
        }


        public async Task<IActionResult> DodajKosaricu(LijekKolicinaView lw)
        {

            var user = await userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                Kosarica ad = new Kosarica();
                ad.KorisnikID = user.Id;
                ad.LijekID = lw.lijekID;
                if (db.kosarica.Where(w => w.LijekID == lw.lijekID && w.KorisnikID == user.Id).Any() == false)
                {
                        ad.kolicina = lw.kolicina;
                        db.kosarica.Add(ad);
                }
                else
                {
                    Kosarica k = db.kosarica.Find(db.kosarica.Where(w => w.LijekID == lw.lijekID && w.KorisnikID == user.Id).FirstOrDefault().KosaricaID);
                    k.kolicina = lw.kolicina;
                    db.Update(k);
                }
                db.SaveChanges();
                return Redirect("PrikaziStanje");
            }
           
            else
            {
                LijekKolicinaView lw2 = db.Lijek.Where(w => w.LijekID == lw.lijekID).Select(s => new LijekKolicinaView
                {
                    lijekID = s.LijekID,
                    nazivLijeka = s.NazivLijeka,
                    nabavnaCijenaLijeka = s.NabavnaCijena,
                    pronadjenError = true

                }).FirstOrDefault();
                return View("AjaxPrikazLijeka", lw2);
            }


        }
        public async Task<IActionResult> ZapocniNabavku()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            AddNabavkaViewM ad = new AddNabavkaViewM
            {
                datum = DateTime.Now,
                nazivApoteke = "Europharm Sarajevo",
                
            };
            Korisnik k = db.Apotekar.Where(s => user.ApotekarID == s.ID).Select(s => new Korisnik { Ime = s.Ime, Prezime = s.Prezime, Telefon = s.Telefon }).FirstOrDefault();


            KosaricaView kw = new KosaricaView
            {
                podaci = db.kosarica.Where(s => s.KorisnikID == user.Id).Select(k => new KosaricaView.Podaci
                {

                    KosaricaID = k.KosaricaID,
                    NazivLijeka = k.Lijek.NazivLijeka,
                    Kolicina = k.kolicina,
                    Cijena = k.Lijek.NabavnaCijena,
                    

                }).ToList()
            };

            ViewData["korisnik"] = k;
            ViewData["podaci"] = kw;


            return View(ad);

        }
        public async Task<IActionResult> ObrisiKosaricu(int id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            Kosarica k = db.kosarica.Find(id);

            db.Remove(k);
            db.SaveChanges();
            if (db.kosarica.Where(w => w.KorisnikID == user.Id).ToList().Count() == 0)
            {
                return Redirect("/Nabavka/PrikaziStanje");
            }
            return Redirect("/Nabavka/PregledKosariceNabavke");
        }
        public async Task<IActionResult> DodajNabavku(AddNabavkaViewM ad)
        {
            List<Kosarica> podaci = db.kosarica.ToList();
            var user = await userManager.GetUserAsync(HttpContext.User);

            Nabavka n = new Nabavka();
            n.ID = n.ID;
            n.ApotekarID = user.Id;
            n.datum = DateTime.Now;
            n.statusNarudzbe = false;
            n.vrijednostNarudzbe = ad.vrijednostNarudzbe;
            n.datum = DateTime.Now;
            db.nabavka.Add(n);
            db.SaveChanges();


            StavkeNabavke sn = new StavkeNabavke();
            sn.NabavkaID = n.ID;
            foreach (var l in podaci)
            {
                if (user.Id == l.KorisnikID)
                {
                    sn.LijekID = l.LijekID;
                    sn.kolicina = l.kolicina;
                    sn.ukupnaCijenaStavke = db.Lijek.Where(w => w.LijekID == l.LijekID).FirstOrDefault().NabavnaCijena * l.kolicina;
                    sn.NabavnaCijenaLijeka = db.Lijek.Where(w => w.LijekID == l.LijekID).FirstOrDefault().NabavnaCijena;
                    db.stavkaNabavke.Add(sn);
                    db.SaveChanges();
                }
            }
           
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = db.GetConnectionString();
            sql.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            cmd.CommandText = "delete from kosarica where KorisnikID= '" + user.Id + "'";

            cmd.ExecuteNonQuery();

            
            db.SaveChanges();
            return Redirect("ListaNarucenihLijekova");
        }
        public async Task<IActionResult> ListaNarucenihLijekova()
        {

            var user = await userManager.GetUserAsync(HttpContext.User);


            NabavkaViewM n = new NabavkaViewM
            {
                podaci = db.nabavka.Where(w => w.ApotekarID == user.Id).Select(s => new NabavkaViewM.Podaci
                {
                    
                    statusNarudzbe = s.statusNarudzbe,
                    vrijednostNarudzbe = s.vrijednostNarudzbe,
                    datum = s.datum,
                    ID = s.ID,
                    datumPrimanja = s.datumPrimanja,

                   
                }).ToList()
            };
            n.podaci.Reverse();
            Korisnik k = db.korisnik.Where(s => user.KorisnikID == s.ID).Select(s => new Korisnik { Ime = s.Ime, Prezime = s.Prezime }).FirstOrDefault();

            n.imePrezime = k.Ime + "a " + k.Prezime+ "a";

            return View(n);
        }
        public IActionResult Dostavljeno(int id)
        {
            Nabavka n = db.nabavka.Where(w => w.ID == id).FirstOrDefault();
            n.statusNarudzbe = true;
            n.datumPrimanja = DateTime.Now;

            List<StavkeNabavke> sn = db.stavkaNabavke.Where(w => w.NabavkaID == n.ID).ToList();

            foreach (var item in sn)
            {
                Lijek l = db.Lijek.Where(w=>w.LijekID == item.LijekID).FirstOrDefault();
                l.Kolicina += item.kolicina;
                db.Update(l);
                db.SaveChanges();
            }
            db.SaveChanges();

            return Redirect("ListaNarucenihLijekova");
        }
        public IActionResult DetaljiNabavke(int nabavkaID)
        {

            List<DetaljiStavkiNabavke> nabavke = db.stavkaNabavke.Where(w => w.NabavkaID == nabavkaID).Select(s => new DetaljiStavkiNabavke
            {
                nazivLijeka = s.Lijek.NazivLijeka,
                kolicina = s.kolicina,
                ukupnaCijenStavke = s.ukupnaCijenaStavke,
                nabavnaCIjena = s.NabavnaCijenaLijeka,
                datumNabavke = s.Nabavka.datum,
                datumPrimanja = s.Nabavka.datumPrimanja,
                status = s.Nabavka.statusNarudzbe
                , vrijednostNarudzbe = s.Nabavka.vrijednostNarudzbe
            }).ToList();

           
            return PartialView(nabavke);
        }
        public async Task<IActionResult> Export()
        {
            await Task.Yield();
            var stream = new MemoryStream();
          
            LijekKolicinaView lk = new LijekKolicinaView
            {
                podaci = db.Lijek.Select(s => new LijekKolicinaView.Podaci
                {
                   
                    nazivLijeka = s.NazivLijeka,
                    nabavnaCijenaLijeka = s.NabavnaCijena,
                    kolicina = s.Kolicina
                }).ToList()
            };

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(lk.podaci, true);
                package.Save();
            }
            stream.Position = 0;
            string excelNAME = $"Pregled_Kolicinskog_Stanja"+DateTime.Today.ToShortDateString()+".xlsx";

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelNAME);
        }
    }
}
