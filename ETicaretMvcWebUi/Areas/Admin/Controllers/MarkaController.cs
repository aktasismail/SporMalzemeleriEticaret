using BussinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ETicaretMvcWebUi.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class MarkaController : Controller
    {
        MarkaManager markaManager = new MarkaManager();

        public ActionResult Index()
        {
            return View(markaManager.GetAll());
        }
        public ActionResult Ekleme()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekleme(Marka marka)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    marka.Tarih = DateTime.Now;
                    var ekleme = markaManager.Add(marka);
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

            Marka marka = markaManager.Get(id.Value);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }
        [HttpPost]
        public ActionResult Duzenleme(Marka marka)
        {
            if (ModelState.IsValid)
            {
                markaManager.Update(marka);
                return RedirectToAction("Index");
            }
            return View(marka);
        }
        public ActionResult Silme(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marka marka = markaManager.Get(id.Value);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }
        [HttpPost, ActionName("Silme")]
        public ActionResult Silmeonay(int? id)
        {
            try
            {
                Marka marka = markaManager.Get(id.Value);
                markaManager.Delete(marka.Id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata oluştu!");
            }
            return RedirectToAction("Index");
        }
    }
}