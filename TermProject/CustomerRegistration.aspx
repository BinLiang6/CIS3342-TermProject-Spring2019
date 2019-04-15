<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="TermProject.CustomerRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            Username
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            Password&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            Email&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            Address&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <br />
            Phone&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <br />
            <br />
            What is your sibling&#39;s middle name?<br />
            Security Question 1:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtSq1" runat="server"></asp:TextBox>
            <br />
            <br />
            What is your high school mascot?<br />
            Security Question 2:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtSq2" runat="server"></asp:TextBox>
            <br />
            <br />
            What is your favorite board game?<br />
            Security Question 3:
            <asp:TextBox ID="txtSq3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblNotif" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        </div>
    </form>
</body>
</html>
