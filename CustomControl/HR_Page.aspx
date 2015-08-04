<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HR_Page.aspx.cs" Inherits="CustomControl.WebForm1" %>

<%@ Register Src="~/HR_AddEmployee.ascx" TagPrefix="uc3" TagName="HR_AddEmployee" %>
<%@ Register Src="~/HR_AddRemark.ascx" TagPrefix="uc2" TagName="HR_AddRemark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="container">
        <ul class="nav nav-tabs">

            <li class="active"><a data-toggle="tab" href="#Div1">Add Employee</a></li>
            <li><a data-toggle="tab" href="#Div2">Add Remark</a></li>
            <li><a data-toggle="tab" href="#Div3">Change Password</a></li>
            <li class="pull-right"><a data-toggle="tab" href="#Div4">Log out</a></li>

        </ul>

        <div class="tab-content">

            <div id="Div1" class="tab-pane fade in active">
                <uc3:HR_AddEmployee runat="server" id="HR_AddEmployee" Visible="true" />
            </div>
            <div id="Div2" class="tab-pane fade in">
                <uc2:HR_AddRemark runat="server" ID="HR_AddRemark" />
            </div>

            <div id="Div3" class="tab-pane fade in">
                <a href="ChangePassword.aspx">Click here to change your Password !!!</a>
            </div>

             <div id="Div4" class="tab-pane fade in">
                 <a href="LogOut.aspx">Click here to log out !!!</a>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>


