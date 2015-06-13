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
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.EmployeeHolidays = new HashSet<EmployeeHoliday>();
        }
    
        public int ID { get; set; }
        public string EmpName { get; set; }
        public Nullable<System.DateTime> DateOfJoining { get; set; }
        public Nullable<int> HolidaysEntitled { get; set; }
        public Nullable<bool> Dormant { get; set; }
    
        public virtual ICollection<EmployeeHoliday> EmployeeHolidays { get; set; }
    }
}
