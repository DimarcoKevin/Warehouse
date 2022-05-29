<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateItem.aspx.cs" Inherits="Warehouse.CreateItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Create new items</h1>
        <div>
            <asp:Label ID="ItemLabel" runat="server">Item:</asp:Label>
            <asp:TextBox ID="ItemTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Color" runat="server">Color:</asp:Label>
            <asp:DropDownList ID="ColorDD" runat="server" ></asp:DropDownList>
          
        </div>
    </form>
</body>
</html>
