<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="TermProject.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <title></title>
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
        <br />
            <div class="d-flex justify-content-center">
            <img src="img/amazon.jpg" alt="amazon.com" style="width: 166px; height: 60px;" />
            </div>
        <br />
        <div>
            <br />
            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvCart_RowCancelingEdit" OnRowEditing="gvCart_RowEditing" OnRowUpdating="gvCart_RowUpdating" OnRowDeleting="gvCart_RowDeleting" ShowFooter="True" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Image" ReadOnly="True" />
                    <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" />
                    <asp:BoundField DataField="Desc" HeaderText="Description" ReadOnly="True" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" />
                    <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True" />
                    <asp:CommandField ButtonType="Button" EditText="" HeaderText="Delete" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnCheckout" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" OnClick="btnCheckout_Click" Text="Continue to Checkout" />
            <br />
        </div>
    </form>
</body>
</html>
