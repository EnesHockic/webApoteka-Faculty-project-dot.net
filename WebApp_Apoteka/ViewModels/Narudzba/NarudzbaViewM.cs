using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class NarudzbaViewM
    {
        public DateTime datumNarudzbe{ get; set; }
        public double vrijednostNarudzbe { get; set; }
        public double cijenaDostave { get; set; }

        public string adresaDostave { get; set; }
        public bool statusNarudzbe { get; set; }

        public DateTime datumSlanja { get; set; }
        public DateTime datumPrimanja { get; set; }
        public string narucioKorisnik { get; set; }
        public string grad { get; set; }
        public string adresa { get; set; }
        public int ID { get; internal set; }
    }
}
