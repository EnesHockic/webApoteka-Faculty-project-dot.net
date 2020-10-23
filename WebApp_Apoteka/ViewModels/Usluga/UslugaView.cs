using System;
using System.Collections.Generic;

namespace WebApp_Apoteka.Models
{
    public class UslugaView
    {
        public List<Podaci> podaci { get; set; }
        public bool postoji { get; set; }
        public bool Rezervisano { get; internal set; }
        public bool BrojPacijenata { get; internal set; }

        public class Podaci
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
            public DateTime DatumVrijeme { get; set; }
            public string Napomena { get; set; }
            public int BrojPacijenata { get; set; }
            public string korisnikID { get; internal set; }
            public bool rezervisano { get; internal set; }
        }
    }
}
