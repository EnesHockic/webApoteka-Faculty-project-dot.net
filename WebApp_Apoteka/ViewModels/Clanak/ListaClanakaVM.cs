using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels.Clanak
{
    public class ListaClanakaVM
    {
        public int ID { get; set; }
        public string Naslov { get; set; }
        public string Slika { get; set; }
    }
}
