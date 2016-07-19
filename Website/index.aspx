<%@ Page Title="" Language="C#" MasterPageFile="~/Aardwolf.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Website.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="jumbotron text-center">
        <h1>Lets buy Pokémons!</h1>
        <p>Check out our awesome collection of Pokémons for sale</p>
    </div>
    <div class="container index">
        <div class="row products">
            <form runat="server">
                <asp:Literal ID="LiteralProducts" runat="server"></asp:Literal>
            </form>
        </div>
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-5">
                <ul class="pagination">
                    <li><a href="#">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
