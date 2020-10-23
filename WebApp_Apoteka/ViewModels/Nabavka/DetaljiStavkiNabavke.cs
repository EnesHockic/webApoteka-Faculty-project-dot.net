using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class DetaljiStavkiNabavke
    {
        public DateTime datumNabavke { get; set; }
        public DateTime datumPrimanja { get; set; }

        public double vrijednostNarudzbe { get; set; }

        public bool status { get; set; }

        public string nazivLijeka { get; set; }

        public double nabavnaCIjena { get; set; }
        public int kolicina { get; set; }

        public double ukupnaCijenStavke { get; set; }
    }
}
