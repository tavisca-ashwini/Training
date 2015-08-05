<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee_Page.aspx.cs" Inherits="CustomControl.Employee_Page" %>

<%@ Register Src="~/Employee_FetchRemark.ascx" TagPrefix="uc2" TagName="Employee_FetchRemark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="container">
        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#Div1">Display Password</a></li>
            <li><a data-toggle="tab" href="#Div2">Change Password</a></li>
            <li class="pull-right"><a data-toggle="tab" href="#Div3">Log out</a></li>
        </ul>

        <div class="tab-content">

            <div id="Div1" class="tab-pane fade in active">
                <uc2:Employee_FetchRemark runat="server" ID="Employee_FetchRemark" />
            </div>
            <div id="Div2" class="tab-pane fade in">
                <a href="ChangePassword.aspx">ChangePassword</a>
            </div>
            <div id="Div3" class="tab-pane fade in">
                 <a href="LogOut.aspx">Click here to log out !!!</a>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
