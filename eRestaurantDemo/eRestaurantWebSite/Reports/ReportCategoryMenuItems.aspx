﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReportCategoryMenuItems.aspx.cs" Inherits="Reports_ReportCategoryMenuItems" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ObjectDataSource ID="ODSReport" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReportCategoryMenuItems" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>


    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Reports\CategoryMenuItems.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ODSReport" Name="CategoryMenuItemDS" />
            </DataSources>
        </LocalReport>
</rsweb:ReportViewer>
</asp:Content>

