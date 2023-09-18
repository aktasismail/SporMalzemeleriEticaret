using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kategori : IEntity
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public string KategoriAciklama { get; set; }
        public string Gorsel { get; set; }
        public DateTime Tarih { get; set; }
        public bool Akifmi { get; set; }
    }
}
