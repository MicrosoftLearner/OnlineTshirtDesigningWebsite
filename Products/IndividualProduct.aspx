<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="IndividualProduct.aspx.cs" Inherits="Products_IndividualProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
<div class="container">
    <div class="individual-container relate">
        <div class="row">
            <div class="col-md-4 col-xs-12 padd-rt0">
              
                <div class="individual-first relate visible-lg">
                    <div class="product-img">
                        <asp:Image ID="ImgIndividProd" runat="server" />
                      
                    </div>
                    
                </div>
            </div>
            <div class="col-md-8 col-xs-12 padd-lt3">
                <div class="prod-code">
                    <div class="pull-left">
                        <p class="prod-code__left">Product Code: <asp:Label ID="LblProdCode" runat="server"></asp:Label></p>
                    </div>

                    <p class="prod-code__right pull-right text-right"><span> AVAILABILITY </span>:
                        <asp:Label ID="LblProdQuant"  runat="server" Text="In Stock"></asp:Label>                 

                </div>
                <div class="clearfix"></div>
                <div class="individual-main">
                    <div class="first-sec clearfix border-div relate ">
                        <h4> <asp:Label ID="LblProdName" runat="server"></asp:Label> </h4>
                        <div class="pull-left mrp">
                            <h3>
                                <!--<i class="fa fa-inr " aria-hidden="true "></i>-->
                                <!--<div class="inline-block">-->
                            <asp:Label ID="LblProdMrp" runat="server"><del>Strikethrough</del></asp:Label>
                              
                                <span class="pull-right">&#x20B9; <asp:Label ID="LblProdDiscPrice" runat="server" ></asp:Label></span>
                                <!--</div>-->
                                <!--<div class="inline-block">-->
                               
                                <!--</div>-->
                            </h3>
                        </div>
                    
                    </div>
                    <div class="second-sec border-div pd-bottom ">
                        <div class="viewSize inline-block relate ">
                            <h5>SIZE </h5>

                            <div class="inline-block buy-para__sizes ">
                                <p ng-repeat="size in sizes " ng-click="selectSize(size) " ng-class="{'active':activeButton==size.name} ">{{size.name}}</p>
                                <div>
                                    <a class="linking" ng-click="openSizeChart()">Size Chart</a>
                                    <!--{{product.category.image}}-->
                                </div>

                            </div>

                            <!--<div class="dropdown inline-block">
                            <button class="btn dropdown-toggle btn-select" type="button" data-toggle="dropdown">{{selectedSize.name}}
                            <i class="fa fa-angle-down" aria-hidden="true"></i></button>
                            <ul class="dropdown-menu">
                                <li ng-repeat="size in sizes"> <a ng-click="setSelectedSize(size)">{{size.name}}</a></li>
                                <li><a href="#">1</a></li>
                                <li><a href="#">2</a></li>
                                <li><a href="#">3</a></li>
                                <li><a href="#">4</a></li>
                                <li><a href="#">5</a></li>
                                <li><a href="#">6</a></li>
                            </ul>
                        </div>
                        <div class="dropdown inline-block ml-10">
                            <button class="btn dropdown-toggle btn-no" type="button" data-toggle="dropdown">{{reqQuantity}}
                            <i class="fa fa-angle-down" aria-hidden="true"></i></button>
                            <ul class="dropdown-menu">
                                <li ng-repeat="quantity in product.quantity"><a ng-click="setSelectedQuantity(quantity)">{{quantity}}</a></li>
                                <li><a ng-click="setQuantity(1)">1</a></li>
                                <li><a ng-click="setQuantity(2)">2</a></li>
                                <li><a ng-click="setQuantity(3)">3</a></li>
                                <li><a ng-click="setQuantity(4)">4</a></li>
                                <li><a ng-click="setQuantity(5)">5</a></li>
                            </ul>
                        </div>-->
                        </div>
                        <div class="inline-block quantity text-center">
                            <h5>QUANTITY </h5>
                                <asp:LinkButton ID="LnkBtnDown" runat="server"> <i class="fa fa-minus square__bg" aria-hidden="true"></i></asp:LinkButton>
                         
                            <div class="inline-block">
                                <form>
                                    <div class="form-group marg0 plus-minus-btn">
                                    <asp:TextBox ID="TextBox1" ReadOnly="true"   CssClass="form-control quantity__input" runat="server"></asp:TextBox>
                                      
                                    </div>
                                </form>
                            </div>
                             <asp:LinkButton ID="LnkBtnUp" runat="server"> <i class="fa fa-minus square__bg" aria-hidden="true"></i></asp:LinkButton>
                        </div>
                    </div>
                    <div class="third-sec border-div common-Accordian">
                        <uib-accordion close-others="oneAtATime">
                            <div uib-accordion-group class="hidebordercolor panel-default " is-open="status.open1">
                                <uib-accordion-heading>
                                    <h4 class="text-uppercase">Description
                                        <i class="fa fa-angle-down pull-right" aria-hidden="true"></i>
                                    </h4>
                                </uib-accordion-heading>
                                <div class="pd-bottom">
                                    <p>
                                        {{product.description}}
                                    </p>
                                </div>
                            </div>
                        </uib-accordion>
                    </div>
                    <div class="fourth-sec border-div common-Accordian">
                        <uib-accordion close-others="oneAtATime">
                            <div uib-accordion-group class="hidebordercolor panel-default " is-open="status.open1">
                                <uib-accordion-heading>
                                    <h4 class="text-uppercase">Specification
                                        <i class="fa fa-angle-down pull-right" aria-hidden="true"></i>
                                    </h4>
                                </uib-accordion-heading>
                                <div class="row">
                                    <div class="col-md-5 col-sm-5 col-xs-6">
                                        <div class="leftContent">
                                            <ul class="list-unstyled">
                                                <li class="flex-item-container spec" ng-if="product.brand">
                                                    <div class=" leftContent__specHead">
                                                        <p class="mb-0">Brand</p>
                                                    </div>
                                                    <div>
                                                        <ul class="list-unstyled">
                                                            <li>
                                                                {{product.brand.name}}
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </li>
                                                <li class="flex-item-container spec" ng-if="product.prodCollection">
                                                    <div class=" leftContent__specHead">
                                                        <div>
                                                            <p class="mb-0">Collection</p>
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <ul class="list-unstyled">
                                                            <li>
                                                                {{product.prodCollection.name}}
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </li>
                                                <li class=" flex-item-container spec" ng-if="product.style">
                                                    <div class=" leftContent__specHead">
                                                        <div>
                                                            <p class="mb-0">Sleeve</p>
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <ul class="list-unstyled">
                                                            <li>
                                                                {{product.style}}
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </li>
                                                <li class="flex-item-container spec" ng-if="product.fabric">
                                                    <div class=" leftContent__specHead">
                                                        <p class="mb-0">Fabric</p>
                                                    </div>
                                                    <div>
                                                        <ul class="list-unstyled">
                                                            <li>
                                                                {{product.fabric.name}}
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </li>
                                                <li class=" flex-item-container spec" ng-if="product.color">
                                                    <div class=" leftContent__specHead">
                                                        <div>
                                                            <p class="mb-0">Color</p>
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <ul class="list-unstyled">
                                                            <li>
                                                                {{product.color.name}}
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                    <div class="col-md-7 col-sm-7 col-xs-6">
                                        <div class="right-content" ng-if="product.washcare">
                                            <p class="marg0 weight-600">Washcare</p>
                                            <p class="washcare">{{product.washcare}}
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </uib-accordion>
                    </div>
                    <div class="sixth-sec  border-div common-Accordian">
                        <uib-accordion close-others="oneAtATime">
                            <div uib-accordion-group class="hidebordercolor panel-default " is-open="status.open1">
                                <uib-accordion-heading>
                                    <h4 class="text-uppercase">comment
                                        <i class="fa fa-angle-down pull-right" aria-hidden="true"></i>
                                    </h4>
                                </uib-accordion-heading>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <textarea class="usr-comment form-control" ng-model="productComment.name" rows="2" id="comment"></textarea>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </uib-accordion>
                    </div>
                    <div class="fifth-sec custom-checkbox">
                        <div class="checkbox inline-block">
                            <input type="checkbox" id="f2" ng-checked="checkStateOnReload(product.productId)" ng-click="clickfun(product);">
                            <label for="f2"> Add to compare</label>
                        </div>
                        <!--<p class="inline-block"><input type="checkbox">Add to compare</p>-->
                        <div class="inline-block ml-10">
                            <img src="img/listing/sale.png" class="img-responsive inline-block"><a>Offer?</a>
                        </div>
                        <p class="inline-block" ng-repeat="discount in applicableDiscounts track by $index">{{discount.name}} <span ng-if="$index!=applicableDiscountsLength-1">,</span>
                        </p>

                    </div>
                    <div class="individual-btn">
                        <button class=" btn btn-default btn--brown text-uppercase btn-add" ng-disabled="product.quantity < 1" ng-click="addToCart(productComment)"><i class="fa fa-shopping-cart" aria-hidden="true"></i>  ADD TO CART</button>
                        <button class="btn btn-default btn--brown text-uppercase btn-wish" ng-click="addToWishlist()"><i class="fa fa-heart" aria-hidden="true"></i>  ADD TO WISHLIST</button>
                    </div>

                </div>

            </div>
        </div>
    </div>
