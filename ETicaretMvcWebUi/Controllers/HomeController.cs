using BussinessLayer;
using DataAccessLayer;
using Entities;
using ETicaretMvcWebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ETicaretMvcWebUi.Controllers
{
    public class HomeController : Controller
    {
        UrunManager urunManager = new UrunManager();
        SliderManager SliderManager = new SliderManager();
        KategoriManager kategoriManager = new KategoriManager();
        IletisimManager _iletisimManager = new IletisimManager();
        YorumManager yorumManager = new YorumManager();
        public ActionResult Index()
        {
            var UrunleSlider = new AnasayfaWm
            {
                Sliders = SliderManager.GetAll(),
                Urunler = urunManager.GetAll()
            };
            return View(UrunleSlider);
        }

        public PartialViewResult _PartialView()
        {
            return PartialView(kategoriManager.GetAll());
        }
        public PartialViewResult _YorumPartialView(int id)
        {
            return PartialView(yorumManager.GetAll(x => x.UrunId == id));
        }
        public ActionResult İletisim()
        {
            ViewBag.Message = "Aktas Sport İletişim Sayfası";

            return View();
        }
        public ActionResult Hakkimizda()
        {
            ViewBag.Message = "Aktas Sport İletişim Sayfası";

            return View();
        }
        [HttpPost]
        public ActionResult İletisim(string email, string adi, string soyadi, string mesaj)
        {
            try
            {
                var formMesaj = new Iletisim
                {
                    Ad = adi,
                    Soyad = soyadi,
                    Email = email,
                    Mesaj = mesaj,
                };
                var sonuc = _iletisimManager.Add(formMesaj);
                if (sonuc > 0)
                {
                    TempData["Mesaj"] = $"Sayın {adi} {soyadi} Mesajınız İletilmiştir!";
                }
            }
            catch (Exception)
            {
                TempData["Mesaj"] = $"Hata Olustu! Sayın {adi} {soyadi} Mesajınız İletilememistir!";
            }

            return View();
        }
        public ActionResult Detail(int id)
        {
            var detaylar = urunManager.Get(id);
            return View(detaylar);
        }
        public ActionResult Kategori(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var urunler = urunManager.GetAll(u => u.KategoriId == id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }
        public ActionResult Arama(string ara)
        {
            if (!String.IsNullOrEmpty(ara))
            {
                var model = urunManager.GetAll(i => i.UrunAdi.Contains(ara) || i.Aciklama.Contains(ara));
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult YorumYapma(Yorumlar data)
        {
            if (User.Identity.IsAuthenticated)
            {
                yorumManager.Add(data);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GirisYap","Account");
        }
    }
}