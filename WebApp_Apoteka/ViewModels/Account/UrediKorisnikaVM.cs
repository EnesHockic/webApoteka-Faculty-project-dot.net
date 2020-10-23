using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels.Account
{
    public class UrediKorisnikaVM
    {
        public string userID { get; set; }

        [Required]
        [MinLength(12, ErrorMessage = "Broj karaktera mora biti minimalno 12")]
        [RegularExpression(@"^[+][3][8][0-9]{5,}", ErrorMessage = "Telefon mora biti u formatu +38--------")]
        public string Telefon { get; set; }
        public bool ConfirmedTelefon { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
