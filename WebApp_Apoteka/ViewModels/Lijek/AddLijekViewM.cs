using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp_Apoteka.ViewModels
{
    public class AddLijekViewM
    {
        public int LijekID { get; set; }

        [Required(ErrorMessage = "Naziv lijeka nije unesen!")]
        public string NazivLijeka { get; set; }




        [Required(ErrorMessage = "Kvalitativni i kvantitativni sastav nije unesen!")]
        public string KvalitativniIKvantitativniSastav { get; set; }

        [Required(ErrorMessage = "Farmaceutski oblik nije unesen!")]
        public string FarmaceutskiOblik { get; set; }

        [Required(ErrorMessage = "Način primjene nije unesen!")]
        public string NacinPrimjene { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Nabavna cijena mora biti veća od 0!")]
        
        public double NabavnaCijena { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Prodajna cijena mora biti veća od 0!")]
        public double ProdajnaCijena { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Rok trajana nije unesen!")]
        public int RokTrajanjaMjeseci { get; set; }


        [Required(ErrorMessage = "Naziv proizvođača nije unesen!")]
        public string NazivProizvodjaca { get; set; }


        //[Required(ErrorMessage = "Način primjene nije unesen!")]
        //public string SlikaLijeka { get; set; }


        [Required(ErrorMessage = "Kategorija nije odabrana!")]
        public int KategorijeID { get; set; }


        public List<SelectListItem> ListaKategorija { get; set; }
        

        [Required(ErrorMessage = "Datum dodavanja u promet nije dodan!")]
      
        public DateTime DatumProizvodnje { get; set; }


        public bool Postojeci { get; set; }

        
        public int Kolicina { get;  set; }


    }
}
