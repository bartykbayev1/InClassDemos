<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterAdmin.aspx.cs" Inherits="CommandPages_WaiterAdmin" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Waiter Admin </h1>

    <br />

    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <br />
    Currently looged guys <asp:Label runat="server" Text="CurrentUserName" ></asp:Label>

     <asp:Label ID="Label1" runat="server" Text="SelectWaiterForUpdate"></asp:Label>
                <asp:DropDownList ID="WaiterList" runat="server" DataSourceID="ODSWaiters" DataTextField="FirstName" DataValueField="WaiterID" Width="177px" AppendDataBoundItems="True">
                </asp:DropDownList>
                
                 <asp:LinkButton ID="FetchWaiter" runat="server" OnClick="FetchWaiter_Click">FetchWaiter</asp:LinkButton>
    <table style="width: 70%">
        <tr>
            <td>ID</td>
            <td>
                <asp:Label ID="WaiterID" runat="server" ></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Lname</td>
            <td>
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Phone</td>
            <td>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Address</td>
            <td>
                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Date hired</td>
            <td>
                <asp:TextBox ID="DateHired" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Date released</td>
            <td>
                <asp:TextBox ID="DateReleased" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
               
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="InsertWaiter" runat="server" OnClick="InsertWaiter_Click">Insert</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="UpdateWaiter" runat="server" OnClick="UpdateWaiter_Click">Update</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:ObjectDataSource ID="ODSWaiters" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Waiter_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
   
</asp:Content>

