<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageBooksPage.aspx.cs" Inherits="ManageBooksPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        所有图书信息
        <asp:Button ID="btnAddBook" runat="server" Text="添加图书" OnClick="btnAddBook_Click" />
        <br />
    <asp:Repeater  ID="repeaterBooks" runat="server" OnItemCommand="repeaterBooks_ItemCommand">
        <HeaderTemplate >
            <table>
                <tr>
                <th>索书号</th>
                <th>书名</th>
                <th>作者</th>
                <th>出版信息</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("NumBook") %></td>
                <td> <%# Eval("Bookname")%></td>
                <td><%# Eval("Author") %></td>
                <td><%# Eval("PrintInfo") %></td>
                <td><asp:LinkButton ID="btn" runat="server" Text="修改信息" CommandName="change" CommandArgument='<%# Eval("id")%>'></asp:LinkButton></td>
                <td><asp:LinkButton ID="btnDel" runat="server" Text="删除" CommandName="del" CommandArgument='<%# Eval("id")%>'></asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
        <asp:Button ID="btnUp" runat="server" Text="上一页"  OnClick="btnUp_Click" />
        <asp:Button ID="btnDown" runat="server" Text="下一页" OnClick="btnDown_Click"/>
        <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
        <asp:Button ID="btnLast" runat="server" Text="尾页"  OnClick="btnLast_Click"/>
        页次：<asp:Label ID="lblNow" runat="server" Text="1"></asp:Label>
        /<asp:Label ID="lblTotal" runat="server" Text="1"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="16px"></asp:TextBox>
        <asp:Button ID="btnJump" runat="server" Text="Go" OnClick="btnJump_Click"/>
        <br /><asp:Button ID="btnBack" runat="server" Text="返回管理员首页" OnClick="btnBack_Click1" />
    </div>
    </form>
</body>
</html>
