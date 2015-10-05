<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CategoryMenuItems.aspx.cs" Inherits="SamplePages_CategoryMenuItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="row col-md-12">


        <asp:Repeater ID="MenuCategories" runat="server" DataSourceID="ODSCategoryMenuItems">
            <ItemTemplate>
                <h3>
                <%#Eval ("Description") %></h3>
                <asp:Repeater ID="MenuItems" runat="server">
                    <ItemTemplate>
                        <h5>
                        <%#Eval("Description") %>
                        <%# ((decimal)Eval("Price")).ToString("C") %>
                            <span class="badge" <%#Eval("Calories") %>>Calories </span>
                        <%#Eval ("Comment") %>
                        </h5>
                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:Repeater>


    </div>
    <asp:ObjectDataSource ID="ODSCategoryMenuItems" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="CategoryMenuItems_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
</asp:Content>

