using System;
using WebApp_Apoteka.Models;

namespace WebApp_Apoteka.ViewModels
{
    public class AddKosaricaViewM
    {
        public int KosaricaID { get; set; }

        public string KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int LijekID { get; set; }
        public Lijek Lijek { get; set; }
        public int kolicinaNabavke { get; set; }
    }
}
