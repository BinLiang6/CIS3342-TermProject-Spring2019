﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerAccount.aspx.cs" Inherits="TermProject.CustomerAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="bootstrap-style.css" />
    <title>Customer Account</title>
</head>
<body>
    <form id="frmCustomerAccount" runat="server">
        <br />
        <div class="d-flex justify-content-center">
            <img src="img/amazon.jpg" alt="amazon.com" style="width: 166px; height: 60px;" />
        </div>
        <br />
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <!--Account Info-->
                <div class="form-group">
                    <label><b>Account Information</b></label> 
                    <asp:GridView ID="gvAccountInfo" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="username" HeaderText="Username" />
                            <asp:BoundField DataField="name" HeaderText="Name" />
                            <asp:BoundField DataField="address" HeaderText="Address" />
                            <asp:BoundField DataField="city" HeaderText="City" />
                            <asp:BoundField DataField="state" HeaderText="State" />
                            <asp:BoundField DataField="zipcode" HeaderText="Zip Code" />
                            <asp:BoundField DataField="phone" HeaderText="Phone" />
                            <asp:BoundField DataField="email" HeaderText="Email" />
                            <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
                <!--Account security questions-->
                <div class="form-group">
                    <label><b>Edit your security question</b></label>
                </div>
                <!--Reset password-->
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
                        <asp:Label ID="lblSuccess" class="alert alert-success" runat="server" Text="Password reset successful!" Visible="false" ></asp:Label>
                     </div>
                    <div class="form-group">
                        <asp:Button ID="btnSubmit" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                </div>
                <!--Order history-->
                <div class="form-group">
                    <label><b>Order history</b></label>
                </div>
                <!--Go back-->
                <hr />
                <div class="form-group">
                    <a href="ShoppingSite.aspx" class="btn btn-outline-dark btn-block" style="border: 1px solid grey;">Go back</a>
                </div>
            </div>
            <div class="col-md-3"></div>
        </div>
    </form>
</body>
</html>