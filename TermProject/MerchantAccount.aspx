<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantAccount.aspx.cs" Inherits="TermProject.MerchantAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    '
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="bootstrap-style.css" />
    <title>Merchant Account</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex justify-content-center">
            <img src="img/amazon.jpg" alt="amazon.com" style="width: 166px; height: 60px;" />
        </div>
        <br />
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">

                <asp:LinkButton ID="lbSignout" class="float-right" runat="server" OnClick="lbSignout_Click">Sign out</asp:LinkButton>

                <br />
                <label><b>Account Information</b></label>
                <br />
                <div class="col-md-3"></div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <asp:GridView ID="gvAccountInfo" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCancelingEdit="gvAccountInfo_RowCancelingEdit" OnRowEditing="gvAccountInfo_RowEditing" OnRowUpdating="gvAccountInfo_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="address" HeaderText="Address" />
                        <asp:BoundField DataField="city" HeaderText="City" />
                        <asp:BoundField DataField="state" HeaderText="State" />
                        <asp:BoundField DataField="zipcode" HeaderText="Zipcode" />
                        <asp:BoundField DataField="phone" HeaderText="Phone" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <br />
                <asp:Button ID="btnRetrieveAPI" class="btn btn-warning btn-block" Style="border: 1px solid grey;" runat="server" OnClick="btnRetrieveAPI_Click" Text="Retrieve API Key" />
                &nbsp;&nbsp;&nbsp;
                <br />
                <asp:TextBox ID="txtAPIKey" class="form-control" runat="server"></asp:TextBox>
                <br />
                <div class="form-group">
                    <label><b>Reset your password</b></label>
                    <div class="form-group">
                        <label>Enter your current password</label>
                        <asp:TextBox ID="txtPassword" class="form-control" runat="server" type="password" />
                    </div>
                    <div class="form-group">
                        <label>Enter your new password</label>
                        <asp:TextBox ID="txtNewPassword" class="form-control" runat="server" type="password" />
                    </div>
                    <div class="form-group">
                        <label>Confirm new password</label>
                        <asp:TextBox ID="txtConfirmPassword" class="form-control" runat="server" type="password" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblDisplay" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
                        <asp:Label ID="lblSuccess" class="alert alert-success" runat="server" Text="Password reset successful!" Visible="false"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSubmit" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                </div>
                <hr />
                <asp:Button ID="btnViewSales" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" Text="View Sales" OnClick="btnViewSales_Click" />
                <br />
                <asp:GridView ID="gvSales" runat="server" AutoGenerateColumns="False">
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
                <br />
            </div>
            <div class="col-md-3"></div>
        </div>
    </form>
</body>
</html>
