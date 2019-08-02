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
                                                                    Name:
                                                                    <asp:Label ID="LblUserProfFullName" runat="server" CssClass="text-capitalize left-space"></asp:Label>
                                                                    <br>
                                                                    Email id:
                                                                    <asp:Label ID="LblUserProfEmail" runat="server" CssClass="text-lowercase left-space"></asp:Label>
                                                                    <%--<span class="text-capitalize left-space"><%= cust.EmailId %></span>--%><br>
                                                                    Mobile:
                                           
                                                  <asp:Label ID="LblUserProfMob" CssClass="text-uppercase left-space" runat="server"></asp:Label>
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
                                                                                    <asp:TextBox ID="TBoxFirstName" CssClass="form-control" placeholder="First Name" runat="server"></asp:TextBox>

                                                                                    <asp:RequiredFieldValidator ID="ValidatorFirstName" runat="server" ErrorMessage="Enter first name" ControlToValidate="TBoxFirstName" CssClass="alert-danger">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                                                <div class="form-group">
                                                                                    <asp:TextBox ID="TBoxLastName" CssClass="form-control" placeholder="Last Name" runat="server"></asp:TextBox>

                                                                                    <asp:RequiredFieldValidator ID="ValidatorLastName" runat="server" ErrorMessage="Enter last name" ControlToValidate="TBoxLastName" CssClass="alert-danger">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6 col-sm-6 col-xs-12 ">
                                                                                <div class="form-group">
                                                                                    <asp:TextBox ID="TBoxMobNo" CssClass="form-control" placeholder="Mobile No" runat="server"></asp:TextBox>

                                                                                    <asp:RequiredFieldValidator ID="ValidatorMobNo" runat="server" ErrorMessage="Enter Mobile no" ControlToValidate="TBoxMobNo" CssClass="alert-danger">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6 col-sm-6 col-xs-12">

                                                                                <div class="form-group">
                                                                                    <asp:TextBox ID="TBoxEmail" CssClass="form-control" TextMode="Email" placeholder="Email Address" runat="server"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="ValidatorEmail" runat="server" ErrorMessage="Enter Email" ControlToValidate="TBoxEmail" CssClass="alert-danger">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <p>
                                                                <asp:Button ID="BtnUserDtlSaved" CommandName="SwitchViewByID" CommandArgument="ViewUserDtlSaved" UseSubmitBehavior="false" OnClick="BtnUserDtlSaved_Click" CssClass="btn btn--brown" runat="server" Text="Save" />
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
                                   
                                                <asp:LinkButton ID="LkBtnAddMoreShipAddr" data-toggle="popover" data-trigger="hover" data-content="Add new address" data-placement="left" CssClass=" tab-title pull-right" OnClick="LkBtnAddMoreShipAddr_Click" runat="server">
                                                    <span>

                                                        <i class="fa fa-plus"></i>
                                                    </span> 
                                                </asp:LinkButton>

                                            </h3>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <asp:Repeater ID="RptUserAddr" OnItemDataBound="RptUserAddr_ItemDataBound" runat="server">
                                    <ItemTemplate>
                                        <asp:Panel ID="PanelUserAddrSaved" CssClass="col-md-4 col-sm-6 col-xs-12" runat="server">

                                            <div class="manage-addrs custom-checkbox">
                                                <p class="usrdtl-info">
                                                    <asp:Label ID="LblUserFirstName" CssClass="usr-name text-capitalize" runat="server"></asp:Label>
                                                    &nbsp;

                                                      <asp:Label ID="LblUserLastName" CssClass="usr-name text-capitalize" runat="server"></asp:Label>
                                                    <br>

                                                                  <asp:Label ID="LblUserAddrEmail" runat="server"></asp:Label>
                                                    
                                                </p>
                                                <address class="usrdtl-info">
                                                    <asp:Label ID="LblUserShipAddr" CssClass="text-capitalize" runat="server"></asp:Label>

                                                    <asp:Label ID="LblUserShipCity" CssClass="text-capitalize city" runat="server"></asp:Label>

                                                    <asp:Label ID="LblUserShipPinCode" runat="server" Text="Label"></asp:Label>
                                                    <br>
                                                    <asp:Label ID="LblUserShipContry" runat="server" Text="Label"> </asp:Label>

                                                </address>
                                                <div class="checkbox usrdtl-info">
                                                    <asp:CheckBox ID="CheckBoxUserAddrDef" Text="Use this as default shipping address" runat="server" />
                                                </div>
                                                <p>
                                                    <asp:Button ID="ButtonUserAddrEdit" OnCommand="ButtonUserAddrEdit_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Key") %>' UseSubmitBehavior="false" CssClass="btn address-edit-btn" runat="server" Text="Edit" />

                                                    <asp:Button ID="ButtonUserAddrDelete" CssClass="btn address-delt-btn" runat="server" Text="Delete" />
                                                </p>
                                            </div>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:Repeater>

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

                                                        <asp:RequiredFieldValidator ID="ValidatorShipAddrLine1" runat="server" ErrorMessage="Enter Address" ControlToValidate="TboxLine1" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="TboxLine2" CssClass="form-control" placeholder="Line 2*" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="ValidatorShipAddrLine2" runat="server" ErrorMessage="Enter Address" ControlToValidate="TboxLine2" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="TboxCity" placeholder="City" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="ValidatorShipAddrCity" runat="server" ErrorMessage="Enter City" ControlToValidate="TboxCity" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="TboxPinCode" TextMode="Number" placeholder="Pincode" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="ValidatorShipAddrPinCode" runat="server" ErrorMessage="Enter City" ControlToValidate="TboxPinCode" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group country-dropdown">
                                                        <asp:DropDownList ID="DropDownListUserCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListUserCountry_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Country" />
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator ID="ValidatorShipAddrContry" runat="server" ErrorMessage="Select Country" ControlToValidate="DropDownListUserCountry" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>
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
                                                        <asp:DropDownList ID="DropDownListUserState" runat="server">
                                                            <asp:ListItem Text="Select State" />

                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator ID="ValidatorShipAddrState" runat="server" ErrorMessage="Select State" ControlToValidate="DropDownListUserState" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>
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
                                                <asp:Button ID="ButtonUserAddrSave" CssClass="btn save--btn text-uppercase" runat="server" UseSubmitBehavior="false" OnClick="ButtonUserAddrSave_Click" Text="save" />

                                                <asp:Button ID="ButtonUserAddrCancel" CausesValidation="false" CssClass="btn delt--btn text-uppercase" CommandName="SwitchViewByID" CommandArgument="ViewUserAddrSaved" runat="server" Text="cancel" />
                                            </p>
                                        </div>

                                    </div>

                                </asp:Panel>

                            </asp:View>

                            <asp:View ID="ViewUserAddrPresence" runat="server">
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <div class="edit-addrs">
                                        <div class="customized-form">

                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-xs-12">
                                                    <h3 class="tab-title text-uppercase">shipping address</h3>
                                                </div>
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="TBoxNewAddrLine1" CssClass="form-control" placeholder="Line 1*" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="ValidatorShipNewAddrL1" runat="server" ErrorMessage="Enter Address" ControlToValidate="TBoxNewAddrLine1" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="TBoxNewAddrLine2" CssClass="form-control" placeholder="Line 2*" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="ValidatorShipNewAddrL2" runat="server" ErrorMessage="Enter Address" ControlToValidate="TBoxNewAddrLine2" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="TBoxNewAddrCity" placeholder="City" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="ValidatorShipNewAddrCity" runat="server" ErrorMessage="Enter City" ControlToValidate="TBoxNewAddrCity" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="TBoxNewAddrPinCode" TextMode="Number" placeholder="Pincode" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="ValidatorShipNewAddrPinCode" runat="server" ErrorMessage="Enter City" ControlToValidate="TBoxNewAddrPinCode" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4 col-sm-6 col-xs-12">
                                                    <div class="form-group country-dropdown">
                                                        <asp:DropDownList ID="ListShipNewCountry" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ListShipNewCountry_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Country" />
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator ID="ValidatorShipNewAddrCont" runat="server" ErrorMessage="Select Country" ControlToValidate="ListShipNewCountry" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>
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

                                                <asp:Panel ID="Panel1" CssClass="col-md-4 col-sm-6 col-xs-12" runat="server">
                                                    <div class="form-group country-dropdown">
                                                        <asp:DropDownList ID="ListShipNewState" runat="server">
                                                            <asp:ListItem Text="Select State" />

                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator ID="ValidatorShipNewAddrState" runat="server" ErrorMessage="Select State" ControlToValidate="ListShipNewState" CssClass="alert-danger">
                                                        </asp:RequiredFieldValidator>
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

                                                <asp:Panel ID="Panel2" CssClass="col-md-4 col-sm-6 col-xs-12" runat="server">
                                                </asp:Panel>
                                            </div>
                                            <p>
                                                <asp:Button ID="BtnShipNewAddrSave" CssClass="btn save--btn text-uppercase" runat="server" CommandName="SwitchViewByID" CommandArgument="ViewUserAddrSaved" UseSubmitBehavior="false" OnClick="BtnShipNewAddrSave_Click" Text="save" />
                                                <%--<asp:Button ID="Button3" CssClass="btn delt--btn text-uppercase" runat="server" Text="cancel" />--%>
                                            </p>
                                        </div>

                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </asp:Panel>

                    <%--To open Ordered product panel--%>

                    <asp:Panel ID="PanelUserOrder" Visible="false" runat="server">
                        <asp:Panel ID="PaneluserOrderButtons" CssClass="col-md-9 col-sm-12 col-xs-12" runat="server">

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

