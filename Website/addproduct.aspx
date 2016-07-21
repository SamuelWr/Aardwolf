<%@ Page Title="" Language="C#" MasterPageFile="~/Aardwolf.Master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="Website.updateproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:Literal ID="productHtml" runat="server"></asp:Literal>
    <div class="col-sm-6 col-md-4 col-sm-offset-3 col-md-offset-4">
        <form runat="server" action="addproduct.aspx" method="post" class="form-signin">

            <label class="control-label" for="name">Product name</label>
            <input type="text" id="name" name="name" placeholder="" class="form-control" />
            <p class="help-block"></p>

             <label class="control-label" for="description">Product description</label>
            <input type="text" id="description" name="description" placeholder="" class="form-control" />
            <p class="help-block"></p>

             <label class="control-label" for="url">Picture url</label>
            <input type="text" id="url" name="url" placeholder="" class="form-control" />
            <p class="help-block"></p>

             <label class="control-label" for="thumbnail">Thumbnail url</label>
            <input type="text" id="thumbnail" name="thumbnail" placeholder="" class="form-control" />
            <p class="help-block"></p>

             <label class="control-label" for="cost">Product cost</label>
            <input type="text" id="cost" name="cost" placeholder="" class="form-control" />
            <p class="help-block"></p>

             <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" Text="Confirm"></asp:Button>

        </form>
    </div>
</asp:Content>
