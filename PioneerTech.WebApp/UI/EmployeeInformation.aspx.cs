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
    public partial class EmployeeInformation : System.Web.UI.Page
    {
        private string EmployeeID;
        private List<Employee> EmployeeData;
        private List<Company> CompanyData;
        private List<Project> ProjectData;
        private List<Technical> TechnicalData;
        private List<Educational> EducationData;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EmployeeIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string SelectedEmployeeID = EmployeeIDDropDownList.SelectedValue;
            //CompanyObj = EmployeeDALObj.GetCompanyData(SelectedEmployeeID);

        }
    }
}