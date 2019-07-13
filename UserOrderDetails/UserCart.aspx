<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserCart.aspx.cs" Inherits="UserOrderDetails_UserCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <div class="bg-mycart">
            <div class="mycart-img">
                <asp:Image ID="ImageMyCartBg" ImageUrl="~/Images/Cart/mycart-bg.jpg" CssClass=" img-responsive" runat="server" />
            </div>
        </div>
        <div class="container">
            <div class="mycart-container">
                <div class="table-responsive">
                    <asp:Table ID="TableUserCart" CssClass="table mycart-table" runat="server">

                        <asp:TableHeaderRow ID="UserCartHeaderRow" runat="server">
                            <asp:TableHeaderCell Scope="Column" runat="server">
                               ITEM
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server">
                               COLOR
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server">
                               SIZE
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server">
                              QUANTITY
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server">
                               PRICE
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server">
                               SUBTOTAL
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>

                </div>

                <div class="mycart-footer">

                    <div class="pull-right">
                        <div class="text-right inline-block">
                            <p>ITEM(S) SUBTOTAL :</p>
                            <p>SHIPPING:</p>
                            <p>MEMBER'S DISCOUNT:</p>
                            <p>TOTAL:</p>
                            <p>GST:</p>
                            <p>GRAND TOTAL:</p>
                        </div>
                        <div class="inline-block">
                            <p>&#x20b9 {{total}}</p>
                            <p>&#x20b9 0</p>
                            <p>&#x20b9 {{grandTotalAfterDiscount}}</p>
                            <p>&#x20b9 {{total-grandTotalAfterDiscount}}</p>
                            <!--<p ng-if="!discountApplicableforCart">&#x20b9 0</p>-->
                            <p>&#x20b9 {{productGst}}</p>
                            <p>&#x20b9 {{total-grandTotalAfterDiscount+productGst}}</p>
                            <!--<p ng-if="!discountApplicableforCart">&#x20b9 {{total-grandTotalAfterDiscount|number:0}}</p>-->
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="pull-right margin-15">
                        <p>

                            <button class="btn text-uppercase shop--btn" ui-sref="listing-page">Continue shopping</button>
                            <%--  <button class="btn text-uppercase checkout--btn" ng-click="redirectToCheckot()">checkout</button>--%>
                            <%-- <asp:Button ID="BtnCheckout" runat="server" PostBackUrl="~/Checkout.aspx" CssClass="btn text-uppercase checkout--btn" Text="checkout" />--%>

                            <asp:LinkButton ID="BtnCheckout" CssClass="btn text-uppercase checkout--btn" PostBackUrl="~/Checkout.aspx" runat="server">checkout</asp:LinkButton>

                        </p>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

