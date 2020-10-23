using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;
namespace WebApp_Apoteka.Controllers
{
    public class AjaxController : Controller
    {
        private MojDbContext db;

        public AjaxController(MojDbContext _db)
        {
            db = _db;
        }
    }
}