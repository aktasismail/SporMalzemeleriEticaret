using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer;
using Entities;

namespace EticaretWebUı
{
    public partial class Musteriler : System.Web.UI.Page
    {
        MusteriManager musteriManager = new MusteriManager();
        void Mesaj(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "uyarı", $"<script>alert('{mesaj}')</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewMusteri.DataSource = musteriManager.GetAll();
            GridViewMusteri.DataBind();
        }

        protected void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var ekleme = musteriManager.Add(
                    new Musteri
                    {
                        Ad = TxtAd.Text,
                        Soyad = TxtSoyad.Text,
                        Email = TxtEmail.Text,
                        Telefon = TxtTelefon.Text,
                    }
                    );
                if (ekleme > 0)
                {

                    Response.Redirect("Musteriler.aspx");
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
                    var ekleme = musteriManager.Update(
                    new Musteri
                    {
                        Id = id,
                        Ad = TxtAd.Text,
                        Soyad = TxtSoyad.Text,
                        Email = TxtEmail.Text,
                        Telefon = TxtTelefon.Text,
                        
                    }
                    );
                    if (ekleme > 0)
                    {
                        Response.Redirect("Musteriler.aspx");
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
                    var silme = musteriManager.Delete(int.Parse(LblId.Text));
                    if (silme > 0)
                    {
                        Response.Redirect("Kategoriler.aspx");
                    }
                }
            }
            catch (Exception)
            {
                Mesaj("Hata oluştu");
            }
        }

        protected void GridViewMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gridViewRow = GridViewMusteri.SelectedRow;
                var musteri = musteriManager.Get(Convert.ToInt32(gridViewRow.Cells[1].Text));
                TxtAd.Text = musteri.Ad;
                TxtSoyad.Text = musteri.Soyad;
                TxtEmail.Text = musteri.Email;
                TxtTelefon.Text = musteri.Telefon;
                LblId.Text = musteri.Id.ToString();

            }
            catch (Exception)
            {
                Mesaj("Hata oluştu");
            }
        }

        protected void BtnArama_Click(object sender, EventArgs e)
        {
            var kullaniciadi = TxtAd.Text.ToString();
            GridViewMusteri.DataSource = musteriManager.GetAll(x => x.Ad.Contains(kullaniciadi));
            GridViewMusteri.DataBind();
        }
    }
}