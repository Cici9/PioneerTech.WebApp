CREATE PROCEDURE uspGetEmployeeCompanyDetails
@EmployeeID INTEGER

AS
BEGIN
	SELECT * FROM EmployeeCompanyDetails WHERE EmployeeID = @EmployeeID
END