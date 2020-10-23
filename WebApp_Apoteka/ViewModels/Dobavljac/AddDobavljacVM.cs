using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class AddDobavljacVM
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int GradID { get; set; }
        public List<SelectListItem> ListaOpstina { get; set; }
        public string Adresa { get; set; }
    }
}
