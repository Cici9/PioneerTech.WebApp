CREATE PROCEDURE uspSaveEmployeeCompanyDetails
@EmployeeID INTEGER,
@CompanyName VARCHAR(50),
@CompanyContactNumber VARCHAR(20),
@CompanyLocation VARCHAR(50),
@CompanyWebsite VARCHAR(50)

AS
BEGIN
	IF(NOT EXISTS(SELECT * FROM EmployeeCompanyDetails WHERE EmployeeID = @EmployeeID))
		BEGIN
			INSERT INTO EmployeeCompanyDetails (EmployeeID, CompanyName, CompanyContactNumber, CompanyLocation, CompanyWebsite) VALUES (@EmployeeID, @CompanyName, @CompanyContactNumber, @CompanyLocation, @CompanyWebsite)
		END
	ELSE
		BEGIN
			UPDATE EmployeeCompanyDetails
			SET CompanyName = @CompanyName, CompanyContactNumber = @CompanyName, CompanyLocation = @CompanyLocation, CompanyWebsite = @CompanyWebsite
			WHERE EmployeeID = @EmployeeID
		END
END
GO