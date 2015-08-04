<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HR_AddRemark.ascx.cs" Inherits="CustomControl.HR_AddRemark" %>


<asp:Panel ID="Panel1" runat="server" Height="386px" Width="402px">
    <h3 align="center">Add Remark to Employee </h3>
    <asp:Label ID="EmployeeListLabel" runat="server" Text="Select Employee From List"></asp:Label>
    <br />
    <br />
    <asp:DropDownList ID="EmployeeDropDownList" runat="server" Height="50px" Width="164px" ValidationGroup="HRAddRemark" OnSelectedIndexChanged="EmployeeDropDownList_SelectedIndexChanged">
        <asp:ListItem>Add Employee</asp:ListItem>
    </asp:DropDownList>
    <br/>
    <br />
    <asp:Label ID="AddRemarkLabel" runat="server" Text="Add Remark"></asp:Label>
    <br />
    &nbsp;<br />
    <textarea id="TextAreaRemark" name="S1" style="height: 150px; width: 388px" runat="server"></textarea>
    <br />
    <br />
    <asp:Button ID="AddRemarkButton" runat="server" Font-Bold="true" Font-Size="Medium" Height="41px" OnClick="AddRemarkButton_Click" Text="Add Remark" Width="144px" ValidationGroup="HRAddRemark" />
    <br />
    <br />

</asp:Panel>