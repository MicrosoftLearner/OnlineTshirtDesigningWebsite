<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ShortSleeveProduct.aspx.cs" Inherits="Products_ProductShortSleeve_ShortSleeveProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <section>
        <div class="short-sleeve">
            <div class="container">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <h3>Short Sleeve T-shirts</h3>
                        <div class="short-sleeve-filter">
                            <asp:LinkButton ID="LnkBtnProductFilter" OnClick="LnkBtnProductFilter_Click" runat="server">
                                <asp:Image ID="ImgFilter" ImageUrl="~/Images/Products/Filter.png" ImageAlign="Top" runat="server" />
                                <asp:Label ID="LblFilter" runat="server" Text=" Filters"></asp:Label>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>

                <asp:MultiView ID="MlViewFilterChoice" ActiveViewIndex="0" runat="server">
                    <asp:View ID="ViewWithFilter" runat="server">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="panel-group">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <asp:HyperLink ID="HpLinkFilterStyle" data-toggle="collapse" NavigateUrl="#FilterStyle" runat="server">Style</asp:HyperLink>

                                        </div>
                                        <div class="panel-body">
                                            <div id="FilterStyle" class="collapse-in">
                                                <%--<asp:CheckBoxList ID="ChkBoxListStyle" runat="server"></asp:CheckBoxList>--%>

                                                <asp:LinkButton ID="LnkBtnFilterStyleMen" CssClass="pretty p-icon" runat="server">
                                                    <asp:CheckBox ID="ChkBoxMen" runat="server" />

                                                    <div class="state">
                                                        <i class="icon fa fa-check"></i>
                                                        <label>Men's</label>
                                                    </div>
                                                </asp:LinkButton>
                                                <br />
                                                <br />

                                                <asp:LinkButton ID="LnkBtnFilterStyleWomen" CssClass="pretty p-icon" runat="server">
                                                    <asp:CheckBox ID="ChkBoxWomen" runat="server" />
                                                    <div class="state">
                                                        <i class="icon fa fa-check"></i>
                                                        <label>
                                                            Women's
                                                        </label>
                                                    </div>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <asp:HyperLink ID="HpLinkFilterColor" NavigateUrl="#FilterColor" data-toggle="collapse" runat="server">Color Family</asp:HyperLink>

                                        </div>

                                        <div class="panel-body">
                                            <div id="FilterColor" class="collapse-in
                                                ">

                                                <asp:LinkButton ID="LnkBtnFilterColorBlk" CssClass="pretty p-icon" runat="server">
                                                    <asp:CheckBox ID="ChkBoxBlack" runat="server" />
                                                    <div class="state">
                                                        <i class="icon fa fa-check" style="color: white"></i>
                                                        <label class="black"></label>
                                                    </div>
                                                </asp:LinkButton>

                                                <asp:LinkButton ID="LnkBtnFilterColorBlue" CssClass="pretty p-icon" runat="server">
                                                    <asp:CheckBox ID="ChkBoxBlue" runat="server" />
                                                    <div class="state">
                                                        <i class="icon fa fa-check" style="color: white"></i>
                                                        <label class="blue"></label>
                                                    </div>
                                                </asp:LinkButton>

                                                <asp:LinkButton ID="LnkBtnFilterColorBrwn" CssClass="pretty p-icon" runat="server">
                                                    <asp:CheckBox ID="ChkBoxBrwn" runat="server" />
                                                    <div class="state">
                                                        <i class="icon fa fa-check" style="color: white"></i>
                                                        <label class="brwn"></label>
                                                    </div>
                                                </asp:LinkButton>

                                                <asp:LinkButton ID="LnkBtnFilterColorGr" CssClass="pretty p-icon" runat="server">
                                                    <asp:CheckBox ID="ChkBoxGrn" runat="server" />
                                                    <div class="state">
                                                        <i class="icon fa fa-check" style="color: white"></i>
                                                        <label class="green"></label>
                                                    </div>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <asp:HyperLink ID="HpLinkFilterFeature" NavigateUrl="#FilterFeature" data-toggle="collapse" runat="server">Features</asp:HyperLink>
                                        </div>
                                        <div class="panel-body">
                                            <div id="FilterFeature" class="collapse-in">
                                                <asp:LinkButton ID="LnkBtnFilterFeat" CssClass="pretty p-icon" runat="server">
                                                    <asp:CheckBox ID="ChkBoxFeat" runat="server" />
                                                    <div class="state">
                                                        <i class="icon fa fa-check" style="color: black;"></i>
                                                        <label>V-Neck</label>
                                                    </div>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="thumbnail">
                                            <asp:HyperLink ID="HpLinkUltraCotton" NavigateUrl="~/IndividualProduct.aspx?Cat=UltraCotton&ProductID=1000" runat="server">
                                                <asp:Image ID="ImgUltraCotton" ImageUrl="~/Images/Products/UltraCottonTShirt.jpg" CssClass="img-responsive" runat="server" />
                                            </asp:HyperLink>

                                            <div class="caption text-center">
                                                <h3>Ultra Cotton T-shirt</h3>
                                                <p>XS-XXL | No Minimum</p>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="thumbnail">
                                            <asp:HyperLink ID="HpLinkJersy" NavigateUrl="~/IndividualProduct.aspx?Cat=JerseyTshirt&ProductID=2000" runat="server">
                                                <asp:Image ID="ImgJersy" ImageUrl="~/Images/Products/JerseyTShirt.jpg" CssClass="img-responsive" runat="server" />
                                            </asp:HyperLink>

                                            <div class="caption text-center">
                                                <h3>Jersey T-shirt</h3>
                                                <p>XS-XXL | No Minimum</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewWithoutFilter" runat="server">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="thumbnail">
                                    <asp:HyperLink ID="HyperLink1" runat="server">
                                        <asp:Image ID="Image1" ImageUrl="~/Images/Products/UltraCottonTShirt.jpg" CssClass="img-responsive" runat="server" />
                                    </asp:HyperLink>

                                    <div class="caption text-center">
                                        <h3>Ultra Cotton T-shirt</h3>
                                        <p>XS-XXL | No Minimum</p>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="thumbnail">
                                    <asp:HyperLink ID="HyperLink2" runat="server">
                                        <asp:Image ID="Image2" ImageUrl="~/Images/Products/UltraCottonTShirt.jpg" CssClass="img-responsive" runat="server" />
                                    </asp:HyperLink>

                                    <div class="caption text-center">
                                        <h3>Jersey T-shirt</h3>
                                        <p>XS-XXL | No Minimum</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>

            </div>
        </div>
    </section>
</asp:Content>

