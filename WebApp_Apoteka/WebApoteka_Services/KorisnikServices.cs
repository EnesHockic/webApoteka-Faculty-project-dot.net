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
    public class KorisnikServices : IKorisnikServices
    {
        MojDbContext _db;

        public KorisnikServices(MojDbContext db)
        {
            _db = db;
        }

        public void Add(Korisnik k)
        {
            _db.Add(k);
            _db.SaveChanges();
        }

        public List<Korisnik> GetAll()
        {
            return _db.korisnik.Include(k => k.OpstinaRodjenja).Include(k => k.TipKorisnika).ToList();
        }

        public List<Opstina> GetAllOpstine()
        {
            return _db.Opstina.ToList();
        }

        public List<TipKorisnika> GetAllTipKorisnika()
        {
            return _db.tipKorisnika.ToList();
        }

        public void Obrisi(Korisnik k)
        {
            _db.Remove(k);
            _db.SaveChanges();
        }
    }
}
