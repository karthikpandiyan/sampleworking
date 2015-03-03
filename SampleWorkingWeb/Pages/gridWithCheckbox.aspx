<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gridWithCheckbox.aspx.cs" Inherits="SampleWorkingWeb.Pages.gridWithCheckbox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" AllowPaging="True" onpageindexchanging="grdEmployees_PageIndexChanging" PageSize="3" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="false">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="EmpId" HeaderText="Employee Id" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="First Name" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lblFirst" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
            </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Last Name" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lblLast" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
            </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
        </asp:TemplateField>
    </Columns>

<HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
        <PagerSettings Mode="NextPrevious" />
</asp:GridView>
<br />
<asp:Button ID="btnGetSelected" runat="server" Text="Get selected records" OnClick="GetSelectedRecords" />
<hr />
<u>Selected Rows</u>
<br />
<asp:GridView ID="gvSelected" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    AutoGenerateColumns="true">
   <%-- <Columns>
        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
        <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150" />
    </Columns>--%>
</asp:GridView>
    </div>
    </form>
</body>
</html>
