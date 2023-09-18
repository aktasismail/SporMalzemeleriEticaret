using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretMvcWebUi.Models
{
    public class Sepet
    {
        private List<Sepettekiler> sepettekiler = new List<Sepettekiler>();

        public List<Sepettekiler> Sepettekilers
        {
            get { return sepettekiler; }
        }

        public void UrunEkle(Urun urun, int miktar)
        {
            var line = sepettekiler.FirstOrDefault(i => i.Urun.Id == urun.Id);
            if (line == null)
            {
                sepettekiler.Add(new Sepettekiler() { Urun = urun, Miktar = miktar });
            }
            else
            {
                line.Miktar += miktar;
            }
        }

        public void UrunSil(Urun urun)
        {
            sepettekiler.RemoveAll(i => i.Urun.Id == urun.Id);
        }

        public decimal Toplam()
        {
            return sepettekiler.Sum(i => i.Urun.Fiyat * i.Miktar);
        }

        public void Temizle()
        {
            sepettekiler.Clear();
        }
    }

    public class Sepettekiler
    {
        public Urun Urun { get; set; }
        public int Miktar { get; set; }
    }
}