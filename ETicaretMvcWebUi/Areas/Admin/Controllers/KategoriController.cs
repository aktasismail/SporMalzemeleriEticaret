
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
    public class KategoriController : Controller
    {
        KategoriManager kategoriManager = new KategoriManager();
        public ActionResult Index()
        {
            return View(kategoriManager.GetAll());
        }
        public ActionResult Ekleme()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekleme(Kategori kategori, HttpPostedFileBase Resim)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Resim != null)
                    {
                        string directory = Server.MapPath("~/Img/");
                        var fileName = Path.GetFileName(Resim.FileName);
                        Resim.SaveAs(Path.Combine(directory, fileName));
                        kategori.Gorsel = Resim.FileName;
                    }
                    kategori.Tarih = DateTime.Now;
                    var ekleme = kategoriManager.Add(kategori);
                    if (ekleme > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kayıt Eklenemedi");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Kayıt Eklenemedi");
                }
            }
            return View();
        }
        public ActionResult Duzenleme(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Kategori kategori = kategoriManager.Get(id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }
        [HttpPost]
        public ActionResult Duzenleme(Kategori kategori, HttpPostedFileBase Resim, bool cbResimSil)
        {
            if (ModelState.IsValid)
            {
                if (cbResimSil == true)
                {
                    kategori.Gorsel = string.Empty;
                }
                if (Resim != null)
                {
                    string directory = Server.MapPath("~/Img/");
                    var fileName = Path.GetFileName(Resim.FileName);
                    Resim.SaveAs(Path.Combine(directory, fileName));
                    kategori.Gorsel = Resim.FileName;
                }
                kategoriManager.Update(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }
        public ActionResult Silme(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = kategoriManager.Get(id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }
        [HttpPost, ActionName("Silme")]
        public ActionResult SilmeOnay(int? id)
        {
            try
            {
                Kategori kategori = kategoriManager.Get(id.Value);
                kategoriManager.Delete(kategori.Id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata oluştu!");
            }
            return RedirectToAction("Index");
        }
    }
}