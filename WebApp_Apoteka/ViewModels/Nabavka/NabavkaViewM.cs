using System;
using System.Collections.Generic;
using Apoteka.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Models;

namespace WebApp_Apoteka.ViewModels
{
    public class NabavkaViewM
    {
        public List<Podaci> podaci { get; set; }

        public string imePrezime { get; set; }

        public class Podaci
        {
            public int ID { get; set; }

            public string ImePrezime { get; set; }

            public DateTime datum { get; set; }
            public double vrijednostNarudzbe { get; set; }

            public bool statusNarudzbe { get; set; }

            public int kolicina { get; set; }
            public string nazivLijeka { get; set; }

            public double nabavnaCijena { get; set; }

            public string nazivApoteke { get; set; }

            public DateTime datumPrimanja { get; set; }

        }
    }
}
