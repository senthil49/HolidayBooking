using HolidayBooking.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayBooking.Repository
{
   public interface IHolidayDbRepository
    {
        List<LeaveRecord> GetUpcomingHolidays();
        ObservableCollection<EmployeeRecord> GetEmployees();
        int GetLeavesRemaining(int EmployeeID);
        int AddEmployee(EmployeeRecord empRecord);
        void UpdateEmployeeDormantFlag(int empID, bool dormantFlag);
        Feedback<string> BookHoliday(LeaveRecord leaveRecord);

    }
}
