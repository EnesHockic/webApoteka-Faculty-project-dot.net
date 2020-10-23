using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels.Account
{
    public class UporediKodZaKonfirmacijuTelefonaVM
    {
        public string GenerisaniKod { get; set; }

        [Compare("GenerisaniKod", ErrorMessage = "Netačan kod")]
        public string KorisnikovKod { get; set; }
        public string Operacija { get; set; }
        public string userName { get; set; }
    }
}