</div>
<div class="image-individual  hidden-sm hidden-xs">
    <img src="img/home/Individual_Product Page.png" class="img-responsive">
</div>

<section>
    <div class="customer-choice relate">
        <div class="container">
            <div class="customer-choice-container">
                <div class="row">
                    <div class="customer-choice__title text-center">
                        <h1 class="text-uppercase individual--border--line">you may also like</h1>
                    </div>
                </div>
                <div class="customer-choice__slider">
                    <flex-slider flex-slide="new in featured track by $index" prev-text="" next-text="" animation="slide" item-width="270" item-margin="25"
                        min-items="3">
                        <li class="relate">
                            <div class="customer-choice__banner-detail relate">
                                <img ng-src="{{new.img | serverimage}}" alt="" class="img-responsive">
                                <div class="customer-choiced__cloth-desc">
                                    <h3><i class="fa fa-inr" aria-hidden="true"></i>{{new.price |number:0}}</h3>
                                    <h4>{{new.type}}</h4>
                                </div>
                                <!--<div class="customer-choice__icon-heart">
                                    <i class="fa fa-heart" aria-hidden="true"></i>
                                </div>
                                <div class="customer-choice__icon-cart">
                                    <i class="fa fa-shopping-cart" aria-hidden="true"></i>
                                </div>-->
                            </div>
                        </li>
                    </flex-slider>
                </div>
            </div>
        </div>
    </div>
</section>

</asp:Content>

