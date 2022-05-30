<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Warehouse.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server" submitdisabledcontrols="True">    
        <h2>Login Page</h2>
        <div>
            <asp:Label ID="username_label" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="password_label" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="login_button" Text="Login" OnClick="login_button_Click" />
        <asp:HyperLink id="signup_hyperlink" NavigateUrl="../signup.aspx" Text="Signup" runat="server"/> 
        <br />
        <asp:Label ID="login_message" runat="server"></asp:Label>
    </form>
</body>
</html>
