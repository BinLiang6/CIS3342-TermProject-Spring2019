<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="TermProject.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvCart_RowCancelingEdit" OnRowEditing="gvCart_RowEditing" OnRowUpdating="gvCart_RowUpdating" OnRowDeleting="gvCart_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Image" ReadOnly="True" />
                    <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" />
                    <asp:BoundField DataField="Desc" HeaderText="Description" ReadOnly="True" />
                    <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True" />
                    <asp:CommandField ButtonType="Button" EditText="" HeaderText="Delete" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnCheckout" runat="server" OnClick="btnCheckout_Click" Text="Continue to Checkout" />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
