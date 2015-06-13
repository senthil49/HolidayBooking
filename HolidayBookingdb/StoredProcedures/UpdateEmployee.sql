CREATE PROCEDURE [crud].[UpdateEmployee] (@EmpID INT, @Dormant bit)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DECLARE @found int = -99;
SELECT @found = ID FROM [crud].Employee WHERE ID = @EmpID

IF @found != -99
	BEGIN
		Update [crud].Employee Set Dormant = @Dormant where ID = @EmpID
	END   
END

GO