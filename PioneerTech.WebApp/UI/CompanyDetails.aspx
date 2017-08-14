<%@ Page Title="Company Details - Pioneer Technologies Inc." Language="C#" MasterPageFile="~/UI/PioneerTechMasterPage.Master" AutoEventWireup="true" CodeBehind="CompanyDetails.aspx.cs" Inherits="PioneerTech.WebApp.UI.CompanyDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <h1>Employee Company Details</h1>
    <p>You can save a new employee company information or update existing employee details here.</p>
    <p>If you want to add a completely new employee inforation, please enter data in <asp:HyperLink ID="EmployeeDetailsHyperLink" NavigateUrl="~/UI/EmployeeDetails.aspx" runat="server">Employee Details</asp:HyperLink> page to continue.</p>
        <table id ="SelectEmployeeIDTable">        
        <tr>
            <td>
                Select EmployeeID to add/update the Company details of the particular employee:
            </td>
            <td>
                <asp:DropDownList ID="EmployeeIDDropDownList" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="EmployeeIDDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:HiddenField ID="EmployeeIDHiddenField" Value="0" runat="server" />
            </td>
        </tr>
            <tr>
                <td>
                    <asp:Label ID="SelectedEmployeeLabel" runat="server" Text="Selected Employee: " Visible="False"></asp:Label>
                    <asp:Label ID="SelectedEmployeeName" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#FF9900" Visible="False"></asp:Label>
                </td>
                <td>
                    
                </td>
            </tr>
        </table>
    <br /><br />
    <table id ="EmployeeFormTable">
        <tr id="CompanyNameRow">
            <td id="CompanyNameLabelColumn">
                <asp:Label ID="CompanyNameLabel" runat="server" Text="Company Name"></asp:Label>
            </td>
            <td id="CompanyNameTextBoxColumn">
                <asp:textbox runat="server" ID="CompanyNameTextBox"></asp:textbox>
            </td>
            <td>
</td>
        </tr>
        <tr id="CompanyContactNumberRow">
            <td id="CompanyContactNumberLabelColumn">
                <asp:Label ID="CompanyContactNumberLabel" runat="server" Text="Company Contact Number"></asp:Label>
            </td>
            <td id="CompanyContactNumberTextBoxColumn">
                <asp:textbox runat="server" ID="CompanyContactNumberTextBox"></asp:textbox>
            </td>
        </tr>
        <tr id="CompanyLocationRow">
            <td id="CompanyLocationLabelColumn">
                <asp:Label ID="CompanyLocationLabel" runat="server" Text="Company Location"></asp:Label>
            </td>
            <td id="CompanyLocationTextBoxColumn">
                <asp:textbox runat="server" ID="CompanyLocationTextBox"></asp:textbox>
            </td>
            
        </tr>
        <tr id="CompanyWebsiteRow">
            <td id="CompanyWebsiteLabelColumn">
                <asp:Label ID="MobileNumberLabel" runat="server" Text="Company Website"></asp:Label>
            </td>
            <td id="CompanyWebsiteTextBoxColumn">
                <asp:textbox runat="server" ID="CompanyWebsiteTextBox"></asp:textbox>
            </td>
        </tr>
        
        <tr id="SaveCompanyDetailsRow">
            <td id ="CompanyDetailsResetButtonColumn">
                <asp:Button ID="CompanyDetailsResetButton" runat="server" Text="Reset" BackColor="#00CCFF" ForeColor="Black" OnClick="CompanyDetailsResetButton_Click" />
            </td>
            <td id="CompanyDetailsEditButtonColumn">
                <asp:Button ID="CompanyDetailsEditButton" runat="server" Text="Edit" BackColor="#00CCFF" OnClick="CompanyDetailsEditButton_Click" />
            </td>
            <td id="CompanyDetailsSaveButtonColumn">
                <asp:Button ID="CompanyDetailsSaveButton" runat="server" Text="Save" BackColor="#00CCFF" OnClick="CompanyDetailsSaveButton_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
