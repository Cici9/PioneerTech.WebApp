CREATE PROCEDURE uspGetEmployeeTechnicalDetails
@EmployeeID INTEGER

AS
BEGIN
	SELECT * FROM EmployeeTechnicalDetails WHERE EmployeeID = @EmployeeID
END
GO