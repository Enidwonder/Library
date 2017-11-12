<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeBookInfo.aspx.cs" Inherits="ChangeBookInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<b>修改信息</b><br />
        Name: <asp:TextBox ID="txtBookBefore" runat="server" ></asp:TextBox><br />
        新Name:<asp:TextBox ID="txtNewName" runat="server"></asp:TextBox><br />
        Address：<asp:TextBox ID="txtAddress" runat="server" ></asp:TextBox><br />
        
        <asp:Button ID="btnChange" runat="server" Text="确定" OnClick="btnChange_Click" />
        <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />

    </div>
    </form>
</body>
</html>
