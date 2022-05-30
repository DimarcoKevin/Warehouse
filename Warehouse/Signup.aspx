<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Warehouse.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup</title>
    <link href="Styling/Login.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">   
        <h2>Signup Page</h2>
        <div>
            <asp:Label ID="username_label" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="password_label" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="signup_button" Text="Signup" OnClick="signup_button_Click" />
        <asp:HyperLink id="login_hyperlink" NavigateUrl="../Login.aspx" Text="Login" runat="server"/> 
        <br />
        <asp:Label ID="signup_message" runat="server"></asp:Label>
    </form>
</body>
</html>
