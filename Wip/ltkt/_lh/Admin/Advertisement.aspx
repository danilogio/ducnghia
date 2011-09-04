<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Advertisement.aspx.cs" Inherits="ltkt.Admin.Advertisement" %>

<asp:Content ID="AdvertisementAdminHeader" ContentPlaceHolderID="cphAdminHeader"
    runat="Server">
    <title><asp:Literal ID="liTitle" runat="server"></asp:Literal></title>
    <link rel="stylesheet" href="styles.css" type="text/css" />
    <style type="text/css">
        body
        {
            background: white;
            margin: 0;
            padding: 0;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            color: #444;
        }
        .footer-content1
        {
            padding: 20px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="AdvertisementAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div class="block_text">
        <asp:Panel ID="messagePanel" runat="server" Visible="false">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="viewPanel" runat="server">
            <asp:Table ID="NewsTable" CssClass="table" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="table-header" ColumnSpan="5">
                                Quản lý quảng cáo
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="table-header-cell">#</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Tên công ty</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Ngày hết hạn</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Trạng thái</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Thao tác</asp:TableCell>
                </asp:TableRow>
                <asp:TableFooterRow>
                    <asp:TableCell CssClass="table-footer" ColumnSpan="5">
                        <asp:Table ID="FooterTable" Width="100%" BorderWidth="0" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Literal ID="PreviousPageLiteral" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell HorizontalAlign="Right">
                                    <asp:Literal ID="NextPageLiteral" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>
                </asp:TableFooterRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="detailsPanel" runat="server" Visible="false">
            <div id="divFunction">
                <asp:Button ID="btnEdit" runat="server" Text="Sửa" CssClass="formbutton" 
                    onclick="btnEdit_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Quay về" CssClass="formbutton" 
                    onclick="btnCancel_Click" />
            </div>
            <div id="divDetails" class="form_settings">
                <p>
                    <span>Tên công ty:</span>
                    <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Địa chỉ:</span>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Email:</span>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Điện thoại:</span>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Bắt đầu quảng cáo từ ngày:</span>
                    <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Kết thúc quảng cáo vào ngày:</span>
                    <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Giá:</span>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Tập tin quảng cáo:</span>
                    <asp:FileUpload ID="fileAds" runat="server" />
                </p>
                <p>
                    <span>Mô tả:</span>
                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Trạng thái:</span>
                    <asp:DropDownList ID="ddlState" runat="server">
                    </asp:DropDownList>
                </p>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
