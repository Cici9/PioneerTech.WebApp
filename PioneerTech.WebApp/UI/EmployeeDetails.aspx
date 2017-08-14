<%@ Page Title="Employee Details - Pioneer Technologies Inc." Language="C#" MasterPageFile="~/UI/PioneerTechMasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="PioneerTech.WebApp.UI.EmployeeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <h1>Employee Personal Details</h1>
    <p>You can save a new employee information or update existing employee details here.</p>
        <table id ="SelectEmployeeIDTable">
        <tr>
            <td>
                Select Employee ID if you are here to update existing Employee details:
            </td>
            <td>
                <asp:DropDownList ID="EmployeeIDDropDownList" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="EmployeeIDDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:HiddenField ID="EmployeeIDHiddenField" Value="0" runat="server" />
            </td>
        </tr>
        </table>
    <br /><br />
    <table id ="EmployeeFormTable">
        <tr id="FirstNameRow">
            <td id="FirstNameLabelColumn">
                <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label>
            </td>
            <td id="FirstNameTextBoxColumn">
                <asp:textbox runat="server" ID="FirstNameTextBox"></asp:textbox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server" ErrorMessage="First Name is Mandatory!!" ControlToValidate="FirstNameTextBox" ForeColor="#FF3300" Font-Italic="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="LastNameRow">
            <td id="LastNameLabelColumn">
                <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td id="LastNameTextBoxColumn">
                <asp:textbox runat="server" ID="LastNameTextBox"></asp:textbox>
            </td>
            <td>

                <asp:RequiredFieldValidator ID="LastNameValidator" runat="server" ControlToValidate="LastNameTextBox" ErrorMessage="Last Name is Mandatory!!" Font-Italic="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr id="EmailIDRow">
            <td id="EmailIDLabelColumn">
                <asp:Label ID="EmailIDLabel" runat="server" Text="Email ID"></asp:Label>
            </td>
            <td id="EmailIDTextBoxColumn">
                <asp:textbox runat="server" ID="EmailIDTextBox"></asp:textbox>
            </td>
            <td>

                <asp:RequiredFieldValidator ID="EmailIDValidator" runat="server" ControlToValidate="EmailIDTextBox" ErrorMessage="EmailID is Mandatory!!" Font-Italic="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr id="MobileNumberRow">
            <td id="MobileNumberLabelColumn">
                <asp:Label ID="MobileNumberLabel" runat="server" Text="Mobile Number"></asp:Label>
            </td>
            <td id="MobileNumberTextBoxColumn">
                <asp:textbox runat="server" ID="MobileNumberTextBox"></asp:textbox>
            </td>
            <td>

                <asp:RequiredFieldValidator ID="MobileNumberValidator0" runat="server" ControlToValidate="MobileNumberTextBox" ErrorMessage="Mobile Number is Mandatory!!" Font-Italic="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr id="AlternateMobileNumberRow">
            <td id="AlternateMobileNumberLabelColumn">

                <asp:Label ID="AlternateMobileNumberLabel" runat="server" Text="Alternate Mobile Number"></asp:Label>

            </td>
            <td id="AlternateMobileNumberTextBoxColumn">

                <asp:TextBox runat="server" ID="AlternateMobileNumberTextBox"></asp:TextBox>

            </td>
        </tr>
        <tr id="AddressLine1Row">
            <td id="AddressLine1LabelColumn">

                <asp:Label ID="AddressLine1Label" runat="server" Text="Address Line1"></asp:Label>

            </td>
            <td id="AddressLine1TextBoxColumn">

                <asp:TextBox runat="server" ID="AddressLine1TextBox"></asp:TextBox>

            </td>
            <td>

                <asp:RequiredFieldValidator ID="AddressLine1Validator" runat="server" ControlToValidate="AddressLine1TextBox" ErrorMessage="Address Line 1 is Mandatory!!" Font-Italic="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr id="AddressLine2Row">
            <td id="AddressLine2LabelColumn">

                <asp:Label ID="AddressLine2Label" runat="server" Text="Address Line2"></asp:Label>

            </td>
            <td id="AddressLine2TextBoxColumn">

                <asp:TextBox runat="server" ID="AddressLine2TextBox"></asp:TextBox>

            </td>
        </tr>
        <tr id="AddressStateRow">
            <td id ="AddressStateLabelColumn">
                <asp:Label ID="StateLabel" runat="server" Text="State"></asp:Label>
            </td>
            <td id="AddressStateTextBoxColumn">
                <asp:TextBox runat="server" ID="StateTextBox"></asp:TextBox>
            </td>
            <td>

                <asp:RequiredFieldValidator ID="StateValidator" runat="server" ControlToValidate="StateTextBox" ErrorMessage="State is Mandatory!!" Font-Italic="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr id="AddressCountryRow">
            <td id="AddressCountryLabelColumn">
                <asp:Label ID="CountryLabel" runat="server" Text="Country"></asp:Label>
            </td>
            <td id="AddressCountryTextBoxColumn">
                <asp:TextBox runat="server" ID="CountryTextBox"></asp:TextBox>            
            </td>
            <td>

                <asp:RequiredFieldValidator ID="CountryValidator" runat="server" ControlToValidate="CountryTextBox" ErrorMessage="Country is Mandatory!!" Font-Italic="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr id="AddressZipCodeRow">
            <td id="AddressZipCodeLabelColumn">
                <asp:Label ID="ZipCodeLabel" runat="server" Text="ZipCode"></asp:Label>

            </td>
            <td id="AddressZipCodeTextBoxColumn">
                <asp:TextBox runat="server" ID="ZipCodeTextBox"></asp:TextBox>
            </td>
            <td>

                <asp:RequiredFieldValidator ID="ZipCodeValidator" runat="server" ControlToValidate="ZipCodeTextBox" ErrorMessage="ZipCode is Mandatory!!" Font-Italic="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr id="HomeCountryRow">
            <td id="HomeCountryLabelColumn">

                <asp:Label ID="HomeCountryLabel" runat="server" Text="Home Country"></asp:Label>

            </td>
            <td id="HomeCountryTextBoxColumn">

                 <asp:textbox runat="server" ID="HomeCountryTextBox"></asp:textbox>
            </td>
        </tr>
        <tr id="SavePersonalDetailsRow">
            <td id ="PersonalDetailsResetButtonColumn">
                <asp:Button ID="PersonalDetailsResetButton" runat="server" Text="Reset" BackColor="#00CCFF" ForeColor="Black" OnClick="PersonalDetailsResetButton_Click" />
            </td>
            <td id="PersonalDetailsEditButtonColumn">
                <asp:Button ID="PersonalDetailsEditButton" runat="server" Text="Edit" BackColor="#00CCFF" OnClick="PersonalDetailsEditButton_Click" />
            </td>
            <td id="PersonalDetailsSaveButtonColumn">
                <asp:Button ID="PersonalDetailsSaveButton" runat="server" Text="Save" BackColor="#00CCFF" OnClick="PersonalDetailsSaveButton_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
