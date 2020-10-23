using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels.Clanak
{
    public class AddEditClanakVM
    {
        public int ID { get; set; }
        [Required]
        [MinLength(10,ErrorMessage ="Minimalan broj karaktera je 10")]
        [MaxLength(200,ErrorMessage ="Maksimalan broj karaktera je 200")]
        public string Naslov { get; set; }
        [Required]
        [MinLength(100,ErrorMessage ="Minimalan broj karaktera je 100")]
        public string Sadrzaj { get; set; }
        [Required(ErrorMessage ="Slika nije dodana!")]
        public IFormFile Slika { get; set; }
        public string SlikaPath { get; set; }
    }
}
