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
            <br />
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="Product Number" />
                    <asp:BoundField DataField="desc" HeaderText="Description" />
                    <asp:BoundField DataField="price" HeaderText="Price" />
                    <asp:BoundField DataField="image" HeaderText="Image" />
                </Columns>
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
            <br />
            <h1>RECORD PURCHASE API</h1>
            <br />

            <p>
                <asp:Label ID="Label5"  type="number"  runat="server" Text="Quantity"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtQTY" type="number" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label6"  type="number"  runat="server" Text="Product Number"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtProductID" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label7" runat="server" Text="Customer ID"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCustomerID" runat="server"></asp:TextBox>
            </p>
            <p>
                &nbsp;</p>
            <p>
                <asp:Label ID="lblNotify2" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            </p>
            <p>
                &nbsp;</p>
            <p>
                <asp:Button ID="RecordPurchase" runat="server" OnClick="RecordPurchase_Click" Text="Submit" />
            </p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
        </div>
    </form>
</body>
</html>
