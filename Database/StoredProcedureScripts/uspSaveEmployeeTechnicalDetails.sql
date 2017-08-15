CREATE PROCEDURE uspSaveEmployeeTechnicalDetails
@EmployeeID INTEGER,
@ProgrammingLanguages VARCHAR(50),
@DatabasesKnown VARCHAR(50),
@ORMTechnologies VARCHAR(50),
@UITechnologies VARCHAR(50)

AS
BEGIN
	IF(NOT EXISTS(SELECT * FROM EmployeeTechnicalDetails WHERE EmployeeID = @EmployeeID))
		BEGIN
			INSERT INTO EmployeeTechnicalDetails(EmployeeID, ProgrammingLanguages, DatabasesKnown, ORMTechnologies, UITechnologies) VALUES (@EmployeeID, @ProgrammingLanguages, @DatabasesKnown, @ORMTechnologies, @UITechnologies)
		END
	ELSE
		BEGIN
			UPDATE EmployeeTechnicalDetails
			SET ProgrammingLanguages = @ProgrammingLanguages, DatabasesKnown = @DatabasesKnown, ORMTechnologies = @ORMTechnologies, UITechnologies = @UITechnologies
			WHERE EmployeeID = @EmployeeID
		END
END