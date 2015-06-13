using HolidayBooking.Models;
using HolidayBooking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayBooking.ViewModels.DesignTime
{
   public class BookHolidaysViewModel: BaseViewModel, IBookHolidaysViewModel
    {
       public BookHolidaysViewModel()
       {
           this.LeaveRecord = new LeaveRecord() { EmployeeName = "Senthil Rajendran", DateFrom = new DateTime(2015, 02, 07), DateTo = new DateTime(2015, 02, 23), Reason = "Vacation", RemainingLeaves = 10 };
           this.EmployeesList = new List<EmployeeRecord>() { new EmployeeRecord(){ EmployeeId = 1, EmployeeName = "SKR", HolidaysEntitled=20, JoiningDate=new DateTime(2015,01,01)}};
           this.DateFrom = new DateTime(2015, 02, 07);
           this.DateTo = new DateTime(2015, 02, 23);
           this.Reason = "Vacation"; 
           this.RemainingLeaves = 10; 
           this.LeaveRemaining = 12;
       }

       public LeaveRecord LeaveRecord { get; set; }

       public List<EmployeeRecord> EmployeesList {get; set;}

       public int LeaveRemaining { get; set; }

       public int RemainingLeaves { get; set; }

       public string Reason { get; set; }

       public DateTime DateTo { get; set; }

       public DateTime DateFrom { get; set; }
    }
}
