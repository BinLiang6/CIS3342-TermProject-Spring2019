<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="TermProject.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>GET DEPARTMENT API</h1>
            <br />
            <asp:GridView ID="gvDepartment" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="btnGetDepartment" runat="server" OnClick="btnGetDepartment_Click" Text="Get Department" />
            <br />

            <h1>GET PRODUCTS BY DEPARTMENT NUMBER</h1>
            <br />
            <asp:DropDownList ID="ddlDepartment" runat="server">
                <asp:ListItem Value="1">Amazon Devices</asp:ListItem>
                <asp:ListItem Value="2">Books</asp:ListItem>
                <asp:ListItem Value="3">Computer</asp:ListItem>
                <asp:ListItem Value="4">Electronic</asp:ListItem>
                <asp:ListItem Value="5">Home and Kitchen</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:GridView ID="gvProducts" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="btnGetProduct" runat="server" OnClick="btnGetProduct_Click" Text="Get Product by Department Number" />
            <br />
            <h1>REGISTER MERCHANT API</h1>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
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
            <p>&nbsp;</p>
            <p>&nbsp;</p>
        </div>
    </form>
</body>
</html>
