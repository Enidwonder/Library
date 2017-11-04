<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddBookPage.aspx.cs" Inherits="AddBookPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    添加图书<br />
        书名：<asp:TextBox ID="txtName" runat="server" ></asp:TextBox><br />
        作者：<asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox><br />
        出版信息：<asp:TextBox ID="txtPrintInfo" runat="server"></asp:TextBox><br />
        馆藏信息：<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><br />
        价格：<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br />
        书目类型：<asp:TextBox ID="txtKind" runat="server"></asp:TextBox><br />
        所属学科：<asp:TextBox ID="txtSubject" runat="server"></asp:TextBox><br />
        索书号：<asp:TextBox ID="txtNumSpecial" runat="server"></asp:TextBox><br />
        书号：<asp:TextBox ID="txtNumBook" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnAdd" runat="server" Text="添加图书" OnClick="btnAdd_Click" />
        <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" />
    </div>
    </form>
</body>
</html>
