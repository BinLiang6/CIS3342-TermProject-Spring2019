<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantRegistration.aspx.cs" Inherits="TermProject.MerchantRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label4" runat="server" Text="Phone"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblNotify" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btnAddMerchant" runat="server" OnClick="btnAddMerchant_Click" Text="Submit" />
            </p>
            <br />
        </div>
    </form>
</body>
</html>
