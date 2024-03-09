--===========================================
-- Returns all people who have inserted data.
--===========================================
CREATE PROCEDURE [dbo].[GetPeople]
AS

SET NOCOUNT ON
SET xACT_ABORT ON

BEGIN
	SELECT Id, Age, Name FROM Persons;
END
GO