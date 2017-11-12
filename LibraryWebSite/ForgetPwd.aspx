<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPwd.aspx.cs" Inherits="ForgetPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <b>忘记密码：</b><br />
        你是：<asp:RadioButton ID="kindManagerBTN" runat="server"  Text="管理员"  TextAlign="Right" GroupName="kindGroup"/> 
        <asp:RadioButton ID="kindUserBTN" runat="server"  Text="用户" TextAlign="Right" GroupName="kindGroup" /><br />
        证件号：<asp:TextBox ID="cardNumberBOX" runat="server"></asp:TextBox><br />
        验证码：<asp:TextBox ID="codeBOX" runat="server"></asp:TextBox>
        <asp:Button ID="getCodeBTN" runat="server" Text="发送验证码" OnClick="getCodeBTN_Click" /><br />
        设置新密码：<asp:TextBox ID="newPwdSetBOX" runat="server" ></asp:TextBox><br />
        确认新密码：<asp:TextBox ID="newPwdSureBOX" runat="server"></asp:TextBox><br />
        <asp:Button ID="setNewPwdBTN" runat="server" Text="重置密码" OnClick="setNewPwdBTN_Click" /><br />
        <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click" />
    </div>
    </form>
</body>
</html>
