<%@ Page Title="" Language="C#" MasterPageFile="~/Aardwolf.Master" AutoEventWireup="true" CodeBehind="registersuccess.aspx.cs" Inherits="Website.registersuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1 <%--class="vertical-center"--%>>Registration successful! Redirecting to login-page</h1>
    <meta http-equiv="Refresh" content="5;url=login.aspx" />
</asp:Content>
