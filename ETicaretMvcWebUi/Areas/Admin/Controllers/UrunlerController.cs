using BussinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ETicaretMvcWebUi.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UrunlerController : Controller
    {
        UrunManager manager = new UrunManager();
        KategoriManager kategoriManager = new KategoriManager();
        MarkaManager markaManager = new MarkaManager();
        public ActionResult Index()
        {
            var urunler = manager.GetAll();
            return View(urunler);
        }
        public ActionResult Ekleme()
        {
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi");
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekleme(Urun urun, HttpPostedFileBase Resim)
        {
            if (ModelState.IsValid)
            {
                if (Resim != null)
                {
                    string directory = Server.MapPath("~/Img/");
                    var fileName = Path.GetFileName(Resim.FileName);
                    Resim.SaveAs(Path.Combine(directory, fileName));
                    urun.UrunResmi = Resim.FileName;
                }
                urun.Tarih = System.DateTime.Now;
                manager.Add(urun);

                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi", urun.KategoriId);
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi", urun.MarkaId);
            return View(urun);
        }
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = manager.Get(id.Value);
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi", urun.KategoriId);
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi", urun.MarkaId);
            return View(urun);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Urun urun, HttpPostedFileBase Resim, bool cbResimSil)
        {
            if (ModelState.IsValid)
            {
                if (cbResimSil == true)
                {
                    urun.UrunResmi = string.Empty;
                }
                if (Resim != null)
                {
                    string directory = Server.MapPath("~/Img/");
                    var fileName = Path.GetFileName(Resim.FileName);
                    Resim.SaveAs(Path.Combine(directory, fileName));
                    urun.UrunResmi = Resim.FileName;
                }
                manager.Update(urun);

                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi", urun.KategoriId);
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi", urun.MarkaId);
            return View(urun);
        }
        public ActionResult Silme(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = manager.Get(id.Value);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }
        [HttpPost, ActionName("Silme")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urun urun = manager.Get(id);
            manager.Delete(urun.Id);

            return RedirectToAction("Index");
        }
    }
}