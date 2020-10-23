using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels.Account
{
    public class DetaljiKorisnikaVM
    {
        public string userID { get; set; }
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string DatumRodjenja { get; set; }

        public string OpstinaRodjenja { get; set; }

        public string JMBG { get; set; }
        public string DatumZaposlenja { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public bool ConfirmedTelefon { get; set; }
        public string Email { get; set; }
    }
}
