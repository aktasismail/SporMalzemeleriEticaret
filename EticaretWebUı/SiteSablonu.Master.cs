using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EticaretWebUı
{
    public partial class SiteSablonu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                //Response.Redirect("/Admin/Login.aspx");
            }
        }

        protected void LbCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("admin");
            //System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("/Admin/Login.aspx");
        }
    }
}