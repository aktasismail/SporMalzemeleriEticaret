using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretMvcWebUi.Models
{
    public class AnasayfaWm
    {
        public List<Slider> Sliders { get; set; }
        public List<Urun> Urunler { get; set; }
        public List<Kategori> Kategori { get; set; }

    }
}