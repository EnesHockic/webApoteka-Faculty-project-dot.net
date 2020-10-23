using Apoteka.Models;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IApotekarServices
    {
        List<Apotekar> GetAll();
        Apotekar GetByID(int ID);
        void Add(Apotekar a);
        void ObrisiByID(int ID);
        List<Opstina> GetAllOpstine();
        void SaveChanges();
    }
}
