CREATE PROCEDURE [report].[GetUpcomingHolidays]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

	declare @Today date = getDate()
	
	select 
		Emp.ID as EmployeeID,
		Emp.EmpName as EmployeeName,
		EmpH.HolidayBookedFrom as DateFrom,
		EmpH.HolidayBookedTill as DateTo,
		EmpH.RemainingLeaves,
		EmpH.Reason
	from [crud].Employee Emp 
	join [crud].EmployeeHolidays EmpH on Emp.ID = EmpH.EmpID
	where Emp.Dormant !=  1 and EmpH.HolidayBookedFrom > @Today
	Order By EmpH.HolidayBookedFrom 

END

GO
