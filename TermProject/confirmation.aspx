<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmation.aspx.cs" Inherits="TermProject.confirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <title>Amazon - Confirmation</title>
</head>
<body>
    <form id="frmConfirmation" runat="server">
        <br />
            <div class="d-flex justify-content-center">
            <img src="img/amazon.jpg" alt="amazon.com" style="width: 166px; height: 60px;" />
            </div>
        <br />
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <div class="form-group">
                    <label><b>Purchase confirmation</b></label>
                    <br />
                    <asp:Label ID="lblCustomer" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:GridView ID="gvConfirm" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="Image" ReadOnly="True" />
                            <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Desc" HeaderText="Description" ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
                <div class="form-row">
                    <div class="col-md-6">
                        <asp:Button ID="btnSendMail" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" Text="Send confirmation to email" OnClick="btnSendMail_Click" />
                    </div>
                    <div class="col-md-6">
                        <a href="ShoppingSite.aspx" class="btn btn-outline-dark btn-block" style="border: 1px solid grey;">Go back to shopping site</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3"></div>
        </div>
    </form>
</body>
</html>
