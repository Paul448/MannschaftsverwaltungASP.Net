 <%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Mannschaftsverwaltung.aspx.cs" Inherits="NetTest.View.Mannschaftsverwaltung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Mannschaftsverwaltung - Teams</h1> 
    <asp:Label ID="infoLabel" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="15"></asp:Label>
    <br /> 
  <h3> Mannschaften: </h3>
   <asp:ListBox ID="listMannschaften" runat="server" Width="200px" Height="75px" OnSelectedIndexChanged="listMannschaften_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
   <br /> <br />
   <div class="div1">
   <div class="Fleft">
   <h3> Personen (Mannschaft) </h3>
   <asp:ListBox ID="ListPersonen" runat="server" Height="200px" Width="300px" AutoPostBack="true"></asp:ListBox>
   </div>
   <div class="Fright">
   <h3>Personen (Verfügbar) </h3>
   <asp:ListBox ID="ListVerfügbar" runat="server" Height="200px" Width="300px" AutoPostBack="true"></asp:ListBox>
   </div> </div>
   <div class="div2">
   <div class="Fleft">
   <asp:Button ID="btn_del" runat="server" Text="Entfernen" Height="35px" Width="150" OnClick="btn_del_Click"/> 
   </div>
   <div class="Fright">
   <asp:Button ID="btn_add" runat="server" Text="Hinzufügen" Height="35px" Width="150" OnClick="btn_add_Click"/>
   </div> 
   </div> <br /> <br />
   <h1>Mannschaftsverwaltung - Hinzufügen</h1> <br />
    <asp:TextBox ID="txtName" runat="server" Height="25px" Width="200px"></asp:TextBox> <br /> <br />
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>Fussball</asp:ListItem>
        <asp:ListItem>Tennis</asp:ListItem>
        <asp:ListItem>Handball</asp:ListItem>
    </asp:DropDownList> <br /> <br />
    <asp:Button ID="BtnAdd" runat="server" Text="Hinzufügen" OnClick="Button1_Click" />
</asp:Content>
