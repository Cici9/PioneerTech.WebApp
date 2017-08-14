using PioneerTechSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PioneerTechSystem.DAL;

namespace PioneerTech.WebApp.UI
{
    public partial class ViewEmployeeDetails : System.Web.UI.Page
    {
        private string EmployeeID;
        private EmployeeDataAccessLayer EmployeeDALObj;
        private List<Employee> EmployeeData;
        private List<Company> CompanyData;
        private List<Project> ProjectData;
        private List<Technical> TechnicalData;
        private List<Educational> EducationData;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            EmployeeDataAccessLayer EmployeeDataAccessLayerObj = new EmployeeDataAccessLayer();

            PersonalDetailsGridView.DataSource = EmployeeDataAccessLayerObj.ViewEmployeeData(SelectedEmployeeID);
            PersonalDetailsGridView.DataBind();

            CompanyDetailsGridView.DataSource = EmployeeDataAccessLayerObj.ViewCompanyData(SelectedEmployeeID);
            CompanyDetailsGridView.DataBind();

            ProjectDetailsGridView.DataSource = EmployeeDataAccessLayerObj.ViewProjectData(SelectedEmployeeID);
            ProjectDetailsGridView.DataBind();
        }
    }
}