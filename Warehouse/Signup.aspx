<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Warehouse.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup</title>
    <link href="Styling/LoginSignup.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">   
        <h2>Signup Page</h2>
        <div class="input-container">
            <asp:TextBox CssClass="input" ID="username" runat="server" placeholder="Username"></asp:TextBox>
        </div>
        <div class="input-container">
            <asp:TextBox CssClass="input" ID="password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="submit" Text="Signup" OnClick="signup_button_Click" />
        <asp:Button runat="server" ID="login" Text="Go To Login" OnClick="login_Click" />
        <br />
        <asp:Label ID="signup_message" runat="server"></asp:Label>
    </form>
</body>
</html>
