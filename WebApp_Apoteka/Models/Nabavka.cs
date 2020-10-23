using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class Nabavka
    {
        public int ID { get; set; }
        public string ApotekarID { get; set; }
        public AppUser Apotekar { get; set; }
        //public Apotekar Apotekar { get; set; }
        public DateTime datum { get; set; }
        public double vrijednostNarudzbe { get; set; }

        public bool statusNarudzbe { get; set; }

        public DateTime datumPrimanja { get; set; }
    }
}
