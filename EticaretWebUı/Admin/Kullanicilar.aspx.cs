using BussinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EticaretWebUı
{
    public partial class Kullanicilar : System.Web.UI.Page
    {
        KullaniciManager kullaniciManager = new KullaniciManager();
        void Mesaj(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "uyarı", $"<script>alert('{mesaj}')</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewKullanici.DataSource = kullaniciManager.GetAll();
            GridViewKullanici.DataBind();
        }

        protected void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var ekleme = kullaniciManager.Add(
                    new Kullanici
                    {
                        KullaniciAdi = TxtKullaniciAd.Text,
                        Sifre = TxtSifre.Text,
                        Email = TxtEmail.Text,
                        Ad = TxtAd.Text,
                        Soyad = TxtSoyad.Text,
                        Aktifmi = Cbaktifmi.Checked,
                    }
                    );
                if (ekleme > 0)
                {

                    Response.Redirect("Kullanicilar.aspx");
                    LblHata.Text = "Kayıt Eklendi";
                }
                else
                {
                    LblHata.Text = "Kayıt Eklenemedi";
                }
            }
            catch (Exception)
            {

                LblHata.Text = "Kayıt Eklenemedi";
            }
        }

        protected void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(LblId.Text);
                if (id > 0)
                {
                    var ekleme = kullaniciManager.Update(
                    new Kullanici
                    {
                        Id = id,
                        KullaniciAdi = TxtKullaniciAd.Text,
                        Sifre = TxtSifre.Text,
                        Email = TxtEmail.Text,
                        Ad = TxtAd.Text,
                        Soyad = TxtSoyad.Text,
                        Aktifmi = Cbaktifmi.Checked,
                    }
                    );
                    if (ekleme > 0)
                    {
                        Response.Redirect("Kullanicilar.aspx");
                    }
                    else Mesaj("Kayıt Seçiniz");
                }

            }
            catch (Exception)
            {
                LblHata.Text = "Kayıt Eklenemedi";
            }
        }

        protected void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblId.Text == "0")
                {
                    Mesaj("Kayıt seçiniz");
                }
                else
                {
                    var silme = kullaniciManager.Delete(int.Parse(LblId.Text));
                    if (silme > 0)
                    {
                        Response.Redirect("Kullanicilar.aspx");
                    }
                }
            }
            catch (Exception)
            {
                Mesaj("Hata oluştu");
            }
        }

        protected void GridViewKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gridViewRow = GridViewKullanici.SelectedRow;
                var kullanici = kullaniciManager.Get(Convert.ToInt32(gridViewRow.Cells[1].Text));
                TxtKullaniciAd.Text = kullanici.KullaniciAdi;
                TxtSifre.Text = kullanici.Sifre;
                TxtEmail.Text = kullanici.Email;
                TxtAd.Text = kullanici.Ad;
                TxtSoyad.Text = kullanici.Soyad;
                Cbaktifmi.Checked = kullanici.Aktifmi;
                LblId.Text = kullanici.Id.ToString();
                

            }
            catch (Exception)
            {
                Mesaj("Hata oluştu");
            }
        }
    }
}