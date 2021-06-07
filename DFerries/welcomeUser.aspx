<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcomeUser.aspx.cs" Inherits="DFerries.welcomeUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 186px;
        }
        .auto-style2 {
            width: 2px;
        }
    </style>
</head>
<body>
    <div>
        <h2><u>Welcome User</u></h2>
    </div>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">Welcome</td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:Label ID="labWelcome" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Total Vowels in Your Name</td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:Label ID="labVowels" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Age</td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:Label ID="labAge" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Days before next birthday</td>
                    <td class="auto-style2">:</td>
                    <td>
                        <asp:Label ID="labDays" runat="server"></asp:Label>
                    </td>
                </tr>

            </table>
        </div><br />
        <div>
            <asp:GridView ID="grd14days" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
