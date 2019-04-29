<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerAccount.aspx.cs" Inherits="TermProject.ManagerAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="bootstrap-style.css" />
    <title>Amazon - Manager</title>
    <style type="text/css">
        *, ::after, ::before {
            text-shadow: none !important;
            box-shadow: none !important
        }

        *, ::after, ::before {
            box-sizing: border-box
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div class="d-flex justify-content-center">
            <img src="img/amazon.jpg" alt="amazon.com" style="width: 166px; height: 60px;" />
        </div>
        <br />
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <div class="card">
                    <article class="card-body">
                        <div class="form-group">
                            <asp:LinkButton ID="lbSignout" runat="server" class="float-right" OnClick="lbSignout_Click">Sign out</asp:LinkButton>
                            <asp:Label ID="lblcustomersales" runat="server"><b>Customer Sales</b></asp:Label>
                            <br /><br />
                            <asp:Button ID="btnCustomerReport" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" OnClick="btnCustomerReport_Click" Text="View Customer Sales Report" />
                        </div>

                        <br />
                        <asp:GridView ID="gvCustomerSales" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="username" HeaderText="Username" />
                                <asp:BoundField DataField="name" HeaderText="Name" />
                                <asp:BoundField DataField="email" HeaderText="Email" />
                                <asp:BoundField DataField="total" DataFormatString="{0:$###,##0.00}" HeaderText="Total" />
                            </Columns>
                        </asp:GridView>
                        <br />
                        <hr />
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server"><b>Inventory</b></asp:Label>
                            <br /><br />
                            <asp:Button ID="btnSearchInventory" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" OnClick="btnSearchInventory_Click" Text="Search Inventory" />
                            <br />
                            Quantity is less than: 
                            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                            <asp:Label ID="lblDisplay" runat="server" ForeColor="Red" Text="Please enter the quantity" Visible="False"></asp:Label>
                        </div>
                        <asp:GridView ID="gvInventory" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="name" HeaderText="Department Name" />
                                <asp:BoundField DataField="desc" HeaderText="Product Description" />
                                <asp:BoundField DataField="price" DataFormatString="{0:$###,##0.00}" HeaderText="Price" />
                                <asp:BoundField DataField="qty" HeaderText="Quantity" />
                            </Columns>
                        </asp:GridView>
                        <br />
                        <hr />
                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server"><b>Amazon Sales</b></asp:Label>
                            <br /><br />
                            <asp:Button ID="btnSalesReport" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" OnClick="btnSalesReport_Click" Text="View Amazon Sales Report" />
                            <br />
                        </div>

                        <asp:GridView ID="gvAmazonSales" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="product_id" HeaderText="Product ID" />
                                <asp:BoundField DataField="title" HeaderText="Title" />
                                <asp:BoundField DataField="customer_name" HeaderText="Name" />
                                <asp:BoundField DataField="customer_address" HeaderText="Address" />
                                <asp:BoundField DataField="customer_city" HeaderText="City" />
                                <asp:BoundField DataField="customer_state" HeaderText="State" />
                                <asp:BoundField DataField="customer_zipcode" HeaderText="Zipcode" />
                                <asp:BoundField DataField="customer_phone" HeaderText="Phone" />
                                <asp:BoundField DataField="customer_email" HeaderText="Email" />
                            </Columns>
                        </asp:GridView>

                    </article>

                    <br />
                </div>
            </div>
            <div class="col-md-3"></div>
        </div>
    </form>
</body>
</html>
