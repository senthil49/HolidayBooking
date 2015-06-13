using HolidayBooking.Models;
using HolidayBooking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HolidayBooking.ViewModels.DesignTime
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// The add employee view model.
    /// </summary>
    public class AddEmployeeViewModel : BaseViewModel, IAddEmployeeViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddEmployeeViewModel"/> class.
        /// </summary>
        public AddEmployeeViewModel()
       {
           this.EmployeeRecord = new EmployeeRecord() { EmployeeName = "New Employee", HolidaysEntitled = 20, JoiningDate = new DateTime(2015, 01, 19) };

            this.EmployeesList = new ObservableCollection<EmployeeRecord>
                                                                        {
                                           new EmployeeRecord { EmployeeName = "SKR", HolidaysEntitled = 20, JoiningDate = new DateTime(2014, 06, 02), Dormant = false },
                                           new EmployeeRecord { EmployeeName = "TC", HolidaysEntitled = 20, JoiningDate = new DateTime(2014, 02, 02), Dormant = false },
                                           new EmployeeRecord { EmployeeName = "MC", HolidaysEntitled = 20, JoiningDate = new DateTime(2013, 10, 01), Dormant = true },
                                                                        }; 
       }

        /// <summary>
        /// Gets or sets the employee record.
        /// </summary>
        public EmployeeRecord EmployeeRecord { get; set; }

        /// <summary>
        /// Gets or sets the employees list.
        /// </summary>
        public ObservableCollection<EmployeeRecord> EmployeesList { get; set; }
    }
}
