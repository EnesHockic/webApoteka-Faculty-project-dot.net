using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class LijekKolicinaView
    {
       public List<Podaci> podaci { get; set; }
        public class Podaci{

            public int lijekID { get; set; }
            public int kolicina { get; set; }
            public string nazivLijeka { get; set; }

            public double nabavnaCijenaLijeka { get; set; }

        }
        public int lijekID { get; set; }

        public bool pronadjen { get; set; }

        [Range (1, 150, ErrorMessage ="Unesite kolicinu!")]
        public int kolicina { get; set; }
        public string nazivLijeka { get; set; }

        public double nabavnaCijenaLijeka { get; set; }

        public bool  pronadjenError { get; set; }

        public int kolicinaUSkladistu { get; set; }

    }
}
