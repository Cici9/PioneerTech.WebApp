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
        private Employee EmployeeObj;
        private EmployeeDataAccessLayer EmployeeDALObj;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeObj = new Employee();
            EmployeeDALObj = new EmployeeDataAccessLayer();
            if (!IsPostBack)
            {
                EmployeeIDDropDownList.DataTextField = "EmployeeID";
                EmployeeIDDropDownList.DataValueField = "EmployeeID";
                EmployeeIDDropDownList.DataSource = EmployeeDALObj.GetEmployeeID();
                EmployeeIDDropDownList.DataBind();
                EmployeeIDDropDownList.Items.Insert(0, new ListItem("Select EmployeeID", "0"));
            }      
        }

        protected void PersonalDetailsResetButton_Click(object sender, EventArgs e)
        {
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
            string returnValue;

            EmployeeObj.EmployeeID = 0;
            EmployeeObj.FirstName = FirstNameTextBox.Text;
            EmployeeObj.LastName = LastNameTextBox.Text;
            EmployeeObj.EmailID = EmailIDTextBox.Text;
            EmployeeObj.MobileNumber = MobileNumberTextBox.Text;
            EmployeeObj.AlternateMobileNumber = AlternateMobileNumberTextBox.Text;
            EmployeeObj.AddressLine1 = AddressLine1TextBox.Text;
            EmployeeObj.AddressLine2 = AddressLine2TextBox.Text;
            EmployeeObj.AddressState = StateTextBox.Text;
            EmployeeObj.AddressCountry = CountryTextBox.Text;
            EmployeeObj.AddressZipCode = ZipCodeTextBox.Text;
            EmployeeObj.HomeCountry = HomeCountryTextBox.Text;

            returnValue = EmployeeDALObj.SaveEmployeePersonalDetails(EmployeeObj);

            if(returnValue.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Data has been saved successfully'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('"+returnValue+"'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
        }

        protected void EmployeeIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedEmployeeID = EmployeeIDDropDownList.SelectedValue;            
            EmployeeObj = EmployeeDALObj.GetPersonalData(SelectedEmployeeID);

            FirstNameTextBox.Text = EmployeeObj.FirstName;
            LastNameTextBox.Text = EmployeeObj.LastName;
            EmailIDTextBox.Text = EmployeeObj.EmailID;
            MobileNumberTextBox.Text = EmployeeObj.MobileNumber;
            AlternateMobileNumberTextBox.Text = EmployeeObj.AlternateMobileNumber;
            AddressLine1TextBox.Text = EmployeeObj.AddressLine1;
            AddressLine2TextBox.Text = EmployeeObj.AddressLine2;
            StateTextBox.Text = EmployeeObj.AddressState;
            CountryTextBox.Text = EmployeeObj.AddressCountry;
            ZipCodeTextBox.Text = EmployeeObj.AddressZipCode;
            HomeCountryTextBox.Text = EmployeeObj.HomeCountry;
        }
    }
}