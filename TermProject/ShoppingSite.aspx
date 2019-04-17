<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingSite.aspx.cs" Inherits="TermProject.ShoppingSite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:DropDownList ID="ddlDepartment" runat="server">
            </asp:DropDownList>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>

        </div>
    </form>
</body>
</html>
