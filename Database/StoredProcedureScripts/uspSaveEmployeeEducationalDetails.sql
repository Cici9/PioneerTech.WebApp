CREATE PROCEDURE uspSaveEmployeeEducationalDetails
@EmployeeID INTEGER,
@CourseType VARCHAR(50),
@CourseSpecialization VARCHAR(50),
@CourseYearOfPassing VARCHAR(50)

AS
BEGIN
	IF(NOT EXISTS(SELECT * FROM EmployeeEducationalDetails WHERE EmployeeID = @EmployeeID))
		BEGIN
			INSERT INTO EmployeeEducationalDetails(EmployeeID, CourseType, CourseSpecialization, CourseYearOfPassing) VALUES (@EmployeeID, @CourseType, @CourseSpecialization, @CourseYearOfPassing)
		END
	ELSE
		BEGIN
			UPDATE EmployeeEducationalDetails
			SET CourseType = @CourseType, CourseSpecialization = @CourseSpecialization, CourseYearOfPassing = @CourseYearOfPassing
			WHERE EmployeeID = @EmployeeID
		END
END