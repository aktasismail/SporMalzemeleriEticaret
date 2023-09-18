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
    public partial class Kategoriler : System.Web.UI.Page
    {
        KategoriManager kategoriManager = new KategoriManager();
        void Mesaj(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "uyarı", $"<script>alert('{mesaj}')</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewKategoriler.DataSource = kategoriManager.GetAll();
            GridViewKategoriler.DataBind();
        }
        protected void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var ekleme = kategoriManager.Add(
                    new Kategori
                    {
                        KategoriAdi = TxtAd.Text,
                        KategoriAciklama = TxtAciklama.Text,
                        Akifmi = Cbaktifmi.Checked,
                        Tarih = DateTime.Now
                    }
                    );
                if (ekleme > 0)
                {

                    Response.Redirect("Kategoriler.aspx");
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
                if (id>0 )
                {
                    var ekleme = kategoriManager.Update(
                    new Kategori
                    {
                        Id = id,
                        KategoriAdi = TxtAd.Text,
                        KategoriAciklama = TxtAciklama.Text,
                        Akifmi = Cbaktifmi.Checked,
                        Tarih = Convert
                        .ToDateTime(LblTarih.Text)
                    }
                    );
                    if (ekleme > 0)
                    {
                        Response.Redirect("Kategoriler.aspx");
                    }
                    else Mesaj("Kayıt Seçiniz");
                }
                
            }
            catch (Exception)
            {
                LblHata.Text = "Kayıt Eklenemedi";
            }
        }
         
	
        protected void GridViewKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gridViewRow = GridViewKategoriler.SelectedRow;
                var kategori = kategoriManager.Get(Convert.ToInt32(gridViewRow.Cells[1].Text));
                TxtAd.Text = kategori.KategoriAdi;
                TxtAciklama.Text = kategori.KategoriAciklama;
                Cbaktifmi.Checked = kategori.Akifmi;
                LblId.Text = kategori.Id.ToString();
                LblTarih.Text = kategori.Tarih.ToString();
            }
            catch (Exception)
            {
                Mesaj("Hata oluştu");
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
                    var silme = kategoriManager.Delete(int.Parse(LblId.Text));
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
    }
    
}