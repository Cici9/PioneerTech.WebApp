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
        public List<Employee> employeeData;
        public List<Company> companyData;
        public List<Project> projectData;

        // Opening Connection
        private SqlConnection OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("server =ABIJIT; Initial Catalog = PioneerTechConsultancySystem; Integrated Security = true");
            sqlConnection.Open();
            return sqlConnection;
        }

        // Close Connection
        private void CloseConnection(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }

        // Save Employee Personal Details
        public string SaveEmployeePersonalDetails(Employee employeeObj)
        {
            try
            {
                string returnValue;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEmployeePersonalDetails";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = employeeObj.EmployeeID;
                sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = employeeObj.FirstName;
                sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = employeeObj.LastName;
                sqlCommand.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = employeeObj.EmailID;
                sqlCommand.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = employeeObj.MobileNumber;
                sqlCommand.Parameters.Add("@AlternateMobileNumber", SqlDbType.VarChar).Value = employeeObj.AlternateMobileNumber;
                sqlCommand.Parameters.Add("@AddressLine1", SqlDbType.VarChar).Value = employeeObj.AddressLine1;
                sqlCommand.Parameters.Add("@AddressLine2", SqlDbType.VarChar).Value = employeeObj.AddressLine2;
                sqlCommand.Parameters.Add("@State", SqlDbType.VarChar).Value = employeeObj.AddressState;
                sqlCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = employeeObj.AddressCountry;
                sqlCommand.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = employeeObj.AddressZipCode;
                sqlCommand.Parameters.Add("@HomeCountry", SqlDbType.VarChar).Value = employeeObj.HomeCountry;
                
                returnValue = sqlCommand.ExecuteNonQuery().ToString();
                sqlCommand.Dispose();
                return returnValue;
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.ToString();
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }

        // Save Employee Company Details
        public string SaveEmployeeCompanyDetails(Company companyObj)
        {
            try
            {
                string returnValue;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEmployeeCompanyDetails";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = companyObj.EmployeeID;
                sqlCommand.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = companyObj.CompanyName;
                sqlCommand.Parameters.Add("@CompanyContactNumber", SqlDbType.VarChar).Value = companyObj.CompanyContactNumber;
                sqlCommand.Parameters.Add("@CompanyLocation", SqlDbType.VarChar).Value = companyObj.CompanyLocation;
                sqlCommand.Parameters.Add("@CompanyWebsite", SqlDbType.VarChar).Value = companyObj.CompanyWebsite;

                returnValue = sqlCommand.ExecuteNonQuery().ToString();
                sqlCommand.Dispose();
                return returnValue;
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.ToString();
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }


        // Save Employee Project Details
        public string SaveEmployeeProjectDetails(Project projectObj)
        {
            try
            {
                string returnVaue;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEmployeeProjectDetails";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = projectObj.EmployeeID;
                sqlCommand.Parameters.Add("@ProjectName", SqlDbType.VarChar).Value = projectObj.ProjectName;
                sqlCommand.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = projectObj.ClientName;
                sqlCommand.Parameters.Add("@ProjectLocation", SqlDbType.VarChar).Value = projectObj.ProjectLocation;
                sqlCommand.Parameters.Add("@ProjectRoles", SqlDbType.VarChar).Value = projectObj.ProjectRoles;

                returnVaue = sqlCommand.ExecuteNonQuery().ToString();

                sqlCommand.Dispose();
                return returnVaue;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }

        // Save Employee Technical Details
        public string SaveEmployeeTechnicalDetails(Technical technicalObj)
        {
            try
            {
                string returnVaue;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEmployeeTechnicalDetails";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = technicalObj.EmployeeID;
                sqlCommand.Parameters.Add("@ProgrammingLanguages", SqlDbType.VarChar).Value = technicalObj.ProgrammingLanguages;
                sqlCommand.Parameters.Add("@DatabasesKnown", SqlDbType.VarChar).Value = technicalObj.DatabasesKnown;
                sqlCommand.Parameters.Add("@ORMTechnologies", SqlDbType.VarChar).Value = technicalObj.ORMTechnologies;
                sqlCommand.Parameters.Add("@UITechnologies", SqlDbType.VarChar).Value = technicalObj.UITechnologies;

                returnVaue = sqlCommand.ExecuteNonQuery().ToString();

                sqlCommand.Dispose();
                return returnVaue;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }

        // Save Employee Education Details
        public string SaveEmployeeEducationDetails(Educational educationalObj)
        {
            try
            {
                string returnVaue;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEmployeeEducationalDetails";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = educationalObj.EmployeeID;
                sqlCommand.Parameters.Add("@CourseType", SqlDbType.VarChar).Value = educationalObj.CourseType;
                sqlCommand.Parameters.Add("@CourseSpecialization", SqlDbType.VarChar).Value = educationalObj.CourseSpecialization;
                sqlCommand.Parameters.Add("@CourseYearOfPassing", SqlDbType.VarChar).Value = educationalObj.CourseYearofPassing;

                returnVaue = sqlCommand.ExecuteNonQuery().ToString();

                sqlCommand.Dispose();
                return returnVaue;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }

        // Get particular Employee Name
        public string GetEmployeeName(string employeeID)
        {
            try
            {
                string EmployeeName = null;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeName";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = employeeID;

                SqlDataReader nameReader = sqlCommand.ExecuteReader();

                while (nameReader.Read())
                {
                    EmployeeName = nameReader.GetString(nameReader.GetOrdinal("LastName")) + ", " + nameReader.GetString(nameReader.GetOrdinal("FirstName"));
                }

                sqlCommand.Dispose();
                return EmployeeName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }

        // Get all the EmployeeID
        public List<Employee> GetEmployeeID()
        {
            try
            {
                sqlConnection = OpenConnection();
                employeeData = new List<Employee>();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeIDDetails";

                SqlDataReader employeeIDReader = sqlCommand.ExecuteReader();

                while (employeeIDReader.Read())
                {
                    employeeData.Add(new Employee() { EmployeeID = employeeIDReader.GetInt32(employeeIDReader.GetOrdinal("EmployeeID")) });
                }
                employeeIDReader.Close();

                sqlCommand.Dispose();
                return employeeData;
            }
            catch (Exception ex)
            {
                // Logging goes here
                throw;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }

        // Get Personal Details Table Values
        public Employee GetPersonalData(string employeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                Employee selectedEmployee = new Employee();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeePersonalDetails";

                sqlCommand.Parameters.Add("EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(employeeID);

                SqlDataReader personalDetailsReader = sqlCommand.ExecuteReader();

                while (personalDetailsReader.Read())
                {
                    selectedEmployee.EmployeeID = personalDetailsReader.GetInt32(personalDetailsReader.GetOrdinal("EmployeeID"));
                    selectedEmployee.FirstName = personalDetailsReader.GetString(personalDetailsReader.GetOrdinal("FirstName"));
                    selectedEmployee.LastName = personalDetailsReader.GetString(personalDetailsReader.GetOrdinal("LastName"));
                    selectedEmployee.EmailID = personalDetailsReader.GetString(personalDetailsReader.GetOrdinal("EmailID"));
                    selectedEmployee.MobileNumber = personalDetailsReader.GetString(personalDetailsReader.GetOrdinal("MobileNumber"));
                    selectedEmployee.AlternateMobileNumber = personalDetailsReader.GetString(personalDetailsReader.GetOrdinal("AlternateMobileNumber"));
                    selectedEmployee.AddressLine1 = personalDetailsReader.GetString(personalDetailsReader.GetOrdinal("AddressLine1"));
                    selectedEmployee.AddressLine2 = personalDetailsReader.GetString(personalDetailsReader.GetOrdinal("AddressLine2"));
                    selectedEmployee.AddressState = personalDetailsReader.GetString(personalDetailsReader.GetOrdinal("AddressState"));
                    selectedEmployee.AddressCountry = personalDetailsReader.GetString(personalDetailsReader.GetOrdinal("AddressCountry"));
                    selectedEmployee.AddressZipCode = personalDetailsReader.GetString(personalDetailsReader.GetOrdinal("AddressState"));
                    selectedEmployee.HomeCountry = personalDetailsReader.GetString(personalDetailsReader.GetOrdinal("HomeCountry"));
                }
                personalDetailsReader.Close();
                sqlCommand.Dispose();
                return selectedEmployee;
            }
            catch (Exception)
            {
                // Logging goes here
                throw;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }

        // Get Company Details Table Values
        public Company GetCompanyData(string employeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                Company employeeCompany = new Company();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeCompanyDetails";

                sqlCommand.Parameters.Add("EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(employeeID);

                SqlDataReader companyDetailsReader = sqlCommand.ExecuteReader();

                while (companyDetailsReader.Read())
                {
                    employeeCompany.EmployeeID = companyDetailsReader.GetInt32(companyDetailsReader.GetOrdinal("EmployeeID"));
                    employeeCompany.CompanyName = companyDetailsReader.GetString(companyDetailsReader.GetOrdinal("CompanyName"));
                    employeeCompany.CompanyContactNumber = companyDetailsReader.GetString(companyDetailsReader.GetOrdinal("CompanyContactNumber"));
                    employeeCompany.CompanyLocation = companyDetailsReader.GetString(companyDetailsReader.GetOrdinal("CompanyLocation"));
                    employeeCompany.CompanyWebsite = companyDetailsReader.GetString(companyDetailsReader.GetOrdinal("CompanyWebsite"));
                }
                companyDetailsReader.Close();
                sqlCommand.Dispose();
                return employeeCompany;
            }
            catch (Exception)
            {
                // Logging goes here
                throw;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }

        // Get Company Details Table Values
        public Project GetProjectData(string employeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                Project employeeProject = new Project();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeProjectDetails";

                sqlCommand.Parameters.Add("EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(employeeID);

                SqlDataReader projectDetailsReader = sqlCommand.ExecuteReader();

                while (projectDetailsReader.Read())
                {
                    employeeProject.ProjectID = projectDetailsReader.GetInt32(projectDetailsReader.GetOrdinal("ProjectID"));
                    employeeProject.ProjectName = projectDetailsReader.GetString(projectDetailsReader.GetOrdinal("ProjectName"));
                    employeeProject.ClientName = projectDetailsReader.GetString(projectDetailsReader.GetOrdinal("ClientName"));
                    employeeProject.ProjectLocation = projectDetailsReader.GetString(projectDetailsReader.GetOrdinal("ProjectLocation"));
                    employeeProject.ProjectRoles = projectDetailsReader.GetString(projectDetailsReader.GetOrdinal("ProjectRoles"));
                    employeeProject.EmployeeID = projectDetailsReader.GetInt32(projectDetailsReader.GetOrdinal("EmployeeID"));
                }
                projectDetailsReader.Close();
                sqlCommand.Dispose();
                return employeeProject;
            }
            catch (Exception)
            {
                // Logging goes here
                throw;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }

        // Get Technical Details Table Values
        public Technical GetTechnicalData(string employeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                Technical employeeTechnical = new Technical();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeTechnicalDetails";

                sqlCommand.Parameters.Add("EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(employeeID);

                SqlDataReader technicalDetailsReader = sqlCommand.ExecuteReader();

                while (technicalDetailsReader.Read())
                {
                    employeeTechnical.EmployeeID = technicalDetailsReader.GetInt32(technicalDetailsReader.GetOrdinal("EmployeeID"));
                    employeeTechnical.ProgrammingLanguages = technicalDetailsReader.GetString(technicalDetailsReader.GetOrdinal("ProgrammingLanguages"));
                    employeeTechnical.DatabasesKnown = technicalDetailsReader.GetString(technicalDetailsReader.GetOrdinal("DatabasesKnown"));
                    employeeTechnical.ORMTechnologies = technicalDetailsReader.GetString(technicalDetailsReader.GetOrdinal("ORMTechnologies"));
                    employeeTechnical.UITechnologies = technicalDetailsReader.GetString(technicalDetailsReader.GetOrdinal("UITechnologies"));
                }
                technicalDetailsReader.Close();
                return employeeTechnical;
            }
            catch (Exception)
            {
                // Logging goes here
                throw;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }

        // Get Education Details Table Values
        public Educational GetEducationData(string employeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                Educational employeeEducation = new Educational();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeEducationalDetails";

                sqlCommand.Parameters.Add("EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(employeeID);

                SqlDataReader educationDetailsReader = sqlCommand.ExecuteReader();

                while (educationDetailsReader.Read())
                {
                    employeeEducation.EmployeeID = educationDetailsReader.GetInt32(educationDetailsReader.GetOrdinal("EmployeeID"));
                    employeeEducation.CourseType = educationDetailsReader.GetString(educationDetailsReader.GetOrdinal("CourseType"));
                    employeeEducation.CourseSpecialization = educationDetailsReader.GetString(educationDetailsReader.GetOrdinal("CourseSpecialization"));
                    employeeEducation.CourseYearofPassing = educationDetailsReader.GetString(educationDetailsReader.GetOrdinal("CourseYearOfPassing"));
                }
                educationDetailsReader.Close();
                return employeeEducation;
            }
            catch (Exception)
            {
                // Logging goes here
                throw;
            }
            finally
            {
                sqlCommand.Dispose();
                CloseConnection(sqlConnection);
            }
        }

        // To Display values        
        public List<Employee> ViewEmployeeData(string employeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                employeeData = new List<Employee>();
                string getPersonalInformationQuery = "SELECT FirstName, LastName, EmailID, MobileNumber, AddressState as State FROM EmployeePersonalDetails where EmployeeID = '" + employeeID + "'";
                sqlCommand = new SqlCommand(getPersonalInformationQuery, sqlConnection);
                SqlDataReader employeeDetailsReader = sqlCommand.ExecuteReader();
                while (employeeDetailsReader.Read())
                {
                    employeeData.Add(new Employee() { FirstName = employeeDetailsReader.GetString(employeeDetailsReader.GetOrdinal("FirstName")), LastName = employeeDetailsReader.GetString(employeeDetailsReader.GetOrdinal("LastName")), EmailID = employeeDetailsReader.GetString(employeeDetailsReader.GetOrdinal("EmailID")), MobileNumber = employeeDetailsReader.GetString(employeeDetailsReader.GetOrdinal("MobileNumber")), AddressState = employeeDetailsReader.GetString(employeeDetailsReader.GetOrdinal("LastName")) });
                }
                employeeDetailsReader.Close();
                return employeeData;
            }
            catch (Exception)
            {
                // Logging goes here
                throw;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }
        public List<Company> ViewCompanyData(string employeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                companyData = new List<Company>();
                string getCompanyInformationQuery = "SELECT CompanyName, CompanyContactNumber, CompanyLocation, CompanyWebsite FROM EmployeeCompanyDetails where EmployeeID = '" + employeeID + "'";
                sqlCommand = new SqlCommand(getCompanyInformationQuery, sqlConnection);
                SqlDataReader companyDetailsReader = sqlCommand.ExecuteReader();
                while (companyDetailsReader.Read())
                {
                    companyData.Add(new Company() { CompanyName = companyDetailsReader.GetString(companyDetailsReader.GetOrdinal("CompanyName")), CompanyContactNumber = companyDetailsReader.GetString(companyDetailsReader.GetOrdinal("CompanyContactNumber")), CompanyLocation = companyDetailsReader.GetString(companyDetailsReader.GetOrdinal("CompanyLocation")), CompanyWebsite = companyDetailsReader.GetString(companyDetailsReader.GetOrdinal("CompanyWebsite")) });
                }
                
                return companyData;
            }
            catch (Exception)
            {
                // Logging goes here
                throw;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }
        public List<Project> ViewProjectData(string EmployeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                projectData = new List<Project>();
                string getProjectInformationQuery = "SELECT ProjectName, ClientName, ProjectLocation, ProjectRoles FROM EmployeeProjectDetails where EmployeeID = '" + EmployeeID + "'";
                sqlCommand = new SqlCommand(getProjectInformationQuery, sqlConnection);
                SqlDataReader projectDetailsReader = sqlCommand.ExecuteReader();
                while (projectDetailsReader.Read())
                {
                    projectData.Add(new Project() { ProjectName = projectDetailsReader.GetString(projectDetailsReader.GetOrdinal("ProjectName")), ClientName = projectDetailsReader.GetString(projectDetailsReader.GetOrdinal("ClientName")), ProjectLocation = projectDetailsReader.GetString(projectDetailsReader.GetOrdinal("ProjectLocation")), ProjectRoles = projectDetailsReader.GetString(projectDetailsReader.GetOrdinal("ProjectRoles")) });
                }

                CloseConnection(sqlConnection);
                return projectData;
            }
            catch (Exception)
            {
                // Logging goes here
                throw;
            }
            finally
            {
                CloseConnection(sqlConnection);
            }
        }
    }
}
