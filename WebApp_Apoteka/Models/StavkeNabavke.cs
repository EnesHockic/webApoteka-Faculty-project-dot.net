using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class StavkeNabavke
    {
        public int NabavkaID { get; set; }
        public Nabavka Nabavka { get; set; }        
        public int LijekID { get; set; }
        public Lijek Lijek { get; set; }
        public double NabavnaCijenaLijeka { get; set; }
        public int kolicina { get; set; }
        public double ukupnaCijenaStavke { get; set; }
    }
}
