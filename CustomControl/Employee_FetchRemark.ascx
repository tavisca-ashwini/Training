<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Employee_FetchRemark.ascx.cs" Inherits="CustomControl.Employee_FetchRemark" %>

<asp:Panel ID="Panel1" runat="server" Height="572px" Width="593px" BorderStyle="None">
    <h2 align="center">Display Remarks</h2>

    <asp:Label ID="EnterEmployeeIDLabel" runat="server" Text="Enter Employee ID"></asp:Label>
    <br />
    <input id="TextEmployeeId" type="number" style="width: 267px; height: 32px" />
    <br />
    <br />
    <input id="ButtonDisplayRemark" type="button" value="Display Remarks" style="height: 35px; width: 155px" />
    <br />
    <br />

    <asp:GridView ID="GridViewRemark" runat="server" AllowCustomPaging="True" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
        ForeColor="Black" Height="16px" HorizontalAlign="Left" OnPageIndexChanging="GridViewRemark_PageIndexChanging"
        PageSize="5" Width="220px">
        <Columns>
            <asp:BoundField DataField="Text" HeaderText="Remark" SortExpression="Text" />
            <asp:BoundField DataField="TimeStamp" HeaderText="TimeStamp" SortExpression="TimeStamp" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br /> <br /> <br />
    <br /> <br /> <br />
    <br /> <br /> <br />
    <br /> <br />
    <asp:Repeater ID="RepeaterPage" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButtonPage" runat="server" Text='<%#Eval("Text") %>' 
                CommandArgument='<%#Eval("Value") %>' Enabled='<%#Eval("Enabled") %>' OnClick="LinkButtonPage_Click">
            </asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
</asp:Panel>


