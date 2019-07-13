<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InnerBlogs.aspx.cs" Inherits="Blogs_InnerBlogs" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <article>
        <div class="container">
            <div class="inner-blog blog">
                <div class="blog__slider">
                    <asp:Panel ID="PanelInnerBlogSlider" runat="server">
                        <div id="innerBlogSlider" class="flexslider">
                            <ul class="slides">
                                <asp:Repeater ID="RepeatInnerBlogs" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="inner-blog-section">
                                                <div>
                                                    <h3 class="inner-blog-title text-center text-uppercase "><%# Eval("InnerBlogsName") %></h3>
                                                </div>
                                                <asp:Image ID="ImageInnerBlogUser" ImageUrl='<%# Eval("InnerBlogsImg") %>' runat="server"></asp:Image>
                                                <!-- <p class="section-tp-bt-padd">{{innarBlogs.description}}</p> -->
                                                <!-- <div class="section-tp-bt-padd">
                        <img ng-src="{{innarBlogs.image |serverimage}}" alt="Blogger Photo" class="img-responsive">
                    </div> -->
                                                <div class="inner-blog-dynmc-content">
                                                    <div class="section-tp-bt-padd">
                                                        <p><%# Eval("InnerBlogsDesc") %></p>
                                                    </div>
                                                </div>
                                                <div class="section-tp-bt-padd inner-blog-change-content">
                                                    <div class="flex-item-container">
                                                        <div class="flex-item text-left">
                                                            <div class=" action relate">
                                                                <!-- <a href="#" class=" action"><i class="fa fa-long-arrow-left" aria-hidden="true"></i> <span class="action-btn">Previous</span></a> -->
                                                                <ul class="flex-direction-nav">
                                                                    <li class="flex-nav-prev"><a class="action flex-prev " href="#"></a></li>

                                                                </ul>
                                                                <div>
                                                                    <span class="action-btn action-btn-prev">Previous</span>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="flex-item ">
                                                            <div class="social-box">
                                                                <ul class="list-unstyled mb-0 flex-item-container">
                                                                    <li>Share</li>
                                                                    <li>
                                                                        <asp:HyperLink ID="HyperLinkInnerBlogFb" NavigateUrl="#" runat="server"><i class="fa fa-facebook" aria-hidden="true"></i></asp:HyperLink>
                                                                    </li>
                                                                    <li>
                                                                        <asp:HyperLink ID="HyperLinkInnerBlogTw" NavigateUrl="#" runat="server"><i class="fa fa-twitter" aria-hidden="true"></i></asp:HyperLink>
                                                                    </li>
                                                                    <li>
                                                                        <asp:HyperLink ID="HyperLinkInnerBlogInsta" NavigateUrl="#" runat="server"><i class="fa fa-instagram" aria-hidden="true"></i></asp:HyperLink>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                        <div class="flex-item text-right">
                                                            <div class="action relate">
                                                                <ul class="flex-direction-nav">
                                                                    <li class="flex-nav-next">
                                                                        <asp:HyperLink ID="HyperLinkInnerBlogFlexNext" runat="server" NavigateUrl="#" CssClass="action flex-next pull-right"></asp:HyperLink>
                                                                        <%--<a class="action flex-next pull-right" href="#"></a>--%>

                                                                    </li>
                                                                </ul>
                                                                <div>
                                                                    <asp:Label ID="LabelInnerBlogNext" runat="server" CssClass="action-btn action-btn-next" Text="Next"></asp:Label>
                                                                    <%--<span class="action-btn action-btn-next">Next</span>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                        <%--<flex-slider flex-slide="allBlogData in sliderBlogsData track by $index" animation="slide" item-width="" min-items="1" slideshow="false">
                    <li>
                        
                    </li>
                </flex-slider>--%>
                    </asp:Panel>

                    <%--SqlDataSource for the particular user--%>
                    <asp:SqlDataSource ID="DataSourceParticularUser" runat="server" ProviderName="MySql.Data.MySqlClient" ConnectionString="<%$ ConnectionStrings:OnlineTshirtDesigning %>" SelectCommand="SELECT InnerBlogsId, InnerBlogsImg, InnerBlogsName, InnerBlogsDesc FROM inner_blogs WHERE InnerBlogsId=@InnerBlogsId">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="InnerBlogsId" QueryStringField="InnerBlogsId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:Label ID="LblDatabaseError" runat="server"></asp:Label>
                    <%--Also view section--%>
                    <div class="also-view">
                        <h3 class="inner-blog-title text-uppercase">Also view</h3>
                        <asp:Panel ID="PanelInnerBlogOther" runat="server">
                            <div class="flexslider innerblog-other">
                                <ul class="slides">
                                    <asp:Repeater ID="RepeatAlsoView" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <div class="blog__banner-detail relate">
                                                    <asp:Image ID="ImageInnerBlogOther" CssClass="img-responsive" ImageUrl='<%# Eval("InnerBlogsImg") %>' runat="server"></asp:Image>
                                                    <div class="blog__desc">
                                                        <h3 class="text-uppercase"><%# Eval("InnerBlogsName") %></h3>
                                                        <p class="typedin-desc">
                                                            <%# Eval("InnerBlogsDesc") %>
                                                        </p>
                                                        <p class="relate extra-content">
                                                            <asp:HyperLink ID="HyperLinkinnerBlogRead" NavigateUrl='<%# Eval("InnerBlogsId", "~/Blogs/{0}") %>' Target="_self" runat="server">Read more</asp:HyperLink>

                                                        </p>
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </asp:Panel>
                        <%--  <flex-slider flex-slide="blogs in removedBlog track by $index" animation="slide" item-width="300" min-items="3" slideshow-speed="2000">
                        </li>
                    </flex-slider>--%>
                    </div>
                </div>
            </div>
        </div>
    </article>
</asp:Content>

