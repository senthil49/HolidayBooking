using HolidayBooking.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayBooking.Services
{
   public interface IDataService
    {

       Feedback<List<LeaveRecord>> GetUpcomingHolidays();

        int AddEmployee(EmployeeRecord empRecord);

       Feedback<ObservableCollection<EmployeeRecord>> GetEmployees();

        int GetLeavesRemaining(int SelectedEmployeeID);

        Feedback<string> BookHoliday(LeaveRecord leaveRecord);

        void UpdateEmployeeDormantFlag(int empID, bool dormantFlag);
    }
}
