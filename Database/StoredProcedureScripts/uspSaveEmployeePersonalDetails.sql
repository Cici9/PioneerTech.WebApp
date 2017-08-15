CREATE PROCEDURE uspSaveEmployeePersonalDetails
@EmployeeID INTEGER,
@FirstName varchar(50),
@LastName varchar(50),
@EmailID varchar(50),
@MobileNumber varchar(50),
@AlternateMobileNumber varchar(50),
@AddressLine1 varchar(100),
@AddressLine2 varchar(100),
@State varchar(50),
@Country varchar(50),
@ZipCode varchar(50),
@HomeCountry varchar(50)

AS
BEGIN
	IF(NOT EXISTS (SELECT EmployeeID FROM EmployeePersonalDetails WHERE EmployeeID = @EmployeeID))
		BEGIN
			Insert into EmployeePersonalDetails (FirstName, LastName, EmailID, MobileNumber, AlternateMobileNumber, AddressLine1, AddressLine2, AddressState, AddressCountry, AddressZipCode, HomeCountry) values (@FirstName, @LastName, @EmailID, @MobileNumber, @AlternateMobileNumber, @AddressLine1, @AddressLine2, @State, @Country, @ZipCode, @HomeCountry)
		END
	ELSE
		BEGIN
			UPDATE EmployeePersonalDetails
			SET FirstName = @FirstName, LastName = @LastName, EmailID = @EmailID, MobileNumber = @MobileNumber, AlternateMobileNumber = @AlternateMobileNumber, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, AddressState = @State, AddressCountry = @Country, AddressZipCode = @ZipCode, HomeCountry = @HomeCountry
			WHERE EmployeeID = @EmployeeID
		END
END