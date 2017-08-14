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
        private Technical TechnicalObj;
        private EmployeeDataAccessLayer EmployeeDALObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            TechnicalObj = new Technical();
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

            TechnicalObj = EmployeeDALObj.GetTechnicalData(SelectedEmployeeID);


            EmployeeIDHiddenField.Value = SelectedEmployeeID.ToString();
            ProgrammingLanguagesTextBox.Text = TechnicalObj.ProgrammingLanguages;
            DatabasesKnownTextBox.Text = TechnicalObj.DatabasesKnown;
            ORMTechnologiesTextBox.Text = TechnicalObj.ORMTechnologies;
            UITechnologiesTextBox.Text = TechnicalObj.UITechnologies;
        }

        protected void TechninalDetailsSaveButton_Click(object sender, EventArgs e)
        {
            int EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (EmployeeID == 0)
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
            int EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            if (EmployeeID == 0)
            {
                Response.Write("<script>alert('To Edit: Please select an EmployeeID first!!'); window.location = '" + Request.ApplicationPath + "UI/TechnicalDetails.aspx';</script>");
            }
            else
                SaveData();
        }

        protected void SaveData()
        {
            string returnValue;

            TechnicalObj.EmployeeID = Convert.ToInt32(EmployeeIDHiddenField.Value);
            TechnicalObj.ProgrammingLanguages = ProgrammingLanguagesTextBox.Text;
            TechnicalObj.DatabasesKnown = DatabasesKnownTextBox.Text;
            TechnicalObj.ORMTechnologies = ORMTechnologiesTextBox.Text;
            TechnicalObj.UITechnologies = UITechnologiesTextBox.Text;

            returnValue = EmployeeDALObj.SaveEmployeeTechnicalDetails(TechnicalObj);

            if (returnValue.Equals("1"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Technical Data has been saved/updated successfully'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + returnValue + "'); window.location='" + Request.ApplicationPath + "UI/Home.aspx';", true);
        }
    }
}