<%@ Page Title="Education Details - Pioneer Technologies Inc." Language="C#" MasterPageFile="~/UI/PioneerTechMasterPage.Master" AutoEventWireup="true" CodeBehind="EducationDetails.aspx.cs" Inherits="PioneerTech.WebApp.UI.EducationDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <h1>Employee Education Details</h1>
    <p>You can save a new employee education information or update existing employee details here.</p>
    <p>If you want to add a completely new employee inforation, please enter data in <asp:HyperLink ID="EmployeeDetailsHyperLink" NavigateUrl="~/UI/EmployeeDetails.aspx" runat="server">Employee Details</asp:HyperLink> page to continue.</p>
        <table id ="SelectEmployeeIDTable">        
        <tr>
            <td>
                Select EmployeeID to add/update the Education details of the particular employee:
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
    <table id ="EducationFormTable">
        <tr id="CourseTypeRow">
            <td id="CourseTypeLabelColumn">
                <asp:Label ID="CourseTypeLabel" runat="server" Text="Course Type"></asp:Label>
            </td>
            <td id="CourseTypeTextBoxColumn">
                <asp:textbox runat="server" ID="CourseTypeTextBox"></asp:textbox>
            </td>
        </tr>
        <tr id="CourseSpecializaionRow">
            <td id="CourseSpecializaionLabelColumn">
                <asp:Label ID="CourseSpecializaionLabel" runat="server" Text="Course Specializaion"></asp:Label>
            </td>
            <td id="CourseSpecializaionTextBoxColumn">
                <asp:textbox runat="server" ID="CourseSpecializaionTextBox"></asp:textbox>
            </td>
        </tr>
        <tr id="CourseYearOfPassingRow">
            <td id="CourseYearOfPassingLabelColumn">
                <asp:Label ID="CourseYearOfPassingLabel" runat="server" Text="Year Of Passing"></asp:Label>
            </td>
            <td id="CourseYearOfPassingTextBoxColumn">
                <asp:textbox runat="server" ID="CourseYearOfPassingTextBox"></asp:textbox>
            </td>            
        </tr>
        <tr id="SaveEducationDetailsRow">
            <td id ="EducationDetailsResetButtonColumn">
                <asp:Button ID="EducationDetailsResetButton" runat="server" Text="Reset" BackColor="#00CCFF" ForeColor="Black" OnClick="EducationDetailsResetButton_Click" />
            </td>
            <td id="CompanyDetailsEditButtonColumn">
                <asp:Button ID="EducationDetailsEditButton" runat="server" Text="Edit" BackColor="#00CCFF" OnClick="EducationDetailsEditButton_Click" />
            </td>
            <td id="CompanyDetailsSaveButtonColumn">
                <asp:Button ID="EducationDetailsSaveButton" runat="server" Text="Save" BackColor="#00CCFF" OnClick="EducationDetailsSaveButton_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
