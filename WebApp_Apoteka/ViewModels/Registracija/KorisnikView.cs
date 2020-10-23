using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class KorisnikView
    {
        public int ID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public string OpstinaRodjenja { get; set; }

        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string TipKorisnika { get; set; }

        public string Email { get; set; }
        public int Bonovi { get; set; }
    }
}
