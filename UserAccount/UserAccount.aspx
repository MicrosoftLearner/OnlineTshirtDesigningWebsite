<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserAccount.aspx.cs" Inherits="UserAccount_UserAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="usr-account">
        <div>
            <img src="../Images/UserAccount/myaccount-banner.jpg" alt="BannerImage" class="img-responsive">
        </div>
        <div class="container">
            <div class="content-spacing">
                <div class="row">
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="list-checkout">
                            <div class="checkout-tab-btn">
                                <asp:LinkButton ID="LinkButtonUserProf" CssClass="btn btn--list" OnClick="LinkButtonUserProf_Click" runat="server">PROFILE</asp:LinkButton>

                            </div>
                            <div class="checkout-tab-btn">
                                <asp:LinkButton ID="LinkButtonUserAddr" CssClass="btn btn--list" runat="server" OnClick="LinkButtonUserAddr_Click">MANAGE
                                ADDRESS</asp:LinkButton>
                            </div>
                            <div class="checkout-tab-btn">
                                <asp:LinkButton ID="LinkButtonuserOrdered" CssClass="btn order-list--btn text-uppercase" OnClick="LinkButtonuserOrdered_Click" runat="server">Orders</asp:LinkButton>
                            </div>
                            <%--<div class="checkout-tab-btn">
                                <asp:LinkButton ID="LinkButtonUserReturn" CssClass="btn order-list--btn text-uppercase" runat="server">Return/Exchange</asp:LinkButton>
                            </div>
                            <div class="checkout-tab-btn">
                                <asp:LinkButton ID="LinkButtonUserCancel" CssClass="btn order-list--btn text-uppercase" runat="server">Cancelled</asp:LinkButton>
                            </div>
                            <div class="checkout-tab-btn">
                                <asp:LinkButton ID="LinkButtonUserWishlist" CssClass="btn btn--list text-uppercase" runat="server">WISHLIST</asp:LinkButton>
                            </div>--%>
                        </div>
                    </div>

                    <!--To open profile Tab-->
                    <asp:Panel ID="PanelUserProf" CssClass="prof-tab" runat="server">
                        <asp:MultiView ID="MultiViewUserChoice" runat="server">
                            <asp:View ID="ViewUserProf" runat="server">
                                <div class="col-md-9 col-sm-12  col-xs-12">
                                    <div class="row">
                                        <div class="col-md-6 col-sm-12  col-xs-12">
                                            <div class="userdtl-main">
                                                <asp:MultiView ID="MultiViewUserDtl" ActiveViewIndex="0" runat="server">

                                                    <asp:View ID="ViewUserDtlSaved" runat="server">
                                                        <asp:Panel ID="PanelUserDtlSave" runat="server">
                                                            <div class="usrdtl-title">
                                                                <h3 class="tab-title">YOUR DETAILS
                                                     <%--<asp:HyperLink ID="HyperLinkUserEdit"  NavigateUrl="#" CssClass-="linking" runat="server"><span>edit</span> </asp:HyperLink>--%>
                                                                </h3>
                                                            </div>
                                                            <div class="usrdtl">
                                                                <p class="usrdtl-info">
                                                                    Name: <asp:Label ID="LblUserProfFullName" runat="server"  CssClass="text-capitalize left-space"></asp:Label>
                                                                    <br>

                                                                    Email id: <asp:Label ID="LblUserProfEmail" runat="server"  CssClass="text-lowercase left-space"></asp:Label>
                                                                    <%--<span class="text-capitalize left-space"><%= cust.EmailId %></span>--%><br>
                                                                    Mobile:
                                           
                                                  <asp:Label ID="LblUserProfMob" CssClass="text-uppercase left-space"  runat="server" ></asp:Label>  
                                                                </p>

                                                                <p class="usrdtl-info">
                                                                    Want to change your password? 
                                                        <asp:HyperLink ID="HyperLink1" CssClass="linking" runat="server">CLICK HERE</asp:HyperLink>

                                                                </p>
                                                                <p>
                                                                    <asp:Button ID="Button1" CommandName="SwitchViewByID" CommandArgument="ViewUserDtlEdit" UseSubmitBehavior="false" CssClass="btn btn--brown" runat="server" Text="Edit" />
                                                                </p>
                                                            </div>
                                                        </asp:Panel>
                                                    </asp:View>

                                                    <asp:View ID="ViewUserDtlEdit" runat="server">
                                                        <div class="userdtl-main">
                                                            <h3 class="tab-title">YOUR DETAILS 
                                                   
                                                        <%--<asp:HyperLink ID="HyperLinkuserSave" NavigateUrl="#" CssClass="linking" runat="server">
                                                            <asp:Label ID="LabelUserSave" runat="server" Text="Save"></asp:Label>
                                                        </asp:HyperLink>--%>

                                                            </h3>
                                                        </div>
                                                        <asp:Panel ID="PanelUserDtlEdit" runat="server">
                                                            <div class="row">
                                                                <div class="col-md-12 col-sm-12 col-xs-12 edit-dtl">
                                                                    <div class="row">
                                                                        <div class="customized-form">
                                                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                                                <div class="form-group">
                                                                                    <input type="text" placeholder="First Name" class="form-control ">
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                                                <div class="form-group">
                                                                                    <input type="text" placeholder="Last Name" class="form-control ">
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6 col-sm-6 col-xs-12 ">
                                                                                <div class="form-group">
                                                                                    <input type="text" placeholder="Mobile No" class="form-control ">
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                                                <div class="form-group">
                                                                                    <input type="email" placeholder="Email Address" class="form-control ">
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <p>
                                                                <asp:Button ID="Button2" CommandName="SwitchViewByID" CommandArgument="ViewUserDtlSaved" UseSubmitBehavior="false" CssClass="btn btn--brown" runat="server" Text="Save" />
                                                            </p>
                                                        </asp:Panel>
                                                    </asp:View>
                                                </asp:MultiView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>

                        </asp:MultiView>
                    </asp:Panel>

                    <%--To open Manage address panel--%>
                    <asp:Panel ID="PanelUserAddr" runat="server">
                        <asp:MultiView ID="MultiViewUserAddr" runat="server">

                            <asp:View ID="ViewUserAddrSaved" runat="server">
                                <!--To open Manage Address Tab-->
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <div class="row">

                                        <asp:Panel ID="PanelShowEditAddr" CssClass="col-md-12 col-sm-12 col-xs-12" runat="server">
                                            <h3 class="tab-title text-uppercase">shipping address
                                   
                                                <a class="linking">
                                                    <span class="tab-title pull-right">
                                                        <i class="fa fa-plus"></i>
                                                    </span>
                                                </a>
                                            </h3>

                                        </asp:Panel>
                                    </div>
                                </div>

                                <asp:Panel ID="PanelUserAddrSaved" CssClass="col-md-4 col-sm-6 col-xs-12" runat="server">

                                    <div class="manage-addrs custom-checkbox">
                                        <p class="usrdtl-info">
                                            <asp:Label ID="LblUserAddrFullName" CssClass="usr-name text-capitalize" runat="server"></asp:Label>
                                           
                                       
                                            <br>
                                            <asp:Label ID="LblUserAddrEmail" runat="server"></asp:Label>
                                         
                                        </p>
                                        <address class="usrdtl-info">
                                            <asp:Label ID="LblUserShipAddr" CssClass="text-capitalize" runat="server"></asp:Label>

                                            <asp:Label ID="LblUserShipCity" CssClass="text-capitalize city" runat="server"></asp:Label>

                                            <asp:Label ID="LblUserShipPinCode" runat="server" Text="Label"></asp:Label>
                                          <br>
                                            <asp:Label ID="LblUserShipContry" runat="server" Text="Label"></asp:Label>
                                         
                                        </address>
                                        <div class="checkbox usrdtl-info">
                                            <asp:CheckBox ID="CheckBoxUserAddrDef" Text="Use this as default shipping address" runat="server" />
                                        </div>
                                        <p>
                                            <asp:Button ID="ButtonUserAddrEdit" CommandName="SwitchViewByID" CommandArgument="ViewUserAddrEdit" UseSubmitBehavior="false" CssClass="btn address-edit-btn" runat="server" Text="Edit" />
                                            <asp:Button ID="ButtonUserAddrDelete" CssClass="btn address-delt-btn" runat="server" Text="Delete" />
                                        </p>
                                    </div>
                                </asp:Panel>
                            </asp:View>

                            <asp:View ID="ViewUserAddrEdit" runat="server">
                                <asp:Panel ID="PaneluserShowEditAddr" CssClass="col-md-9 col-sm-12 col-xs-12" runat="server">
                                    <div class="edit-addrs">
                                        <div class="customized-form">
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-xs-12">
                                                    <h3 class="tab-title text-uppercase">shipping address</h3>
                                                </div>
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="TboxLine1" CssClass="form-control" placeholder="Line 1*" runat="server"></asp:TextBox>
                                                       
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                           <asp:TextBox ID="TboxLine2" CssClass="form-control" placeholder="Line 2*" runat="server"></asp:TextBox>
                                                       
                                                    </div>
                                                </div>
                                            </div>
                                          
                                            <div class="row">
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="TboxCity"  placeholder="City" CssClass="form-control"  runat="server"></asp:TextBox>
                                                        
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                         <asp:TextBox ID="TboxPinCode" TextMode="Number" placeholder="Pincode" CssClass="form-control"  runat="server"></asp:TextBox>
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group country-dropdown">
                                                        <asp:DropDownList ID="DropDownListUserState" runat="server">
                                                            <asp:ListItem Text="State" />
                                                            <asp:ListItem Text="Maharashtra" />
                                                            <asp:ListItem Text="India" />

                                                        </asp:DropDownList>
                                                        <%--<button class="btn country-dropdown--btn text-capitalize" ng-model="editAddress.country"type="button" >
                                                            {{countryButton}} <span class="caret"></span>
                                                        </button>

                                                        <ul class="country-dropdown-menu dropdown-menu text-capitalize"
                                                            uib-dropdown-menu role="menu">
                                                            <li role="menuitem" ng-repeat="country in selectCounteries"
                                                                ng-click="changeCountry(country.name)"><a>{{country.name}}</a></li>
                                                        </ul>--%>
                                                    </div>
                                                </div>

                                                <asp:Panel ID="PanelUserAddrCountry" CssClass="col-md-4 col-sm-6 col-xs-12" runat="server">
                                                    <div class="form-group country-dropdown">
                                                        <asp:DropDownList ID="DropDownListUserCountry" runat="server">
                                                            <asp:ListItem Text="Country" />
                                                            <asp:ListItem Text="Maha" />

                                                        </asp:DropDownList>
                                                        <%-- <button class="btn country-dropdown--btn text-capitalize" ng-model="editAddress.state"
                                                            type="button" uib-dropdown-toggle>
                                                            {{stateButton}} <span class="caret"></span>
                                                        </button>
                                                        <ul class="country-dropdown-menu dropdown-menu text-capitalize"
                                                            uib-dropdown-menu role="menu">
                                                            <li role="menuitem" ng-repeat="state in selectedState" ng-click="changeState(state)"><a>{{state}}</a></li>
                                                        </ul>--%>
                                                    </div>

                                                </asp:Panel>

                                                <asp:Panel ID="PanelUserAddrCountryNot" CssClass="col-md-4 col-sm-6 col-xs-12" runat="server">
                                                    
                                                </asp:Panel>
                                            </div>
                                            <p>
                                                <asp:Button ID="ButtonUserAddrSave" CssClass="btn save--btn text-uppercase" runat="server" CommandName="SwitchViewByID" CommandArgument="ViewUserAddrSaved" UseSubmitBehavior="false" Text="save" />
                                                <asp:Button ID="ButtonUserAddrCancel" CssClass="btn delt--btn text-uppercase" runat="server" Text="cancel" />
                                            </p>
                                        </div>

                                    </div>

                                </asp:Panel>

                            </asp:View>

                        </asp:MultiView>
                    </asp:Panel>

                    <%--To open Ordered product panel--%>

                    <asp:Panel ID="PanelUserOrder" Visible="false" runat="server">
                        <asp:Panel ID="PaneluserOrderButtons"  CssClass="col-md-9 col-sm-12 col-xs-12" runat="server">

                            <p class="text-uppercase order-list-action text-center">
                                <asp:Button ID="ButtonUserOrders" OnClick="ButtonUserOrders_Click" CssClass="btn order-list--btn text-capitalize" runat="server" Text="orders" UseSubmitBehavior="false" />
                                <asp:Button ID="ButtonUserReturn" OnClick="ButtonUserReturn_Click" CssClass="btn order-list--btn text-capitalize" runat="server" Text="return" UseSubmitBehavior="false" />
                                <asp:Button ID="ButtonUserCancelled" OnClick="ButtonUserCancelled_Click" UseSubmitBehavior="false" CssClass="btn order-list--btn text-capitalize" runat="server" Text="cancelled" />
                            </p>
                            <asp:MultiView ID="MultiViewUserOrdered" ActiveViewIndex="0" runat="server">
                                <asp:View ID="ViewUserOrdered" runat="server">
                                    <asp:Panel ID="PanelUserOrderTable" CssClass="account-order-table table-responsive" runat="server">
                                        <asp:Table ID="TableUserOrder" CssClass="table" runat="server">
                                        </asp:Table>
                                    </asp:Panel>
                                </asp:View>

                                <asp:View ID="ViewUserReturned" runat="server">
                                    <asp:Panel ID="PanelUserOrderReturnTable" CssClass="account-order-table table-responsive" runat="server">
                                    </asp:Panel>

                                </asp:View>

                                <asp:View ID="ViewUserCancelled" runat="server">
                                    <asp:Panel ID="PanelUserOrderCancelTable" CssClass="account-order-table table-responsive" runat="server">
                                    </asp:Panel>
                                </asp:View>
                            </asp:MultiView>
                        </asp:Panel>

                        <%--<div class="order-tab" ng-if="view == 'orderTab' ">
                            <!--To open an Order Tab-->
                        </div>--%>
                    </asp:Panel>

                    <asp:Panel ID="PaneluserWishlist" runat="server"></asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

