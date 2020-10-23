using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;
using WebApp_Apoteka.ViewModels.Clanak;
using WebApp_Apoteka.ViewModels.Konkurs;

namespace WebApp_Apoteka.Controllers
{
    public class KonkursController : Controller
    {
        private MojDbContext db;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly UserManager<AppUser> userManager;

        public KonkursController(MojDbContext _db,IHostingEnvironment hostingEnvironment, UserManager<AppUser> userManager)
        {
            db = _db;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }
    [Authorize(Roles = "Admin,Apotekar")]
        public IActionResult DodajKonkurs(int Id)
        {

            DodajKonkursVM model = new DodajKonkursVM();
            if(Id!=0)
            {
                Praksa p = db.Praksa.Find(Id);
                model.ID = p.ID;
                model.Naziv = p.Naziv;
                model.Rok = p.Rok;
                model.Sadrzaj = p.Sadrzaj;
                model.Stanje = p.Stanje;
                model.DatumObjave = p.DatumObjave;
            }
            return View(model);
        }
    [Authorize(Roles = "Admin,Apotekar")]
        public IActionResult PohraniKonkurs(DodajKonkursVM model)
        {
            if (ModelState.IsValid == false)
                return View("DodajKonkurs",model);
            if(model.Rok.CompareTo(DateTime.Now)<=0)
            {
                ModelState.AddModelError("", "Datum nije uredan");
                return View("DodajKonkurs", model);
            }
            if (model.ID == 0)
            {
                Praksa p = new Praksa()
                {
                    Naziv = model.Naziv,
                    Rok = model.Rok,
                    Sadrzaj=model.Sadrzaj,
                    DatumObjave = DateTime.Now,
                    Stanje = true
                };
                db.Add(p);
                db.SaveChanges();
            }
            else
            {
                Praksa p = db.Praksa.Find(model.ID);
                p.ID = model.ID;
                p.Naziv = model.Naziv;
                p.Sadrzaj = model.Sadrzaj;
                p.Stanje = model.Stanje;
                p.Rok = model.Rok;
                db.SaveChanges();
            }
            return RedirectToAction("ListaKonkursa");
        }
        [Authorize]

        public IActionResult ListaKonkursa()
        {
            List<ListaKonkursaVM> model = db.Praksa.Select(p => new ListaKonkursaVM
            {
                ID = p.ID,
                Naziv = p.Naziv,
                Stanje = p.Stanje,
                Rok = p.Rok,
                DatumObjave = p.DatumObjave,
                DatumObjaveStr = p.DatumObjave.ToString("dd.MM.yyyy mm:HH"),
                RokStr = p.Rok.ToString("dd.MM.yyyy mm:HH")

            }).ToList();
            foreach (var item in model)
            {
                if(item.Rok.CompareTo(DateTime.Now)<0)
                {
                    item.Stanje = false;
                    db.Praksa.Find(item.ID).Stanje = false;
                    db.SaveChanges();
                }    
            }
            return View(model);
        }

    [Authorize(Roles = "Admin,Apotekar,Korisnik")]
        public async Task<IActionResult> PrikaziKonkurs(int Id)
        {
            Praksa p = db.Praksa.Find(Id);
            PrikaziKonkursVM model = new PrikaziKonkursVM()
            {
                ID=p.ID,
                Naziv = p.Naziv,
                Sadrzaj=p.Sadrzaj,
                DatumObjave=p.DatumObjave,
                Rok=p.Rok.ToString("dd.MM.yyyy  hh:mm"),
                Stanje=p.Stanje
            };
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (db.konkursPraksa.Where(kp=>kp.KonkursID==model.ID).Where(k=>k.KorisnikID==user.Id).Any())
            {
                model.VecAplicirao = true;
            }
            else
            {
                model.VecAplicirao = false;
            }
            return View(model);
        }
        [Authorize(Roles = "Korisnik")]

        public async Task<IActionResult> KonkurisiPraktikanta(PrikaziKonkursVM model)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                string CVuniqueFileName = null;
                if (model.CV != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "CVs");
                    CVuniqueFileName = Guid.NewGuid().ToString() + "_" + model.CV.FileName;
                    string filePath = Path.Combine(uploadsFolder, CVuniqueFileName);
                    model.CV.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                string MLuniqueFileName = null;
                if (model.ML != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "MLs");
                    MLuniqueFileName = Guid.NewGuid().ToString() + "_" + model.ML.FileName;
                    string filePath = Path.Combine(uploadsFolder, MLuniqueFileName);
                    model.CV.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                KonkursPraksa kp = new KonkursPraksa()
                {
                    KonkursID = model.ID,
                    KorisnikID = user.Id,
                    CVpath = CVuniqueFileName,
                    MLpath = MLuniqueFileName
                };
                db.konkursPraksa.Add(kp);
                db.SaveChanges();
                return RedirectToAction("ListaKonkursa");
            }
            return RedirectToAction("PrikaziKonkurs", new { Id = model.ID });
        }
        [Authorize(Roles = "Admin,Apotekar")]
        public IActionResult PrikazAplikanata(int Id)
        {
            PrikazAplikanataVM model = db.Praksa.Select(p => new PrikazAplikanataVM
            {
                KonkursID = p.ID,
                Naziv = p.Naziv,
                Rok = p.Rok.ToString("dd.MM.yyyy"),
                DatumObjave = p.DatumObjave.ToString("dd.MM.yyyy"),
                aplikanti=new List<PrikazAplikanataVM.Aplikanti>()
            }).Where(pa => pa.KonkursID == Id).FirstOrDefault();
            model.aplikanti = db.konkursPraksa.Where(pp=>pp.KonkursID==Id).Select(kp => new PrikazAplikanataVM.Aplikanti
            {
                AplikantID = kp.KorisnikID,
                Ime = kp.Korisnik.korisnik.Ime,
                Prezime = kp.Korisnik.korisnik.Prezime,
                CV = kp.CVpath,
                ML = kp.MLpath
            }).ToList();

            return View(model);
        }
    [Authorize(Roles = "Admin,Apotekar")]
        public IActionResult PreuzmiCV(string CVpath)
        {
            string filePath = Path.Combine(hostingEnvironment.WebRootPath,"CVs",CVpath);
            string fileName = CVpath;
               byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/force-download", CVpath.Substring(37));

            
        }
        [Authorize(Roles = "Admin,Apotekar")]
        public IActionResult PreuzmiML(string MLpath)
        {
            string filePath = Path.Combine(hostingEnvironment.WebRootPath, "MLs", MLpath);
            string fileName = MLpath;
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/force-download", MLpath.Substring(37));

            
        }
        [Authorize(Roles ="Admin,Apotekar")]
        public async Task<IActionResult> DetaljiKorisnika(string aplikantId)
        {
            var User = await userManager.FindByIdAsync(aplikantId);
            if(User!=null)
            {
                DetaljiKorisnikaVM model = db.korisnik.Where(kk => kk.ID == User.KorisnikID).Select(k => new DetaljiKorisnikaVM()
                {
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    Email = User.Email,
                    Adresa = k.Adresa,
                    DatumRodjenja = k.DatumRodjenja.ToString("dd.MM.yyyy"),
                    OpstinaRodjenja = k.OpstinaRodjenja.Naziv,
                    Telefon = k.Telefon
                }).FirstOrDefault();
                return PartialView(model);
            }
            return RedirectToAction("ListaKonkursa");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
