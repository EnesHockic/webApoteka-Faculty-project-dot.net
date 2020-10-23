using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class Usluga
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Napomena { get; set; }
        public int BrojPacijenata { get; set; }


    }
}
