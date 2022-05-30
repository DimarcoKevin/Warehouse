<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Warehouse.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Hello <%=user%>!</h1>
        <h4>Please select a function in the list below</h4>
        <div>
            <asp:LinkButton ID="Items" runat="server" PostBackUrl="~/Items.aspx">Items</asp:LinkButton> <br />
            <asp:LinkButton ID="CreateItem" runat="server" PostBackUrl="~/CreateItem.aspx">Create Item</asp:LinkButton> <br />
            <asp:LinkButton ID="CreatePallet" runat="server" PostBackUrl="~/CreatePallet.aspx">Create Pallet</asp:LinkButton> 
            <!-- 
                DONE:
                1) Display Items
                2) Create new Item
                3) Add back in login/signup page

                ON-DECK:
                2) validate user authentication as well as status - users.role
                    - Current validates user and passes it back as a global var
                    - Need to add admin/superuser functionality         

                Linkable pages:
                3) Insert a pallet of items and place in location
                4) Receive a pallet of items (Inbound) (Tied with ^)
                5) Create an order (Picking warehouse items)
                6) Packing order (Closing up pallet) (Might only be needed if I decide to add delivery doors/trucks)
                7) ship an order of items (Outbound)

                8) Search for locations with 'XYZ' item 
                9) Display item and stock in '123' location


                You can decide to do full inbound deliveries with full pallets of items
                and then do full pick pick orders for customers
                Then have outbound deliveries for customers 
                

                *** Hidden admin panel inside if-statement                       
                -->


            <%
                if (user != "" && user != null) {
                    LogoutButton.Visible = true;
                }
            %>
            <!-- Temporary BR to make gap until styling is added -->
            <br />
            <br />
            <asp:LinkButton ID="LogoutButton" runat="server" PostBackUrl="~/Login.aspx" Visible="false">Logout</asp:LinkButton> 
        </div>
    </form>
</body>
</html>
