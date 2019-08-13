<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="IndividualCustomProd.aspx.cs" Inherits="IndividualCustomProd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb-nav">
        <ul class="breadcrumb">
            <li><a href="#">Home</a></li>
            <li><a href="#">Products</a></li>
            <li class="active">Accessories</li>
        </ul>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="product-cat">
                    <div class="product-cat-title">
                        <h3>
                            <asp:Label ID="LblProductCatName" runat="server" Text="Label"></asp:Label>
                        </h3>
                    </div>
                    <p>
                        <asp:Label ID="LblProductCatDesc" runat="server">A great look. Priced right. And this t‑shirt feels softer with every wash ‑ it's no wonder our customers love this "ultra" popular style!</asp:Label>
                    </p>

                    <div class="well">
                        <asp:Button ID="BtnProductDesign" CssClass="btn btn--brown btn-block" runat="server" Text="Start Desigining" />
                    </div>
                    <div class="product-avail-colr">
                        <h4>AVAILABLE COLORS</h4>
                        <hr />
                    </div>
                    <div class="product-colr-selct">

                        <label class="custom-check-container">
                            <asp:CheckBox ID="ChkBoxAvailColrBlack" runat="server" />
                            <span class="checkmark" style="background-color: black"></span>
                        </label>
                        <label class="custom-check-container">
                            <asp:CheckBox ID="ChkBoxAvailColrBlue" runat="server" />
                            <span class="checkmark" style="background-color: blue"></span>

                        </label>

                        <label class="custom-check-container">
                            <asp:CheckBox ID="ChkBoxAvailColrBrow" runat="server" />
                            <span class="checkmark" style="background-color: saddlebrown"></span>
                        </label>
                        <label class="custom-check-container">
                            <asp:CheckBox ID="ChkBoxAvailColrGreen" runat="server" />
                            <span class="checkmark" style="background-color: green"></span>
                        </label>

                        <%--                        <asp:LinkButton ID="LnkBtnAvailColrBlue" PostBackUrl="IndividualProduct.aspx?Cat=UltraCotton&ProductID=1000&ColorCode=04664" CssClass="pretty p-default" runat="server">
                            <asp:CheckBox ID="ChkBoxAvailColrBlue" runat="server" />
                            <div class="state p-success">
                                <label>
                                </label>
                            </div>
                        </asp:LinkButton>--%>
                        <%--<asp:CheckBoxList ID="ChkBoxLstProductColr" runat="server">
                        </asp:CheckBoxList>--%>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div id="colorChoicedSlider" class="flexslider">
                    <ul class="slides">
                        <li>
                            <img src="Images/Products/CustomDesiging/front_large_extended.jpg" />
                        </li>
                        <li>
                            <img src="Images/Products/CustomDesiging/1.jpg" />
                        </li>
                        <li>
                            <img src="Images/Products/CustomDesiging/1back.jpg" />
                        </li>

                        <!-- items mirrored twice, total of 12 -->
                    </ul>
                </div>
                <div id="thumbnailChoiced" class="flexslider">
                    <ul class="slides">
                        <li>
                            <img src="Images/Products/CustomDesiging/front_large_extended.jpg" />

                        </li>
                        <li>
                            <img src="Images/Products/CustomDesiging/1.jpg" />
                        </li>
                        <li>
                            <img src="Images/Products/CustomDesiging/1back.jpg" />
                        </li>
                        <!-- items mirrored twice, total of 12 -->
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <section>
        <div class="container">
            <div class="product-overview">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Product Overview</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <h4>Features</h4>
                        <hr />
                        <ul>
                            <li>6 oz. 100% pre-shrunk cotton; Ash, Sports Grey, Heather, Antique, and Safety colors are poly/cotton blends
                            </li>
                            <li>Womens option is the Gildan Ultra Cotton Women's T-shirt
                            </li>
                            <li>Sturdy heavyweight cotton
                            </li>
                            <li>Double-needle stitched for durability
                            </li>
                            <li>Huge color selection
                            </li>
                        </ul>
                    </div>
                    <div class="col-md-6">
                        <h4>Additional Details</h4>
                        <hr />
                        <div>
                            <h5>Guaranteed Delivery</h5>
                            <p>Free 2-week / Rush 1-week</p>
                        </div>
                        <div>
                            <h5>Decoration</h5>
                            <p>Screen printing or high-quality digital printing</p>
                        </div>
                        <div>
                            <h5>Minimum Quantity</h5>
                            <p>1</p>
                        </div>
                    </div>

                </div>
            </div>
            <div class="product-comments">
                <div class="row bootstrap snippets">
                    <div class="col-md-10 col-sm-12">
                        <div class="comment-wrapper">
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    Reviews for Online T-shirt Desigining
                                </div>
                                <div class="panel-body">
                                    <asp:TextBox ID="TBoxUserComment" CssClass="form-control" TextMode="MultiLine" Rows="3" Text="write a comment..." runat="server"></asp:TextBox>
                                    <br>
                                    <asp:Button ID="BtnUserCommentPost" CssClass="btn btn--brown pull-right" runat="server" Text="Post" />
                                    <div class="clearfix"></div>
                                    <hr>
                                    <ul class="media-list">
                                        <li class="media">
                                            <a href="#" class="pull-left">
                                                <img src="https://bootdey.com/img/Content/user_1.jpg" alt="" class="img-circle">
                                            </a>
                                            <div class="media-body">
                                                <span class="text-muted pull-right">
                                                    <small class="text-muted">30 min ago</small>
                                                </span>
                                                <strong class="text-success">@MartinoMont</strong>
                                                <p>
                                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                                    Lorem ipsum dolor sit amet, <a href="#">#consecteturadipiscing </a>.
                                                </p>
                                            </div>
                                        </li>
                                        <li class="media">
                                            <a href="#" class="pull-left">
                                                <img src="https://bootdey.com/img/Content/user_2.jpg" alt="" class="img-circle">
                                            </a>
                                            <div class="media-body">
                                                <span class="text-muted pull-right">
                                                    <small class="text-muted">30 min ago</small>
                                                </span>
                                                <strong class="text-success">@LaurenceCorreil</strong>
                                                <p>
                                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                                    Lorem ipsum dolor <a href="#">#ipsumdolor </a>adipiscing elit.
                                                </p>
                                            </div>
                                        </li>
                                        <li class="media">
                                            <a href="#" class="pull-left">
                                                <img src="https://bootdey.com/img/Content/user_3.jpg" alt="" class="img-circle">
                                            </a>
                                            <div class="media-body">
                                                <span class="text-muted pull-right">
                                                    <small class="text-muted">30 min ago</small>
                                                </span>
                                                <strong class="text-success">@JohnNida</strong>
                                                <p>
                                                    Lorem ipsum dolor <a href="#">#sitamet</a> sit amet, consectetur adipiscing elit.
                                                </p>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>

