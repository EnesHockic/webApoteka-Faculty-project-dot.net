using Microsoft.AspNetCore.Diagnostics;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Apoteka.ViewModels
{
    public class AddUslugaViewM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Naziv usluge nije unesen!")]
        public string Naziv { get; set; }

       
        public DateTime DatumVrijeme { get; set; }

        [Required(ErrorMessage = "Napomena nije unesena!")]
        public string Napomena { get; set; }

        [Range(1, 20, ErrorMessage ="Maksimalan broj pacijenata je 20!")]
        public int BrojPacijenata { get; set; }
        public bool postoji { get; internal set; }
        public bool neispravanDatum { get; internal set; }
    }
}
