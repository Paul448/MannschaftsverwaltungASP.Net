<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Tabelle.aspx.cs" Inherits="NetTest.View.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Liste aller Personen</h1> <br />
    <h3>Personen aus der Datenbank:</h3> 
    <asp:Table ID="TableDB" runat="server" CellPadding="100" CellSpacing="100" Width="900px">
    </asp:Table>
    <br />

</asp:Content>
