<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <b>图书馆 </b> <br />
        <asp:ListBox  ID="searchTypeBOX" runat="server" SelectionMode="Single" ></asp:ListBox>
        <asp:TextBox ID="searchBOX" runat="server" Text =" 请输入搜索关键字/词" ></asp:TextBox>
        <asp:Button ID="searchBTN" runat="server" Text ="搜索" OnClick="searchBTN_Click" />

    <br /><br />
        <b> ·</b>
        <asp:Button ID="linkMyLibrary" runat="server" Text="我的图书馆" OnClick="linkMyLibrary_Click" />
        
    </div>
    </form>
</body>
</html>
