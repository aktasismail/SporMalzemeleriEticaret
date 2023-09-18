using DataAccessLayer;
using ETicaretMvcWebUi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ETicaretMvcWebUi.Controllers
{
    
    public class AccountController : Controller
    {
        private EntityConnection db = new EntityConnection();
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;
        public AccountController()
        {
            var userstore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userstore);
            var rolestore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            roleManager = new RoleManager<ApplicationRole>(rolestore);

        }
        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i => i.KullaniciAdi == username)
                .Select(i => new VerilenSiparisler()
                {
                    Id = i.Id,
                    SiparisNo = i.SiparisNo,
                    Tarih = i.Tarih,
                    siparisDurumu = i.SiparisDurumu,
                    Toplam = i.Toplam
                }).OrderByDescending(i => i.Tarih).ToList();

            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new SiparisDetay()
                {
                    SiparisId = i.Id,
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
        public ActionResult KayitOlma()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOlma(Kayit model)
        {
            var user = new ApplicationUser();
            user.Ad = model.Ad;
            user.Soyad = model.Soyad;
            user.Email = model.Email;
            user.UserName = model.KullaniciAdi;
            IdentityResult result = userManager.Create(user, model.Sifre);
            if (result.Succeeded)
            {
                if (roleManager.RoleExists("Admin"))
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
                return RedirectToAction("GirisYap", "Account");
            }
            else
            {
                ModelState.AddModelError("RegisterUserError", "Kullanıcı  oluşturma hatası.");
            }
            return View(model);
        }
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GirisYap(Giris model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser u = null;
                if (model.KullaniciAdi.Contains('@'))
                {
                    u = userManager.FindByEmail(model.KullaniciAdi);
                    model.KullaniciAdi = u.UserName;
                }
                var user = userManager.Find(model.KullaniciAdi, model.Sifre);

                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.BeniHatirla;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}