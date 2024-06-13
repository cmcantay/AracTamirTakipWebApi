using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AracTamirTakipWebApi.Model
{
    public class MusteriLoginViewModel
    {
        public string Plaka{ get; set; }
        public string MarkaAd{ get; set; }
        public string ModelAd{ get; set; }
        public int ModelYil{ get; set; }
        public string YakitTuru{ get; set; }
        public int AracKm{ get; set; }
        public DateTime GelisTarihi{ get; set; }
        public string Mail{ get; set; }
    }
}
