using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReflectionIT.Mvc.Paging;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels.Clanak;

namespace WebApp_Apoteka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MojDbContext db;

        public HomeController(ILogger<HomeController> logger, MojDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        [AllowAnonymous]

        public async Task<IActionResult> Index(int page=1)
        {
            var query = db.clanak.AsNoTracking().OrderByDescending(c=>c.DatumObjave);
            var model = await PagingList.CreateAsync(query, 5, page);
            //List<ListaClanakaVM> model = db.clanak.Select(c => new ListaClanakaVM
            //{
            //    ID=c.ClanakID,
            //    Naslov=c.Naslov,
            //    Slika=c.SlikaPath
            //}).ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
