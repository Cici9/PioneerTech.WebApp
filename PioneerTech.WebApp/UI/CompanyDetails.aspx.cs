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
    public partial class CompanyDetails : System.Web.UI.Page
    {
        private Company companyObject;
        private EmployeeDataAccessLayer employeeDataAccessLayerObject;
        protected void Page_Load(object sender, EventArgs e)
        {
            companyObject = new Company();
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

        protected void EmployeeIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEmployeeID = EmployeeIDDropDownList.SelectedValue;
            string employeeName = employeeDataAccessLayerObject.GetEmployeeName(selectedEmployeeID);

            SelectedEmployeeLabel.Visible = true;
            SelectedEmployeeName.Text = employeeName;
            SelectedEmployeeName.Visible = true;

            companyObject = employeeDataAccessLayerObject.GetCompanyData(selectedEmployeeID);            

            EmployeeIDHiddenField.Value = selectedEmployeeID.ToString();
            CompanyNameTextBox.Text = companyObject.CompanyName;
            CompanyContactNumberTextBox.Text = companyObject.CompanyContactNumber;
            CompanyLocationTextBox.Text = companyObject.CompanyLocation;
            CompanyWebsiteTextBox.Text = companyObject.CompanyWebsite;
        }

        protected void CompanyDetailsResetButton_Click(object sender, EventArgs e)
        {
            EmployeeIDHiddenField.Value = string.Empty;
            CompanyNameTextBox.Text = string.Empty;
            CompanyContactNumberTextBox.Text = string.Empty;
            CompanyLocationTextBox.Text = string.Empty;
            CompanyWebsiteTextBox.Text = string.Empty;
        }

        protected void CompanyDetailsSaveButton_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if(employeeID == 0)
            {
                Response.Write("<script>alert('Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/CompanyDetails.aspx'; document.getElementById('EmployeeIDDropDownList').focus();</script>");
            }
            else
                SaveData();
        }
        
        protected void SaveData()
        {
            string returnValue;

            companyObject.EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            companyObject.CompanyName = CompanyNameTextBox.Text;
            companyObject.CompanyContactNumber = CompanyContactNumberTextBox.Text;
            companyObject.CompanyLocation = CompanyLocationTextBox.Text;
            companyObject.CompanyWebsite = CompanyWebsiteTextBox.Text;

            returnValue = employeeDataAccessLayerObject.SaveEmployeeCompanyDetails(companyObject);

            if (returnValue.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Company Data has been saved/updated successfully'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + returnValue + "'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
        }

        protected void CompanyDetailsEditButton_Click(object sender, EventArgs e)
        {
            int EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (EmployeeID == 0)
            {
                Response.Write("<script>alert('To Edit: Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/CompanyDetails.aspx';</script>");
            }
            else
                SaveData();
        }
    }
}