CREATE PROCEDURE [crud].[GetRemainingLeaves](@EmpID int)
	
AS
BEGIN
	
	select RemainingLeaves from crud.EmployeeHolidays 
	where ID in (select Max(ID) from crud.EmployeeHolidays where EmpID = @EmpID)

END


GO


