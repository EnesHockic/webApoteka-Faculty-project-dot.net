using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class AddKorisnikVM
    {
        public int ID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public int OpstinaRodjenjaID { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }

        public int TipKorisnikaID { get; set; }
        public string Email { get; set; }
        public string PorukaEmailPostoji { get; set; }
        public string Password { get; set; }
        public List<SelectListItem> Opstine { get; set; }
        public List<SelectListItem> TipoviKorisnika { get; set; }
    }
}
