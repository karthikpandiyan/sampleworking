<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleWorkingWeb.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
            <td>
Search for LDAP Groups
            </td>
            <td>
                <asp:TextBox ID="txtSearchbox" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="75px" /></td>
                </tr>
        </table>
    <div>
    

    <asp:GridView ID="grdEmployees" runat="server" AllowPaging="True" onpageindexchanging="grdEmployees_PageIndexChanging" PageSize="3" AutoGenerateColumns="true">

        <PagerSettings Mode="NextPrevious" />
    </asp:GridView>
    </form>

    </div>
</body>
</html>