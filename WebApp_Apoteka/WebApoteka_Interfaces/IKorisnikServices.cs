using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Apoteka.Models;

namespace WebApp_Apoteka.WebApoteka_Interfaces
{
    public interface IKorisnikServices
    {
        List<Korisnik> GetAll();
        void Add(Korisnik k);
        List<Opstina> GetAllOpstine();

        void Obrisi(Korisnik k);
        List<TipKorisnika> GetAllTipKorisnika();
    }
}
