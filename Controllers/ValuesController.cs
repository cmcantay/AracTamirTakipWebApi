
using AracTamirTakipWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AracTamirTakipWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Context _context;

        public ValuesController(Context context)
        {
            _context = context;
        }

        [HttpGet("GetMusteris")]
        public ActionResult<IEnumerable<Musteri>> GetMusteris()
        {
            return _context.Musteris.ToList();
        }

        // GET: api/Musteri/5
        [HttpGet("{id}")]
        public ActionResult<Musteri> GetMusteri(int id)
        {
            var musteri = _context.Musteris.Find(id);

            if (musteri == null)
            {
                return NotFound();
            }

            return musteri;
        }
        [HttpGet("GetMusteriLogin")]
        public ActionResult<IEnumerable<MusteriLoginViewModel>> GetMusteriLogin(string plaka, string eposta)
        {
            var query = from isEmri in _context.Isemris
                        join model in _context.Models on isEmri.ModelId equals model.ModelId
                        join marka in _context.Markas on model.MarkaId equals marka.MarkaId
                        join musteri in _context.Musteris on isEmri.MusteriId equals musteri.MusteriId
                        where isEmri.Plaka == plaka && musteri.Eposta == eposta
                        select new MusteriLoginViewModel
                        {
                            Plaka = isEmri.Plaka,
                            Mail = musteri.Eposta,
                            AracKm = isEmri.AracKm,
                            ModelYil = isEmri.ModelYil,
                            MarkaAd = marka.MarkaAd,
                            ModelAd = model.ModelAd,
                            YakitTuru = isEmri.YakitTuru,
                            GelisTarihi = isEmri.GelisTarihi
                            // İhtiyaç duyulan diğer özellikleri de buraya ekleyebilirsiniz
                        };

            var result = query.ToList();

            if (result.Count == 0)
            {
                // Eğer plaka ve eposta bulunamazsa, hata mesajı döndür
                return NotFound("Girilen plaka ve eposta adresi eşleşmedi.");
            }
            else
            {
                // Plaka ve eposta bulunursa, sonucu döndür
                result.FirstOrDefault().ModelYil.ToString();
                return result;
            }


        }
        [HttpGet("GetIsemri")]
        public ActionResult<IEnumerable<BakimlarViewModel>> GetIsemri(string plaka)
        {
             var query = from islem in _context.Islems
                         join isemri in _context.Isemris on islem.IsemriId equals isemri.IsemriId
                               where isemri.Plaka == plaka // Aracın plakasına göre filtreleme yapabilirsiniz
                         select new BakimlarViewModel
                         {
                              IslemAd=islem.IslemAd,
                              BirimFiyat=islem.BirimFiyat,
                              Adet=islem.Adet,
                              AraToplam=islem.AraToplam
                                   
                               };

            var result = query.ToList();
            return result;

        }
        //[HttpGet("{id}")]
        //public ActionResult<Isemri> GetIsemri(int id)
        //{
        //    var isemri = _context.Isemris.Find(id);

        //    if (isemri == null)
        //    {
        //        return NotFound();
        //    }

        //    return isemri;
        //}
    }
}
