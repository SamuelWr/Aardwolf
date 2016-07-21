using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlHandler;

namespace Website
{
    public partial class updateproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string name = Request.Form["name"];
                string description = Request.Form["description"];
                string url = Request.Form["url"];
                string thumbnail = Request.Form["thumbnail"];
                decimal cost = Convert.ToDecimal(Request.Form["cost"]);
                Sql.AddProduct(name, description, url, thumbnail, cost);
            }
        }
    }
}