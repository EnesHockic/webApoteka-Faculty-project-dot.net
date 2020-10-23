using System;
namespace WebApp_Apoteka.ViewModels
{
    public class AddDetaljiOnlineNarudzbeViewM
    {
        public int onlineNarudzbaID { get; set; }
        //public OnlineNarudzba onlineNarudzba { get; set; }

        public int lijekID { get; set; }
        //public Lijek lijek { get; set; }

        public double cijenaLijeka { get; set; }

        public int kolicina { get; set; }
        public double popust { get; set; }

        public double ukupnaCijenaStavke { get; set; }
    }
}
