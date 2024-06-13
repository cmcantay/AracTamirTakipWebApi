﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AracTamirTakipWebApi.Model
{
    public class Islem
    {
        [Key]
        public int IslemId { get; set; }
        public int IsemriId { get; set; }
        public string IslemAd { get; set; }
        public decimal BirimFiyat { get; set; }
        public int Adet { get; set; }
        public decimal AraToplam { get; set; }
        public virtual Isemri Isemri { get; set; }
    }
}
