using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class loginsuccessful : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";
            if (Session["login"] != null && (int)Session["login"] > 0)
            {
                html = "<meta http-equiv=\"Refresh\"content=\"5;url=basket.aspx/\"/>";
            }
            else
                html = "<h1>Login successful! Redirecting</h1>";

            LoginLiteral.Text = html;
        }
    }
}