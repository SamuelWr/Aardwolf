using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aardwolf;
using SqlHandler;
using System.Text;

namespace Website
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["login"] = -1;

            StringBuilder productsTable = new StringBuilder();
            var products = Sql.GetProducts();
            foreach (var item in products)
            {
                productsTable.Append("<div class=\"col-sm-3 product\">");
                productsTable.Append($"<h3>{item.ProductName}</h3>");
                productsTable.Append($"<div class=\"thumbnail\"><img src = \"{item.ThumbnailPictureUrl}\"/></div>");
                productsTable.Append($"<p>{item.Description}</p>");
                productsTable.Append($"<asp:Button runat = \"server\" class=\"btn btn-lg btn-primary btn-block\" type=\"submit\" Text=\"Add to cart {item.ProductId}\" />");
                productsTable.Append("</div>");                    
            }
            LiteralProducts.Text = productsTable.ToString();

            if (IsPostBack)
            {
                //check for add product to shopping cart.
            }
        }
    }
}