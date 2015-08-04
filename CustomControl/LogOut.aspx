<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="CustomControl.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="160px" Width="414px">
        <br />
        <br />
        <br />
        <asp:Label ID="LabelLogOut" runat="server" Text="Log in again to access your account" margin-left="20px"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonLogOut" runat="server" Text="Log out" Width="132px" margin-left="196px" OnClick="ButtonLogOut_Click" />
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
