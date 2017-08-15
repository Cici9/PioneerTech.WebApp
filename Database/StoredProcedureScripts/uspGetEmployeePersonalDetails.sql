CREATE PROCEDURE uspGetEmployeePersonalDetails
@EmployeeID INTEGER

AS
BEGIN
	SELECT * FROM EmployeePersonalDetails WHERE EmployeeID = @EmployeeID
END
GO