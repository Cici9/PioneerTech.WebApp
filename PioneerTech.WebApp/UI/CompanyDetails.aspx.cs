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
            string EmployeeName = EmployeeDALObj.GetEmployeeName(SelectedEmployeeID);

            SelectedEmployeeLabel.Visible = true;
            SelectedEmployeeName.Text = EmployeeName;
            SelectedEmployeeName.Visible = true;

            CompanyObj = EmployeeDALObj.GetCompanyData(SelectedEmployeeID);            

            EmployeeIDHiddenField.Value = SelectedEmployeeID.ToString();
            CompanyNameTextBox.Text = CompanyObj.CompanyName;
            CompanyContactNumberTextBox.Text = CompanyObj.CompanyContactNumber;
            CompanyLocationTextBox.Text = CompanyObj.CompanyLocation;
            CompanyWebsiteTextBox.Text = CompanyObj.CompanyWebsite;
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
            int EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if(EmployeeID == 0)
            {
                Response.Write("<script>alert('Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/CompanyDetails.aspx'; document.getElementById('EmployeeIDDropDownList').focus();</script>");
            }
            else
                SaveData();
        }
        
        protected void SaveData()
        {
            string returnValue;

            CompanyObj.EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            CompanyObj.CompanyName = CompanyNameTextBox.Text;
            CompanyObj.CompanyContactNumber = CompanyContactNumberTextBox.Text;
            CompanyObj.CompanyLocation = CompanyLocationTextBox.Text;
            CompanyObj.CompanyWebsite = CompanyWebsiteTextBox.Text;

            returnValue = EmployeeDALObj.SaveEmployeeCompanyDetails(CompanyObj);

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