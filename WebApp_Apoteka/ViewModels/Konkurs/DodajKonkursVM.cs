using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class DodajKonkursVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Neophodno je dodati naziv!")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Neophodno je dodati Rok za prijave!")]
        
        public DateTime Rok { get; set; }
        [Required(ErrorMessage = "Neophodno je dodati sadrzaj!")]
        public string Sadrzaj { get; set; }
        public bool Stanje { get; set; }
        public DateTime DatumObjave { get; set; }

    }
}
