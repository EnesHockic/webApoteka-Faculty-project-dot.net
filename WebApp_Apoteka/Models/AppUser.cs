using Apoteka.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class AppUser:IdentityUser
    {
        public int? KorisnikID { get; set; }
        public Korisnik korisnik { get; set; }

        public int? ApotekarID { get; set; }
        public Apotekar apotekar { get; set; }
    }
}
