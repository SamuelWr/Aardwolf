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

            //display products on page
            StringBuilder productsTable = new StringBuilder();
            var products = Sql.GetProducts();
            foreach (var item in products)
            {
                productsTable.Append("<div class=\"col-sm-3 product\">");
                productsTable.Append($"<h3>{item.ProductName}</h3>");
                productsTable.Append($"<div class=\"thumbnail\"><img src = \"{item.ThumbnailPictureUrl}\"/></div>");
                productsTable.Append($"<p>{item.Description}</p>");
                productsTable.Append($"<a href=\"index.aspx?action=addtocart&pid={item.ProductId}\" class=\"btn btn-lg btn-primary btn-block\">Add item {item.ProductId} to cart</a>");
                productsTable.Append("</div>");
            }
            LiteralProducts.Text = productsTable.ToString();

            if (Request["action"] == "addtocart")
            {
                int ProductId = int.Parse(Request["pid"]);
                //Todo: actually add product to cart here. @Viktor, hur vill vi lagra det? Session["cart"] = List<int> ?
            }

            if (IsPostBack)
            {
            }
        }
    }
}