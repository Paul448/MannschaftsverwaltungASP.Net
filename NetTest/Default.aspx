<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/view/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NetTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Personen & Mannschaftsverwaltung | Paul Jansen</h1> <br />

    <h3>
    Links zur Weiterleitung: <br />
    <a href="View/Personenverwaltung.aspx">Personenverwaltung</a> <br />
    <a href="View/Mannschaftsverwaltung.aspx">Mannschaftsverwaltung</a> <br />
    <a href="View/Tabelle.aspx">Ansicht aller Personen</a>
    </h3> <br />

    <h4>
    Funktionen: <br /> <br />
    Personenverwaltung <br />
    - Modelklassen + Polymorphie (Fussballer usw...) <br />
    - Hinzufügen von Personen <br />
    - Entfernen von Personen <br />
    - Bearbeiten (Nicht Funktionsfähig!) <br />
    - Sortieren (Nach Name, Vorname und Aufwärts, Abwärts) <br /> <br />

    Mannschaftsverwaltung <br />
    - Hinzufügen von Mannschaften <br />
    - Spieler einer Mannschaft Hinzufügen <br />
    - Spieler einer Mannschaft Entfernen <br />
    - Überprüft ob Spieler gelöscht wurde <br /> <br />
    
    Programm: <br />
    - Verwalter daten werden in Session gespeichert <br />
    - Anbindung zur einer SQL-Datenbank (Momentan Deaktiviert) <br />

    </h4>
</asp:Content>
