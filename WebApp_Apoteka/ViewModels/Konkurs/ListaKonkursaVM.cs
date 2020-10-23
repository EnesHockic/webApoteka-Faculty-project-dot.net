using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels.Konkurs
{
    public class ListaKonkursaVM
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        public string RokStr { get; set; }
        public DateTime Rok { get; set; }
        public bool Stanje { get; set; }
        public string DatumObjaveStr { get; set; }
        public DateTime DatumObjave { get; set; }
    }
}
