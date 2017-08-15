CREATE PROCEDURE uspGetEmployeeEducationalDetails
@EmployeeID INTEGER

AS
BEGIN
	SELECT * FROM EmployeeEducationalDetails WHERE EmployeeID = @EmployeeID
END