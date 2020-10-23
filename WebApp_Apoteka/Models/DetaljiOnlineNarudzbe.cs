using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class DetaljiOnlineNarudzbe
    {
        public int onlineNarudzbaID { get; set; }
        public OnlineNarudzba onlineNarudzba { get; set; }

        public int lijekID { get; set; }
        public Lijek lijek { get; set; }

        public double cijenaLijeka { get; set; }

        public int kolicina { get; set; }
        public double popust { get; set; }

        public double ukupnaCijenaStavke { get; set; }
    }
}
