<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyLibraryFirstPage.aspx.cs" Inherits="MyLibraryFirstPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <b>欢迎来到我的图书馆！请登录...</b><br />
        你是：<asp:RadioButton ID="kindManagerBTN" runat="server"  Text="管理员"  TextAlign="Right" GroupName="kindGroup"/> 
        <asp:RadioButton ID="kindUserBTN" runat="server"  Text="用户" TextAlign="Right" GroupName="kindGroup" /><br />
        注册号:
        <asp:TextBox  ID ="numberLoginBOX" runat ="server" ></asp:TextBox>
        <br />
        密码：
        <asp:TextBox ID = "passwordLoginBOX" runat = "server"  TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="loginBTN" runat="server" Text="登陆" OnClick="loginBTN_Click" /> <br />
        <asp:HyperLink ID="forgetPwdLINK" runat="server" Text="忘记密码？" NavigateUrl="~/ForgetPwd.aspx" ></asp:HyperLink> <br />
        <asp:HyperLink ID="registerLINK" runat="server" Text="注册" NavigateUrl="~/Register.aspx"></asp:HyperLink>
    </div>
    </form>
</body>
</html>
