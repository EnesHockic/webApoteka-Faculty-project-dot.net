using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class Kosarica
    {
        public int KosaricaID { get; set; }

        public string KorisnikID { get; set; }

        public AppUser appUser { get; set; }
        //public Korisnik Korisnik { get; set; }
        public int LijekID { get; set; }
        public Lijek Lijek { get; set; }

        public int kolicina { get; set; }

    }
}
