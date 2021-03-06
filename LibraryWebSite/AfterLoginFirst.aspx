﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AfterLoginFirst.aspx.cs" Inherits="AfterLoginFirst" %>

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
        <asp:DropDownList ID="drop" runat="server">
            <asp:ListItem Text="bookname"></asp:ListItem>
            <asp:ListItem Text="author"></asp:ListItem>  
            </asp:DropDownList>
        <asp:TextBox ID="txtSearch" runat="server" ></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" /><br />
    <b> ·个人信息</b><br />
        用户姓名：<asp:Label ID="nameLABEL" runat="server"></asp:Label><br />
        性别：<asp:Label ID="sexLABEL" runat="server"></asp:Label><br />
        Email:<asp:Label ID="emailLABEL" runat="server"></asp:Label><br />
        证件开始日期：<asp:Label ID="beginTimeLABEL" runat="server"></asp:Label><br />
        证件结束日期：<asp:Label ID="endTimeLABEL" runat="server"></asp:Label><br />
        <asp:Button ID="changePwdBTN" runat="server" Text="修改密码" OnClick="changePwdBTN_Click" />
        <asp:Button ID="changeUserInfoBTN" runat="server" Text="修改信息" OnClick="changeUserInfoBTN_Click" />
        <asp:HyperLink ID="backToMainPageLINK" runat="server" Text="返回我的图书馆登陆页" NavigateUrl="~/MyLibraryFirstPage.aspx"></asp:HyperLink><br />
        <asp:HyperLink ID="hylinkMyLend" runat="server" Text="我的借阅" NavigateUrl="~/MyLend.aspx"></asp:HyperLink>

    </div>
    </form>
</body>
</html>
