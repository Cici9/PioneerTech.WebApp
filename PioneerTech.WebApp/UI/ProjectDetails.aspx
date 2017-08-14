<%@ Page Title="Project Details - Pioneer Technologies Inc." Language="C#" MasterPageFile="~/UI/PioneerTechMasterPage.Master" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="PioneerTech.WebApp.UI.ProjectDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <h1>Employee Project Details</h1>
    <p>You can save a new employee project information or update existing employee details here.</p>
    <p>If you want to add a completely new employee inforation, please enter data in <asp:HyperLink ID="EmployeeDetailsHyperLink" NavigateUrl="~/UI/EmployeeDetails.aspx" runat="server">Employee Details</asp:HyperLink> page to continue.</p>
        <table id ="SelectEmployeeIDTable">        
        <tr>
            <td>
                Select EmployeeID to add/update the Project details of the particular employee:
            </td>
            <td>
                <asp:DropDownList ID="EmployeeIDDropDownList" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="EmployeeIDDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:HiddenField ID="EmployeeIDHiddenField" Value="0" runat="server" />
            </td>
        </tr>
        </table>
    <br /><br />
    <table id ="ProjectFormTable">
        <tr id="ProjectNameRow">
            <td id="ProjectNameLabelColumn">
                <asp:Label ID="ProjectNameLabel" runat="server" Text="Project Name"></asp:Label>
            </td>
            <td id="ProjectNameTextBoxColumn">
                <asp:textbox runat="server" ID="ProjectNameTextBox"></asp:textbox>
            </td>
        </tr>
        <tr id="ClientNameRow">
            <td id="ClientNameLabelColumn">
                <asp:Label ID="ClientNameLabel" runat="server" Text="Client Name"></asp:Label>
            </td>
            <td id="ClientNameTextBoxColumn">
                <asp:textbox runat="server" ID="ClientNameTextBox"></asp:textbox>
            </td>
        </tr>
        <tr id="ProjectLocationRow">
            <td id="ProjectLocationLabelColumn">
                <asp:Label ID="ProjectLocationLabel" runat="server" Text="Project Location"></asp:Label>
            </td>
            <td id="ProjectLocationTextBoxColumn">
                <asp:textbox runat="server" ID="ProjectLocationTextBox"></asp:textbox>
            </td>
            
        </tr>
        <tr id="ProjectRolesRow">
            <td id="ProjectRolesLabelColumn">
                <asp:Label ID="ProjectRolesLabel" runat="server" Text="Project Roles"></asp:Label>
            </td>
            <td id="ProjectRolesTextBoxColumn">
                <asp:textbox runat="server" ID="ProjectRolesTextBox"></asp:textbox>
            </td>
        </tr>
        
        <tr id="SaveProjectDetailsRow">
            <td id ="ProjectDetailsResetButtonColumn">
                <asp:Button ID="ProjectDetailsResetButton" runat="server" Text="Reset" BackColor="#00CCFF" ForeColor="Black" OnClick="ProjectDetailsResetButton_Click" />
            </td>
            <td id="CompanyDetailsEditButtonColumn">
                <asp:Button ID="ProjectDetailsEditButton" runat="server" Text="Edit" BackColor="#00CCFF" OnClick="ProjectDetailsEditButton_Click1" />
            </td>
            <td id="CompanyDetailsSaveButtonColumn">
                <asp:Button ID="ProjectDetailsSaveButton" runat="server" Text="Save" BackColor="#00CCFF" OnClick="ProjectDetailsSaveButton_Click1" />
            </td>
        </tr>
    </table>
</asp:Content>
