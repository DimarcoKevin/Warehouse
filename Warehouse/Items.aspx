<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="Warehouse.Items" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    
    <form id="form1" runat="server">
        <asp:LinkButton ID="GoHomeLink" runat="server">Go Home</asp:LinkButton>

        <div>
            <asp:Label ID="HeaderLabel" runat="server" Text="Search by Item"></asp:Label>
            <br />
            <asp:TextBox ID="SearchBox" runat="server"></asp:TextBox>
            <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
        </div>

        <asp:GridView ID="GridViewItems" runat="server"></asp:GridView>
    </form>
</body>
</html>
