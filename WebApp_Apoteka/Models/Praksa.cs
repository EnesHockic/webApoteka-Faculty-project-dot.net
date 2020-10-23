using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class Praksa
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public DateTime Rok { get; set; }
        public bool Stanje { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumObjave { get; set; }
    }
}
