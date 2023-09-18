using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EticaretWebUı.Admin
{
    public partial class UrunDetay : System.Web.UI.Page
    {
        UrunManager urunManager = new UrunManager();
        void UrunBilgi(int id)
        {
            var urun = urunManager.Get(id);
            if (urun!=null)
            {
                Baslik.InnerText = urun.UrunAdi;
                UrunResmi.ImageUrl ="/Images/"+ urun.UrunResmi;
                UrunAciklama.Text = urun.Aciklama;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["urunId"]!=null)
                {
                    var urunId = int.Parse(Request.QueryString["urunId"]);
                    UrunBilgi(urunId);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}