<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <b>注册：</b>
        <br />
        姓名：
        <asp:TextBox ID="nameRegister" runat ="server" ></asp:TextBox>
        <br />
        性别：
        <asp:RadioButton ID="sexManBTN" runat="server" Text="男" TextAlign="Right"  GroupName="sex"/>
        <asp:RadioButton ID="sexWomanBTN" runat="server" Text="女" TextAlign="Right" GroupName="sex" />
        <br />
        身份证号：<asp:TextBox ID="personIDBOX" runat="server"></asp:TextBox><br />
        工作单位：<asp:TextBox ID="workplaceBOX" runat="server"></asp:TextBox><br />
        手机号码：<asp:TextBox ID="phoneNumberBOX" runat="server"></asp:TextBox><br />
        出生年月：<asp:TextBox ID="birthdayBOX" runat="server"></asp:TextBox><br />
        邮箱：
        <asp:TextBox ID="EmailBOX" runat ="server" ></asp:TextBox>
        <asp:Button ID="sendEmailBTN" runat="server" Text="发送验证码" OnClick="sendEmailBTN_Click" />
        <br />
        验证码：<asp:TextBox ID="codeBOX" runat="server" ></asp:TextBox><br />
        设置密码：
        <asp:TextBox ID="pwdSetBOX" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        确认密码：
        <asp:TextBox ID="pwdSureBOX" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="registerBTN" runat="server" Text="注册"  OnClick="registerBTN_Click" />
        <br />
    </div>
        <div id="numberShow" runat="server" visible="false"> 
            <asp:Label ID="numberLABEL" runat="server" ></asp:Label>
        </div>
    </form>
</body>
</html>
