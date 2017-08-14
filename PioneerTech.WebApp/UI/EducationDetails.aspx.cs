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
        private EmployeeDataAccessLayer EmployeeDataAccessLayerObj;
        private Educational EducationalObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeDataAccessLayerObj = new EmployeeDataAccessLayer();
            EducationalObj = new Educational();

            if (!IsPostBack)
            {
                EmployeeIDDropDownList.DataTextField = "EmployeeID";
                EmployeeIDDropDownList.DataValueField = "EmployeeID";
                EmployeeIDDropDownList.DataSource = EmployeeDataAccessLayerObj.GetEmployeeID();
                EmployeeIDDropDownList.DataBind();
                EmployeeIDDropDownList.Items.Insert(0, new ListItem("Select EmployeeID", "0"));
            }
        }

        protected void EmployeeIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedEmployeeID = EmployeeIDDropDownList.SelectedValue;
            string EmployeeName = EmployeeDataAccessLayerObj.GetEmployeeName(SelectedEmployeeID);

            SelectedEmployeeLabel.Visible = true;
            SelectedEmployeeName.Text = EmployeeName;
            SelectedEmployeeName.Visible = true;

            EducationalObj = EmployeeDataAccessLayerObj.GetEducationData(SelectedEmployeeID);

            EmployeeIDHiddenField.Value = SelectedEmployeeID.ToString();
            CourseTypeTextBox.Text = EducationalObj.CourseType;
            CourseSpecializaionTextBox.Text = EducationalObj.CourseSpecialization;
            CourseYearOfPassingTextBox.Text = EducationalObj.CourseYearofPassing;
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
            int EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (EmployeeID == 0)
            {
                Response.Write("<script>alert('Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/EducationDetails.aspx';</script>");
            }
            else
                SaveData();
        }


        protected void EducationDetailsEditButton_Click(object sender, EventArgs e)
        {
            int EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (EmployeeID == 0)
            {
                Response.Write("<script>alert('To Edit: Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/EducationDetails.aspx';</script>");
            }
            else
                SaveData();
        }

        protected void SaveData()
        {
            string returnValue;

            EducationalObj.EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            EducationalObj.CourseType = CourseTypeTextBox.Text;
            EducationalObj.CourseSpecialization = CourseSpecializaionTextBox.Text;
            EducationalObj.CourseYearofPassing = CourseYearOfPassingTextBox.Text;

            returnValue = EmployeeDataAccessLayerObj.SaveEmployeeEducationDetails(EducationalObj);

            if (returnValue.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Education Data has been saved/updated successfully'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + returnValue + "'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
        }
    }
}