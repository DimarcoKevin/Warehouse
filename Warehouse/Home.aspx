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
            <asp:LinkButton ID="CreatePallet" runat="server" PostBackUrl="~/CreatePallet.aspx">Create Pallet</asp:LinkButton> <br />
            <asp:LinkButton ID="SearchByItem" runat="server" PostBackUrl="~/SearchByItem.aspx">Search By Item</asp:LinkButton> 
            <!-- 
                DONE:
                1) Display Items
                2) Create new Item
                3) Add back in login/signup page
                4) Create Pallets page
                5) Linking create Pallets to Locations
                6) Search for locations with 'XYZ' item 

                ON-DECK:
                2) validate user authentication as well as status - users.role
                    - Need to add admin/superuser functionality         

                Linkable pages:
                4) Receive a pallet of items (Inbound) (might not be needed)
                5) Create an order (Picking warehouse items) (could have role='customer' and have users place order)
                6) Have a fake payment processor for customer view to make sale
                7) ship an order of items (Outbound)

                
                9) Display item and stock in '123' location


                You can decide to do full inbound deliveries with full pallets of items
                and then do full pick pick orders for customers
                Then have outbound deliveries for customers 
                
                *** USE THIS FOR COMMENTS ***
                System.Diagnostics.Debug.WriteLine(GlobalVariables.user);                 
                -->

            <%
                if (role == "admin") {
                    AdminButton.Visible = true;
                }
                if (user != "" && user != null) {
                    LogoutButton.Visible = true;
                }
            %>
            <!-- Temporary BR to make gap until styling is added -->
            <br />
            <br />
            <asp:LinkButton ID="AdminButton" runat="server" PostBackUrl="~/Admin.aspx" Visible="false">Admin</asp:LinkButton> <br />
            <asp:LinkButton ID="LogoutButton" runat="server" PostBackUrl="~/Login.aspx" Visible="false">Logout</asp:LinkButton> 
        </div>
    </form>
</body>
</html>
