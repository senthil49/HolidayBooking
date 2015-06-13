namespace HolidayBooking.Models
{
    using System.Linq;

    using HolidayBooking.Commands;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The employee record.
    /// </summary>
    public class EmployeeRecord : INotifyPropertyChanged, IDataErrorInfo
    {
        /// <summary>
        /// Gets or sets the employee name.
        /// </summary>
        public string employeeName;

        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int employeeId;

        private bool dormant;

        public bool Dormant
        {
            get
            {
                return this.dormant;
            }
            set
            {
                this.dormant = value;
                this.OnPropertyChanged("Dormant");
            }
        }

        /// <summary>
        /// Gets or sets the joining date.
        /// </summary>
        public DateTime joiningDate;

        /// <summary>
        /// Gets or sets the holidays entitled.
        /// </summary>
        public int holidaysEntitled;

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int EmployeeId
        {
            get
            {
                return this.employeeId;
            }

            set
            {
                this.employeeId = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the employee name.
        /// </summary>
        public string EmployeeName
        {
            get
            {
                return this.employeeName;
            }

            set
            {
                this.employeeName = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the joining date.
        /// </summary>
        public DateTime JoiningDate
        {
            get
            {
                return this.joiningDate;
            }

            set
            {
                this.joiningDate = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the holidays entitled.
        /// </summary>
        public int HolidaysEntitled 
        {
            get
            {
                return this.holidaysEntitled;
            }

            set
            {
                this.holidaysEntitled = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="caller">
        /// The caller.
        /// </param>
        private void OnPropertyChanged(
          [CallerMemberName] string caller = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "EmployeeName" && this.EmployeeName != null)
                {
                    return this.EmployeeName.Any(char.IsDigit) ? "incorrect name" : string.Empty;
                }

                return null;
            }
        }
    }
}
