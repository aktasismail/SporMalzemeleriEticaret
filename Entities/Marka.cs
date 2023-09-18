using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Marka:IEntity
    {
        public int Id { get; set; }
        public string MarkaAdi { get; set; }
        public string MarkaAciklama { get; set; }
        public DateTime Tarih { get; set; }
        public bool Akifmi { get; set; }
    }
}
