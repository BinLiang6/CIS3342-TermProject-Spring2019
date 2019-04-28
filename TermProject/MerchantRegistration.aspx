<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantRegistration.aspx.cs" Inherits="TermProject.MerchantRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="bootstrap-style.css" />
    <title>Amazon - Merchant registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div class="d-flex justify-content-center">
            <img src="img/amazon.jpg" alt="amazon.com" style="width: 166px; height: 60px;" />
        </div>
        <br />
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <div class="card">
                    <article class="card-body">
                        <h2 class="card-title mb-4 mt-1">Create merchant account</h2>
                        <label>Merchant name</label>
                        <br />
                        <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                        <br />
                        <div class="form-row">
                            <div class="col-md-6">
                                <label>Email</label>
                                <asp:TextBox ID="txtEmail" type="email" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Phone number</label>
                                <asp:TextBox ID="txtPhone" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <label>Password</label>
                        <br />
                        <asp:TextBox ID="txtPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                        <br />
                        <label>Description</label>
                        <br />
                        <asp:TextBox ID="txtDesc" class="form-control" runat="server"></asp:TextBox>
                        <br />
                        <label>API URL (optional)</label>
                        <br />
                        <asp:TextBox ID="txtUrl" class="form-control" runat="server"></asp:TextBox>
                        <br />
                        <label>Address</label>
                        <br />
                        <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                        <br />
                        <div class="form-row">
                            <div class="col-md-6">
                                <label>City</label>
                                <asp:TextBox ID="txtCity" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label>State</label>
                                <asp:TextBox ID="txtState" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Zip code</label>
                                <asp:TextBox ID="txtZipcode" type="number" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <asp:Label ID="lblDisplay" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
                        <asp:Label ID="lblSuccess" class=" alert alert-success btn-block" runat="server" Text="Label" Visible="False"></asp:Label>
                        <asp:Label ID="lblNotify" class=" alert alert-danger btn-block" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                        <asp:Button ID="btnAddMerchant" class="btn btn-warning btn-block" Style="border: 1px solid grey;" runat="server" OnClick="btnAddMerchant_Click" Text="Create your Amazon merchant account" />
                        <hr />
                        <a href="login.aspx" class="btn btn-outline-dark btn-block" style="border: 1px solid grey;">Go back to Sign in</a>
                    </article>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
