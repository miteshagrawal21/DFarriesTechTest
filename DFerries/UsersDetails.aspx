<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersDetails.aspx.cs" Inherits="DFerries.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <style type="text/css">
        .auto-style1 {
            width: 74px;
        }
        .auto-style2 {
            width: 6px;
        }
        .auto-style3 {
            width: 4px;
        }
        .auto-style4 {
            width: 46%;
            height: 39px;
        }
        .auto-style5 {
            width: 167px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2><u>User Details</u></h2>
        </div>
        <div>
            <asp:TextBox ID="txtUserId" runat="server" Visible="false"></asp:TextBox>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style5">First Name</td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" Width="176px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Last Name</td>
                    <td class="auto-style2">:</td>
                    <td><asp:TextBox ID="txtLastName" runat="server" Width="176px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style5">Birth Date <asp:Label ID="labDate" runat="server" Text="(dd/mm/yyyy)"></asp:Label></td>
                    <td class="auto-style2">:</td>
                    <td><asp:TextBox ID="txtDob" runat="server" Width="176px"></asp:TextBox>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div>
            <table class="auto-style4">
                <tr>
                    <td class="auto-style1" style="width:33%;">
                        <asp:Button ID="btnAdd" runat="server" Text=" Add User " PostBackUrl="~/welcomeUser.aspx" />
                    </td>
                    <td class="auto-style3" style="width:34%;">
                        <asp:Button ID="btnUpdate" runat="server" Text=" Update User " Width="97px" OnClick="btnUpdate_Click" />
                    </td>
                    <td class="auto-style3" style="width:33%;">
                        <asp:Button ID="btnDelete" runat="server" Text=" Delete User " OnClick="btnDelete_Click" />
                    </td>
                </tr>
            </table>
        </div><br />
        <div>
            <asp:GridView ID="grdUsers" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdUsers_SelectedIndexChanged"></asp:GridView>
        </div>
    </form>
</body>
</html>
