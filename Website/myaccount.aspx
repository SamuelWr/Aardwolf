<%@ Page Title="" Language="C#" MasterPageFile="~/Aardwolf.Master" AutoEventWireup="true" CodeBehind="myaccount.aspx.cs" Inherits="Website.myaccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>User ID</th>
                        <th>Username</th>
                        <th>Firstname</th>
                        <th>Lastname</th>
                        <th>Delivery address</th>
                        <th>Email</th>
                    </tr>
                </thead>

                <asp:Literal ID="LiteralUserinfo" runat="server"></asp:Literal>

            </table>
        </div>
    </div>

</asp:Content>
