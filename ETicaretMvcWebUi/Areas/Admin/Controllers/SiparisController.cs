using DataAccessLayer;
using Entities;
using ETicaretMvcWebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretMvcWebUi.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class SiparisController : Controller
    {
        EntityConnection db = new EntityConnection();

        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminSiparisWm()
            {
                Id = i.Id,
                SiparisNo = i.SiparisNo,
                Tarih = i.Tarih,
                SiparisDurumu = i.SiparisDurumu,
                Toplam = i.Toplam,
                Miktar = i.Siparislers.Count
            }).OrderByDescending(i => i.Tarih).ToList();

            return View(orders);
        }

        public ActionResult Detaylar(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new SiparisDetay()
                {
                    SiparisId = i.Id,
                    KullaniciAdi = i.KullaniciAdi,
                    SiparisNo = i.SiparisNo,
                    Toplam = i.Toplam,
                    Tarih = i.Tarih,
                    siparisDurumu = i.SiparisDurumu,
                    Baslik = i.Baslik,
                    Adres = i.Adres,
                    Sehir = i.Sehir,

                    PostaKodu = i.PostaKodu,
                    SiparisModels = i.Siparislers.Select(a => new SiparisModel()
                    {
                        UrunId = a.UrunId,
                        UrunAdi = a.Urun.UrunAdi.Length > 50 ? a.Urun.UrunAdi.Substring(0, 47) + "..." : a.Urun.UrunAdi,
                        UrunResmi = a.Urun.UrunResmi,
                        Miktar = a.Miktar,
                        Fiyat = a.Fiyat
                    }).ToList()
                }).FirstOrDefault();

            return View(entity);
        }

        public ActionResult DurumGuncelle(int SiparisId, SiparisDurumu SiparisDurumu)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == SiparisId);

            if (order != null)
            {
                order.SiparisDurumu = SiparisDurumu;
                db.SaveChanges();

                TempData["message"] = "Bilgileriniz Kayıt Edildi";

                return RedirectToAction("Detaylar", new { id = SiparisId });
            }

            return RedirectToAction("Index");
        }
    }
}