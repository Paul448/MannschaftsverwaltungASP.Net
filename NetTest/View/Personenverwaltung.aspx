<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="NetTest.View.Personenverwaltung" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="div1">
   <div class="Fleft">
    <h1> Mannschaftsverwaltung - Paul Jansen</h1>
 <h2>Personen Hinzufügen</h2> <br /> <br />
   <asp:Label ID="lblVorname" Text="Vorname:" runat="server" Width="80px"/> 
    <asp:TextBox ID="txtVorname" runat="server" Text="" Height="25px" Width="200px" /> <br /> <br /> 
    <asp:Label ID="lblNachname" Text="Nachname:" runat="server" Width="80px"/> 
    <asp:TextBox ID="txtNachname" runat="server" Text="" Height="25px" Width="200px" /> <br /> <br /> 

    <asp:Label ID="Label1" Text="Aufgabe:" runat="server" Width="80px"/>  
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" Width="150px" Height="30px">
            <asp:ListItem>Auswahl</asp:ListItem>
            <asp:ListItem>Fussballspieler</asp:ListItem>
            <asp:ListItem>Tennisspieler</asp:ListItem>
            <asp:ListItem>Trainer</asp:ListItem>
            <asp:ListItem>Physiotherapeut</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
    <asp:Table ID="Table1" runat="server" AutoPostBack="true">
    </asp:Table>
    <br /> 
    <asp:Button ID="btn_add" runat="server" Text="Hinzufügen" Height="35px" Width="150" OnClick="btn_add_Click" BackColor="#555555" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="17px" ForeColor="White" /> <br /> <br />
   </div>
        <div class="Fright" style="padding-top: 30px;">
            <br />
            <br />
            <h2>Sortierung</h2>
            <asp:RadioButtonList ID="CheckVorname" runat="server" Width="125px" Height="40px" >
                <asp:ListItem Selected="True"> Name</asp:ListItem>
                <asp:ListItem> Vorname</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:RadioButtonList ID="CheckAbwärts" runat="server" Width="125px" Height="40px">
                <asp:ListItem Selected="True"> Aufwärts</asp:ListItem>
                <asp:ListItem> Abwärts</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Button ID="btnSort" runat="server" Text="Sortieren" OnClick="btnSort_Click" Width="122px" Height="31px" />
        </div>
        </div>
    <div style="float: left">
    <asp:Label ID="lbl_Info" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"/>
    <br />
    <br />
    <h2> Fussballspieler: </h2>
    <asp:Table ID="TableFussball" runat="server" BorderWidth ="2" BorderColor="Black" CellPadding="100" CellSpacing="100" Width="600px"></asp:Table>
    <h2>Tennisspieler: </h2>
    <asp:Table ID="TableTennis" runat="server" BorderWidth ="2" BorderColor="Black" CellPadding="100" CellSpacing="100" Width="500px"></asp:Table> <br />
    <h2>Handballspieler:</h2> <br />
    <asp:Table ID="TableHandball" runat="server" BorderWidth ="2" BorderColor="Black" CellPadding="100" CellSpacing="100" Width="400px"></asp:Table> <br />
    <h2>Trainer: </h2><br />
    <asp:Table ID="TableTrainer" runat="server" BorderWidth ="2" BorderColor="Black" CellPadding="100" CellSpacing="100" Width="400px"></asp:Table> <br />
    <h2>Physiotherapeut:</h2>
    <asp:Table ID="TablePhysio" runat="server" BorderWidth ="2" BorderColor="Black" CellPadding="100" CellSpacing="100" Width="400px"></asp:Table> <br />
        </div>
    <div style="visibility: hidden;"></div>
</asp:Content>