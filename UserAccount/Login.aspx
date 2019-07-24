<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="UserAccount_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:MultiView ID="multiviewloginmodal" ActiveViewIndex="0" runat="server">
        <asp:View ID="viewuserloinmodal" runat="server">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="relate hidden-xs" style="border: 1px dashed #341314; margin: 20px 0;">
                        <div class="row ">

                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div class="modal-container">
                                    <div class="minHeight">
                                        <div class="text-center login-head login-head-top">
                                            <h1 class="brown--color">Log in</h1>
                                            <p class="gray--color">to your account</p>
                                        </div>
                                        <div>
                                            <div class="modal__customized-form">
                                                <div class="form-group">
                                                                          <asp:TextBox ID="TextBoxUserEmailModalLogin" CssClass="form-control" Text="Email Address" TextMode="Email" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox ID="TextBoxUserPwd" CssClass="form-control" Text="Password" runat="server"></asp:TextBox>

                                                </div>
                                                <div class="marginTop">
                                                    <asp:Button ID="ButtonLoginModal" OnClick="ButtonLoginModal_Click" CssClass="btn btn-login btn-block" runat="server" Text=" log in" />
                                                </div>

                                                <asp:RequiredFieldValidator ID="ValidatorEmail" runat="server" ErrorMessage="Enter Email id" CssClass="alert-danger" ControlToValidate="TextBoxUserEmailModalLogin"></asp:RequiredFieldValidator>

                                                <asp:RequiredFieldValidator ID="ValidatorPwd" runat="server" ErrorMessage="Enter password" CssClass="alert-danger"  ControlToValidate="TextBoxUserPwd"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="login-footer">
                                        <asp:HyperLink ID="HyperLinkForgotPwd" runat="server">Forgot Password?</asp:HyperLink>

                                        <a class="visible-xs">Sign Up</a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-12 padd0">
                                <!--<img src="img/home/login.jpg" alt="" class="img-responsive width100">-->
                                <div class="modal-container-right sign-up">
                                    <div class="minHeight">
                                        <div class="text-center login-head login-head-top">
                                            <h1>sign up</h1>
                                            <p>
                                                with one of your<br>
                                                social profile
                                            </p>
                                        </div>
                                        <div class="login__social-icons">
                                            <ul class="list-unstyled list-inline">
                                                <li>
                                                    <div class="social-icons__list fb">
                                                        <asp:HyperLink ID="HyperLinkFb" NavigateUrl="#" runat="server">                                 <i class="fa fa-facebook" aria-hidden="true"></i></asp:HyperLink>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="social-icons__list tw">
                                                        <asp:HyperLink ID="HyperLinkTwitt" NavigateUrl="#" runat="server">                            <i class="fa fa-twitter" aria-hidden="true"></i></asp:HyperLink>

                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="social-icons__list gp">
                                                        <asp:HyperLink ID="HyperLinkGPlus" NavigateUrl="#" runat="server">                 <i class="fa fa-google-plus" aria-hidden="true"></i></asp:HyperLink>

                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="login-footer">
                                        <p class="marg0">Don't have an account?</p>
                                        <div>
                                            <asp:LinkButton ID="LinkButtonUserSignUpShow" CommandName="SwitchViewByID" CommandArgument="viewusersignupmodal" runat="server"> Sign Up</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </asp:View>
        <asp:View ID="viewusersignupmodal" runat="server">
            <div style="margin: 15px 0;">
                <div class="row">
                    <div class="col-md-6 col-md-offset-3" style="border: 1px dashed #341314; border-right-style: none;">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div class="modal-container">
                                    <div class="minHeight">
                                        <div class="text-center login-head">
                                            <h1>sign up</h1>
                                            <p>to your account</p>
                                        </div>
                                        <div>
                                            <div class="modal__customized-form">
                                                <div class="form-group">
                                                    <input type="text" placeholder="First Name" name="firstname" runat="server" class="form-control">
                                                </div>
                                                <div class="form-group">
                                                    <input type="text" placeholder="Last Name" name="lastname" runat="server" class="form-control">
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox ID="TextBoxUserSignUpEmail" Text="Email" TextMode="Email" CssClass=" form-control" runat="server"></asp:TextBox>

                                                   <%--Validation--%>
                                                    <<asp:RequiredFieldValidator ID="ValidatorEmailSignUp" runat="server" Text="Invalid Email Id"  ControlToValidate="TextBoxUserSignUpEmail"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox ID="TextBoxUserSignUpMobNo" Text="Mob No" TextMode="Number" CssClass=" form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox ID="TextBoxUserSignUpPwd" Text="Password" TextMode="Password" CssClass=" form-control" runat="server"></asp:TextBox>

                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox ID="TextBoxUserUserSignUpCnfPwd" Text="Confirm Password" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>

                                                    <!--<span ng-show='registerForm.formData.confirm.$error.hsPswdMatch'>Passwords don't match</span>-->
                                                </div>
                                                <div class="marginTop">
                                                    <asp:Button ID="ButtonUserSignUp" CssClass="btn btn-login btn-block" runat="server" Text="Sign Up" OnClick="ButtonUserSignUp_Click" />

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-12 padd0">
                                <!--<img src="img/home/login.jpg" alt="" class="img-responsive width100">-->
                                <div class="modal-container-right sign-up">
                                    <div class="minHeight">
                                        <div class="text-center login-head">
                                            <h1>log in</h1>
                                            <p>
                                                with one of your<br>
                                                social profile
                                            </p>
                                        </div>
                                        <div class="login__social-icons">
                                            <ul class="list-unstyled list-inline">
                                                <li>
                                                    <div class="social-icons__list fb">

                                                        <a href="#">
                                                            <i class="fa fa-facebook" aria-hidden="true"></i>
                                                        </a>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="social-icons__list tw">
                                                        <a href="#">
                                                            <i class="fa fa-twitter" aria-hidden="true"></i>
                                                        </a>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="social-icons__list gp">
                                                        <a href="#">
                                                            <i class="fa fa-google-plus" aria-hidden="true"></i>
                                                        </a>
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="login-footer have-account">
                                        <p class="marg0">Have an account</p>
                                        <div>
                                            <asp:LinkButton ID="LinkButtonUserLogin" CommandName="SwitchViewByID" CommandArgument="viewuserloinmodal" runat="server">Login</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>

    <div>
        <asp:Label ID="LblError" runat="server"></asp:Label>
    </div>
</asp:Content>

