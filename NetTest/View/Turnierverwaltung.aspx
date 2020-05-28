<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/Site.Master" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="NetTest.View.Turnierverwaltung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Turnierverwaltung</h1> <br />
    <asp:ListBox ID="Turniere" runat="server">
        <asp:ListItem Text="Turnier1"></asp:ListItem>
    </asp:ListBox>

</asp:Content>
