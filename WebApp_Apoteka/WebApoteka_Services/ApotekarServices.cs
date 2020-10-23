using Apoteka.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp_Apoteka.Entity_Framework;

namespace WebApoteka_Services
{
    public class ApotekarServices : IApotekarServices
    {
        private readonly MojDbContext _db;

        public ApotekarServices(MojDbContext db)
        {
            _db = db;
        }
        public List<Apotekar> GetAll()
        {
            return _db.Apotekar.Include(a=>a.MjestoRodjenja).ToList();
        }

        public Apotekar GetByID(int ID)
        {
            return _db.Apotekar.Find(ID);
        }

        public void Add(Apotekar a)
        {
            _db.Add(a);
            _db.SaveChanges();
        }

        public List<Opstina> GetAllOpstine()
        {
            return _db.Opstina.ToList();
        }

        public void ObrisiByID(int ID)
        {
            _db.Apotekar.Remove(_db.Apotekar.Find(ID));
            _db.SaveChanges();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
