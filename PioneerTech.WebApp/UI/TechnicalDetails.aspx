<%@ Page Title="Technical Details - Pioneer Technologies Inc." Language="C#" MasterPageFile="~/UI/PioneerTechMasterPage.Master" AutoEventWireup="true" CodeBehind="TechnicalDetails.aspx.cs" Inherits="PioneerTech.WebApp.UI.TechnicalDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <h1>Employee Technical Details</h1>
    <p>You can save a new employee techninal information or update existing employee details here.</p>
    <p>If you want to add a completely new employee inforation, please enter data in <asp:HyperLink ID="EmployeeDetailsHyperLink" NavigateUrl="~/UI/EmployeeDetails.aspx" runat="server">Employee Details</asp:HyperLink> page to continue.</p>
        <table id ="SelectEmployeeIDTable">        
        <tr>
            <td>
                Select EmployeeID to add/update the Techninal details of the particular employee:
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
    <table id ="TechninalFormTable">
        <tr id="ProgrammingLanguagesRow">
            <td id="ProgrammingLanguagesLabelColumn">
                <asp:Label ID="ProgrammingLanguagesLabel" runat="server" Text="Programming Languages"></asp:Label>
            </td>
            <td id="ProgrammingLanguagesTextBoxColumn">
                <asp:textbox runat="server" ID="ProgrammingLanguagesTextBox"></asp:textbox>
            </td>
        </tr>
        <tr id="DatabasesKnownRow">
            <td id="DatabasesKnownLabelColumn">
                <asp:Label ID="DatabasesKnownLabel" runat="server" Text="Databases Known"></asp:Label>
            </td>
            <td id="DatabasesKnownTextBoxColumn">
                <asp:textbox runat="server" ID="DatabasesKnownTextBox"></asp:textbox>
            </td>
        </tr>
        <tr id="ORMTechnologiesRow">
            <td id="ORMTechnologiesLabelColumn">
                <asp:Label ID="ORMTechnologiesLabel" runat="server" Text="ORM Technologies"></asp:Label>
            </td>
            <td id="ORMTechnologiesTextBoxColumn">
                <asp:textbox runat="server" ID="ORMTechnologiesTextBox"></asp:textbox>
            </td>
            
        </tr>
        <tr id="UITechnologiesRow">
            <td id="UITechnologiesLabelColumn">
                <asp:Label ID="UITechnologiesLabel" runat="server" Text="UI Technologies"></asp:Label>
            </td>
            <td id="UITechnologiesTextBoxColumn">
                <asp:textbox runat="server" ID="UITechnologiesTextBox"></asp:textbox>
            </td>
        </tr>
        
        <tr id="SaveTechninalDetailsRow">
            <td id ="TechninalDetailsResetButtonColumn">
                <asp:Button ID="TechninalDetailsResetButton" runat="server" Text="Reset" BackColor="#00CCFF" ForeColor="Black" OnClick="TechninalDetailsResetButton_Click" />
            </td>
            <td id="TechninalDetailsEditButtonColumn">
                <asp:Button ID="TechninalDetailsEditButton" runat="server" Text="Edit" BackColor="#00CCFF" OnClick="TechninalDetailsEditButton_Click" />
            </td>
            <td id="TechninalDetailsSaveButtonColumn">
                <asp:Button ID="TechninalDetailsSaveButton" runat="server" Text="Save" BackColor="#00CCFF" OnClick="TechninalDetailsSaveButton_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
