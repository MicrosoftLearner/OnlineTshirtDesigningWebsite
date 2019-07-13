<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="AboutUs_ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="contact-us">
        <div class="contactus-bgimg listing-img-common">
            <asp:Image ID="ImageContactUs" ImageUrl="Images/ContactUs/contactus-banner.jpg" CssClass="img-responsive" runat="server" AlternateText="Banner Image" />
        </div>
        <div class="container">
            <div class="contactus-content">
                <div class="enquiry-form-pdd">
                    <div class="enquiry-form-shadow">
                        <div class="enquiry-form">
                            <h3 class="tab-title text-center">ENQUIRY FORM
                            </h3>
                            <asp:Panel ID="CustomizedForm" CssClass="customized-form" runat="server">
                                <div class="row">
                                    <div class="col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <input id="Text" placeholder="Full Name" type="text" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <input id="Email" type="text" placeholder="Email Address" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <input type="text" id="Mobile" placeholder="Mobile" class="form-control">
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <textarea id="TextAreaComment" rows="3" class="form-control" placeholder="Enquiry"></textarea>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12">
                                        <p>
                                            <asp:Button ID="ButtonSendUserInfo" runat="server" CssClass="btn send--btn btn-block" Text="Send" />
                                        </p>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
                <div class="contactus-details text-center">
                    <div>
                        <h3 class="tab-title ">CALL US</h3>
                        <p>022 4215 4542</p>
                    </div>

                    <div class="head-office">
                        <h3 class="tab-title ">HEAD OFFICE
                        </h3>
                        <address>
                            Delphi Building, Orchard Ave, Hiranandani Gardens, Powai, Mumbai, Maharashtra 400076
                       
                        </address>
                    </div>
                    <div>
                        <h3 class="tab-title ">TIMINGS
                        </h3>
                        <p>
                            Monday - Friday :- 9.00 to 17.00 Saturday :- 9.00 to 17.00 Sunday :- Holiday
                       
                        </p>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

