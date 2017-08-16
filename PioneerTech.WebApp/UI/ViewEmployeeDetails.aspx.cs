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
        //private string EmployeeID;
        private EmployeeDataAccessLayer employeeDataAccessLayerObject;
        //private List<Employee> EmployeeData;
        //private List<Company> CompanyData;
        //private List<Project> ProjectData;
        //private List<Technical> TechnicalData;
        //private List<Educational> EducationData;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            EmployeeDataAccessLayer employeeDataAccessLayerObject = new EmployeeDataAccessLayer();
 
            PersonalDetailsGridView.DataSource = employeeDataAccessLayerObject.ViewEmployeeData(selectedEmployeeID);
            PersonalDetailsGridView.DataBind();

            CompanyDetailsGridView.DataSource = employeeDataAccessLayerObject.ViewCompanyData(selectedEmployeeID);
            CompanyDetailsGridView.DataBind();

            ProjectDetailsGridView.DataSource = employeeDataAccessLayerObject.ViewProjectData(selectedEmployeeID);
            ProjectDetailsGridView.DataBind();
        }
    }
}