<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Warehouse.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Styling/NewLogin.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server" submitdisabledcontrols="True">    
        <h2>Login Page</h2>
        <div class="input-container">
            <!--<asp:Label ID="username_label" runat="server" Text="Username:"></asp:Label>-->
            <asp:TextBox CssClass="input" ID="username" runat="server" placeholder="Username"></asp:TextBox>
        </div>
        <div class="input-container">
            <!--<asp:Label ID="password_label" runat="server" Text="Password:"></asp:Label>-->
            <asp:TextBox CssClass="input" ID="password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="submit" Text="Login" OnClick="login_button_Click" />
        <!--<asp:HyperLink id="signup_hyperlink" NavigateUrl="../signup.aspx" Text="Signup" runat="server"/> -->
        <asp:Button runat="server" ID="signup" Text="Go To Signup" OnClick="signup_Click" />
        <br />
        <asp:Label ID="login_message" runat="server"></asp:Label>
    </form>
</body>
</html>
