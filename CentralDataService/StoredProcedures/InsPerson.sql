--===========================================
-- Insert a person's data.
--===========================================
CREATE PROCEDURE [dbo].[InsPerson]
@AGE INT,
@NAME VARCHAR(50) = NULL

AS

SET NOCOUNT ON
SET xACT_ABORT ON

BEGIN
	INSERT INTO Persons (Name, Age)
	VALUES (@NAME, @AGE);
END
GO