﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="ltkt.Search" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content ID="SearchHeader" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <%--<title>Tìm kiếm | Website luyện thi kinh tế</title>--%>
    <title>
        <asp:Literal ID="liTitleHeader" runat="server"></asp:Literal></title>

    <script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>

    <script type="text/javascript" src="js/jquery-ui-1.8.14.custom.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $('#<%= ddlSubject.ClientID %>').change(function(e) {
                var selectedIndex = $('#<%= ddlSubject.ClientID%>').get(0).selectedIndex;

                if (selectedIndex == 0) {
                    $('#divLessonType').hide();
                    $('#divContest').show();
                }
                else {
                    $('#divLessonType').show();
                    $('#divContest').hide();
                }
            });

            $('#<%= ddlSearchingType.ClientID %>').change(function(e) {
                var selectedIndex = $('#<%= ddlSearchingType.ClientID%>').get(0).selectedIndex;
                if (selectedIndex == 0) {
                    $('#Contest').hide();
                    //$('#Keyword').show();
                }
                else {
                    $('#Contest').show();
                    //$('#Keyword').hide();
                }
            });
        });
        function init() {
            $('#<%= ddlSubject.ClientID%>').val(0);
            $('#<%= ddlSearchingType.ClientID%>').val(0);
            $('#Contest').hide();
            $('#divLessonType').hide();
            $('#divContest').show();
        }
    </script>

</asp:Content>
<asp:Content ID="Search" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="search" class="block_text">
        <h2>
            <asp:Literal ID="liTitle" runat="server" Text="Tìm kiếm"></asp:Literal>
        </h2>
        <hr />
        <%-- <form method="post">--%>
        <asp:Panel ID="ErrorMessagePanel" runat="server" Visible="false" CssClass="alert">
            <asp:Literal ID="liErrorMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="searchPanel" runat="server">
            <p>
                <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />
            </p>
            <div class="form_settings">
                <p id="Keyword">
                    <span>Chuỗi tìm kiếm:</span><asp:TextBox ID="txtboxSearch" runat="server" CssClass="contact"></asp:TextBox></p>
                <asp:RequiredFieldValidator ID="reqSearch" runat="server" ErrorMessage="Vui lòng nhập từ khóa tìm kiếm"
                    ControlToValidate="txtboxSearch" Display="None"></asp:RequiredFieldValidator>
                <p>
                    <span>Chủ đề:</span><asp:DropDownList ID="ddlSubject" runat="server">
                        <asp:ListItem Text="Luyện thi đại học" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Tin học" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Anh văn" Value="2"></asp:ListItem>
                        <asp:ListItem Text="--Tất cả chủ đề--" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <%--<p>
                    <span>Tìm kiếm theo:</span><asp:DropDownList ID="ddlSearchingType" runat="server">
                        <asp:ListItem Text="--Tất cả--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Tiêu đề" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Tag" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </p>--%>
                <%--Đối với Anh văn, Tin học--%>
                <div id="divLessonType">
                    <%--
                    <p id="lessonType">
                        <span>Loại bài viết: </span>
                        <asp:DropDownList ID="ddlType" runat="server">
                            <asp:ListItem Text="Bài giảng" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Đề thi" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Bài tập" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <p id="P1">
                        <span>Năm(+-3): </span>
                        <asp:DropDownList ID="ddlYearSearch" runat="server" ToolTip="Tìm kiếm trong khoảng từ +3 năm tới -3 năm">
                            <asp:ListItem Text="2002" Value="2002"></asp:ListItem>
                            <asp:ListItem Text="2003" Value="2003"></asp:ListItem>
                            <asp:ListItem Text="2004" Value="2004"></asp:ListItem>
                            <asp:ListItem Text="2005" Value="2005"></asp:ListItem>
                            <asp:ListItem Text="2006" Value="2006"></asp:ListItem>
                            <asp:ListItem Text="2007" Value="2007"></asp:ListItem>
                            <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                            <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                            <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                            <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                            <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                        </asp:DropDownList>
                    </p>--%>
                </div>
                <%--Đối với loại 1: Luyện thi đại học--%>
                <div id="divContest">
                    <p>
                        <span>Tìm kiếm theo:</span><asp:DropDownList ID="ddlSearchingType" runat="server">
                            <asp:ListItem Text="Tất cả" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Đề thi" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <p id="Contest">
                        <span>Đề thi : </span>
                        <asp:DropDownList ID="ddlTypeContest" runat="server" Width="20%" ToolTip="Loại trường">
                            <asp:ListItem Text="Đại học" Value="true"></asp:ListItem>
                            <asp:ListItem Text="Cao đẳng" Value="false"></asp:ListItem>
                        </asp:DropDownList>
                        <%--<asp:DropDownList ID="ddlBranch" runat="server" Width="15%" ToolTip="Khối của ngành học">
                            <asp:ListItem Text="khối A" Value="0"></asp:ListItem>
                            <asp:ListItem Text="khối B" Value="1"></asp:ListItem>
                            <asp:ListItem Text="khối C" Value="2"></asp:ListItem>
                            <asp:ListItem Text="khối D" Value="3"></asp:ListItem>
                            <asp:ListItem Text="khối khác" Value="4"></asp:ListItem>
                        </asp:DropDownList>--%>
                        &nbsp;&nbsp;&nbsp;năm&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlYear" runat="server" Width="15%" ToolTip="Tìm kiếm trong khoảng từ +3 năm tới -3 năm">
                        </asp:DropDownList>
                    </p>
                </div>
                <p style="padding-top: 15px">
                    <span>&nbsp;</span><asp:Button ID="btnSearch" runat="server" Text="Tìm" CssClass="submit"
                        OnClick="btnSearch_Click" />
                </p>
            </div>
        </asp:Panel>
        <%--</form>--%>
        <asp:Panel ID="resultPanel" runat="server">
            <h2>
                Kết quả tìm kiếm
            </h2>
            <hr />
            <div>
                <asp:Label ID="lblResult" runat="server" Text="adsfasd"></asp:Label>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
