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
    public partial class Urunler : System.Web.UI.Page
    {
        UrunManager urunManager = new UrunManager();
        MarkaManager markaManager = new MarkaManager();
        KategoriManager kategoriManager = new KategoriManager();
        void Mesaj(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "uyarı", $"<script>alert('{mesaj}')</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridViewUrun.DataSource = urunManager.GetAll();
                GridViewUrun.DataBind();
                DropDownMarka.DataSource = markaManager.GetAll();
                DropDownMarka.DataTextField = "MarkaAdi";
                DropDownMarka.DataValueField = "Id";
                DropDownMarka.DataBind();
                DropDownKategori.DataSource = kategoriManager.GetAll();
                DropDownKategori.DataTextField = "KategoriAdi";
                DropDownKategori.DataValueField = "Id";
                DropDownKategori.DataBind();
            }
        }

        protected void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string resim = "";
                if (FileUploadResim.HasFile)
                {
                    FileUploadResim.SaveAs(Server.MapPath("/Images") + FileUploadResim.FileName);
                    resim = FileUploadResim.FileName;
                }
                var ekleme = urunManager.Add(
                    new Urun
                    {
                        UrunAdi = TxtAd.Text,
                        Aciklama = TxtAciklama.Text,
                        Tarih = DateTime.Now,
                        Aktifmi = CbAktifmi.Checked,
                        Fiyat = decimal.Parse(TxtFiyat.Text),
                        Kdv = int.Parse(TxtKdv.Text),
                        StokMiktari = int.Parse(TxtStok.Text),
                        ToptanFiyat = int.Parse(TxtToptanFiyat.Text),
                        MarkaId = int.Parse(DropDownMarka.SelectedValue.ToString()),
                        KategoriId = int.Parse(DropDownKategori.SelectedValue.ToString()),
                        UrunResmi = resim
                    }
                    );;
                if (ekleme > 0)
                {
                    Response.Redirect("Urunler.aspx");
                }
            }
            catch (Exception)
            {

                Mesaj("Kayıt Eklenemedi"); ;
            }
        }

        protected void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int UrunID = Convert.ToInt32(LblId.Text);
                if (UrunID > 0)
                {
                    string resim = "";
                    if (FileUploadResim.HasFile)
                    {
                        FileUploadResim.SaveAs(Server.MapPath("/Images/") + FileUploadResim.FileName);
                        resim = FileUploadResim.FileName;
                    }
                    else resim = HiddenFieldResim.Value;
                    var sonuc = urunManager.Update(
                    new Urun
                    {

                        Id = int.Parse(LblId.Text),
                        UrunAdi = TxtAd.Text,
                        Aciklama = TxtAciklama.Text,
                        Tarih = DateTime.Now,
                        Aktifmi = CbAktifmi.Checked,
                        Fiyat = decimal.Parse(TxtFiyat.Text),
                        Kdv = int.Parse(TxtKdv.Text),
                        StokMiktari = int.Parse(TxtStok.Text),
                        ToptanFiyat = int.Parse(TxtToptanFiyat.Text),
                        UrunResmi = resim,
                        MarkaId = int.Parse(DropDownMarka.SelectedValue.ToString()),
                        KategoriId = int.Parse(DropDownKategori.SelectedValue.ToString())
                    }
                    );
                    if (sonuc > 0)
                    {
                        Response.Redirect("Urunler.aspx");
                    }
                }
            }
            catch (Exception)
            {
                Mesaj("Kayıt Güncellenemedi");
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
                    var silme = urunManager.Delete(int.Parse(LblId.Text));
                    if (silme > 0)
                    {
                        Response.Redirect("Urunler.aspx");
                    }
                }
            }
            catch (Exception)
            {
                Mesaj("Hata oluştu");
            }
        }

        protected void GridViewUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewUrun.SelectedRow;
            var urun = urunManager.Get(Convert.ToInt32(row.Cells[1].Text));
            TxtAd.Text = urun.UrunAdi.ToString();
            TxtAciklama.Text = urun.Aciklama.ToString();
            TxtStok.Text = urun.StokMiktari.ToString();
            TxtKdv.Text = urun.Kdv.ToString();
            TxtFiyat.Text = urun.Fiyat.ToString();
            CbAktifmi.Checked = urun.Aktifmi;
            LblTarih.Text = urun.Tarih.ToString();
            HiddenFieldResim.Value = urun.UrunResmi;
            LblId.Text = row.Cells[1].Text;
        }
    }
}