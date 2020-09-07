<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="NetTest.View.Turnierverwaltung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Turnierverwaltung</h1> <br />
    <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <asp:Button ID="Erstellen" runat="server" Text="Erstellen" />
    <asp:Button ID="Löschen" runat="server" Text="Löschen" /> <br />
    <asp:ListBox ID="TurnierList" runat="server" Width="300px"></asp:ListBox> <br />
    <asp:Table ID="MS_Table" runat="server" Height="115px" Width="296px">
    </asp:Table> <br />
    <asp:Table ID="Spiele_Table" runat="server"></asp:Table>
</asp:Content>
