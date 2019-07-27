<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControl_Header" %>
<%--Header Section--%>
<header>
    <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container hidden-sm  hidden-xs ">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#nav-collapse" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <div>

                    <div class="navbar-brand-wrap inline-block">
                        <asp:HyperLink ID="HyperLinkBrandLogo" NavigateUrl="~/Home.aspx" CssClass="navbar-brand" runat="server">
                            <asp:Image ID="ImageLogo" Width="130px" ImageUrl="~/Images/Brands/logo.png" CssClass="img-responsive" runat="server" />
                        </asp:HyperLink>
                    </div>
                </div>
            </div>
            <div class="collapse navbar-collapse" id="nav-collapse">
                <ul class="nav navbar-nav navbar-right">
                    <li class="hidden-sm hidden-xs"><a href="#"><i class="fa fa-search"></i></a>
                        <div>
                            <div class="search-box-area">
                                <div>
                                    <asp:TextBox ID="TextBoxProductSearch" Text="search" TextMode="Search" runat="server"></asp:TextBox>
                                    <%--<input type="search"  placeholder="search">--%>
                                </div>
                            </div>
                        </div>
                    </li>

                    <li>
                        <asp:HyperLink ID="HyperLinkwishlistNav" NavigateUrl="#" CssClass="wish-list" runat="server">
                                    <i class="fa fa-heart hvr-pulse"></i>Wishlist</asp:HyperLink>
                    </li>

                    <li>
                        <asp:HyperLink ID="HyperLinkCart" NavigateUrl="~/UserCart.aspx" Target="_self" CssClass="mycart" runat="server">
                                    <i class="fa fa-shopping-cart "></i>Cart ( <span>3</span> )
                        </asp:HyperLink>
                        <ul class="cart-dropdown-menu dropdown-menu">
                            <li>
                                <div class="dropdown-menu__dropdown-cart ">
                                    <div class="inline-block img ">
                                        <asp:Image ID="Image1" AlternateText="shirt_img" CssClass="img-responsive" runat="server" />
                                    </div>
                                    <div class="inline-block desc ">
                                        <h5>Product</h5>
                                        <p>
                                            <i class="fa fa-inr " aria-hidden="true ">
                                                <asp:Label ID="LabelProductCost" CssClass="product-cost" runat="server" Text="0"></asp:Label>
                                            </i>
                                        </p>
                                        <p></p>

                                        <div class="inline-block__size ">
                                            <div class="inline-block ">
                                                <div class="size ">
                                                    <asp:Label ID="LabelUserNameCartNav" runat="server" Text="SIdd"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="inline-block ">
                                                <asp:Label ID="LabelUserSizeCartNav" runat="server" Text="Size"></asp:Label>
                                            </div>
                                        </div>
                                        <p>
                                            <asp:LinkButton ID="LinkButton1" CssClass="btn remove--btn" runat="server"> <i class="fa fa-trash-o " aria-hidden="true "></i>Remove</asp:LinkButton>

                                        </p>
                                    </div>
                                </div>

                            </li>
                            <div class="dropdown-menu__btn text-center ">
                                <a>
                                    <asp:Button ID="ButtonCheckout" CssClass="btn btn--brown-checkout" runat="server" Text="CHECKOUT" />
                                </a>
                                <p>{{cartErr}}</p>
                            </div>
                        </ul>

                    </li>

                    <li>
                        <a>
                            <asp:Button ID="ButtonLogin" UseSubmitBehavior="false" CssClass="btn header--login" OnClick="ButtonLogin_Click" PostBackUrl="~/UserAccount/Login.aspx" runat="server" Text="LOGIN" />
                        </a>
                    </li>
                    <li runat="server">

                        <!--<button class=" btn header--logout" ng-click="logout(); " ng-if="userId !='' ">Hi, siddhesh</button>-->

                        <asp:HyperLink ID="HyperLinkUserName" Visible="false" CssClass="user-name" runat="server">
                            <i class="fa fa-caret-down"></i>      
                        </asp:HyperLink>
                        <ul class="header-top-right-dropdown list-unstyled">

                            <li class="text-uppercase">
                                <asp:HyperLink ID="HyperLinkProfile" NavigateUrl="~/UserAccount.aspx" runat="server">profile</asp:HyperLink>
                            </li>
                            <li class="text-uppercase">
                                <asp:HyperLink ID="HyperLinkManageAddress" NavigateUrl="~/UserAccount.aspx" runat="server">manage address</asp:HyperLink>
                            </li>
                            <li class="text-uppercase">
                                <asp:HyperLink ID="HyperLinkOrder" NavigateUrl="~/OrderDetails.aspx" runat="server">order</asp:HyperLink>
                            </li>
                            <li class="text-uppercase">
                                <asp:HyperLink ID="HyperLinkWishlist" NavigateUrl="#" runat="server">Wishlist</asp:HyperLink>

                            </li>
                            <!-- <li class="text-uppercase"><a href="">forgot password?</a> </li> -->
                            <li class="text-uppercase">
                                <asp:LinkButton ID="HyperLinkLogout" OnClick="HyperLinkLogout_Click" runat="server">logout</asp:LinkButton>
                                <%--<asp:HyperLink ID="HyperLinkLogout" On NavigateUrl="#" runat="server">logout</asp:HyperLink>--%>

                            </li>

                        </ul>

                    </li>
                </ul>
            </div>
        </div>
    </nav>
</header>
