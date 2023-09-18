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
    public class SliderController : Controller
    {
        SliderManager manager = new SliderManager();
        public ActionResult Index()
        {
            var urunler = manager.GetAll();
            return View(urunler);
        }
        public ActionResult Ekleme()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekleme(Slider slider, HttpPostedFileBase Resim)
        {
            if (ModelState.IsValid)
            {
                if (Resim != null)
                {
                    string directory = Server.MapPath("~/Img/");
                    var fileName = Path.GetFileName(Resim.FileName);
                    Resim.SaveAs(Path.Combine(directory, fileName));
                    slider.resim = Resim.FileName;
                }
                manager.Add(slider);

                return RedirectToAction("Index");
            }

            return View(slider);
        }
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = manager.Get(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Slider slider, HttpPostedFileBase Resim, bool cbResimSil)
        {
            if (ModelState.IsValid)
            {
                if (cbResimSil == true)
                {
                    slider.resim = string.Empty;
                }
                if (Resim != null)
                {
                    string directory = Server.MapPath("~/Img/");
                    var fileName = Path.GetFileName(Resim.FileName);
                    Resim.SaveAs(Path.Combine(directory, fileName));
                    slider.resim = Resim.FileName;
                }
                manager.Update(slider);

                return RedirectToAction("Index");
            }
            return View(slider);
        }
        public ActionResult Silme(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = manager.Get(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }
        [HttpPost, ActionName("Silme")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = manager.Get(id);
            manager.Delete(slider.Id);

            return RedirectToAction("Index");
        }
    }
}