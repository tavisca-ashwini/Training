<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="CustomControl.LoginControl" %>

<style type="text/css">
    .auto-style3 {
        width: 137px;
        height: 60px;
    }

    .auto-style10 {
        width: 108px;
        height: 60px;
    }

    .auto-style14 {
        width: 108px;
    }
</style>

<asp:Panel ID="Panel1" runat="server" Height="273px" Width="525px" style="margin-left: 92px" BackColor="Wheat">
    <section id="loginForm" style="width: 100%; margin-right: 0px; height: 270px;">
        <h2 align="center">Logic</h2>
        <table style="width: 100%; height: 218px; margin-right: 10px">
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="UserIdLabel" runat="server" Text="Username" Font-Size="Medium"></asp:Label>
                </td>

                <td class="auto-style3">

                    <asp:TextBox ID="UserIdText" runat="server" Height="38px" Width="236px" Font-Size="Medium" ValidationGroup="LoginText"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="EmptyUserIdTextValidator" runat="server" ErrorMessage="*"
                        Font-Size="Medium" Font-Bold="true" ForeColor="Red" ControlToValidate="UserIdText">
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="UsernamePatternUserIdValidator" runat="server" ErrorMessage="Invalid Username"
                        Font-Size="Medium" Font-Bold="true" ForeColor="Red" ControlToValidate="UserIdText"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td class="auto-style14">
                    <asp:Label ID="PasswordLable" runat="server" Text="Password" Font-Size="Medium"></asp:Label>
                </td>

                <td class="auto-style2">
                    <asp:TextBox ID="PasswordText" runat="server" Height="42px" Width="237px" Font-Size="Medium"
                        TextMode="Password" ValidationGroup="LoginText"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="EmptyPasswordValidator" runat="server" ErrorMessage="*"
                        Font-Size="Medium" Font-Bold="true" ForeColor="Red" ControlToValidate="PasswordText">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="auto-style14">
                    <asp:Button ID="LoginButton" runat="server" Font-Size="Medium" Text="Log in" 
                        Width="137px" Font-Bold="true" Height="41px" OnClick="LoginButton_Click" ValidationGroup="LoginText" />
                </td>

            </tr>
           <%-- <tr>
                <td class="auto-style14">
                    <asp:CheckBox ID="PasswordCheckbox" runat="server" Font-Size="small" Text="Remember Me?" OnCheckedChanged="PasswordCheckbox_CheckedChanged" ValidationGroup="LoginText" />
                </td>
            </tr>--%>
        </table>
    </section>
</asp:Panel>


