using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EticaretWebUı.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        KullaniciManager kullaniciManager = new KullaniciManager();
        void Mesaj(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "uyarı", $"<script>alert('{mesaj}')</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(TxtSifre.Text))
            {
                Mesaj("Lütfen tüm alanları doldurunuz");
            }
            else
            {
                var kullanicilar = kullaniciManager.Find(k => k.KullaniciAdi == TxtKullaniciAdi.Text && k.Sifre == TxtSifre.Text);
                if (kullanicilar != null)
                {
                    Session["admin"] = kullanicilar;
                    FormsAuthentication.SetAuthCookie(kullanicilar.KullaniciAdi, true);
                    if (Request.QueryString["ReturnUrl"] == null)
                        Response.Redirect("/Admin/Default.aspx");
                    else Response.Redirect(Request.QueryString["ReturnUrl"]);
                }
                else
                {
                    Mesaj("Kullanıcı adı veya şifre hatalı");
                }
            }
        }
    }
}