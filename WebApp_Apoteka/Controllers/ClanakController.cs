using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels.Clanak;
using WebApp_Apoteka.WebApoteka_Interfaces;

namespace WebApp_Apoteka.Controllers
{
    [Authorize(Roles = "Admin,Apotekar")]

    public class ClanakController : Controller
    {
        private MojDbContext db;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly UserManager<AppUser> userManager;
        private IFileManager fileManager;

        public ClanakController(IHostingEnvironment hostingEnvironment, MojDbContext db, UserManager<AppUser> userManager,IFileManager fileManager)
        {
            this.db = db;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
            this.fileManager = fileManager;
        }
        [Authorize(Roles ="Apotekar")]
        public IActionResult ObjaviClanak(int Id)
        {
            AddEditClanakVM model = new AddEditClanakVM();
            if (Id != 0)
            {
                Clanak c = db.clanak.Find(Id);
                model.ID = c.ClanakID;
                model.Naslov = c.Naslov;
                model.Sadrzaj = c.Sadrzaj;
                model.SlikaPath = c.SlikaPath;
            }
            return View(model);
        }
        [Authorize(Roles ="Apotekar")]
        public async Task<IActionResult> Spremi(AddEditClanakVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                if (model.ID == 0)
                {
                    Clanak c = new Clanak()
                    {
                        Naslov = model.Naslov,
                        Sadrzaj = model.Sadrzaj,
                        ApotekarID = user.Id,
                        DatumObjave = DateTime.Now,
                        SlikaPath = await fileManager.SaveImage(model.Slika)

                    };

                    db.Add(c);

                }
                else
                {
                    Clanak c = db.clanak.Find(model.ID);
                    c.Naslov = model.Naslov;
                    c.Sadrzaj = model.Sadrzaj;
                    if (c.SlikaPath == null)
                    {
                        c.SlikaPath = await fileManager.SaveImage(model.Slika);
                    }
                    else
                    {
                        fileManager.DeleteImage(c.SlikaPath);
                        c.SlikaPath = await fileManager.SaveImage(model.Slika);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("ObjaviClanak",model);
        }
        [AllowAnonymous]
        public IActionResult ViewClanak(int Id)
        {
            Clanak c = db.clanak.Find(Id);
            ViewClanakVM model = new ViewClanakVM()
            {
                ID = c.ClanakID,
                Naslov = c.Naslov,
                Sadrzaj = c.Sadrzaj,
                DatumObjave = c.DatumObjave.ToShortDateString(),
                Slika = c.SlikaPath

            };
            return View(model);
        }
        [Authorize(Roles ="Apotekar")]
        public IActionResult ObrisiClanak(int Id)
        {
            Clanak c = db.clanak.Find(Id);
            db.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
