//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HolidayBooking.Models
{
    using System;
    
    public partial class GetUpcomingHolidays_Result
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<System.DateTime> DateFrom { get; set; }
        public Nullable<System.DateTime> DateTo { get; set; }
        public Nullable<int> RemainingLeaves { get; set; }
        public string Reason { get; set; }
    }
}
