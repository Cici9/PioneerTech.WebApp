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
    public partial class ProjectDetails : System.Web.UI.Page
    {
        private EmployeeDataAccessLayer employeeDataAccessLayerObject;
        private Project projectObject;

        protected void Page_Load(object sender, EventArgs e)
        {
            employeeDataAccessLayerObject = new EmployeeDataAccessLayer();
            projectObject = new Project();

            if(!IsPostBack)
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

            projectObject = employeeDataAccessLayerObject.GetProjectData(selectedEmployeeID);

            EmployeeIDHiddenField.Value = selectedEmployeeID.ToString();
            ProjectNameTextBox.Text = projectObject.ProjectName;
            ClientNameTextBox.Text = projectObject.ClientName;
            ProjectLocationTextBox.Text = projectObject.ProjectLocation;
            ProjectRolesTextBox.Text = projectObject.ProjectRoles;
        }

        protected void ProjectDetailsResetButton_Click(object sender, EventArgs e)
        {
            EmployeeIDHiddenField.Value = string.Empty;
            ProjectNameTextBox.Text = string.Empty;
            ClientNameTextBox.Text = string.Empty;
            ProjectLocationTextBox.Text = string.Empty;
            ProjectRolesTextBox.Text = string.Empty;
        }

        protected void ProjectDetailsSaveButton_Click1(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (employeeID == 0)
            {
                Response.Write("<script>alert('Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/ProjectDetails.aspx';</script>");
            }
            else
                SaveData();
        }

        protected void ProjectDetailsEditButton_Click1(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (employeeID == 0)
            {
                Response.Write("<script>alert('To Edit: Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/ProjectDetails.aspx';</script>");
            }
            else
                SaveData();
        }

        protected void SaveData()
        {
            string returnValue;

            projectObject.EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            projectObject.ProjectName = ProjectNameTextBox.Text;
            projectObject.ClientName = ClientNameTextBox.Text;
            projectObject.ProjectLocation = ProjectLocationTextBox.Text;
            projectObject.ProjectRoles = ProjectRolesTextBox.Text;

            returnValue = employeeDataAccessLayerObject.SaveEmployeeProjectDetails(projectObject);

            if (returnValue.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Project Data has been saved/updated successfully'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + returnValue + "'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
        }
    }
}