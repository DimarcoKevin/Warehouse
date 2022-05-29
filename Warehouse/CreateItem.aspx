<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateItem.aspx.cs" Inherits="Warehouse.CreateItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton ID="GoHomeLink" runat="server" PostBackUrl="~/Home.aspx">Go Home</asp:LinkButton>
        <h1>Create new items!</h1>
        
        <div>
            <asp:Label ID="ItemLabel" runat="server">Item</asp:Label>
            <asp:TextBox ID="ItemTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Color" runat="server">Color</asp:Label>
            <asp:DropDownList ID="ColorDD" runat="server" ></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="DescLabel" runat="server">Description</asp:Label>
            <asp:TextBox ID="DescTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MaxLabel" runat="server">Max per pallet</asp:Label>
            <asp:TextBox ID="MaxTextBox" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="PriceLabel" runat="server">Price ($)</asp:Label>
            <asp:TextBox ID="PriceTextBox" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
