using System;
using System.Collections.Generic;
using WebApp_Apoteka.Models;

namespace WebApp_Apoteka.ViewModels
{
    public class KosaricaView
    {
        public List<Podaci> podaci { get; set; }
        public class Podaci
        {
            public int KosaricaID { get; set; }
            public int LijekID { get; set; }
            public Lijek lijek { get; set; }
            public string NazivLijeka { get; set; }

            public int Kolicina { get; set; }
            public string KorisnikID { get; set; }

            public double Cijena { get; set; }
        }

    }
}
