using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class PrikazAplikanataVM
    {
            public int KonkursID { get; set; }
        public string Naziv { get; set; }
        public string DatumObjave { get; set; }
        public string Rok { get; set; }
        public List<Aplikanti> aplikanti { get; set; }
        public class Aplikanti
        {
            public int KonkursID { get; set; }
            public string AplikantID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string CV { get; set; }
            public string ML { get; set; }
        }
    }
}
