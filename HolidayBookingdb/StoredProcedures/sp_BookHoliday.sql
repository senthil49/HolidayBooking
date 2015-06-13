CREATE PROCEDURE [crud].[BookHoliday] (@EmpID INT, @EmpName NVARCHAR(MAX), @RemainingLeaves INT, @HolidayBookedFrom Date, @HolidayBookedTill Date, @Reason NVARCHAR(MAX))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

Insert into [crud].EmployeeHolidays values (
@EmpID,
@RemainingLeaves, 
@HolidayBookedFrom, 
@HolidayBookedTill, 
@Reason)
   
END

GO


