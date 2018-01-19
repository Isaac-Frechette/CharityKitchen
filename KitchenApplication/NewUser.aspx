<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="KitchenApplication.NewUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create New User</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Create User</h1>
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
                    <th>Role level:</th>
                    <td><asp:TextBox runat="server" ID="txtRoleLevel" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="Create" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
