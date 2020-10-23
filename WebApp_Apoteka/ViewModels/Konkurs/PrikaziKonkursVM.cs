using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels.Konkurs
{
    public class PrikaziKonkursVM
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public string Rok { get; set; }
        public bool Stanje { get; set; }
        public DateTime DatumObjave { get; set; }

        public bool VecAplicirao { get; set; }
        [Required]
        public IFormFile ML { get; set; }
        [Required]
        public IFormFile CV { get; set; }
    }
}
