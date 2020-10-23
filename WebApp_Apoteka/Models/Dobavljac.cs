using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class Dobavljac
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int GradID { get; set; }
        public Opstina Grad { get; set; }
        public string Adresa { get; set; }
    }
}
