CREATE PROCEDURE uspGetEmployeeProjectDetails
@EmployeeID INTEGER

AS
BEGIN
	SELECT * FROM EmployeeProjectDetails WHERE EmployeeID = @EmployeeID
END
GO