<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventsAdmin.aspx.cs" Inherits="SamplePages_SpecialEventsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Special events administration</h1>
    <table align="center" style="width: 80%">
        <tr>
            <td align ="right" style ="width:50%" >Select an Event &nbsp;</td>
            <td>
                <asp:DropDownList ID="SpecialEventList" runat="server" Width="200px">
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
        </tr>

        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="ReservationList" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <asp:ObjectDataSource ID="ODSSpecialEvents" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSReservations" runat="server"></asp:ObjectDataSource>

</asp:Content>

