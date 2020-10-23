using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public class Apotekar
    {
        public int ID { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public Opstina MjestoRodjenja { get; set; }
        public int MjestoRodjenjaID { get; set; }

        public string Telefon { get; set; }
    }
}
