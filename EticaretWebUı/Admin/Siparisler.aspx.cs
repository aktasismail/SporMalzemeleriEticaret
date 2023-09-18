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
    public partial class Siparisler : System.Web.UI.Page
    {

        SiparisManager siparisManager = new SiparisManager();
        MusteriManager musteriManager = new MusteriManager();
        UrunManager urunManager = new UrunManager();
        void Mesaj(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "uyarı", $"<script>alert('{mesaj}')</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridViewSiparis.DataSource = siparisManager.GetAll();
                GridViewSiparis.DataBind();
                DropDownMusteri.DataSource = musteriManager.GetAll();
                DropDownMusteri.DataTextField = "Ad";
                DropDownMusteri.DataValueField = "Id";
                DropDownMusteri.DataBind();
                DropDownUrun.DataSource = urunManager.GetAll();
                DropDownUrun.DataTextField = "UrunAdi";
                DropDownUrun.DataValueField = "Id";
                DropDownUrun.DataBind();
            }
            
        }

        protected void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var ekleme = siparisManager.Add(
                    new Siparis
                    {
                        SipariNo = TxtSipariNo.Text,
                        MusteriId = int.Parse(DropDownMusteri.SelectedValue.ToString()),
                        UrunId = int.Parse(DropDownUrun.SelectedValue.ToString()),
                    }
                    );
                if (ekleme > 0)
                {
                    Response.Redirect("Siparisler.aspx");
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
                int SiparisId = Convert.ToInt32(LblId.Text);
                if (SiparisId > 0)
                {
                    var sonuc = siparisManager.Update(
                    new Entities.Siparis
                    {
                        Id = int.Parse(LblId.Text),
                        SipariNo = TxtSipariNo.Text,
                        MusteriId = int.Parse(DropDownMusteri.SelectedValue.ToString()),
                        UrunId = int.Parse(DropDownMusteri.SelectedValue.ToString()),
                    }
                    );
                    if (sonuc > 0)
                    {
                        Response.Redirect("Siparisler.aspx");
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
                    var silme = siparisManager.Delete(int.Parse(LblId.Text));
                    if (silme > 0)
                    {
                        Response.Redirect("Siparisler.aspx");
                    }
                }
            }
            catch (Exception)
            {
                Mesaj("Hata oluştu");
            }
        }

        protected void GridViewSiparis_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = GridViewSiparis.SelectedRow;
                var siparis = siparisManager.Get(Convert.ToInt32(row.Cells[1].Text));
                TxtSipariNo.Text = siparis.SipariNo;
                DropDownMusteri.SelectedValue = siparis.MusteriId.ToString();
                DropDownUrun.SelectedValue = siparis.UrunId.ToString();
                LblId.Text = row.Cells[1].Text;
            }
            catch (Exception)
            {
                Mesaj("Hata Oluştu! Kayıt Getirilemedi!");
            }
        }
    }
}