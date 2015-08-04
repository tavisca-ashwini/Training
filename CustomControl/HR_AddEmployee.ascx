<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HR_AddEmployee.ascx.cs" Inherits="CustomControl.HR_HomePage" %>
<style type="text/css">
    .auto-style3 {
        width: 418px;
    }

    .auto-style4 {
        width: 212px;
    }
    .auto-style5 {
        height: 19px;
        width: 229px;
    }
    .auto-style6 {
        width: 229px;
    }
</style>
<asp:Panel ID="Panel1" runat="server" Height="467px" Style="margin-left: 109px" Width="779px">

    <h3 align="center" style="width: 771px; height: 33px">Add Employee </h3>

    <table style="width: 100%; height: 411px;">
        <tr>
            <td class="auto-style6">
                <asp:Label ID="TitleLabel" runat="server" Text="Title" Font-Size="Medium"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxTitle" runat="server" Height="31px" Width="230px" ValidationGroup="HRAddEmployee"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmptyTitleFieldValidator" runat="server" ErrorMessage="*"
                    ControlToValidate="TextBoxTitle" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="auto-style6">
                <asp:Label ID="FirstNameLabel" runat="server" Text="FirstName" Font-Size="Medium"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxFirstName" runat="server" Height="33px" Width="228px" ValidationGroup="HRAddEmployee"></asp:TextBox>

                <asp:RequiredFieldValidator ID="FirstNameEmptyFieldValidator" runat="server" ErrorMessage="*"
                    ControlToValidate="TextBoxFirstName" Font-Size="Medium" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="auto-style6">
                <asp:Label ID="LastNameLabel" runat="server" Text="LastName" Font-Size="Medium"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxLastName" runat="server" Height="33px" Width="228px" ValidationGroup="HRAddEmployee"></asp:TextBox>

                <asp:RequiredFieldValidator ID="LastNameEmptyFieldValidator" runat="server" ErrorMessage="*"
                    ControlToValidate="TextBoxLastName" Font-Size="Medium" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="auto-style6">
                <asp:Label ID="EmailIdLabel" runat="server" Text="Email ID" Font-Size="Medium"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxEmailID" runat="server" Height="33px" Width="228px" ValidationGroup="HRAddEmployee"></asp:TextBox>

                <asp:RequiredFieldValidator ID="EmailIDEmptyFieldValidator" runat="server" ErrorMessage="*"
                    ControlToValidate="TextBoxEmailID" Font-Size="Medium" ForeColor="Red">
                </asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="EmailIDPatternUserIdValidator" runat="server" ErrorMessage="Invalid Email"
                    Font-Size="Medium" Font-Bold="true" ForeColor="Red" ControlToValidate="TextBoxEmailID"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> 
                </asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td class="auto-style6">
                <asp:Label ID="ContactLabel" runat="server" Text="Contact" Font-Size="Medium"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxContact" runat="server" Height="33px" Width="228px" ValidationGroup="HRAddEmployee"></asp:TextBox>

                <asp:RequiredFieldValidator ID="ContactEmptyFieldValidator" runat="server" ErrorMessage="*"
                    ControlToValidate="TextBoxContact" Font-Size="Medium" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="auto-style6">
                <asp:Label ID="PasswordLabel" runat="server" Text="Password" Font-Size="Medium"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxPassword" runat="server" Height="33px" Width="228px"
                    TextMode="Password" ValidationGroup="HRAddEmployee"></asp:TextBox>

                <asp:RequiredFieldValidator ID="EmptyPasswordFieldValidator" runat="server" ErrorMessage="*"
                    ControlToValidate="TextBoxPassword" Font-Size="Medium" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="auto-style6">
                <asp:Label ID="LabelReenter" runat="server" Text="Re-enter Password" Font-Size="Medium"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxReenterPassword" runat="server" Height="33px" Width="228px"
                    TextMode="Password" ValidationGroup="HRAddEmployee"></asp:TextBox>

                <asp:RequiredFieldValidator ID="ReenterEmptyFieldValidator" runat="server" ErrorMessage="*"
                    ControlToValidate="TextBoxReenterPassword" Font-Size="Medium" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Button ID="SubmitButton" runat="server" Font-Size="Medium" Text="Submit" Width="140px" 
                    Font-Bold="true" Height="41px" OnClick="SubmitButton_Click" ValidationGroup="HRAddEmployee" />
            </td>

            <td class="auto-style4">
                <asp:Button ID="ResetButton" runat="server" Font-Size="Medium" Text="Reset" Width="140px" 
                    Font-Bold="true" Height="41px" OnClick="ResetButton_Click" ValidationGroup="HRAddEmployee" />
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="LabelMessage" runat="server" Text="Fields Marked with * Can Not Be Empty" 
                    ForeColor="Red" Font-Size="Small" Font-Italic="False" Font-Bold="True"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Panel>

