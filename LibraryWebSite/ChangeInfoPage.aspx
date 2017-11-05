<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeInfoPage.aspx.cs" Inherits="ChangeInfoPage" %>

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
        Email: <asp:TextBox ID="emailBeforeBOX" runat="server" ></asp:TextBox><br />
        新Email:<asp:TextBox ID="newEmailBOX" runat="server"></asp:TextBox><br />
        电话：<asp:TextBox ID="phoneNUMBOX" runat="server" ></asp:TextBox><br />
        
        <asp:Button ID="ChangeBTN" runat="server" Text="确定" OnClick="ChangeBTN_Click" />
        <asp:Button ID="Returnn" runat="server" Text="返回" OnClick="Returnn_Click" />

    </div>
    </form>
</body>
</html>
