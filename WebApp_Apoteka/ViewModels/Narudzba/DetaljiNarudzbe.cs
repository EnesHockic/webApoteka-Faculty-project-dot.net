using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class DetaljiNarudzbe
    {

        public DateTime datumNarudzbe { get; set; }

        public DateTime datumSlanja { get; set; }
        public double cijenaLijeka { get; set; }

        public int kolicina { get; set; }
     


        public double ukupnaCijenaStavke { get; set; }

        public bool status { get; set; }
        public string nazivLijeka { get; internal set; }
        public double vrijednostNarudzbe { get; internal set; }
    }
}
