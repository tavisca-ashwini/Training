<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CustomControl.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 181px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="446px" Style="margin-left: 109px" Width="766px">
        <h3 align="center" style="width: 771px; height: 33px">Change Password</h3>

        <table style="width: 100%; height: 377px;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="EmailLabel" runat="server" Text="Enter Email Id" Font-Size="Medium"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxEmail" runat="server" Height="31px" Width="230px" ValidationGroup="ChangePassword"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                        ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBoxEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">
                    <asp:Label ID="LabelOldPassword" runat="server" Text="Enter Old Password" Font-Size="Medium"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxOldPassword" runat="server" Height="31px" Width="230px" ValidationGroup="ChangePassword"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOldPassword" runat="server"
                        ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBoxOldPassword"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">
                    <asp:Label ID="LabelNewPassword" runat="server" Text="  Enter New Password" Font-Size="Medium"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxNewPassword" runat="server" Height="31px" Width="230px" ValidationGroup="ChangePassword"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPassword" runat="server" ErrorMessage="*"
                        ForeColor="Red" ControlToValidate="TextBoxNewPassword"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">
                    <asp:Label ID="LabelConfirmPassword" runat="server" Text="  Enter Confirm Password" Font-Size="Medium"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxConfirmPassword" runat="server" Height="31px" Width="230px" ValidationGroup="ChangePassword"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirm" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBoxConfirmPassword"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">
                    <asp:Button ID="SubmitPasswordButton" runat="server" Font-Size="Medium" Text="Submit" Width="134px"
                        Font-Bold="true" Height="41px" OnClick="SubmitPasswordButton_Click" ValidationGroup="ChangePassword" />
                </td>

                <td class="auto-style4">
                    <asp:Button ID="ResetPasswordButton" runat="server" Font-Size="Medium" Text="Reset" Width="140px"
                        Font-Bold="true" Height="41px" OnClick="ResetPasswordButton_Click" ValidationGroup="ChangePassword" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
