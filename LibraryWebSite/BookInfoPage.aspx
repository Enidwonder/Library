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
        <asp:Button ID="btnShelf" runat="server" Text="加入我的书架" OnClick="btnShelf_Click" />
       <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click" />
    </div>
        <div id="divShelf" runat="server" visible="false">
        我的书架们：<br />
        <asp:Repeater  ID="repeaterMyShelf" runat="server" OnItemCommand="repeaterMyShelf_ItemCommand">
        <HeaderTemplate >
            <table>
                <tr>
                <th>书架名</th>
                
                    </tr>
            
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td> <%# Eval("shelfName")%></td>
               
                <td><asp:LinkButton ID="btnAdd" runat="server" Text="加入当前书架" CommandName="lend" CommandArgument='<%# Eval("id")%>'></asp:LinkButton></td>
              
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
        <asp:Button ID="btnNewShelf" runat="server" Text="新建书架"  OnClick="btnNewShelf_Click"/>
       <asp:Button ID="btnCancelAdd" runat="server" Text="取消" OnClick="btnCancelAdd_Click" />
    </div>
        <div id="divNewShelf" runat="server" visible="false">
            新的书架名称：
            <asp:TextBox ID="txtNewShelfName" runat="server" ></asp:TextBox>
            <asp:Button ID="btnNew" runat="server" Text="创建" OnClick="btnNew_Click" />
        </div>
    </form>
</body>
</html>
