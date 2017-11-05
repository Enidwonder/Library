<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerFirstPage.aspx.cs" Inherits="ManagerFirstPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <b> 我的首页</b><br /> <br />
    <b> ·个人信息</b><br />
        管理员姓名：<asp:Label ID="nameLABEL" runat="server"></asp:Label><br />
        性别：<asp:Label ID="sexLABEL" runat="server"></asp:Label><br />
        Email:<asp:Label ID="emailLABEL" runat="server"></asp:Label><br />
        证件开始日期：<asp:Label ID="beginTimeLABEL" runat="server"></asp:Label><br />
        证件结束日期：<asp:Label ID="endTimeLABEL" runat="server"></asp:Label><br />
        <asp:Button ID="changePwdBTN" runat="server" Text="修改密码"  OnClick="changePwdBTN_Click"/>
        <asp:Button ID="changeInfoBTN" runat="server" Text="修改信息"   OnClick="changeInfoBTN_Click" />
        <asp:HyperLink ID="backToMainPageLINK" runat="server" Text="返回我的图书馆登陆页" NavigateUrl="~/MyLibraryFirstPage.aspx"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="linkManageUsers" runat="server" Text="管理用户" NavigateUrl="~/ManageUsersPage.aspx"></asp:HyperLink>
        <asp:HyperLink ID="linkManageBooks" runat="server" Text="管理图书" NavigateUrl="~/ManageBooksPage.aspx"></asp:HyperLink>
        <asp:HyperLink ID="linkManageLendInfo" runat="server" Text="管理借书" NavigateUrl="~/ManageLendInfoPage.aspx"></asp:HyperLink>
    </div>
    </form>
</body>
</html>
