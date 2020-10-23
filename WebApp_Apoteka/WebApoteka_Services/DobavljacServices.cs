using Apoteka.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.WebApoteka_Interfaces;

namespace WebApp_Apoteka.WebApoteka_Services
{
    public class DobavljacServices : IDobavljacServices
    {
        MojDbContext _db;
        public DobavljacServices(MojDbContext db)
        {
            _db = db;
        }
        public void Add(Dobavljac d)
        {
            _db.Add(d);
            _db.SaveChanges();
        }

        public Dobavljac GetDobavljac()
        {
            return _db.dobavljac.FirstOrDefault();
        }
        public List<Dobavljac> GetAll()
        {
            return _db.dobavljac.Include(d => d.Grad).ToList();
        }

        public List<Opstina> GetAllOpstine()
        {
            return _db.Opstina.ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
