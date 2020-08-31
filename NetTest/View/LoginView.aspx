<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/Site.Master" CodeBehind="LoginView.aspx.cs" Inherits="NetTest.View.LoginView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Login</h1> <br />
    <h2>Bitte melden sie sich an!</h2> <br /> <br />
    Benutzername: <asp:TextBox ID="txtUser" runat="server"></asp:TextBox> <br />
    Passwort:     <asp:TextBox ID="txtPasswort" runat="server"></asp:TextBox> <br />

    <asp:Button ID="btnLogin" runat="server" Text="Anmelden" OnClick="btnLogin_Click" />
    <asp:Label ID="txtInfo" runat="server" Text=""></asp:Label>

</asp:Content>
