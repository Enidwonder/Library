<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyLend.aspx.cs" Inherits="MyLend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        所有借阅信息
       
    <asp:Repeater  ID="repeaterlend" runat="server"  OnItemCommand="repeaterlend_ItemCommand">
        <HeaderTemplate >
            <table>
                <tr>
                <th>索书号</th>
                <th>书名</th>
                
                <th>状态</th>
                <th>续借次数</th>
                <th>应还日期</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("BookId") %></td>
                <td> <%# Eval("BookId")%></td>
                <td><%# Eval("status") %></td>
                <td><%# Eval("ContinueTimesNow") %></td>
                <td><%# Eval("ReturnTime") %></td>
                <td><asp:LinkButton ID="btn" runat="server" Text="续借" CommandName="continue" CommandArgument='<%# Eval("Id")%>'></asp:LinkButton></td>
                <td><asp:LinkButton ID="btnDel" runat="server" Text="还书" CommandName="back" CommandArgument='<%# Eval("Id")%>'></asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
        <br /><asp:Button ID="btnBack" runat="server" Text="返回用户首页"   OnClick="btnBack_Click" />
    
    </div>
    </form>
</body>
</html>
