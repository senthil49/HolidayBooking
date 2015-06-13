using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HolidayBooking.Models
{
    /// <summary>
    /// The leave record.
    /// </summary>
    public class LeaveRecord : INotifyPropertyChanged
    {

        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int EmployeeId
        {
            get { return employeeId; }
            set
            {
                this.employeeId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the employee name.
        /// </summary>
        public string EmployeeName
        {
            get { return employeeName; }
            set
            {
                this.employeeName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the date from.
        /// </summary>
        public DateTime DateFrom
        {
            get { return dateFrom; }
            set
            {
                this.dateFrom = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the date to.
        /// </summary>
        public DateTime DateTo
        {
            get { return dateTo; }
            set
            {
                this.dateTo = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the remaining leaves.
        /// </summary>
        public int RemainingLeaves 
        {
            get { return remainingLeaves; } 
            set
            {
                this.remainingLeaves = value;
                OnPropertyChanged();
            } 
        }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        public string Reason
        {
            get 
            { 
                return reason; 
            }
            set
            {
                this.reason = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string employeeName { get; set; }
        private string reason { get; set; }
        private int employeeId { get; set; }
        private int remainingLeaves { get; set; }
        private DateTime dateFrom { get; set; }
        private DateTime dateTo { get; set; }

        private void OnPropertyChanged(
             [CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }


        //public string Error
        //{
        //    get { return string.Empty; }
        //}

        //public string this[string propertyName]
        //{
        //    get { return GetErrorForProperty(propertyName); }
        //}

        //private string GetErrorForProperty(string propertyName)
        //{
        //    switch (propertyName)
        //    {
        //        case "DateFrom":
        //            if (DateFrom < DateTime.Today)
        //            {
        //                return "invalid date";
        //            }
        //            else return string.Empty;

        //        default:
        //            return string.Empty;
        //    }
        //}
    }
}
