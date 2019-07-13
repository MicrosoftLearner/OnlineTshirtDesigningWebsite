<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="UserOrderDetails_OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <div>
            <asp:Image ID="ImageOrderDetailBg" ImageUrl="~/Images/UserAccount/myaccount-banner.jpg" runat="server" />
        </div>
        <div class="container">
            <div class="order-details-table">
                <h2 class="order-status-title text-center">order details</h2>
                <asp:Panel ID="PanelOrderDtlTable" runat="server">
                </asp:Panel>

                <%--User Address--%>
                <div class="ordertable-footer">
                    <div class="row">
                        <div class="col-md-4 col-sm-4 col-xs-6">
                            <h4 class="usr-status-title usr-addrs-title">BILLING ADDRESS</h4>
                            <address>
                                <asp:Label ID="LabelUserBillingAdd" runat="server" Text="Label"></asp:Label>
                            </address>
                        </div>
                        <div class="col-md-4 col-sm-4 col-xs-6">
                            <h4 class="usr-status-title usr-addrs-title">SHIPPING ADDRESS</h4>
                            <address>
                                <asp:Label ID="LabelUserShippingAdd" runat="server" Text="Label"></asp:Label>
                            </address>
                        </div>
                        <div class="col-md-4 col-sm-4 col-xs-7">
                            <div class="usr-payment-info">
                                <h4 class="text-right usr-status-title usr-addrs-title">PAYMENT INFORMATION</h4>
                                <p class="text-right order-payment-info">
                                    Item(s) Subtotal:
                              
                                    <asp:Label ID="LabelTotalAmnt" runat="server" Text="Label">&#8377; </asp:Label>
                                    <br>
                                    Shipping:
                                    <asp:Label ID="LabelShiipingAmnt" runat="server" Text="Label">
                                        &#8377;</asp:Label><br>
                                    Disscount:
                                    <asp:Label ID="LabelDisscount" runat="server" Text="Label"> &#8377;</asp:Label>
                                    <br>
                                    Total:<asp:Label ID="LabelTotalAmnt1" runat="server" Text="Label"> &#8377;</asp:Label><br>
                                    Grand Total:<asp:Label ID="LabelGrandTotal" runat="server" Text="Label">&#8377; 00</asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>

                <%--UserReturned Products--%>
                <div class="return">
                    <h2 class="order-status-title text-center">Returned</h2>
                    <asp:Panel ID="PanelOrderReturnTable" runat="server">
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

