<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <!--Section home banner -->
    <section>
        <div class="cloth-cat">
            <div id="HomeBannersSlider" class="flexslider flexslider-home-banner">
                <ul class="slides cloth-cat__banner-detail relate">
                    <asp:Repeater ID="RepeatHomeBannerData" runat="server" OnItemDataBound="RepeatHomeBannerData_ItemDataBound">
                        <ItemTemplate>
                            <li class="relate">
                                <asp:HyperLink ID="HyperLinkHomeBanner" NavigateUrl="~/Products/Products.aspx" Target="_self" runat="server">
                                    <asp:Image ID="SliderHomeBannerImg" CssClass="img-responsive" runat="server" />
                                </asp:HyperLink>
                                <div class="get-center text-uppercase">
                                    <h1><%# Eval("HomeBannerName") %></h1>
                                    <h3><%# Eval("HomeBannerDesc") %></h3>
                                    <p>
                                        <asp:HyperLink ID="HyperLinkHomeBanShop" NavigateUrl="" Target="_self" runat="server">
                                            <asp:Button ID="ButtonHomeShopNow" UseSubmitBehavior="false" PostBackUrl="~/Products.aspx" CssClass="btn shop--now" runat="server" Text="Shop Now" />
                                        </asp:HyperLink>
                                    </p>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--   <li>
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Products.aspx"  Target="_self"  runat="server">
                            <asp:Image ID="Image1" ImageUrl="~/Images/Home/2.jpg" CssClass="img-responsive" runat="server" />
                        </asp:HyperLink>
                    </li>--%>
                </ul>
                <div class="custom-flex-nav">
                    <ul class="flex-direction-nav">
                        <li class="flex-nav-prev"><a class="flex-prev" href="#"></a></li>
                        <li class="flex-nav-next"><a class="flex-next" href="#"></a></li>
                    </ul>
                </div>
            </div>
            <div>
                <asp:Label ID="LblDatabaseError" runat="server"></asp:Label>
            </div>
        </div>
    </section>

    <%--Section new arriaval--%>
    <section class="new-arrival">
        <div class="new-arrival__title text-center ">
            <h1 class="text-uppercase new-arrival--border--line homepg-title">new arrivals</h1>
        </div>
        <div class="new-arrival__img">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-9 col-sm-9 col-md-offset-3 col-sm-offset-3  padd-rt0">
                        <div id="NewArrivalSlider" class="flexslider  new-arrival__slider">
                            <asp:Panel ID="SliderNew1" runat="server">

                                <ul class="slides">
                                    <asp:Repeater ID="RepeatNewArrivalData" runat="server">
                                        <ItemTemplate>

                                            <%--<flex-slider flex-slide="newArrival in newArrivals track by $index" prev-text="" next-text="" animation="slide" item-width="220"
                            item-margin="20" min-items="3">--%>
                                            <li>
                                                <div class=" new-arrival__banner-detail  relate">
                                                    <div class="relate">
                                                        <asp:HyperLink ID="LnkIndividualProd" Target="_blank" NavigateUrl='<%# String.Format("~/Products/IndividualProduct.aspx?prodId={0}&prodCode={1}&prodCat={2}&prodName={3}&prodStyle={4}&prodColor={5}&prodImg={6}&prodDesc={7}&prodPrice={8}&prodSizeM={9}&prodSizeXL={10}&prodSizeXXL={11}",Eval("ProductId"),Eval("ProductCode"),Eval("ProductCat"),Eval("ProductName"),Eval("ProductStyle"),Eval("ProductColor"),Eval("ProductImg"),Eval("ProductDesc"),Eval("ProductPrice"),((Product) Container.DataItem).SizeQuantity[0], ((Product) Container.DataItem).SizeQuantity[1], ((Product) Container.DataItem).SizeQuantity[2] ) %>' runat="server">
                                                            <asp:Image ID="ImageNewArrival" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ProductImg") %>' CssClass="img-responsive" runat="server" />

                                                        </asp:HyperLink>
                                                        <div>
                                                            <asp:HyperLink ID="LnkAddToCart" runat="server" CssClass="featured__icon-cart"> <i class="fa fa-shopping-cart"></i></asp:HyperLink>
                                                        </div>

                                                        <asp:Panel ID="PanelFeaturedIconHeart" CssClass="featured__icon-heart" runat="server">
                                                            <i>s</i>
                                                        </asp:Panel>
                                                    </div>

                                                    <div class="get-left">
                                                        <h3 class="homepg-slider-product-cost"><i class="fa fa-inr" aria-hidden="true"></i>
                                                            <asp:Label ID="LblProdCost" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "ProductPrice") %>'></asp:Label></h3>
                                                        <h4 class="homepg-slider-product-name text-uppercase">
                                                            <asp:Label ID="LblProdName" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "ProductName") %>'></asp:Label></h4>

                                                        <%--<asp:Label ID="Label1" runat="server" Text='<%# ((Product) Container.DataItem).SizeQuantity[0] %>' ForeColor="White"></asp:Label> &nbsp;

                                                <asp:Label ID="Label2" runat="server" Text='<%# ((Product) Container.DataItem).SizeQuantity[1]  %>' ForeColor="White"></asp:Label>&nbsp;

                                                <asp:Label ID="Label3" runat="server" Text='<%#  ((Product) Container.DataItem).SizeQuantity[2] %>' ForeColor="White"></asp:Label>&nbsp;--%>

                                                        <div class="abslt-buynow-btn">
                                                            <asp:Button ID="ButtonFeaturedBuyNow" OnCommand="ButtonFeaturedBuyNow_Command" CssClass="btn buynow--btn btn--mob-modal text-uppercase" runat="server" Text="Buy" UseSubmitBehavior="false" CommandArgument='<%#  DataBinder.Eval(Container.DataItem, "ProductId") %>' />
                                                        </div>
                                                    </div>

                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </ul>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!--Start of Blog section-->
    <article>
        <div class="blog">
            <div class="container">
                <div class="blog__title text-center">
                    <h1 class="homepg-title text-uppercase blog--border--line">blogs</h1>
                </div>

                <asp:Panel ID="BlogSlider" runat="server">
                    <div id="blog__slider" class="blog__slider flexslider">
                        <ul class="slides">
                            <%-- <flex-slider flex-slide="blog in blogs track by $index" prev-text="" next-text="" animation="slide" item-width="400" min-items="3">--%>
                            <asp:Repeater ID="RepeatBlogData" runat="server">
                                <ItemTemplate>
                                    <li class="relate">
                                        <article class="blog__banner-detail relate">
                                            <asp:HyperLink ID="HyperLinkInnerBlog" NavigateUrl="#" runat="server">
                                                <asp:Image ID="ImageInnerBlog" ImageUrl='<%# Eval("InnerBlogsImg") %>' CssClass="img-responsive" runat="server" />
                                            </asp:HyperLink>

                                            <div class="blog__desc">
                                                <h3 class="text-uppercase">'<%# Eval("InnerBlogsName") %>'</h3>
                                                <p class="typedin-desc">'<%# Eval("InnerBlogsDesc") %>'</p>
                                                <p class="relate extra-content">

                                                    <asp:HyperLink ID="HyperLinkReadMore" NavigateUrl='<%# Eval("InnerBlogsId" , "~/Blogs/{0}") %>' runat="server" Target="_self">Read more</asp:HyperLink>
                                                </p>
                                            </div>
                                        </article>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </article>
    <!--End of Blog section-->
</asp:Content>

