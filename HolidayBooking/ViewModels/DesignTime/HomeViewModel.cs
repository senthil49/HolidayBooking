using HolidayBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayBooking.ViewModels.DesignTime
{
   public class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        public HomeViewModel()
        {
            this.UpcomingHolidays = new List<LeaveRecord>
            {
                new LeaveRecord { EmployeeName = "SKR", DateFrom = new DateTime(2015, 01, 19), DateTo = new DateTime(2015, 01, 20), RemainingLeaves = 12 },
                new LeaveRecord { EmployeeName = "CL", DateFrom = new DateTime(2015, 01, 19),  DateTo = new DateTime(2015, 01, 30), RemainingLeaves = 14 },
                new LeaveRecord { EmployeeName = "PZ", DateFrom = new DateTime(2015, 01, 19), DateTo = new DateTime(2015, 02, 10), RemainingLeaves = 2 }
            };
        }

        /// <summary>
        /// Gets or sets the upcoming holidays.
        /// </summary>
        public List<LeaveRecord> UpcomingHolidays { get; set; } 

    }
}
