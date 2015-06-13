
CREATE PROCEDURE [report].[GetEmployees]

AS
BEGIN
	
	select 
		Emp.ID as EmployeeID,
		Emp.EmpName as EmployeeName,
		Emp.DateOfJoining as JoiningDate,
		Emp.HolidaysEntitled as HolidaysEntitled,
		Emp.Dormant as Dormant
		
	from [crud].Employee Emp 
	where Dormant = 0
	order by Emp.DateOfJoining asc

END


GO
