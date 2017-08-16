using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PioneerTechSystem.Models;
using PioneerTechSystem.DAL;

namespace PioneerTech.WebApp.UI
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        private Employee employeeObj;
        private EmployeeDataAccessLayer employeeDataAccessLayerObject;

        protected void Page_Load(object sender, EventArgs e)
        {
            employeeObj = new Employee();
            employeeDataAccessLayerObject = new EmployeeDataAccessLayer();
            if (!IsPostBack)
            {
                EmployeeIDDropDownList.DataTextField = "EmployeeID";
                EmployeeIDDropDownList.DataValueField = "EmployeeID";
                EmployeeIDDropDownList.DataSource = employeeDataAccessLayerObject.GetEmployeeID();
                EmployeeIDDropDownList.DataBind();
                EmployeeIDDropDownList.Items.Insert(0, new ListItem("Select EmployeeID", "0"));
            }      
        }

        protected void PersonalDetailsResetButton_Click(object sender, EventArgs e)
        {
            EmployeeIDHiddenField.Value = string.Empty;
            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            EmailIDTextBox.Text = string.Empty;
            MobileNumberTextBox.Text = string.Empty;
            AlternateMobileNumberTextBox.Text = string.Empty;
            AddressLine1TextBox.Text = string.Empty;
            AddressLine2TextBox.Text = string.Empty;
            StateTextBox.Text = string.Empty;
            CountryTextBox.Text = string.Empty;
            ZipCodeTextBox.Text = string.Empty;
            HomeCountryTextBox.Text = string.Empty;
        }

        protected void PersonalDetailsSaveButton_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void EmployeeIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEmployeeID = EmployeeIDDropDownList.SelectedValue;            
            employeeObj = employeeDataAccessLayerObject.GetPersonalData(selectedEmployeeID);

            EmployeeIDHiddenField.Value = employeeObj.EmployeeID.ToString();
            FirstNameTextBox.Text = employeeObj.FirstName;
            LastNameTextBox.Text = employeeObj.LastName;
            EmailIDTextBox.Text = employeeObj.EmailID;
            MobileNumberTextBox.Text = employeeObj.MobileNumber;
            AlternateMobileNumberTextBox.Text = employeeObj.AlternateMobileNumber;
            AddressLine1TextBox.Text = employeeObj.AddressLine1;
            AddressLine2TextBox.Text = employeeObj.AddressLine2;
            StateTextBox.Text = employeeObj.AddressState;
            CountryTextBox.Text = employeeObj.AddressCountry;
            ZipCodeTextBox.Text = employeeObj.AddressZipCode;
            HomeCountryTextBox.Text = employeeObj.HomeCountry;

            PersonalDetailsSaveButton.Visible = false;

            if(selectedEmployeeID.Equals("0"))
            {
                PersonalDetailsSaveButton.Visible = true;
            }
        }

        protected void PersonalDetailsEditButton_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (employeeID == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('To Edit: Please select an EmployeeID first!!'); window.location='" + Request.ApplicationPath + "UI/EmployeeDetails.aspx';", true);
            }
            else
                SaveData();
        }

        protected void SaveData()
        {
            string returnValue;
            employeeObj.EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            employeeObj.FirstName = FirstNameTextBox.Text;
            employeeObj.LastName = LastNameTextBox.Text;
            employeeObj.EmailID = EmailIDTextBox.Text;
            employeeObj.MobileNumber = MobileNumberTextBox.Text;
            employeeObj.AlternateMobileNumber = AlternateMobileNumberTextBox.Text;
            employeeObj.AddressLine1 = AddressLine1TextBox.Text;
            employeeObj.AddressLine2 = AddressLine2TextBox.Text;
            employeeObj.AddressState = StateTextBox.Text;
            employeeObj.AddressCountry = CountryTextBox.Text;
            employeeObj.AddressZipCode = ZipCodeTextBox.Text;
            employeeObj.HomeCountry = HomeCountryTextBox.Text;
            returnValue = employeeDataAccessLayerObject.SaveEmployeePersonalDetails(employeeObj);

            if (returnValue.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Data has been saved/updated successfully'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + returnValue + "'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
        }
    }
}