using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Apoteka.Models;

namespace WebApp_Apoteka.WebApoteka_Interfaces
{
    public interface IDobavljacServices
    {
        Dobavljac GetDobavljac();
        void Add(Dobavljac d);
        public List<Dobavljac> GetAll();
        public List<Opstina> GetAllOpstine();
        public void SaveChanges();

    }
}
