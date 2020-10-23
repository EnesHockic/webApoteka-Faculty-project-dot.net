using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Apoteka.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Models;

namespace WebApp_Apoteka.ViewModels
{
    public class AddOnlineNarudzbaViewM
    {
        public int ID { get; set; }
        public string korisnikID { get; set; }
        public Korisnik korisnik { get; set; } 

        public DateTime datum { get; set; }
        public double vrijednostNarudzbe { get; set; }
        public double cijenaDostave { get; set; }

        [Required (ErrorMessage ="Odaberite grad!")]
        public int gradDostaveID { get; set; }
        public List<SelectListItem> opstine { get; set; }

        [Required (ErrorMessage ="Unesite adresu dostave!")]
        public string adresaDostave { get; set; }
    }
}
