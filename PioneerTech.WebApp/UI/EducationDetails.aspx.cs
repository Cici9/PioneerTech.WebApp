using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PioneerTechSystem.DAL;
using PioneerTechSystem.Models;

namespace PioneerTech.WebApp.UI
{
    public partial class EducationDetails : System.Web.UI.Page
    {
        private EmployeeDataAccessLayer employeeDataAccessLayerObject;
        private Educational educationalObject;
        protected void Page_Load(object sender, EventArgs e)
        {
            employeeDataAccessLayerObject = new EmployeeDataAccessLayer();
            educationalObject = new Educational();

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

            educationalObject = employeeDataAccessLayerObject.GetEducationData(selectedEmployeeID);

            EmployeeIDHiddenField.Value = selectedEmployeeID.ToString();
            CourseTypeTextBox.Text = educationalObject.CourseType;
            CourseSpecializaionTextBox.Text = educationalObject.CourseSpecialization;
            CourseYearOfPassingTextBox.Text = educationalObject.CourseYearofPassing;
        }

        protected void EducationDetailsResetButton_Click(object sender, EventArgs e)
        {
            EmployeeIDHiddenField.Value = string.Empty;
            CourseTypeTextBox.Text = string.Empty;
            CourseSpecializaionTextBox.Text = string.Empty;
            CourseYearOfPassingTextBox.Text = string.Empty;
        }

        protected void EducationDetailsSaveButton_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (employeeID == 0)
            {
                Response.Write("<script>alert('Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/EducationDetails.aspx';</script>");
            }
            else
                SaveData();
        }


        protected void EducationDetailsEditButton_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (employeeID == 0)
            {
                Response.Write("<script>alert('To Edit: Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/EducationDetails.aspx';</script>");
            }
            else
                SaveData();
        }

        protected void SaveData()
        {
            string returnValue;

            educationalObject.EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            educationalObject.CourseType = CourseTypeTextBox.Text;
            educationalObject.CourseSpecialization = CourseSpecializaionTextBox.Text;
            educationalObject.CourseYearofPassing = CourseYearOfPassingTextBox.Text;

            returnValue = employeeDataAccessLayerObject.SaveEmployeeEducationDetails(educationalObject);

            if (returnValue.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Education Data has been saved/updated successfully'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + returnValue + "'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
        }
    }
}