<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminHeader.ascx.cs" Inherits="UserControl_AdminHeader" %>
<nav class="navbar navbar-inverse navbar-fixed-top ">
    <div class="container-fluid">
        <div class="navbar-header">
            <a class="navbar-brand" href="#">Admin Panel</a>
        </div>
        <ul class="nav navbar-nav">
            <li class="active"><a href="#">Home</a></li>
            <li class="dropdown">
                <a class="dropdown-toggle" data-toggle="dropdown" href="#">Page 1 <span class="caret"></span></a>
                <ul class="dropdown-menu">
                    <li>
                        <asp:HyperLink ID="HypLinkHomeBanner" NavigateUrl="~/Account/AdminOrder.aspx" runat="server">Home Baneer</asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="HypLinkUserOrder" runat="server">HyperLink</asp:HyperLink>
                    </li>
                </ul>
            </li>
            <li><a href="#">Page 2</a></li>
        </ul>
        <ul class="nav navbar-nav navbar-right">
            <%--<li><a ><span class="glyphicon glyphicon-user"></span>Sign Up</a></li>--%>
            <li>
                <asp:Panel ID="PnlAdminIdentity" Visible="false" runat="server">
                    <i class="fa fa-user-circle-o" aria-hidden="true"></i>&nbsp;
                <asp:Label ID="LblAdminName" runat="server">
                </asp:Label>
                    <asp:Button ID="BtnAdminLogout" CssClass="btn btn--brown pull-right " OnClick="BtnAdminLogout_Click" runat="server" Text="Logout" />

                </asp:Panel>

              <%--  <a href="../Account/AdminLogin.aspx"><span class="glyphicon glyphicon-log-in"></span>Logout</a>--%>

            </li>
        </ul>
    </div>
</nav>