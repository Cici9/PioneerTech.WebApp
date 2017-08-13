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
        private Company CompanyObj;
        private EmployeeDataAccessLayer EmployeeDALObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyObj = new Company();
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

        protected void EmployeeIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedEmployeeID = EmployeeIDDropDownList.SelectedValue;
            CompanyObj = EmployeeDALObj.GetCompanyData(SelectedEmployeeID);

            CompanyNameTextBox.Text = CompanyObj.CompanyName;
            CompanyContactNumberTextBox.Text = CompanyObj.CompanyContactNumber;
            CompanyLocationTextBox.Text = CompanyObj.CompanyLocation;
            CompanyWebsiteTextBox.Text = CompanyObj.CompanyWebsite;
        }

        protected void CompanyDetailsResetButton_Click(object sender, EventArgs e)
        {
            CompanyNameTextBox.Text = string.Empty;
            CompanyContactNumberTextBox.Text = string.Empty;
            CompanyLocationTextBox.Text = string.Empty;
            CompanyWebsiteTextBox.Text = string.Empty;
        }

        protected void CompanyDetailsSaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}