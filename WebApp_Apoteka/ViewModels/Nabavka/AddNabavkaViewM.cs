using System;
using System.Collections.Generic;
using Apoteka.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Models;

namespace WebApp_Apoteka.ViewModels
{
    public class AddNabavkaViewM
    {
        public int ID { get; set; }
        public string korisnikID { get; set; }
        public Korisnik korisnik { get; set; }

        public DateTime datum { get; set; }
        public double vrijednostNarudzbe { get; set; }

        public string statusNarudzbe { get; set; }

        public string nazivLijeka { get; set; }

        public double nabavnaCijena { get; set; }

        public string nazivApoteke { get; set; }

    }
}
