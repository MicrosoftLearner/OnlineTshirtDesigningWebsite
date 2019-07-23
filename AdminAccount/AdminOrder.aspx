<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdminOrder.aspx.cs" Inherits="Account_AdminOrder" %>

<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container">
        <asp:Panel CssClass="well well-lg" runat="server">
            <asp:Label ID="LblAdminName" runat="server" />
            <asp:Button ID="AdminLogout" OnClick="AdminLogout_Click" Text="Log out" CssClass="btn btn--brown pull-right" runat="server" />
        </asp:Panel>

        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <asp:FileUpload ID="AdminUpload" CssClass="form-control" runat="server" />

                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:TextBox ID="TboxBannerName" CssClass="form-control" Text="Banner Text" runat="server"></asp:TextBox>

                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:TextBox ID="TboxBannerDesc" CssClass="form-control" Text="Banner Desc" runat="server"></asp:TextBox>

                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12 text-center">
                <p>
                    <asp:Button ID="BtnAddHomeImg" UseSubmitBehavior="false" CssClass="btn btn--brown" runat="server" OnClick="BtnAddHomeImg_Click" Text="Add" />

                </p>

            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">

                    <asp:GridView ID="GridHomeBannerData" CssClass="table table-hover" runat="server" PageSize="5" AllowPaging="true" OnRowDataBound="GridHomeBannerData_RowDataBound" AutoGenerateColumns="false" OnRowEditing="GridHomeBannerData_RowEditing" OnRowUpdating="GridHomeBannerData_RowUpdating" OnRowCancelingEdit="GridHomeBannerData_RowCancelingEdit">
                        <Columns>
                            <%--<asp:BoundField DataField="HomeImg" ReadOnly="true" HeaderText="Home Banner Image" />--%>
                            <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                    <asp:Image ID="GridHomeBannerImg" Width="255px" CssClass="img-responsive" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="LblImgId" runat="server" Text='<%# Eval("HomeImgId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Image Name">
                                <ItemTemplate>
                                    <i><%# Eval("HomeBannerName") %> </i>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:TextBox ID="TBoxImgName" Text=' <%# Eval("HomeBannerName") %>' CssClass="form-control" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Banner Description">
                                <ItemTemplate>
                                    <i><%# Eval("HomeBannerDesc") %> </i>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TBoxBannerDesc" Text='<%# Eval("HomeBannerDesc") %>' CssClass="form-control" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton Text="Edit" ID="LnkBtn" CssClass="btn btn--brown" CommandName="Edit" runat="server" /><br />
                                </ItemTemplate>
                                <EditItemTemplate>

                                    <asp:LinkButton ID="LnkBtnUpdate" Text="Update" runat="server" CssClass="btn btn--brown" CommandName="Update" />

                                    <asp:LinkButton ID="LnkBtnCan" CssClass="btn btn--brown" Text="Cancel" runat="server" CommandArgument='<%# Eval("HomeImgId") %>' CommandName="Cancel" CausesValidation="false" />
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <%-- <asp:commandfield   showeditbutton="true"    buttontype="button"  />
                             <asp:BoundField DataField="HomeBannerName"  HeaderText="Home Banner Image" />
                             <asp:BoundField DataField="HomeBannerDesc"  HeaderText="Home Banner Image" />--%>

                            <asp:TemplateField HeaderText="Change Image" Visible="false">
                                <ItemTemplate>
                                    <asp:FileUpload ID="AdminNewUpload" CssClass="form-control" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <%--                    <asp:SqlDataSource DataSourceMode="DataSet" ConflictDetection="CompareAllValues" ProviderName="MySql.Data.MySqlClient" ConnectionString="<%$ ConnectionStrings: OnlineTshirtDesigning %>" OnSelected="SqlDataSrcHomeBanner_Selected" OnUpdated="SqlDataSrcHomeBanner_Updated" SelectCommand=" SELECT * FROM home_banner;" UpdateCommand="UPDATE home_banner SET HomeBannerName = @HomeBannerName, HomeBannerDesc = @HomeBannerDesc WHERE HomeImgId = @HomeImgId"
                        ID="SqlDataSrcHomeBanner" runat="server">
                        
                    </asp:SqlDataSource>--%>
                </div>
            </div>
        </div>
        <asp:Label ID="LblDatabaseError" runat="server" />
    </div>
</asp:Content>

