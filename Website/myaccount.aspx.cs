using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlHandler;
using Aardwolf;

namespace Website
{
    public partial class myaccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null || (int)Session["login"] < 0)
            {
                // TODO: lägg redirecten i html istället med delay så vi kan berätta
                // för användaren att den måste vara inloggad för att ha åtkomst
                // till denna sida.
                Response.Redirect("index.aspx");
            }

            User currentUser = Sql.GetUser((int)Session["ID"]);
            string html = "";
            html += $"<tbody><tr><td>{currentUser.UserId}</td>";
            html += $"<td>{currentUser.UserName}</td>";
            html += $"<td>{currentUser.FirstName}</td>";
            html += $"<td>{currentUser.LastName}</td>";
            html += $"<td>{currentUser.DeliveryAddress}</td>";
            html += $"<td>{currentUser.EmailAddress}</td></tr></tbody>";

            LiteralUserinfo.Text = html;
        }
    }
}