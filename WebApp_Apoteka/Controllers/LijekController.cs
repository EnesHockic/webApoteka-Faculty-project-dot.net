
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;
namespace WebApp_Apoteka.Controllers
{
    public class LijekController : Controller
    {
        private MojDbContext db;
        private readonly UserManager<AppUser> userManager;
        public LijekController(MojDbContext _db, UserManager<AppUser> userManager)
        {
            db = _db;
            this.userManager = userManager;
        }
    [Authorize(Roles = "Admin,Apotekar")]
        public IActionResult DodajLijek(int id)
        {
            AddLijekViewM model = new AddLijekViewM
            {
                ListaKategorija = db.kategorija.Select(k => new SelectListItem { Value = k.KategorijaID.ToString(), Text = k.NazivKategorije }).ToList()
                , DatumProizvodnje = DateTime.Now
            };
            if(id != 0)
            {
                Lijek l = db.Lijek.Find(id);
                model.LijekID = l.LijekID;
                model.NazivLijeka = l.NazivLijeka ;
            
                model.KvalitativniIKvantitativniSastav = l.KvalitativniIKvantitativniSastav;
                model.FarmaceutskiOblik = l.FarmaceutskiOblik;
                model.NacinPrimjene = l.NacinPrimjene;
                model.RokTrajanjaMjeseci = l.RokTrajanjaMjeseci;
                model.NazivProizvodjaca = l.NazivProizvodjaca;
                model.DatumProizvodnje = l.DatumDodavanjaUPromet;
                model.KategorijeID = l.KategorijaID;
                model.NabavnaCijena = l.NabavnaCijena;
                model.ProdajnaCijena = l.ProdajnaCijena;
                model.Kolicina = l.Kolicina;
            }
            return View(model);
        }

      
    [Authorize(Roles = "Admin,Apotekar")]
        private bool ProvjeriNazivLijeka(string naziv, int id)
        {
            if (db.Lijek.Where(w=>w.NazivLijeka == naziv && w.LijekID != id).Any())
            {
                return true;
            }
            else if (db.Lijek.Where(w => w.NazivLijeka == naziv && w.LijekID == 0).Any())
            {
                return true;
            }
            return false;
        }
    [Authorize(Roles = "Admin,Apotekar")]
        public IActionResult PohraniLijek(AddLijekViewM m)
        {
            if (ProvjeriNazivLijeka(m.NazivLijeka, m.LijekID))
            {
                m.ListaKategorija = db.kategorija.Select(k => new SelectListItem { Value = k.KategorijaID.ToString(), Text = k.NazivKategorije }).ToList();
                m.DatumProizvodnje = DateTime.Now;
                m.Postojeci = true;
                return View("DodajLijek", m);
            }
           

             if (m.LijekID == 0 && ModelState.IsValid && m.NabavnaCijena < m.ProdajnaCijena)
              {
                    Lijek lijek = new Lijek
                    {
                        LijekID = m.LijekID,
                        NazivLijeka = m.NazivLijeka,

                        KvalitativniIKvantitativniSastav = m.KvalitativniIKvantitativniSastav,
                        FarmaceutskiOblik = m.FarmaceutskiOblik,
                        NacinPrimjene = m.NacinPrimjene,
                        RokTrajanjaMjeseci = m.RokTrajanjaMjeseci,
                        NazivProizvodjaca = m.NazivProizvodjaca,
                        DatumDodavanjaUPromet = m.DatumProizvodnje,
                        KategorijaID = m.KategorijeID,
                        NabavnaCijena = m.NabavnaCijena,
                        ProdajnaCijena = m.ProdajnaCijena,
                       
                    };
                    db.Lijek.Add(lijek);
                    db.SaveChanges();
                   
                    return RedirectToAction("PrikaziStanje", "Nabavka");
                }

             else if (m.LijekID != 0  && ModelState.IsValid && m.NabavnaCijena < m.ProdajnaCijena)
            { 
                    Lijek l = db.Lijek.Find(m.LijekID);

                    l.NazivLijeka = m.NazivLijeka;
                  
                    l.KvalitativniIKvantitativniSastav = m.KvalitativniIKvantitativniSastav;
                    l.FarmaceutskiOblik = m.FarmaceutskiOblik;
                    l.NacinPrimjene = m.NacinPrimjene;
                    l.RokTrajanjaMjeseci = m.RokTrajanjaMjeseci;
                    l.NazivProizvodjaca = m.NazivProizvodjaca;
                    l.DatumDodavanjaUPromet = m.DatumProizvodnje;
                    l.KategorijaID = m.KategorijeID;
                    l.NabavnaCijena = m.NabavnaCijena;
                    l.ProdajnaCijena = m.ProdajnaCijena;
                    l.Kolicina = m.Kolicina;
                    db.SaveChanges();
                    return Redirect("PrikaziLijekove");
             }
            else if (m.LijekID == 0 && (!ModelState.IsValid || m.NabavnaCijena > m.ProdajnaCijena))
            {
                m.ListaKategorija = db.kategorija.Select(k => new SelectListItem { Value = k.KategorijaID.ToString(), Text = k.NazivKategorije }).ToList();
                m.DatumProizvodnje = DateTime.Now;


                return View("DodajLijek", m);
            }
            else
            {
                m.ListaKategorija = db.kategorija.Select(k => new SelectListItem { Value = k.KategorijaID.ToString(), Text = k.NazivKategorije }).ToList();
                m.DatumProizvodnje = DateTime.Now;

                Lijek l = db.Lijek.Where(w => w.LijekID == m.LijekID).FirstOrDefault();
                m.NabavnaCijena = l.NabavnaCijena;
                m.RokTrajanjaMjeseci = l.RokTrajanjaMjeseci;
                m.Kolicina = l.Kolicina;
                return View("DodajLijek", m);
            }
           
           

        }
        
       
    [Authorize(Roles = "Admin,Apotekar,Korisnik")]
        public async Task<IActionResult> PrikaziLijekove(bool pronadjen1)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            
            LijekView model = new LijekView
            {
                podaci = db.Lijek.Select(m => new LijekView.Podaci
                {
                    LijekID = m.LijekID,
                    NazivLijeka = m.NazivLijeka,
                   
                    KvalitativniIKvantitativniSastav = m.KvalitativniIKvantitativniSastav,
                    FarmaceutskiOblik = m.FarmaceutskiOblik,
                    NacinPrimjene = m.NacinPrimjene,
                    RokTrajanjaMjeseci = m.RokTrajanjaMjeseci,
                    NazivProizvodjaca = m.NazivProizvodjaca,
                    DatumProizvodnje = m.DatumDodavanjaUPromet,
                    NazivKategorije = m.Kategorija.NazivKategorije,
                    NabavnaCijena = m.NabavnaCijena,
                    ProdajnaCijena = m.ProdajnaCijena,
                    Kolicina = m.Kolicina
                }).ToList(),
                postojeci = pronadjen1
               
            };


            int stanjeKosarice = db.kosarica.Where(w=>w.KorisnikID == user.Id).ToList().Count();
            ViewData["stanjeKosarice"] = stanjeKosarice;
            
           
            return View(model);
        }
    [Authorize(Roles = "Admin,Apotekar")]
        public IActionResult Uklanjanje(int id, bool nabavka)
        {
            Lijek lijek = db.Lijek.Find(id);
            TempData["keyUkloni"] = lijek.NazivLijeka;
            db.Lijek.Remove(lijek);
            db.SaveChanges();
            if (nabavka)
            {
                return RedirectToAction("PrikaziStanje", "Nabavka");
            }
            return Redirect("PrikaziLijekove");

        }
    }
}