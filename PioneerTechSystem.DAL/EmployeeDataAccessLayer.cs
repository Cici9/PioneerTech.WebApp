﻿using System;
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

        // Save Employee Personal Details
        public string SaveEmployeePersonalDetails(Employee EmployeeObj)
        {
            try
            {
                string returnValue;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEmployeePersonalDetails";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = EmployeeObj.EmployeeID;
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
                
                returnValue = sqlCommand.ExecuteNonQuery().ToString();
                return returnValue;
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.ToString();
            }
            finally
            {
                sqlCommand.Dispose();
                CloseConnection(sqlConnection);
            }
        }

        // Save Employee Company Details
        public string SaveEmployeeCompanyDetails(Company CompanyObj)
        {
            try
            {
                string returnValue;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEmployeeCompanyDetails";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = CompanyObj.EmployeeID;
                sqlCommand.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = CompanyObj.CompanyName;
                sqlCommand.Parameters.Add("@CompanyContactNumber", SqlDbType.VarChar).Value = CompanyObj.CompanyContactNumber;
                sqlCommand.Parameters.Add("@CompanyLocation", SqlDbType.VarChar).Value = CompanyObj.CompanyLocation;
                sqlCommand.Parameters.Add("@CompanyWebsite", SqlDbType.VarChar).Value = CompanyObj.CompanyWebsite;

                returnValue = sqlCommand.ExecuteNonQuery().ToString();
                return returnValue;
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.ToString();
            }
            finally
            {
                sqlCommand.Dispose();
                CloseConnection(sqlConnection);
            }
        }


        // Save Employee Project Details
        public string SaveEmployeeProjectDetails(Project ProjectObj)
        {
            try
            {
                string returnVaue;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEmployeeProjectDetails";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = ProjectObj.EmployeeID;
                sqlCommand.Parameters.Add("@ProjectName", SqlDbType.VarChar).Value = ProjectObj.ProjectName;
                sqlCommand.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = ProjectObj.ClientName;
                sqlCommand.Parameters.Add("@ProjectLocation", SqlDbType.VarChar).Value = ProjectObj.ProjectLocation;
                sqlCommand.Parameters.Add("@ProjectRoles", SqlDbType.VarChar).Value = ProjectObj.ProjectRoles;

                returnVaue = sqlCommand.ExecuteNonQuery().ToString();

                return returnVaue;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                CloseConnection(sqlConnection);
            }
        }

        // Save Employee Technical Details
        public string SaveEmployeeTechnicalDetails(Technical TechnicalObj)
        {
            try
            {
                string returnVaue;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEmployeeTechnicalDetails";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = TechnicalObj.EmployeeID;
                sqlCommand.Parameters.Add("@ProgrammingLanguages", SqlDbType.VarChar).Value = TechnicalObj.ProgrammingLanguages;
                sqlCommand.Parameters.Add("@DatabasesKnown", SqlDbType.VarChar).Value = TechnicalObj.DatabasesKnown;
                sqlCommand.Parameters.Add("@ORMTechnologies", SqlDbType.VarChar).Value = TechnicalObj.ORMTechnologies;
                sqlCommand.Parameters.Add("@UITechnologies", SqlDbType.VarChar).Value = TechnicalObj.UITechnologies;

                returnVaue = sqlCommand.ExecuteNonQuery().ToString();

                return returnVaue;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                CloseConnection(sqlConnection);
            }
        }

        // Save Employee Education Details
        public string SaveEmployeeEducationDetails(Educational EducationalObj)
        {
            try
            {
                string returnVaue;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEmployeeEducationalDetails";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = EducationalObj.EmployeeID;
                sqlCommand.Parameters.Add("@CourseType", SqlDbType.VarChar).Value = EducationalObj.CourseType;
                sqlCommand.Parameters.Add("@CourseSpecialization", SqlDbType.VarChar).Value = EducationalObj.CourseSpecialization;
                sqlCommand.Parameters.Add("@CourseYearOfPassing", SqlDbType.VarChar).Value = EducationalObj.CourseYearofPassing;

                returnVaue = sqlCommand.ExecuteNonQuery().ToString();

                return returnVaue;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                CloseConnection(sqlConnection);
            }
        }

        // Get particular Employee Name
        public string GetEmployeeName(string EmployeeID)
        {
            try
            {
                string EmployeeName = null;
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeName";

                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = EmployeeID;

                SqlDataReader GetNameReader = sqlCommand.ExecuteReader();

                while (GetNameReader.Read())
                {
                    EmployeeName = GetNameReader.GetString(GetNameReader.GetOrdinal("LastName")) + ", " + GetNameReader.GetString(GetNameReader.GetOrdinal("FirstName"));
                }

                return EmployeeName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                CloseConnection(sqlConnection);
            }
        }

        // Get all the EmployeeID
        public List<Employee> GetEmployeeID()
        {
            try
            {
                sqlConnection = OpenConnection();
                EmployeeData = new List<Employee>();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeIDDetails";

                SqlDataReader EmployeeDetailsReader = sqlCommand.ExecuteReader();

                while (EmployeeDetailsReader.Read())
                {
                    int id = EmployeeDetailsReader.GetInt32(EmployeeDetailsReader.GetOrdinal("EmployeeID"));
                    EmployeeData.Add(new Employee() { EmployeeID = EmployeeDetailsReader.GetInt32(EmployeeDetailsReader.GetOrdinal("EmployeeID")) });
                }
                EmployeeDetailsReader.Close();

                //EmployeeData = EmployeeData.Where(data => data != null).ToList();
                return EmployeeData;
            }
            catch (Exception ex)
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

        // Get Personal Details Table Values
        public Employee GetPersonalData(string EmployeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                Employee SelectedEmployee = new Employee();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeePersonalDetails";

                sqlCommand.Parameters.Add("EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(EmployeeID);

                SqlDataReader EmployeeDetailsReader = sqlCommand.ExecuteReader();

                while (EmployeeDetailsReader.Read())
                {
                    SelectedEmployee.EmployeeID = EmployeeDetailsReader.GetInt32(EmployeeDetailsReader.GetOrdinal("EmployeeID"));
                    SelectedEmployee.FirstName = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("FirstName"));
                    SelectedEmployee.LastName = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("LastName"));
                    SelectedEmployee.EmailID = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("EmailID"));
                    SelectedEmployee.MobileNumber = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("MobileNumber"));
                    SelectedEmployee.AlternateMobileNumber = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("AlternateMobileNumber"));
                    SelectedEmployee.AddressLine1 = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("AddressLine1"));
                    SelectedEmployee.AddressLine2 = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("AddressLine2"));
                    SelectedEmployee.AddressState = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("AddressState"));
                    SelectedEmployee.AddressCountry = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("AddressCountry"));
                    SelectedEmployee.AddressZipCode = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("AddressState"));
                    SelectedEmployee.HomeCountry = EmployeeDetailsReader.GetString(EmployeeDetailsReader.GetOrdinal("HomeCountry"));
                }
                EmployeeDetailsReader.Close();
                return SelectedEmployee;
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

        // Get Company Details Table Values
        public Company GetCompanyData(string EmployeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                Company employeeCompany = new Company();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeCompanyDetails";

                sqlCommand.Parameters.Add("EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(EmployeeID);

                SqlDataReader CompanyDetailsReader = sqlCommand.ExecuteReader();

                while (CompanyDetailsReader.Read())
                {
                    employeeCompany.EmployeeID = CompanyDetailsReader.GetInt32(CompanyDetailsReader.GetOrdinal("EmployeeID"));
                    employeeCompany.CompanyName = CompanyDetailsReader.GetString(CompanyDetailsReader.GetOrdinal("CompanyName"));
                    employeeCompany.CompanyContactNumber = CompanyDetailsReader.GetString(CompanyDetailsReader.GetOrdinal("CompanyContactNumber"));
                    employeeCompany.CompanyLocation = CompanyDetailsReader.GetString(CompanyDetailsReader.GetOrdinal("CompanyLocation"));
                    employeeCompany.CompanyWebsite = CompanyDetailsReader.GetString(CompanyDetailsReader.GetOrdinal("CompanyWebsite"));
                }
                CompanyDetailsReader.Close();
                return employeeCompany;
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

        // Get Company Details Table Values
        public Project GetProjectData(string EmployeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                Project employeeProject = new Project();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeProjectDetails";

                sqlCommand.Parameters.Add("EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(EmployeeID);

                SqlDataReader ProjectDetailsReader = sqlCommand.ExecuteReader();

                while (ProjectDetailsReader.Read())
                {
                    employeeProject.ProjectID = ProjectDetailsReader.GetInt32(ProjectDetailsReader.GetOrdinal("ProjectID"));
                    employeeProject.ProjectName = ProjectDetailsReader.GetString(ProjectDetailsReader.GetOrdinal("ProjectName"));
                    employeeProject.ClientName = ProjectDetailsReader.GetString(ProjectDetailsReader.GetOrdinal("ClientName"));
                    employeeProject.ProjectLocation = ProjectDetailsReader.GetString(ProjectDetailsReader.GetOrdinal("ProjectLocation"));
                    employeeProject.ProjectRoles = ProjectDetailsReader.GetString(ProjectDetailsReader.GetOrdinal("ProjectRoles"));
                    employeeProject.EmployeeID = ProjectDetailsReader.GetInt32(ProjectDetailsReader.GetOrdinal("EmployeeID"));
                }
                ProjectDetailsReader.Close();
                return employeeProject;
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

        // Get Technical Details Table Values
        public Technical GetTechnicalData(string EmployeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                Technical employeeTechnical = new Technical();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeTechnicalDetails";

                sqlCommand.Parameters.Add("EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(EmployeeID);

                SqlDataReader TechnicalDetailsReader = sqlCommand.ExecuteReader();

                while (TechnicalDetailsReader.Read())
                {
                    employeeTechnical.EmployeeID = TechnicalDetailsReader.GetInt32(TechnicalDetailsReader.GetOrdinal("EmployeeID"));
                    employeeTechnical.ProgrammingLanguages = TechnicalDetailsReader.GetString(TechnicalDetailsReader.GetOrdinal("ProgrammingLanguages"));
                    employeeTechnical.DatabasesKnown = TechnicalDetailsReader.GetString(TechnicalDetailsReader.GetOrdinal("DatabasesKnown"));
                    employeeTechnical.ORMTechnologies = TechnicalDetailsReader.GetString(TechnicalDetailsReader.GetOrdinal("ORMTechnologies"));
                    employeeTechnical.UITechnologies = TechnicalDetailsReader.GetString(TechnicalDetailsReader.GetOrdinal("UITechnologies"));
                }
                TechnicalDetailsReader.Close();
                return employeeTechnical;
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

        // Get Education Details Table Values
        public Educational GetEducationData(string EmployeeID)
        {
            try
            {
                sqlConnection = OpenConnection();
                Educational employeeEducation = new Educational();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeEducationalDetails";

                sqlCommand.Parameters.Add("EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(EmployeeID);

                SqlDataReader EducationDetailsReader = sqlCommand.ExecuteReader();

                while (EducationDetailsReader.Read())
                {
                    employeeEducation.EmployeeID = EducationDetailsReader.GetInt32(EducationDetailsReader.GetOrdinal("EmployeeID"));
                    employeeEducation.CourseType = EducationDetailsReader.GetString(EducationDetailsReader.GetOrdinal("CourseType"));
                    employeeEducation.CourseSpecialization = EducationDetailsReader.GetString(EducationDetailsReader.GetOrdinal("CourseSpecialization"));
                    employeeEducation.CourseYearofPassing = EducationDetailsReader.GetString(EducationDetailsReader.GetOrdinal("CourseYearOfPassing"));
                }
                EducationDetailsReader.Close();
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
        public List<Employee> ViewEmployeeData(string EmployeeID)
        {
            try
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
                return EmployeeData;
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
        public List<Company> ViewCompanyData(string EmployeeID)
        {
            try
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
                
                return CompanyData;
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
        public List<Project> ViewProjectData(string EmployeeID)
        {
            try
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
    }
}
