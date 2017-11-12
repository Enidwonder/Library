<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookInfoPage.aspx.cs" Inherits="BookInfoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        书名：
    <asp:Label ID="lblName" runat="server" ></asp:Label><br />
        作者：
       <asp:Label ID="lblAuthor" runat="server" ></asp:Label><br />
        出版信息：
        <asp:Label ID="lblPrintInfo" runat="server" ></asp:Label><br />
        价格：
        <asp:Label ID="lblPrice" runat="server" ></asp:Label><br />
        索书号：
        <asp:Label ID="lblNumBook" runat="server" ></asp:Label><br />

        <asp:Repeater  ID="repeater" runat="server" OnItemCommand="repeater_ItemCommand">
        <HeaderTemplate >
            <table>
                <tr>
                <th>书号</th>
                <th> 馆藏地</th>
                    <th> 借阅状态</th>
                    </tr>
            
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td> <%# Eval("NumSpecial")%></td>
                <td><%# Eval("Address") %></td>
                <td><%# Eval("status") %></td>
                <td><asp:LinkButton ID="btn" runat="server" Text="我要借书" CommandName="lend" CommandArgument='<%# Eval("id")%>'></asp:LinkButton></td>
              
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
       <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click" />
    </div>
    </form>
</body>
</html>
