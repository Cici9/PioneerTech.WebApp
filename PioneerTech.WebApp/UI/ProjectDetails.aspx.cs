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
        private EmployeeDataAccessLayer EmployeeDataAccessLayerObj;
        private Project ProjectObj;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeDataAccessLayerObj = new EmployeeDataAccessLayer();
            ProjectObj = new Project();

            if(!IsPostBack)
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

            ProjectObj = EmployeeDataAccessLayerObj.GetProjectData(SelectedEmployeeID);

            EmployeeIDHiddenField.Value = SelectedEmployeeID.ToString();
            ProjectNameTextBox.Text = ProjectObj.ProjectName;
            ClientNameTextBox.Text = ProjectObj.ClientName;
            ProjectLocationTextBox.Text = ProjectObj.ProjectLocation;
            ProjectRolesTextBox.Text = ProjectObj.ProjectRoles;
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
            int EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (EmployeeID == 0)
            {
                Response.Write("<script>alert('Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/ProjectDetails.aspx';</script>");
            }
            else
                SaveData();
        }

        protected void ProjectDetailsEditButton_Click1(object sender, EventArgs e)
        {
            int EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (EmployeeID == 0)
            {
                Response.Write("<script>alert('To Edit: Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/ProjectDetails.aspx';</script>");
            }
            else
                SaveData();
        }

        protected void SaveData()
        {
            string returnValue;

            ProjectObj.EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            ProjectObj.ProjectName = ProjectNameTextBox.Text;
            ProjectObj.ClientName = ClientNameTextBox.Text;
            ProjectObj.ProjectLocation = ProjectLocationTextBox.Text;
            ProjectObj.ProjectRoles = ProjectRolesTextBox.Text;

            returnValue = EmployeeDataAccessLayerObj.SaveEmployeeProjectDetails(ProjectObj);

            if (returnValue.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Project Data has been saved/updated successfully'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + returnValue + "'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
        }
    }
}