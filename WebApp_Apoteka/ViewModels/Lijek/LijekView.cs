using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp_Apoteka.ViewModels
{

    public class LijekView{

        public List<Podaci> podaci { get; set; }

        public class Podaci
        {
            public int LijekID { get; set; }


            public string NazivLijeka { get; set; }

    

            public string KvalitativniIKvantitativniSastav { get; set; }

            public string FarmaceutskiOblik { get; set; }

            public string NacinPrimjene { get; set; }

            public double NabavnaCijena { get; set; }

            public double ProdajnaCijena { get; set; }

            public int RokTrajanjaMjeseci { get; set; }

            public string NazivProizvodjaca { get; set; }

           

            public string NazivKategorije { get; set; }

            public DateTime DatumProizvodnje { get; set; }
            public int KategorijaID { get; internal set; }


           
            public int Kolicina { get; internal set; }
        }

        [Range(1, int.MaxValue, ErrorMessage = "Unesite kolicinu!")]

        public int Kolicina { get; set; }


        [Range(1, 3, ErrorMessage = "Maksimalno možete naručiti samo 3.!")]
        public int OdabranaKolicina { get; set; }

        public int LijekID { get; set; }

        public bool postojeci { get; set; }
    }
    
}
