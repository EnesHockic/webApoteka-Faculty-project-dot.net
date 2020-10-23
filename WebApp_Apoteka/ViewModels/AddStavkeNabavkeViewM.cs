using System;
using System.Collections.Generic;
using Apoteka.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Models;

namespace WebApp_Apoteka.ViewModels
{
    public class AddStavkeNabavkeViewM
    {
        public int NabavkaID { get; set; }
        public Nabavka Nabavka { get; set; }
        public int LijekID { get; set; }
        public Lijek Lijek { get; set; }
        public double NabavnaCijenaLijeka { get; set; }
        public int kolicina { get; set; }
        public double ukupnaCijenaStavke { get; set; }
        public string nazivLijeka { get; set; }
    }
}
