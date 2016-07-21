using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlHandler;

namespace Website
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Skicka med all info till metoden samt lägga till klientsidevalidering
            if (IsPostBack)
            {
                string username = Request["username"];
                string pword = Request["password"];
                string email = Request["email"];
                string address = Request["address"];

                int userId = Sql.CreateUser(username, pword);
                if (userId > 0)
                {
                    //Todo: log in user here?
                    //Session["ID"] = userID;
                    Response.Redirect("registersuccess.aspx");
                }
            }
        }
    }
}