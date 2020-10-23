using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;
using WebApp_Apoteka.WebApoteka_Interfaces;

namespace WebApp_Apoteka.Controllers
{
    [Authorize(Roles ="Admin,Apotekar")]
    public class DobavljacController : Controller
    {
        private IDobavljacServices _IDobavljac;
        public DobavljacController(IDobavljacServices IDobavljac)
        {
            _IDobavljac = IDobavljac;
        }

        public IActionResult DodajDobavljaca()
        {
            Dobavljac d;
            if(_IDobavljac.GetAll().Any())
            {
                d = _IDobavljac.GetDobavljac();
            }
            else
            {
                d = new Dobavljac();
            }
            AddDobavljacVM model = new AddDobavljacVM() {
                ID = d.ID,
                Naziv = d.Naziv,
                Adresa = d.Adresa,
                GradID = d.GradID,
                ListaOpstina = _IDobavljac.GetAllOpstine().Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.Naziv }).ToList()
            };
            return View(model);
        }
        public ActionResult Snimi(AddDobavljacVM DVM)
        {
            Dobavljac d;
            if(DVM.ID==0)
            {
                d = new Dobavljac();
            }
            else
            {
                d = _IDobavljac.GetDobavljac();
            }
            d.Naziv = DVM.Naziv;
            d.GradID = DVM.GradID;
            d.Adresa = DVM.Adresa;

            if (DVM.ID == 0)
            {
                _IDobavljac.Add(d);
            }
            else
            {
                _IDobavljac.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult Prikaz()
        {
            List<DobavljacView> model = _IDobavljac.GetAll().Select(s => new DobavljacView
            {
                ID = s.ID,
                Naziv = s.Naziv,
                Grad = s.Grad.Naziv,
                Adresa = s.Adresa
            }).ToList();
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}