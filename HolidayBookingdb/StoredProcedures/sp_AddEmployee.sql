
CREATE PROCEDURE [crud].[AddEmployee] (@EmpName NVARCHAR(MAX), @DateOfJoining Date, @HolidaysEntitled INT, @Dormant Bit)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

Insert into [crud].Employee values (@EmpName, @DateOfJoining, @HolidaysEntitled, @Dormant)
select @@IDENTITY as newEmpID
   
END

GO
