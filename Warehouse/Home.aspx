<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Warehouse.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Hello User!</h1>
        <h4>Please select a function in the list below</h4>
        <div>
            <asp:LinkButton ID="Items" runat="server" PostBackUrl="~/Items.aspx">Items</asp:LinkButton> <br />
            <asp:LinkButton ID="CreateItem" runat="server" PostBackUrl="~/CreateItem.aspx">Create Item</asp:LinkButton> 
            <!-- 
                DONE:
                1) Display Items


                ON-DECK:
                1) Create new item (design complete - needs logic)
                2) Add back in login/signup page
                3) validate user authentication as well as status - users.role

                Linkable pages:
                3) Create a pallet of items
                4) Receive a pallet of itesm
                5) ship a pallet of items

                3) Display location grid
                4) Create new location
                5) Search for locations with 'XYZ' item
                6) Display item and stock in '123' location

                

                *** Hidden admin panel inside if-statement
                <% String code = "Use these to write C# inside aspx";%> 
                
                -->
        </div>
    </form>
</body>
</html>
