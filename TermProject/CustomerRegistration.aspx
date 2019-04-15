<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="TermProject.CustomerRegistration" %>

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
                        <h2 class="card-title mb-4 mt-1">Create account</h2>
                        <label>Name</label>
                    <br />
            <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <label>Username</label>
                    <br />
                    
            <asp:TextBox ID="txtUsername" class="form-control" runat="server" ></asp:TextBox>
                    <br />
                    <label>Password</label>
                    <br />
            <asp:TextBox ID="txtPassword" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <label>Email</label>
                    <br />
            <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <label>Address</label>
                    <br />
            <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <label>Phone Number</label>
                    <br />
            <asp:TextBox ID="txtPhone" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    What is your sibling&#39;s middle name?<br />
                    Security Question 1:
            <asp:TextBox ID="txtSq1" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    What is your high school mascot?<br />
                    Security Question 2:
            <asp:TextBox ID="txtSq2" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    What is your favorite board game?<br />
                    Security Question 3:
            <asp:TextBox ID="txtSq3" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblSuccess" class=" alert alert-success btn-block" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="lblNotif" class=" alert alert-danger btn-block" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Button ID="btnSubmit" class="btn btn-warning btn-block" Style="border: 1px solid grey;" runat="server" OnClick="btnSubmit_Click" Text="Create your Amazon account" />
                    <asp:Button ID="btnReturnLogin" class="btn btn-warning btn-block" Style="border: 1px solid grey;" runat="server" Visible="false"  Text="Return to Login page" OnClick="btnReturnLogin_Click" />
                    </article>
                </div>
            </div>
            <div class="col-md-4"></div>
        </div>

    </form>
</body>
</html>
