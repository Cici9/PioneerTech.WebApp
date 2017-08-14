<%@ Page Title="" Language="C#" MasterPageFile="~/UI/PioneerTechMasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeInformation.aspx.cs" Inherits="EmployeeInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
<h1>View Employee Details</h1>
    <p>You can view a particular Employee's details here.</p>
        <table id ="SelectEmployeeIDTable">        
        <tr>
            <td>
                Select EmployeeID to view the details of the particular employee:
            </td>
            <td>
                <asp:DropDownList ID="EmployeeIDDropDownList" runat="server"></asp:DropDownList>
                <asp:HiddenField ID="EmployeeIDHiddenField" Value="0" runat="server" />
            </td>
        </tr>
        </table>
    <br /><br />
    <asp:GridView ID="PersonalDetailsGridView" runat="server"></asp:GridView>
    <br />
    <asp:GridView ID="CompanyDetailsGridView" runat="server"></asp:GridView>
    <br />
    <asp:GridView ID="ProjectDetailsGridView" runat="server"></asp:GridView>    
    <br />
    <asp:GridView ID="TechnicalDetailsGridView" runat="server"></asp:GridView>
    <br />
    <asp:GridView ID="EducationDetailsGridView" runat="server"></asp:GridView>
</asp:Content>
