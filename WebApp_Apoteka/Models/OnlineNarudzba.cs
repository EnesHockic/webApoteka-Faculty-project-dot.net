using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class OnlineNarudzba
    {
        public int ID { get; set; }
        public string korisnikID { get; set; }
        public AppUser korisnik { get; set; }
        //public Korisnik korisnik { get; set; }

        public DateTime datumNarudzbe { get; set; }
        public double vrijednostNarudzbe { get; set; }
        public double cijenaDostave { get; set; }
        public int gradDostaveID { get; set; }
        public Opstina gradDostave { get; set; }
        public string adresaDostave { get; set; }

        public bool statusNarudzbe { get; set; }

        public  DateTime datumSlanja { get; set; }
       

    }
}
