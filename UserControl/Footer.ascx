<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="UserControl_Footer" %>
 <footer>
            <div class="footer-up relate">
                <div class="container">
                    <div class="row">
                        <div class="flex-item-container">
                            <div class="flex-item footer-up__abt-shop">
                                <div>
                                    <h5>ABOUT THE SHOP</h5>
                                    <p class="line--height">
                                        Burnt Umber is born off Passion for Fashion. Passion for Quality. Therefore our supporting line to our brand is “We Are
                            Mad About Quality”.Burnt Umber creates fashion which is
                       
                                    </p>
                                    <a href="#">Read More</a>
                                </div>
                                <div>
                                    <h5>OPENING TIME</h5>
                                    <p>
                                        Monday to Saturday - 9.00 to 17.00<br>
                                        Sunday - Holiday
                       
                                    </p>
                                </div>
                            </div>
                            <div class="flex-item footer-up__cstmr-serv">
                                <h5>CUSTOMER SERVICE</h5>
                                <ul class="list-unstyled">
                                    <li>
                                        <a href="ContactUs.aspx">Contact Us</a>
                                    </li>
                                    <li>
                                        <a>Brands</a>
                                    </li>
                                    <li>
                                        <a>Gift Vouchers</a>
                                    </li>
                                </ul>
                            </div>
                            <div class="flex-item footer-up__info">
                                <h5>INFORMATION</h5>
                                <ul class="list-unstyled">
                                    <li>
                                        <a href="AboutUs.aspx">About Us</a>
                                    </li>
                                    <li>
                                        <a>Blogs</a>
                                    </li>
                                    <li>
                                        <a id="userClientChat" href="#"><i class="fa fa-weixin" aria-hidden="true">Live Chat Now</i></a>
                                    </li>
                                    <li>
                                        <a href="#">Order Policy</a>
                                    </li>
                                    <li>
                                        <a href="#">Payment Policy</a>
                                    </li>
                                    <li>
                                        <a href="#">Shipping & Retunrs</a>
                                    </li>
                                    <li>
                                        <a href="PrivacyPolicy.aspx">Privacy Policy</a>
                                    </li>
                                    <li>
                                        <a href="#">Terms & Conditions</a>
                                    </li>

                                </ul>
                            </div>
                            <div class="flex-item footer-up__my-account">
                                <h5>MY ACCOUNT</h5>
                                <ul class="list-unstyled">
                                    <li>
                                        <a>My Account</a>
                                    </li>
                                    <li>
                                        <a>Order History</a>
                                    </li>
                                    <li>
                                        <a>Wish List</a>
                                    </li>

                                </ul>
                            </div>
                            <div class="flex-item footer-up__contact">
                                <h5>CONTACT</h5>
                                <address>
                                    <ul class="address-list list-unstyled">
                                        <li>Burnt Umber Fashion Pvt Limited,</li>
                                        <li>R-39, TTC Industrial Area</li>
                                        <li>MIDC- Rabale</li>
                                        <li>Navi Mumbai-400701.</li>
                                        <li>Contact Number: 022-27699479\480.</li>
                                        <li><a href="mailto:trade@burntumberfashion.com">trade@burntumberfashion.com</a></li>
                                    </ul>
                                </address>
                                <p>
                                    <button class="btn contact--btn ">
                                        Call us: +91 8754555035<br>
                                        +91 9768349972.</button>
                                </p>
                            </div>
                            <div class="footer-up__img">
                                <img src="../Images/Home/20.png" alt="" class="img-responsive">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row flex-item-container align-item-center flex-direction-row">
                    <div class="col-sm-4 ">
                        <!--<p>Copyright &copy; {{template.year}}. All Right Resvered.</p>-->
                        <div class="copyright text-center">
                            <p>Burntumber Fashion Pvt Ltd© Copyright 2018</p>
                        </div>
                    </div>

                    <div class="col-sm-4 ">
                        <div class="share-link text-center">
                            <div class="inline-block">
                                Follow us on
                   
                            </div>
                            <div class="inline-block">
                                <div class="share-link__social-icon">
                                    <asp:HyperLink ID="HyperLinkFacebook" NavigateUrl="#" runat="server"><i class="fa fa-facebook" aria-hidden="true"></i></asp:HyperLink>
                                    <asp:HyperLink ID="HyperLinkTwitter" NavigateUrl="#" runat="server"><i class="fa fa-twitter" aria-hidden="true"></i></asp:HyperLink>

                                    <asp:HyperLink ID="HyperLinkInsta" NavigateUrl="#" runat="server"><i class="fa fa-instagram" aria-hidden="true"></i></asp:HyperLink>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-4 ">
                        <p class="design-company text-center">
                            <a href="http://www.ting.in/" target="_blank">Designed by TING.</a>
                        </p>
                    </div>
                </div>
            </div>
            <%--Client chat--%>
            <div class="compare-product-main compareProductMenuOut">
                <div class="close-modal" id="userClientChatMin">
                    <asp:HyperLink ID="UserClientChatClose" data-dismiss="alert" CssClass="close-modal--btn-circle" aria-label="close" runat="server"><i class="fa fa-minus-circle"></i></asp:HyperLink>
                    <%--<a href="" title="Close" ng-click="compareProductModal()"> </a>--%>
                </div>
                <asp:Panel ID="PanelUserClientChat" runat="server">
                    <ul class="list-unstyled compare-product-list">
                        <li>
                            <div class="form-group">
                                <asp:Label ID="LabelUserClientChatName" runat="server" Text="What is your name"></asp:Label><br />
                                <input id="ClientChatName" class="form-control" placeholder="enter text here" type="text" runat="server" />
                            </div>
                        </li>
                        <li>
                            <div class="form-group">
                                <asp:Label ID="LabelUserClientChatEmail" runat="server" Text="What is your email address"></asp:Label><br />
                                <asp:TextBox ID="TextBoxClientChatEmail" Text="enter text here" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </li>
                        
                        <li>
                            <div class="form-group">
                                <asp:Label ID="LabelUserClientChatRsn" runat="server" Text="Please select your reason for chatting today"></asp:Label><br />
                                <asp:DropDownList ID="DropDownListUserChattingResn" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Help placing an order" />
                                    <asp:ListItem Text="An order i recently placed" />

                                </asp:DropDownList>
                            </div>
                        </li>
                        <li>
                            <p class="text-center">
                                <asp:Button ID="BtnUserChattCancel" CssClass="btn btn--brown" runat="server" Text="Cancel" />
                                &nbsp; &nbsp;
                                <asp:Button ID="BtnUserChattSbmt" CssClass="btn btn--brown" runat="server" Text="Submit" />
                            </p>
                        </li>
                    </ul>
                </asp:Panel>

            </div>
        </footer>