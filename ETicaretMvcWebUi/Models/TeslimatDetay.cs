using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretMvcWebUi.Models
{
    public class TeslimatDetay
    {

        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage ="Başlığı Giriniz")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Adresi Giriniz ")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Şehri Giriniz")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Kodu Giriniz")]
        public string PostaKodu { get; set; }
    }
}