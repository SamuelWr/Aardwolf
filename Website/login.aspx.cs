﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlHandler;

namespace Website
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: lägga till klientsidevalidering
            if (IsPostBack)
            {
                string username = Request.Form["username"];
                string pword = Request.Form["password"];

                int userId = Sql.LogIn(username, pword);
                if (userId > 0)
                {
                    Session["login"] = 1;
                    Session["ID"] = userId;
                    Response.Redirect("myaccount.aspx");
                }
            }
        }
    }
}