using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AracTamirTakipWebApi.Model
{
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string Adres { get; set; }
        public List<Isemri> Isemris { get; set; }
    }
}
