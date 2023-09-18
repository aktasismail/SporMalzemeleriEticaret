using DataAccessLayer;
using Entities;
using ETicaretMvcWebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretMvcWebUi.Controllers
{
    
    public class CartController : Controller
    {
        private EntityConnection db = new EntityConnection();
        [Authorize]
        public ActionResult Index()
        {

            return View(GetCart());
        }

        public ActionResult SepeteEkle(int Id)
        {
            var urun = db.Urunler.FirstOrDefault(i => i.Id == Id);

            GetCart().UrunEkle(urun, 1);
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult SepettenSil(int Id)
        {
            var urun = db.Urunler.FirstOrDefault(i => i.Id == Id);

            if (urun != null)
            {
                GetCart().UrunSil(urun);
            }

            return RedirectToAction("Index");
        }
        [Authorize]
        public Sepet GetCart()
        {
            var sepet = (Sepet)Session["Sepet"];

            if (sepet == null)
            {
                sepet = new Sepet();
                Session["Sepet"] = sepet;
            }

            return sepet;
        }
        [Authorize]
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        [Authorize]
        public ActionResult TeslimatDetayi()
        {
            return View(new TeslimatDetay());
        }
        [Authorize]
        [HttpPost]
        public ActionResult TeslimatDetayi(TeslimatDetay entity)
        {
            var sepet = GetCart();

            if (sepet.Sepettekilers.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                Kaydet(sepet, entity);
                sepet.Temizle();
                return View("Tamamlandi");
            }
            else
            {
                return View(entity);
            }
        }
        [Authorize]
        private void Kaydet(Sepet sepet, TeslimatDetay entity)
        {
            var siparis = new Order();

            siparis.SiparisNo = "A" + (new Random()).Next(11111, 99999).ToString();
            siparis.Toplam = (double)sepet.Toplam();
            siparis.Tarih = DateTime.Now;
            siparis.SiparisDurumu = SiparisDurumu.Bekliyor;
            siparis.KullaniciAdi = User.Identity.Name;

            siparis.Baslik = entity.Baslik;
            siparis.Adres = entity.Adres;
            siparis.Sehir = entity.Sehir;
            siparis.PostaKodu = entity.PostaKodu;

            siparis.Siparislers = new List<Siparisler>();

            foreach (var pr in sepet.Sepettekilers)
            {
                var model = new Siparisler();
                model.Miktar = pr.Miktar;
                model.Fiyat = (double)(pr.Miktar * pr.Urun.Fiyat);
                model.UrunId = pr.Urun.Id;

                siparis.Siparislers.Add(model);
            }
            db.Orders.Add(siparis);
            db.SaveChanges();
        }

    }
}
