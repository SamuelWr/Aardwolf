<%@ Page Title="" Language="C#" MasterPageFile="~/Aardwolf.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Website.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <h1 class="text-center login-title">Sign in to continue shopping</h1>
                <div class="account-wall">
                    <img class="profile-img" src="content/img/pikachu.png" alt="" />
                    <form class="form-signin">
                        <input type="text" class="form-control" placeholder="Email" />
                        <input type="password" class="form-control" placeholder="Password" />
                        <button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>
                    </form>
                </div>
                <a href="register.aspx" class="text-center new-account">Create an account </a>
            </div>
        </div>
    </div>
</asp:Content>
