<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwdPage.aspx.cs" Inherits="ChangePwdPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <b>修改密码</b><br />
        原密码;<asp:TextBox ID="beforePwdBOX" runat="server" ></asp:TextBox><br />
        新密码：<asp:TextBox ID="newSetPwdBOX" runat="server"></asp:TextBox><br />
        确认新密码：<asp:TextBox ID="newSurePwdBOX" runat="server"></asp:TextBox><br />
    <asp:Button ID="changePwdBTN" runat="server" Text="确认" OnClick="changePwdBTN_Click" />
        <asp:Button ID="returnBTN" runat="server" Text="返回" OnClick="returnBTN_Click" />
    </div>
    </form>
</body>
</html>
