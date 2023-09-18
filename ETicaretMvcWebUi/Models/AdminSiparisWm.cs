using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretMvcWebUi.Models
{
    public class AdminSiparisWm
    {
        public int Id { get; set; }
        public string SiparisNo { get; set; }
        public double Toplam { get; set; }
        public SiparisDurumu SiparisDurumu { get; set; }
        public DateTime Tarih { get; set; }
        public int Miktar { get; set; }
    }
}