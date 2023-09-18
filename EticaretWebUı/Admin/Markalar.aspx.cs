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
    public partial class Markalar : System.Web.UI.Page
    {
        MarkaManager markaManager = new MarkaManager();
        void Mesaj(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "uyarı", $"<script>alert('{mesaj}')</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewMarka.DataSource = markaManager.GetAll();
            GridViewMarka.DataBind();
        }

        protected void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var ekleme = markaManager.Add(
                    new Marka
                    {
                        MarkaAdi = TxtAd.Text,
                        MarkaAciklama = TxtAciklama.Text,
                        Akifmi = Cbaktifmi.Checked,
                        Tarih = DateTime.Now
                    }
                    );
                if (ekleme > 0)
                {

                    Response.Redirect("Markalar.aspx");
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
                    var ekleme = markaManager.Update(
                    new Marka
                    {
                        Id = id,
                        MarkaAdi = TxtAd.Text,
                        MarkaAciklama = TxtAciklama.Text,
                        Akifmi = Cbaktifmi.Checked,
                        Tarih = Convert
                        .ToDateTime(LblTarih.Text)
                    }
                    );
                    if (ekleme > 0)
                    {
                        Response.Redirect("Markalar.aspx");
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
                    var silme = markaManager.Delete(int.Parse(LblId.Text));
                    if (silme > 0)
                    {
                        Response.Redirect("Markalar.aspx");
                    }
                }
            }
            catch (Exception)
            {
                Mesaj("Hata oluştu");
            }
        }

        protected void GridViewmarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gridViewRow = GridViewMarka.SelectedRow;
                var marka = markaManager.Get(Convert.ToInt32(gridViewRow.Cells[1].Text));
                TxtAd.Text = marka.MarkaAdi;
                TxtAciklama.Text = marka.MarkaAciklama;
                Cbaktifmi.Checked = marka.Akifmi;
                LblId.Text = marka.Id.ToString();
                LblTarih.Text = marka.Tarih.ToString();
            }
            catch (Exception)
            {
                Mesaj("Hata oluştu");
            }
        }
    }
}