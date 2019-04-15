<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantRegistration.aspx.cs" Inherits="TermProject.MerchantRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="bootstrap-style.css" />
    <title></title>
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
                        <p>
                            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                        </p>
                        <p>
                            <asp:TextBox ID="txtUsername" class="form-control" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                        </p>
                        <p>
                            <asp:TextBox ID="txtDesc" class="form-control" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                        </p>
                        <p>
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="Label4" runat="server" Text="Phone"></asp:Label>
                        </p>
                        <p>
                            <asp:TextBox ID="txtPhone" class="form-control" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="lblNotify" class=" alert alert-danger btn-block" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                        </p>
                        <p>
                            <asp:Button ID="btnAddMerchant" class="btn btn-warning btn-block" Style="border: 1px solid grey;" runat="server" OnClick="btnAddMerchant_Click" Text="Create your Amazon merchant account" />
                        </p>

                    </article>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
