<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="NetTest.View.Turnierverwaltung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Turnierverwaltung</h1>
    <asp:Label ID="lblInfo" runat="server"></asp:Label> 
    <h3>Turniere:</h3> 
    <asp:Button ID="Erstellen" runat="server" Text="Erstellen" />
    <asp:Button ID="Löschen" runat="server" Text="Löschen" /> <br /> <br />
    <asp:ListBox ID="TurnierList" runat="server" autopostback="true" Width="300px" OnSelectedIndexChanged="TurnierList_SelectedIndexChanged"></asp:ListBox> <br />
    <br /> <h3>Teilnehmende Mannschaften:</h3>
    <asp:Table ID="TableAddMS" runat="server" Visible="false"></asp:Table> <br />
    <asp:Table ID="MS_Table" runat="server" BorderWidth="2" GridLines="Both" BorderStyle="Solid" Width="280px">
    </asp:Table> <br />
    <h3>Spiele:</h3>
    Mannschaft 1: <asp:DropDownList ID="ListMS1" runat="server"></asp:DropDownList>
    Mannschaft 2: <asp:DropDownList ID="ListMS2" runat="server"></asp:DropDownList> <br />
    MS1 Tore <asp:TextBox ID="txtMS1Tore" runat="server" TextMode="Number" Width="50px"></asp:TextBox>
    MS2 Tore<asp:TextBox ID="txtMS2Tore" runat="server"  TextMode="Number" Width="50px"></asp:TextBox> <br />
    <asp:Button ID="btn_SpielAdd" runat="server" Text="Erstellen" OnClick="btn_SpielAdd_Click" /> <br /> <br />
    <asp:Table ID="Spiele_Table" runat="server" BorderWidth="2" GridLines="Both" BorderStyle="Solid" Width="550px"></asp:Table>
    <br />
    <h3>Turniertabelle:</h3>
    <asp:Table ID="TurnierTabelle" runat="server" BorderWidth="2" GridLines="Both" BorderStyle="Solid"></asp:Table>
</asp:Content>
