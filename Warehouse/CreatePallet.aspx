<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePallet.aspx.cs" Inherits="Warehouse.CreatePallet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Pallet</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton ID="GoHomeLink" runat="server" PostBackUrl="~/Home.aspx">Go Home</asp:LinkButton>
        <h1>Create new pallets!</h1>

        <div>
            <asp:Label ID="ItemLabel" runat="server">Item</asp:Label>
            <asp:DropDownList ID="ItemDD" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Color" runat="server">Color</asp:Label>
            <asp:DropDownList ID="ColorDD" runat="server"></asp:DropDownList>
        </div>



        <div>
            <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click"></asp:Button>
        </div>

    </form>
</body>
</html>
