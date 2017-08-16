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
    public partial class TechnicalDetails : System.Web.UI.Page
    {
        private Technical technicalObj;
        private EmployeeDataAccessLayer employeeDataAccessLayerObject;
        protected void Page_Load(object sender, EventArgs e)
        {
            technicalObj = new Technical();
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

            technicalObj = employeeDataAccessLayerObject.GetTechnicalData(selectedEmployeeID);


            EmployeeIDHiddenField.Value = selectedEmployeeID.ToString();
            ProgrammingLanguagesTextBox.Text = technicalObj.ProgrammingLanguages;
            DatabasesKnownTextBox.Text = technicalObj.DatabasesKnown;
            ORMTechnologiesTextBox.Text = technicalObj.ORMTechnologies;
            UITechnologiesTextBox.Text = technicalObj.UITechnologies;
        }

        protected void TechninalDetailsSaveButton_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (employeeID == 0)
            {
                Response.Write("<script>alert('Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/TechnicalDetails.aspx';</script>");
            }
            else
                SaveData();
        }

        protected void TechninalDetailsResetButton_Click(object sender, EventArgs e)
        {
            EmployeeIDHiddenField.Value = string.Empty;
            ProgrammingLanguagesTextBox.Text = string.Empty;
            DatabasesKnownTextBox.Text = string.Empty;
            ORMTechnologiesTextBox.Text = string.Empty;
            UITechnologiesTextBox.Text = string.Empty;
        }

        protected void TechninalDetailsEditButton_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (employeeID == 0)
            {
                Response.Write("<script>alert('To Edit: Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/TechnicalDetails.aspx';</script>");
            }
            else
                SaveData();
        }

        protected void SaveData()
        {
            string returnValue;

            technicalObj.EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            technicalObj.ProgrammingLanguages = ProgrammingLanguagesTextBox.Text;
            technicalObj.DatabasesKnown = DatabasesKnownTextBox.Text;
            technicalObj.ORMTechnologies = ORMTechnologiesTextBox.Text;
            technicalObj.UITechnologies = UITechnologiesTextBox.Text;

            returnValue = employeeDataAccessLayerObject.SaveEmployeeTechnicalDetails(technicalObj);

            if (returnValue.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Technical Data has been saved/updated successfully'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + returnValue + "'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
        }
    }
}