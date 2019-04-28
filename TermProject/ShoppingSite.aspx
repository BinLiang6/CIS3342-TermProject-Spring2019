<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingSite.aspx.cs" Inherits="TermProject.ShoppingSite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <title>Amazon</title>
    <style type="text/css">
        #frmShopping {
            height: 750px;
        }
    </style>
</head>
<body style="padding: 5px;">
    <form id="frmShopping" runat="server">
        <br />
            <div class="d-flex justify-content-center">
                <img src="img/amazon.jpg" alt="amazon.com" style="width: 166px; height: 60px;" />
            </div>
        <br />
        <div>
            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="True" >
            </asp:DropDownList>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnGetProduct" runat="server" OnClick="btnGetProduct_Click" Text="Search" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLogout" class="float-right" runat="server" Text="Sign Out" OnClick="btnLogout_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnAccount" class="float-right" runat="server" Text="Account setting" OnClick="btnAccount_Click" />
            <asp:LinkButton ID="lbCart" runat="server" OnClick="lbCart_Click" ><span class="glyphicon glyphicon-shopping-cart"></span> Cart</asp:LinkButton>
            <hr />
            <br />
            <asp:Label ID="lblNotify" class=" alert alert-danger btn-block" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            <br />
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <img src='<%# Eval("Image") %>' height="200" width="200" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="title" HeaderText="Title" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="desc" HeaderText="Description" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="price" HeaderText="Price" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" type="number" Text="1" min="1" max="100" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" HeaderText="Add to Cart" ShowSelectButton="true" SelectText="Add to cart" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:BoundField DataField="product_id" HeaderText="Product ID" Visible="False" />
                </Columns>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
            <br />
            
            <asp:Button ID="Button1" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" OnClick="btnViewCart_Click" Text="View Cart" />
            <br /><br />
        </div>
    </form>
</body>
</html>
