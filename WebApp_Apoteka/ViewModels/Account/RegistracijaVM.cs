using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class RegistracijaVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirm password must be the same")]
        public string ConfirmPassword { get; set; }

        [Required]

        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }

        [Required]
        [Display(Name = "Mjesto rodjenja")]
        public int OpstinaRodjenjaID { get; set; }

        public List<SelectListItem> Opstine { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        [MinLength(12, ErrorMessage = "Broj karaktera mora biti minimalno 12")]
        [RegularExpression(@"^[+][3][8][0-9]{5,}",ErrorMessage ="Telefon mora biti u formatu +38---------")]
        public string Telefon { get; set; }
        [Required]
        [Display(Name = "Tip korisnika")]
        public int TipKorisnikaID { get; set; }
        public List<SelectListItem> TipKorisnika { get; set; }

        [Display(Name = "Autentifikacija s dva faktora")]
        public bool TwoWayAuth { get; set; }
        public int Bonovi { get; set; }
    }
}
