using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretMvcWebUi.Models
{
    public class SiparisDetay
    {
        public int SiparisId { get; set; }
        public string KullaniciAdi { get; set; }
        public string SiparisNo { get; set; }
        public double Toplam { get; set; }
        public DateTime Tarih { get; set; }
        public SiparisDurumu siparisDurumu { get; set; }

        public string Baslik { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string PostaKodu { get; set; }

        public virtual List<SiparisModel> SiparisModels { get; set; }
    }

    public class SiparisModel
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string UrunResmi { get; set; }
        public int Miktar { get; set; }
        public double Fiyat { get; set; }
    }
}
