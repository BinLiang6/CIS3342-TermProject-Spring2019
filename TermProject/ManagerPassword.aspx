<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerPassword.aspx.cs" Inherits="TermProject.ManagerPassword" %>

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
    <form id="form1" runat="server" defaultbutton="btnContinue">
        <br />
        <div class="d-flex justify-content-center">
            <img src="img/amazon.jpg" alt="amazon.com" style="width: 166px; height: 60px;" />
        </div>
        <br />

        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <div class="card">
                    <article class="card-body">
                        <div class="form-group">
                            <asp:Label ID="Label1"  runat="server"><b>PASSWORD</b></asp:Label>

                            &nbsp;<asp:Label ID="lblDisplay" runat="server" ForeColor="Red" Text="Wrong Password!" Visible="False"></asp:Label>

                            <asp:TextBox ID="txtPassword" class="form-control" runat="server" type="password"></asp:TextBox>
                            <br />

                            <div class="form-row">

                                <div class="col-md-6">
                                    <asp:Button ID="btnBack" class="btn btn-outline-dark btn-block" Style="border: 1px solid grey;" runat="server" Text="Go back to Login Page" OnClick="btnBack_Click" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="btnContinue" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" Text="Continue" OnClick="btnContinue_Click" />
                                </div>
                            </div>
                        </div>
                    </article>
                </div>
            </div>
            <div class="col-md-3"></div>
        </div>
    </form>
</body>
</html>
