<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="NetTest.View.Turnierverwaltung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Turnierverwaltung</h1>
    <asp:Label ID="lblInfo" runat="server"></asp:Label> <br />
    <h3>Turniere:</h3> 
    <asp:Button ID="Erstellen" runat="server" Text="Erstellen" />
    <asp:Button ID="Löschen" runat="server" Text="Löschen" /> <br /> <br />
    <asp:ListBox ID="TurnierList" runat="server" autopostback="true" Width="300px" OnSelectedIndexChanged="TurnierList_SelectedIndexChanged"></asp:ListBox> <br />
    <br /> <h3>Teilnehmende Mannschaften:</h3>
    <asp:Table ID="TableAddMS" runat="server" Visible="false"></asp:Table> <br />
    <asp:Table ID="MS_Table" runat="server" BorderWidth="2" GridLines="Both" BorderStyle="Solid" Width="280px">
    </asp:Table> <br />
    <h3>Spiele:</h3>
    <asp:Button ID="btn_SpielAdd" runat="server" Text="Erstellen" /> <br /> <br />
    <asp:Table ID="Spiele_Table" runat="server" BorderWidth="2" GridLines="Both" BorderStyle="Solid" Width="550px"></asp:Table>
</asp:Content>
