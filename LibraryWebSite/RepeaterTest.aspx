<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepeaterTest.aspx.cs" Inherits="RepeaterTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Repeater  ID="repeater" runat="server" OnItemCommand="repeater_ItemCommand">
        <HeaderTemplate >
            <table>
                <tr>
                <th>书名</th>
                <th> 作者</th>
                    </tr>
            
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td> <%# Eval("Bookname")%></td>
                <td><%# Eval("Author") %></td>
                <td><asp:LinkButton ID="btn" runat="server" Text="button" CommandName="name" CommandArgument='<%# Eval("Bookname")%>'></asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </div>
    </form>
</body>
</html>
