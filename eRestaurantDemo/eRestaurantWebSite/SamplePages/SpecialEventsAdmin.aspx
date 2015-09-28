<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventsAdmin.aspx.cs" Inherits="SamplePages_SpecialEventsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Special events administration</h1>
    <table align="center" style="width: 80%">
        <tr>
            <td align ="right" style ="width:50%" >Select an Event &nbsp;</td>
            <td>
                <asp:DropDownList ID="SpecialEventList" runat="server" Width="200px" DataSourceID="ODSSpecialEvents" DataTextField="Description"
                     DataValueField="EventCode" AppendDataBoundItems="True">

                    <asp:ListItem Value="z"> Select event</asp:ListItem>

                </asp:DropDownList>&nbsp;&nbsp;
                <asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
        </tr>

        <tr>
            <td colspan="2" style="height: 22px"></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="ReservationListGV" runat="server"
                     AllowPaging="True"
                     DataSourceID="ODSReservations" AutoGenerateColumns="False" 
                     OnSelectedIndexChanged="ReservationListGV_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="CustomerName" HeaderText="Name" SortExpression="CustomerName" />
                        <asp:BoundField DataField="ReservationDate" HeaderText="Date" SortExpression="ReservationDate" />
                        <asp:BoundField DataField="NumberInParty" HeaderText="NumberInParty" SortExpression="NumberInParty" />
                        <asp:BoundField DataField="ContactPhone" HeaderText="ContactPhone" SortExpression="ContactPhone" />
                        <asp:BoundField DataField="ReservationStatus" HeaderText="ReservationStatus" SortExpression="ReservationStatus" />
                        <asp:BoundField DataField="EventCode" HeaderText="EventCode" SortExpression="EventCode" />
                    </Columns>
                    <EmptyDataTemplate>
                        No data to display at this time.
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align ="center">
                <asp:DetailsView ID="ReservationGridView" runat="server" Height="50px" Width="125px" AllowPaging="True" DataSourceID="ODSReservations">
                    <EmptyDataTemplate>
                        no data to display at this time
                    </EmptyDataTemplate>
                </asp:DetailsView>
            </td>
            
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <asp:ObjectDataSource ID="ODSSpecialEvents" runat="server"
         OldValuesParameterFormatString="original_{0}" 
         SelectMethod="SpecialEvent_List"
         TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSReservations" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetReservationByEventCode"
        TypeName="eRestaurantSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SpecialEventList" 
                Name="eventcode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>

