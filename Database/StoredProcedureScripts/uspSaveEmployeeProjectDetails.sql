CREATE PROCEDURE uspSaveEmployeeProjectDetails
@ProjectName VARCHAR(50),
@ClientName VARCHAR(50),
@ProjectLocation VARCHAR(50),
@ProjectRoles VARCHAR(50),
@EmployeeID INTEGER

AS
BEGIN
	IF(NOT EXISTS(SELECT * FROM EmployeeProjectDetails WHERE EmployeeID = @EmployeeID))
		BEGIN
			INSERT INTO EmployeeProjectDetails(ProjectName, ClientName, ProjectLocation, ProjectRoles, EmployeeID) VALUES (@ProjectName, @ClientName, @ProjectLocation, @ProjectRoles, @EmployeeID)
		END
	ELSE
		BEGIN
			UPDATE EmployeeProjectDetails
			SET ProjectName = @ProjectName, ClientName = @ClientName, ProjectLocation = @ProjectLocation, ProjectRoles = @ProjectRoles
			WHERE EmployeeID = @EmployeeID
		END
END