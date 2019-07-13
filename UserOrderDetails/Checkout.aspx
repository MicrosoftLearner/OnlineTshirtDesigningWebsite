<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="UserOrderDetails_Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="checkout">
        <div>
            <asp:Image ID="ImageCheckoutBanner" CssClass="img-responsive" ImageUrl="~/Images/Checkout/checkout-bg.jpg" AlternateText="BannerImage" runat="server" />
        </div>
        <div>
            <div class="container">
                <div class="content-spacing">
                    <div class="row">
                        <div class="col-md-3 col-sm-12 col-xs-12">
                            <div class="list-checkout">
                                <div class="checkout-tab-btn">
                                    <asp:Button ID="ButtonLogin" OnClick="ButtonLogin_Click" runat="server" Text="Login" CssClass="btn btn--list btn--brownActive" />

                                </div>
                                <div class="checkout-tab-btn">
                                    <asp:Button ID="ButtonOrder" UseSubmitBehavior="false" OnClick="ButtonOrder_Click" CssClass="btn btn--list " runat="server" Text="Order" />

                                </div>
                                <div class="checkout-tab-btn">
                                    <asp:Button ID="ButtonDtls" UseSubmitBehavior="false" OnClick="ButtonDtls_Click" runat="server" CssClass="btn btn--list" Text="Details" />

                                </div>
                                <div class="checkout-tab-btn">
                                    <asp:Button ID="ButtonPayment" UseSubmitBehavior="false" OnClick="ButtonPayment_Click" CssClass="btn btn--list" runat="server" Text="Payment" />
                                </div>
                            </div>
                        </div>
                        <asp:MultiView ID="MultiViewCheckout" ActiveViewIndex="0" runat="server">
                            <asp:View ID="ViewLogin" runat="server">

                                <div class="col-md-3 col-md-offset-1 col-sm-6">
                                    <div class="customized-form ">
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBoxUserEmail" Text="Email" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegValidEmail" runat="server" ErrorMessage="This email is missing the @ symbol" OnInit="RegValidEmail_Init" ControlToValidate="TextBoxUserEmail" ValidationExpression=".+@.+">
                                                <i class="fa fa-exclamation-circle text-danger" aria-hidden="true"></i>
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBoxuserPwd" CssClass="form-control" TextMode="Password" Text="Password" runat="server"></asp:TextBox>
                                            <p class="pull-right forgot__checkout">
                                                <asp:HyperLink ID="HyperLinkForgotPwd" runat="server">Forgot Password?</asp:HyperLink>
                                            </p>
                                        </div>
                                        <div>
                                            <asp:Button ID="ButtonUserLogIn" UseSubmitBehavior="false" runat="server" OnClick="ButtonUserLogIn_Click" CssClass="btn btn--login btn-block" Text="login" data-toggle="popover" />
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                        </div>
                                        <p class="user-dicision border-line">or</p>
                                        <div class="social-icons">
                                            <ul class="list-unstyled list-inline">
                                                <li>
                                                    <div class="social-icons__list fb">
                                                        <asp:HyperLink ID="HyperLinkFb" NavigateUrl="#" runat="server"> <i class="fa fa-facebook" aria-hidden="true"></i></asp:HyperLink>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="social-icons__list tw">
                                                        <asp:HyperLink NavigateUrl="#" ID="HyperLinkTwitt" runat="server"><i class="fa fa-twitter" aria-hidden="true"></i></asp:HyperLink>

                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="social-icons__list gp">
                                                        <asp:HyperLink NavigateUrl="#" ID="HyperLinkGoogPlus" runat="server">                                                                <i class="fa fa-google-plus" aria-hidden="true"></i>
                                                        </asp:HyperLink>
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-3 col-md-offset-1  col-sm-6">
                                    <div class="customized-form custom-checkbox ">
                                        <div class="form-group">
                                            <input type="text" id="UserFirstName" runat="server" placeholder="First Name" name="firstname" class="form-control">
                                            <asp:RequiredFieldValidator ID="RequiredValidatorSignUpFstNam" runat="server" ErrorMessage="Enter your Last name" ControlToValidate="UserFirstName">
                                                     <i class="fa fa-exclamation-circle text-danger" aria-hidden="true"></i>
                                                   &nbsp; Enter your first name

                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <input type="text" placeholder="Last Name" runat="server" id="UserLastName" name="lastname" class="form-control">
                                            <asp:RequiredFieldValidator ID="RequiredValidatorSignUpLstNam" runat="server" ErrorMessage="Enter your Last name" ControlToValidate="UserLastName">
                                                     <i class="fa fa-exclamation-circle text-danger" aria-hidden="true"></i>
                                                   &nbsp; Enter your Last name

                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBoxUserEmailSignUp" TextMode="Email" Text="Email Address" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegExpValidatorSignUpEmail" runat="server" Text="Invalid email address" ControlToValidate="TextBoxUserEmailSignUp" ValidationExpression=".+@.+">
                                                    <i class="fa fa-exclamation-circle text-danger" aria-hidden="true"></i>
                                                   &nbsp; Invalid email address
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBoxUserSignUpMob" placeholder="Mob No" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredValidatorSignUpMob" runat="server" Text="Enter mobile no" ControlToValidate="TextBoxUserSignUpMob">
                                                    <i class="fa fa-exclamation-circle text-danger" aria-hidden="true"></i>
                                                       &nbsp;Enter mobile no
                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBoxUserSignUpPwd" TextMode="Password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredValidatorSignUpPwd" runat="server" ErrorMessage="Enter password" ControlToValidate="TextBoxUserSignUpPwd">
                                                    <i class="fa fa-exclamation-circle text-danger" aria-hidden="true"></i>
                                                   &nbsp; Enter password
                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBoxUserSignUpCnfpwd" TextMode="Password" CssClass="form-control" placeholder="Confirm Password" runat="server"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidatorSignUpRePwd" runat="server" ErrorMessage="Wrong password" ControlToCompare="TextBoxUserSignUpPwd" ControlToValidate="TextBoxUserSignUpCnfpwd">
                                                    <i class="fa fa-exclamation-circle text-danger" aria-hidden="true"></i>
                                                   &nbsp; Wrong password
                                            </asp:CompareValidator>
                                        </div>
                                        <div class="checkbox forgot__checkout">
                                            <input id="CheckboxDataAgree" runat="server" value="X" name="agree" type="checkbox" />

                                            <label for="a1">I agree with the terms and conditions and privacy policy</label>
                                        </div>
                                        <div>
                                            <asp:Button ID="ButtonSignUpForm" OnClick="ButtonSignUpForm_Click" CssClass="btn btn--login btn-block" runat="server" Text="sign up" /><br />
                                            <asp:Label ID="LabelAggreeMsg" CssClass="text-danger" runat="server"></asp:Label>
                                        </div>
                                        <p class="user-dicision border-line">or</p>
                                        <div class="social-icons">
                                            <ul class="list-unstyled list-inline">
                                                <li>
                                                    <div class="social-icons__list fb">
                                                        <asp:HyperLink ID="HyperLinkSignUpFb" NavigateUrl="#" runat="server">                                                            <i class="fa fa-facebook" aria-hidden="true"></i>
                                                        </asp:HyperLink>

                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="social-icons__list tw">
                                                        <asp:HyperLink ID="HyperLinkSignUpTwitt" NavigateUrl="#" runat="server">                                                            <i class="fa fa-twitter" aria-hidden="true"></i>
                                                        </asp:HyperLink>

                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="social-icons__list gp">
                                                        <asp:HyperLink ID="HyperLinkSignUpGp" NavigateUrl="#" runat="server">                                                            <i class="fa fa-google-plus" aria-hidden="true"></i>
                                                        </asp:HyperLink>
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="Vieworder" runat="server">
                                <h2>In View orders</h2>
                            </asp:View>
                            <asp:View ID="ViewDtls" runat="server">
                                <div class="col-md-8 col-md-offset-1 col-sm-12">
                                    <div class="details-form ">
                                        <div>
                                            <h3 class="marg0 detail-tab__head ">your details</h3>
                                        </div>
                                        <div class="row ">
                                            <div class="customized-form ">
                                                <div class="form-group ">
                                                    <div class="col-md-4 col-sm-12">
                                                        <input type="text " runat="server" placeholder="First Name "
                                                            class="form-control ">
                                                    </div>
                                                </div>
                                                <div class="form-group ">
                                                    <div class="col-md-4 col-sm-12">
                                                        <input type="text " runat="server" aria-readonly="true" placeholder="Last Name" class="form-control ">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row ">
                                            <div class="customized-form ">
                                                <div class="form-group ">
                                                    <div class="col-md-4 col-sm-12">
                                                        <asp:TextBox ID="TextBoxUserDtlMobNo" TextMode="Number" runat="server" CssClass="form-control" placeholder="Number"></asp:TextBox>

                                                    </div>
                                                </div>
                                                <div class="form-group ">
                                                    <div class="col-md-4 col-sm-12">
                                                        <asp:TextBox ID="TextBoxUserDtlEmail" CssClass="form-control" TextMode="Email" runat="server" Text="Email"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="details-form ">
                                        <div>
                                            <div class="row ">
                                                <div class="col-md-6 col-sm-6">
                                                    <div>
                                                        <h3 class="marg0 detail-tab__head ">billing address</h3>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12 ">
                                                                    <input type="text " id="UserBillAddr1" placeholder="Line 1* " class="form-control ">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <input type="text " id="UserBillAddr2" placeholder="Line 2" class="form-control " runat="server">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <input type="text " id="UserBillAddr3" placeholder="Line 3 "
                                                                        class="form-control " runat="server">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <input type="text" id="UserCity2" runat="server" placeholder="City* " class="form-control">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <asp:TextBox ID="TextBoxUserPinCode" TextMode="Number" CssClass="form-control" runat="server" placeholder="Pincode"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <div class="  relate country-selection ">
                                                                        <i class="fa fa-angle-down pull-right " aria-hidden="true "></i>

                                                                        <asp:DropDownList ID="DropDownListUserCountry" CssClass="form-control checkout-drop relate" runat="server">
                                                                            <asp:ListItem Text="Country1" />
                                                                            <asp:ListItem Text="Country2" />

                                                                        </asp:DropDownList>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <input type="text" id="UserState" placeholder="State"
                                                                        class="form-control" runat="server">
                                                                    <asp:Panel ID="PanelUserCountryEqls" CssClass="relate country-selection" runat="server">
                                                                        <i class="fa fa-angle-down pull-right " aria-hidden="true "></i>
                                                                        <asp:DropDownList ID="DropDownListUserState" CssClass="form-control checkout-drop relate " runat="server">
                                                                            <asp:ListItem Text="State" />
                                                                        </asp:DropDownList>
                                                                    </asp:Panel>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6">
                                                    <div class="custom-checkbox ">
                                                        <h3 class="marg0 detail-tab__head ">shipping address</h3>
                                                        <div class="checkbox ">

                                                            <asp:CheckBox ID="CheckBoxUserSetAddr" Text="Same as BIlling Address" runat="server" />

                                                        </div>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <input type="text " id="UserAddr1" placeholder="Line 1* "
                                                                        class="form-control " runat="server">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <input type="text " id="UserAddr2" placeholder="Line 2 "
                                                                        class="form-control " runat="server">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <input type="text " id="UserAddr3" runat="server" placeholder="Line 3 " class="form-control ">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <input type="text " id="UserCity" runat="server" placeholder="City* "
                                                                        class="form-control ">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <asp:TextBox ID="TextBoxUserPin" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <div class=" relate country-selection ">
                                                                        <i class="fa fa-angle-down pull-right " aria-hidden="true "></i>
                                                                        <asp:DropDownList ID="DropDownListCountry" CssClass="form-control checkout-drop relate" runat="server">
                                                                            <asp:ListItem Text="India" />
                                                                            <asp:ListItem Text="USA" />

                                                                        </asp:DropDownList>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row ">
                                                        <div class="customized-form ">
                                                            <div class="form-group ">
                                                                <div class="col-md-10 col-sm-12">
                                                                    <input type="text" runat="server" placeholder="State" class="form-control ">

                                                                    <div class=" relate country-selection ">
                                                                        <i class="fa fa-angle-down pull-right " aria-hidden="true "></i>

                                                                        <asp:DropDownList ID="DropDownListUserBillState" CssClass="form-control checkout-drop relate" runat="server">
                                                                            <asp:ListItem Text="State1" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="details-form ">
                                        <div>
                                            <h3 class="marg0 detail-tab__head ">payment method</h3>
                                        </div>
                                        <div class="payment-checkbox custom-checkbox">
                                            <div class="font__style ">
                                                <div class="checkbox checkbox-inline ">
                                                    <asp:CheckBoxList ID="CheckBoxListPayment" runat="server">
                                                        <asp:ListItem Text="Net Banking" />
                                                        <asp:ListItem Text="Credit Card" />
                                                        <asp:ListItem Text="Debit Card" />

                                                    </asp:CheckBoxList>

                                                </div>

                                                <div class="text-center ">
                                                    <asp:Button ID="ButtonOrderGenerte" CommandName="SwitchViewByID" CommandArgument="ViewPayment" runat="server" CssClass="btn btn-default checkout__cont-btn " Text="Continue" />
                                                </div>
                                            </div>

                                        </div>

                                    </div>
                                </div>

                            </asp:View>

                            <asp:View ID="ViewPayment" runat="server">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-xs-12 col-md-6">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h3 class="panel-title">Payment Details
                                                    </h3>
                                                    <div class="checkbox pull-right">
                                                        <label>
                                                            <input type="checkbox" />
                                                            Remember
                       
                                                        </label>
                                                    </div>
                                                </div>
                                                <div class="panel-body">
                                                    <div>
                                                        <div class="form-group">
                                                            <label for="cardNumber">
                                                                CARD NUMBER</label>
                                                            <div class="input-group">
                                                                <input type="text" class="form-control" id="cardNumber" placeholder="Valid Card Number"
                                                                    required autofocus />
                                                                <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-xs-7 col-md-7">
                                                                <div class="form-group">
                                                                    <label for="expityMonth">
                                                                        EXPIRY DATE</label>
                                                                    <div class="col-xs-6 col-lg-6 pl-ziro">
                                                                        <input type="text" class="form-control" id="expityMonth" placeholder="MM" required />
                                                                    </div>
                                                                    <div class="col-xs-6 col-lg-6 pl-ziro">
                                                                        <input type="text" class="form-control" id="expityYear" placeholder="YY" required />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-xs-5 col-md-5 pull-right">
                                                                <div class="form-group">
                                                                    <label for="cvCode">
                                                                        CV CODE</label>
                                                                    <input type="password" class="form-control" id="cvCode" placeholder="CV" required />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <ul class="nav nav-pills nav-stacked">
                                                <li class="active"><a href="#"><span class="badge pull-right"><span class="glyphicon glyphicon-usd"></span>4200</span> Final Payment</a>
                                                </li>
                                            </ul>
                                            <br />
                                            <a href="http://www.jquery2dotnet.com" class="btn btn-success btn-lg btn-block" role="button">Pay</a>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

