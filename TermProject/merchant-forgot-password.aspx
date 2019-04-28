<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="merchant-forgot-password.aspx.cs" Inherits="TermProject.merchant_forgot_password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="bootstrap-style.css" />
    <title>Amazon - Forgot password</title>
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
                        <h2 class="card-title mb-4 mt-1">Password assistance</h2>
                        <p>Enter the email address associated with your Amazon email and API Key to reset your password.</p>
                        <div id="email" runat="server" visible="true">
                            <div class="form-group">
                                <label><b>Email</b></label>
                                <asp:TextBox ID="txtEmail" class="form-control" runat="server" placeholder="example@email.com" type="email" />
                            </div>
                            <div class="form-group">
                                <label><b>API Key</b></label>
                                <asp:TextBox ID="txtAPIKey" class="form-control" runat="server" />
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblDisplay" class="alert alert-danger btn-block" runat="server" Text="" Visible="false" ForeColor="#CC3300"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnContinue" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" Text="Continue" OnClick="btnContinue_Click" />
                            </div>
                        </div>

                        <div id="resetPassword" runat="server" visible="false">
                            <hr />
                            <div class="form-group">
                                <label><b>Enter your new password</b></label>
                                <asp:TextBox ID="txtNewPassword" class="form-control" runat="server" type="password" />
                            </div>
                            <div class="form-group">
                                <label><b>Confirm new password</b></label>
                                <asp:TextBox ID="txtConfirmPassword" class="form-control" runat="server" type="password" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblSuccess" class="alert alert-success btn-block" runat="server" Text="Successfully update password" Visible="False"></asp:Label>
                                <br />
                                <asp:Label ID="lblPassword" class="alert alert-danger btn-block" Visible="false" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnSubmit" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" Text="Submit" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                        <!-- reset password// -->
                        <hr />
                        <div class="form-group">
                            <a href="login.aspx" class="btn btn-outline-dark btn-block" style="border: 1px solid grey;">Go back to Sign in</a>
                        </div>
                    </article>
                </div>
            </div>
            <div class="col-md-4"></div>
        </div>
    </form>
</body>
</html>
