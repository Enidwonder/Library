<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageUsersPage.aspx.cs" Inherits="ManageUsersPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    所有用户信息
        <br />
    <asp:Repeater  ID="repeaterUser" runat="server"  OnItemCommand="repeaterUser_ItemCommand">
        <HeaderTemplate >
            <table>
                <tr>
                <th>编号</th>
                <th>姓名</th>
                <th>邮箱</th>
                <th>证件失效日期</th>

                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("number") %></td>
                <td> <%# Eval("Bookname")%></td>
                <td><%# Eval("Author") %></td>
                <td><%# Eval("PrintInfo") %></td>
                <td><asp:LinkButton ID="btn" runat="server" Text="修改信息" CommandName="name" CommandArgument='<%# Eval("number")%>'></asp:LinkButton></td>
                <td><asp:LinkButton ID="btnDel" runat="server" Text="删除" CommandName="name" CommandArgument='<%# Eval("number")%>'></asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
        <br /><asp:Button ID="btnBack" runat="server" Text="返回管理员首页"  OnClick="btnBack_Click" />
    </div>
    </form>
</body>
</html>
