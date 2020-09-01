<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/Site.Master" CodeBehind="LoginView.aspx.cs" Inherits="NetTest.View.LoginView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Login</h1> <br />
    <h2>Bitte melden sie sich an!</h2> <br /> <br />
    <asp:Label ID="Label1" runat="server" Text="Benutzername:" Width="120px" ></asp:Label>
    <asp:TextBox ID="txtUser" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="20px" BorderColor="Black"></asp:TextBox> <br /> <br />
    <asp:Label ID="Label2" runat="server" Text="Passwort:" Width="120px"></asp:Label> 
    <asp:TextBox ID="txtPasswort" runat="server" TextMode="Password" BorderStyle="Solid" BorderWidth="1px" Height="20px" BorderColor="Black"></asp:TextBox><br />
    <br />
    <asp:Button ID="btnLogin" runat="server" Text="Anmelden" OnClick="btnLogin_Click" /> <br />
    <asp:Label ID="txtInfo" runat="server" Text=""></asp:Label>

</asp:Content>
