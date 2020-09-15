<%@ Page Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="PersonenSQL.aspx.cs" Inherits="NetTest.View.PersonenSQL" %>

<asp:Content id="Content1" contentplaceholderid="MainContent" runat="server">
<asp:Label ID="lbl1" Text="Personenverwaltung" runat="server"></asp:Label> <br />
<asp:Button ID="BtnNew" Text="Neue Person" runat="server" OnClick="BtnNew_Click" /> <br />
<asp:Table ID="TNEW" runat="server" Visible="false" BorderWidth="2" GridLines="Both" BorderStyle="Solid" AutoPostBack="true"></asp:Table> <br />
<asp:Table ID="TSpieler" runat="server" AutoPostBack="true" BorderWidth="2" GridLines="Both" BorderStyle="Solid"></asp:Table>
<asp:Table ID="TMitarbeiter" runat="server" AutoPostBack="true"></asp:Table>
</asp:Content>