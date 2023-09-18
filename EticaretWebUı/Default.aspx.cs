using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer;

namespace EticaretWebUı
{
    public partial class Default : System.Web.UI.Page
    {
        UrunManager urunManager = new UrunManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            RptUrun.DataSource = urunManager.GetAll();
            RptUrun.DataBind();
        }
    }
}