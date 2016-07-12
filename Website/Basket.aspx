<%@ Page Title="" Language="C#" MasterPageFile="~/Aardwolf.Master" AutoEventWireup="true" CodeBehind="Basket.aspx.cs" Inherits="Website.Basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <nav class="navbar navbar-default" role="navigation">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>

            </button>
            <a class="navbar-brand" href="#"></a>

        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                
                 

                <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">King is right here<span class="caret"></span></a>

                    <ul class="dropdown-menu" role="menu">
                      

                            <img src="http://w.cdn-expressen.se/images/fc/85/fc85cc4c89e347e49f5316f68fa50d74/4x3/680@80.jpg" class="navimg">
                        </li>
 
                    </ul>
            </li>
        </ul>
        </div>
        <!-- /.navbar-collapse -->
    </nav>
     <div class="container">
        <div class="row products">
            <div class="col-sm-3 product">
                <h3>Other people also bought</h3>
                <p> <img src="http://img3.wikia.nocookie.net/__cb20140916184402/pokemon/images/8/85/007Squirtle_Dream.png" class="navimg" width="100"></p>
                
            </div>
            <div class="col-sm-3 product">
                <h3>Your shopping bag</h3>
                <p>Item 1</p>
                <p>Item 2</p>
                <p>Item 3</p>
                
            </div>
            <div class="col-sm-3 product">
                <h3>Order summary</h3>
                <p>Products</p>
                <p>Shipping</p>
                <p>Total</p>
              
            </div>
       
        </div>
    </div>
</asp:Content>
