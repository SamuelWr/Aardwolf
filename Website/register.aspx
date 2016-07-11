<%@ Page Title="" Language="C#" MasterPageFile="~/Aardwolf.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Website.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row vertical-center">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <h1 class="text-center login-title">Create an account</h1>
                <div class="account-wall">
                    <form class="form-signin">

                        <label class="control-label" for="username">Username</label>
                        <input type="text" id="username" name="username" placeholder="" class="form-control" />
                        <p class="help-block">Username can contain any letters or numbers, without spaces</p>

                        <label class="control-label" for="email">E-mail</label>
                        <input type="text" id="email" name="email" placeholder="" class="form-control" />

                        <p class="help-block">Please provide your E-mail</p>
                        <label class="control-label" for="password">Password</label>
                        <input type="password" id="password" name="password" placeholder="" class="form-control" />

                        <p class="help-block">Password should be at least 4 characters</p>
                        <label class="control-label" for="password_confirm">Password (Confirm)</label>
                        <input type="password" id="password_confirm" name="password_confirm" placeholder="" class="form-control" />

                        <p class="help-block">Please confirm password</p>
                        <button class="btn btn-lg btn-primary btn-block">Register</button>

                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
