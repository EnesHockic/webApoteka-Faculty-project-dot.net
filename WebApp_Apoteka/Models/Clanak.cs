using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class Clanak
    {
        public int ClanakID { get; set; }
        public string ApotekarID { get; set; }
        public AppUser AppUser { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public string SlikaPath { get; set; }
        public DateTime DatumObjave { get; set; }
    }
}
