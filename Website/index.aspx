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
                <div class="col-sm-3 product">
                    <h3>Column 1</h3>
                    <div class="thumbnail">
                        <img src="http://img3.wikia.nocookie.net/__cb20140916184402/pokemon/images/8/85/007Squirtle_Dream.png" />
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit...</p>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" type="submit" Text="Add to cart" />
                </div>
                <div class="col-sm-3 product">
                    <h3>Column 2</h3>
                    <div class="thumbnail">
                        <img src="http://img3.wikia.nocookie.net/__cb20140916184402/pokemon/images/8/85/007Squirtle_Dream.png" />
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit...</p>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" type="submit" Text="Add to cart" />
                </div>
                <div class="col-sm-3 product">
                    <h3>Column 3</h3>
                    <div class="thumbnail">
                        <img src="http://img3.wikia.nocookie.net/__cb20140916184402/pokemon/images/8/85/007Squirtle_Dream.png" />
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit...</p>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" type="submit" Text="Add to cart" />
                </div>
                <div class="col-sm-3 product">
                    <h3>Column 4</h3>
                    <div class="thumbnail">
                        <img src="http://img3.wikia.nocookie.net/__cb20140916184402/pokemon/images/8/85/007Squirtle_Dream.png" />
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit...</p>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" type="submit" Text="Add to cart" />
                </div>
                <div class="col-sm-3">
                    <h3>Column 1</h3>
                    <div class="thumbnail">
                        <img src="http://img3.wikia.nocookie.net/__cb20140916184402/pokemon/images/8/85/007Squirtle_Dream.png" />
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit...</p>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" type="submit" Text="Add to cart" />
                </div>
                <div class="col-sm-3 product">
                    <h3>Column 2</h3>
                    <div class="thumbnail">
                        <img src="http://img3.wikia.nocookie.net/__cb20140916184402/pokemon/images/8/85/007Squirtle_Dream.png" />
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit...</p>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" type="submit" Text="Add to cart" />
                </div>
                <div class="col-sm-3 product">
                    <h3>Column 3</h3>
                    <div class="thumbnail">
                        <img src="http://img3.wikia.nocookie.net/__cb20140916184402/pokemon/images/8/85/007Squirtle_Dream.png" />
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit...</p>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" type="submit" Text="Add to cart" />
                </div>
                <div class="col-sm-3 product">
                    <h3>Column 4</h3>
                    <div class="thumbnail">
                        <img src="http://img3.wikia.nocookie.net/__cb20140916184402/pokemon/images/8/85/007Squirtle_Dream.png" />
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit...</p>
                    <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" type="submit" Text="Add to cart" />
                </div>
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
