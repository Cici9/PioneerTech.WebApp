using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PioneerTechSystem.Models;

namespace PioneerTechSystem.DAL
{
    public class EmployeeDataAccessLayer
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataAdapter DataAdapter;
        private DataTable dataTable;
        public List<Employee> EmployeeData;
        public List<Company> CompanyData;
        public List<Project> ProjectData;

        // Opening Connection
        private SqlConnection OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("server =.; Initial Catalog = PioneerTechConsultancySystem; Integrated Security = true");
            sqlConnection.Open();
            return sqlConnection;
        }

        // Close Connection
        private void CloseConnection(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }

        // Checking Login
        public int loginCheck(Login LoginObj)
        {
            int returnValue = 0;
            if (LoginObj.LoginID.Equals("admin") && LoginObj.Password.Equals("abc@123"))
            {
                returnValue = 1;
            }
            else
                returnValue = 0;

            return returnValue;
        }

        // Insert Consultant Values
        public string InsertConsultantDetails(Employee EmployeeObj, Project ProjectObj, Company CompanyObj, Technical TechnicalObj, Educational EducationalObj)
        {
            
            try
            {
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspInsertDetails";

                sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = EmployeeObj.FirstName;
                sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = EmployeeObj.LastName;
                sqlCommand.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = EmployeeObj.EmailID;
                sqlCommand.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = EmployeeObj.MobileNumber;
                sqlCommand.Parameters.Add("@AlternateMobileNumber", SqlDbType.VarChar).Value = EmployeeObj.AlternateMobileNumber;
                sqlCommand.Parameters.Add("@AddressLine1", SqlDbType.VarChar).Value = EmployeeObj.AddressLine1;
                sqlCommand.Parameters.Add("@AddressLine2", SqlDbType.VarChar).Value = EmployeeObj.AddressLine2;
                sqlCommand.Parameters.Add("@State", SqlDbType.VarChar).Value = EmployeeObj.AddressState;
                sqlCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = EmployeeObj.AddressCountry;
                sqlCommand.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = EmployeeObj.AddressZipCode;
                sqlCommand.Parameters.Add("@HomeCountry", SqlDbType.VarChar).Value = EmployeeObj.HomeCountry;
                sqlCommand.Parameters.Add("@ProjectName", SqlDbType.VarChar).Value = ProjectObj.ProjectName;
                sqlCommand.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = ProjectObj.ClientName;
                sqlCommand.Parameters.Add("@ProjectLocation", SqlDbType.VarChar).Value = ProjectObj.ProjectLocation;
                sqlCommand.Parameters.Add("@ProjectRoles", SqlDbType.VarChar).Value = ProjectObj.ProjectRoles;
                sqlCommand.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = CompanyObj.CompanyName;
                sqlCommand.Parameters.Add("@CompanyContactNumber", SqlDbType.VarChar).Value = CompanyObj.CompanyContactNumber;
                sqlCommand.Parameters.Add("@CompanyLocation", SqlDbType.VarChar).Value = CompanyObj.CompanyLocation;
                sqlCommand.Parameters.Add("@CompanyWebsite", SqlDbType.VarChar).Value = CompanyObj.CompanyWebsite;
                sqlCommand.Parameters.Add("@ProgrammingLanguages", SqlDbType.VarChar).Value = TechnicalObj.ProgrammingLanguages;
                sqlCommand.Parameters.Add("@Databases", SqlDbType.VarChar).Value = TechnicalObj.DatabasesKnown;
                sqlCommand.Parameters.Add("@ORMTechnologies", SqlDbType.VarChar).Value = TechnicalObj.ORMTechnologies;
                sqlCommand.Parameters.Add("@UITechnologies", SqlDbType.VarChar).Value = TechnicalObj.UITechnologies;
                sqlCommand.Parameters.Add("@CourseType", SqlDbType.VarChar).Value = EducationalObj.CourseType;
                sqlCommand.Parameters.Add("@CourseSpecialization", SqlDbType.VarChar).Value = EducationalObj.CourseSpecialization;
                sqlCommand.Parameters.Add("@CourseYear", SqlDbType.VarChar).Value = EducationalObj.CourseYearofPassing;

                SqlParameter returnMessage = sqlCommand.CreateParameter();
                returnMessage.ParameterName = "Message";
                returnMessage.Direction = ParameterDirection.Output;
                returnMessage.DbType = DbType.String;
                returnMessage.Size = 100;
                sqlCommand.Parameters.Add(returnMessage);

                sqlCommand.ExecuteNonQuery();
                string returnValue = returnMessage.Value.ToString();
                sqlCommand.Dispose();
                return returnValue;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }

        // To Display values        
        public List<Employee> ViewEmployeeData(string EmployeeID)
        {
            sqlConnection = OpenConnection();
            EmployeeData = new List<Employee>();
            string DisplayPersonalQuery = "SELECT FirstName, LastName, EmailID, MobileNumber, AddressState as State FROM EmployeePersonalDetails where EmployeeID = '" + EmployeeID + "'";
            sqlCommand = new SqlCommand(DisplayPersonalQuery, sqlConnection);
            SqlDataReader EmployeeDetailsReader = sqlCommand.ExecuteReader();
            while (EmployeeDetailsReader.Read())
            {
                EmployeeData.Add(new Employee() { FirstName = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("FirstName")), LastName = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("LastName")), EmailID = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("EmailID")), MobileNumber = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("MobileNumber")), AddressState = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("LastName")) });
            }
            EmployeeDetailsReader.Close();
            sqlCommand.Dispose();
            CloseConnection(sqlConnection);
            //EmployeeData = EmployeeData.Where(data => data != null).ToList();
            return EmployeeData;
        }
        public List<Company> ViewCompanyData(string EmployeeID)
        {
            sqlConnection = OpenConnection();
            CompanyData = new List<Company>();
            string DisplayCompanyQuery = "SELECT CompanyName, CompanyContactNumber, CompanyLocation, CompanyWebsite FROM EmployeeCompanyDetails where EmployeeID = '" + EmployeeID + "'";
            sqlCommand = new SqlCommand(DisplayCompanyQuery, sqlConnection);
            SqlDataReader CompanyDetailsReader = sqlCommand.ExecuteReader();
            while (CompanyDetailsReader.Read())
            {
                CompanyData.Add(new Company() { CompanyName = CompanyDetailsReader.GetString(CompanyDetailsReader.GetOrdinal("CompanyName")), CompanyContactNumber = CompanyDetailsReader.GetString(CompanyDetailsReader.GetOrdinal("CompanyContactNumber")), CompanyLocation = CompanyDetailsReader.GetString(CompanyDetailsReader.GetOrdinal("CompanyLocation")), CompanyWebsite = CompanyDetailsReader.GetString(CompanyDetailsReader.GetOrdinal("CompanyWebsite")) });
            }

            CloseConnection(sqlConnection);
            return CompanyData;
        }
        public List<Project> ViewProjectData(string EmployeeID)
        {
            sqlConnection = OpenConnection();
            ProjectData = new List<Project>();
            string DisplayProjectQuery = "SELECT ProjectName, ClientName, ProjectLocation, ProjectRoles FROM EmployeeProjectDetails where EmployeeID = '" + EmployeeID + "'";
            sqlCommand = new SqlCommand(DisplayProjectQuery, sqlConnection);
            SqlDataReader ProjectDetailsReader = sqlCommand.ExecuteReader();
            while (ProjectDetailsReader.Read())
            {
                ProjectData.Add(new Project() { ProjectName = ProjectDetailsReader.GetString(ProjectDetailsReader.GetOrdinal("ProjectName")), ClientName = ProjectDetailsReader.GetString(ProjectDetailsReader.GetOrdinal("ClientName")), ProjectLocation = ProjectDetailsReader.GetString(ProjectDetailsReader.GetOrdinal("ProjectLocation")), ProjectRoles = ProjectDetailsReader.GetString(ProjectDetailsReader.GetOrdinal("ProjectRoles")) });
            }

            CloseConnection(sqlConnection);
            return ProjectData;
        }
    }
}
