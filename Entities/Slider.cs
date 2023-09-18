using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Slider:IEntity
    {
        public int Id { get; set; }
        public string SliderAd { get; set; }
        public string Aciklama { get; set; }
        public string link { get; set; }
        public string resim { get; set; }
    }
}
