CREATE PROCEDURE uspGetEmployeeName
@EmployeeID INTEGER

AS
BEGIN
	SELECT FirstName, LastName FROM EmployeePersonalDetails WHERE EmployeeID = @EmployeeID
END
GO