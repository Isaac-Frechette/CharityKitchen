<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KitchenApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>
            <asp:Label runat="server" ID="lblStatus" />
            <table>
                <tr>
                    <th>Username:</th>
                    <td><asp:TextBox runat="server" ID="txtUsername" /></td>
                </tr>
                <tr>
                    <th>Password:</th>
                    <td><asp:TextBox runat="server" ID="txtPassword" TextMode="Password" /></td>
                </tr>
                <tr>
                    <td>Login:</td>
                    <td><asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="Login" /></td>
                </tr>
            </table>
            <a href="NewUser.aspx">Create new account</a>
        </div>
    </form>
</body>
</html>