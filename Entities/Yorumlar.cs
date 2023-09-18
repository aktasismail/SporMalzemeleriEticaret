using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Yorumlar:IEntity
    {
        public int Id { get; set; }
        public string Yorum { get; set; }
        public DateTime Tarih { get; set; }
        public string KullaniciAdi { get; set; }
        public Kullanici Kullanici { get; set; }
        public int UrunId { get; set; }
        public Urun Urun { get; set; }

    }
}
