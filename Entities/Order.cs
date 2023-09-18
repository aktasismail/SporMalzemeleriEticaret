using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string SiparisNo { get; set; }
        public double Toplam { get; set; }
        public DateTime Tarih { get; set; }
        public SiparisDurumu SiparisDurumu { get; set; }

        public string KullaniciAdi { get; set; }
        public string Baslik { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string PostaKodu { get; set; }

        public virtual List<Siparisler> Siparislers { get; set; }
    }

    public class Siparisler
    {
        public int Id { get; set; }

        public int SiparisId { get; set; }
        public virtual Order Orders { get; set; }

        public int Miktar { get; set; }

        public double Fiyat { get; set; }

        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
