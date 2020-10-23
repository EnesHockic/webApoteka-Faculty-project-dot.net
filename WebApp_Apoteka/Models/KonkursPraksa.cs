using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class KonkursPraksa
    {
        public int KonkursID { get; set; }
        public Praksa Konkurs { get; set; }
        public string KorisnikID { get; set; }

        public AppUser Korisnik { get; set; }

        //public Korisnik Korisnik { get; set; }
        public bool Prihvacena { get; set; }
        public string Obrazlozenje { get; set; }

        public string CVpath { get; set; }
        public string MLpath { get; set; }


    }
}
