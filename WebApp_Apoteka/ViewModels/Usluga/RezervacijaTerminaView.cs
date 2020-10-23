using System;
using System.Collections.Generic;

namespace WebApp_Apoteka.ViewModels
{
    public class RezervacijaTerminaView
    {
        public List<Podaci> podaci { get; set; }
        public class Podaci
        {
            public int UslugaID{ get; set; }
            public string KorisnikID { get; set; }
            public string ImePrezime  { get; set; }
            public string NazivUsluge { get; set; }
            public DateTime DatumRezervacije { get; set; }
        }
    }
}
