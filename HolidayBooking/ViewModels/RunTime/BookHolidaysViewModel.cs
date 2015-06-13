namespace HolidayBooking.ViewModels.RunTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    using HolidayBooking.Commands;
    using HolidayBooking.Models;
    using HolidayBooking.Services;
    using HolidayBooking.Views;
    using System.Collections.ObjectModel;
    using HolidayBooking.Repository;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;

    /// <summary>
    /// The book holidays view model.
    /// </summary>
    public class BookHolidaysViewModel: BaseViewModel, IBookHolidaysViewModel, IDataErrorInfo
    {
        /// <summary>
        /// The selected employee id.
        /// </summary>
        private int selectedEmployeeId;

        private int daystaken;

        /// <summary>
        /// The data service.
        /// </summary>
        private IDataService dataService = new DataService();

        private IHolidayDbRepository holidayDbRepository = new HolidayDbRepository();

        /// <summary>
        /// The selected employee.
        /// </summary>
        private string selectedEmployee;

        /// <summary>
        /// The employee list.
        /// </summary>
        private ObservableCollection<EmployeeRecord> employeeList;

        /// <summary>
        /// The employee names.
        /// </summary>
        private List<string> employeeNames;

        /// <summary>
        /// The leave remaining.
        /// </summary>
        private int leaveRemaining;

        /// <summary>
        /// The date from.
        /// </summary>
        private DateTime dateFrom;

        /// <summary>
        /// The date to.
        /// </summary>
        private DateTime dateTo;

        /// <summary>
        /// The reason.
        /// </summary>
        private string reason;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookHolidaysViewModel"/> class.
        /// </summary>
        public BookHolidaysViewModel()
        {
            this.LoadEmployees();
            this.SaveCommand = new DelegateCommand(this.SaveLeave, this.CanSave);
            this.HomeCommand = new DelegateCommand(this.GoHomeView);
            this.BookHolidaysCommand = new DelegateCommand(this.GoBookHolidaysView);
            this.AddEmployeeCommand = new DelegateCommand(this.GoAddEmployeeView);
            this.ReportsCommand = new DelegateCommand(this.GoReportsView);

            TimeSpan ts = this.DateTo - this.DateFrom;
            this.DaysTaken = (int)ts.TotalDays + 1;

            //tbc nav command to be added
        }

        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Gets or sets the home command.
        /// </summary>
        public ICommand HomeCommand { get; set; }

        /// <summary>
        /// Gets or sets the Reports command.
        /// </summary>
        public ICommand ReportsCommand { get; set; }

        /// <summary>
        /// Gets or sets the book holidays command.
        /// </summary>
        public ICommand BookHolidaysCommand { get; set; }

        /// <summary>
        /// Gets or sets the home command.
        /// </summary>
        public ICommand AddEmployeeCommand { get; set; }
 
        /// <summary>
        /// Gets or sets the date from.
        /// </summary>
        public DateTime DateFrom
        {
            get
            {
                if (this.dateFrom == new DateTime(0001, 01, 01))
                {
                    this.dateFrom = DateTime.Today;
                }   
                 
                return this.dateFrom;
            }

           set
            {
                this.dateFrom = value;
                this.OnPropertyChanged("DateFrom");
                TimeSpan ts = this.DateTo - this.DateFrom;
                this.DaysTaken = (int)ts.TotalDays + 1;
                ((DelegateCommand)this.SaveCommand).RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets or sets the date to.
        /// </summary>
        public DateTime DateTo
       {
           get
           {
               if (this.dateTo == new DateTime(0001, 01, 01))
               {
                   this.dateTo = DateTime.Today.AddDays(1);
               }
               return this.dateTo;
           }

           set
           {
               this.dateTo = value;
               this.OnPropertyChanged("DateTo");
               TimeSpan ts = this.DateTo - this.DateFrom;
               this.DaysTaken = (int)ts.TotalDays + 1;
               ((DelegateCommand)this.SaveCommand).RaiseCanExecuteChanged();
           }
       }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        public string Reason
       {
           get
           {
               return this.reason;
           }

           set
           {
               this.reason = value;
               this.OnPropertyChanged();
           }
       }

        /// <summary>
        /// Gets or sets the employees list.
        /// </summary>
        public ObservableCollection<EmployeeRecord> EmployeesList 
        {
            get 
            { 
                return this.employeeList; 
            }

            set 
            { 
                this.employeeList = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the leave remaining.
        /// </summary>
        public int LeaveRemaining 
        {
            get 
            { 
                return this.leaveRemaining; 
            } 

            set
            {
                this.leaveRemaining = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the employee names.
        /// </summary>
        public List<string> EmployeeNames
        {
            get
            {
                return this.employeeNames;
            }

            set
            {
                this.employeeNames = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected employee.
        /// </summary>
        public string SelectedEmployee 
        {
            get
            {
                return this.selectedEmployee;
            }

            set
            {
                this.selectedEmployee = value;
                this.OnPropertyChanged();

                this.selectedEmployeeId = this.EmployeesList.Where(x => x.EmployeeName == this.selectedEmployee).Select(z => z.EmployeeId).FirstOrDefault();
                this.LeaveRemaining = this.dataService.GetLeavesRemaining(this.selectedEmployeeId);
                ((DelegateCommand)this.SaveCommand).RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets or sets the days taken.
        /// </summary>
        public int DaysTaken 
        {
            get 
            { 
                return this.daystaken; 
            }

            set
            {
                this.daystaken = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public string Error
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Gets or sets the close action.
        /// </summary>
        public Action CloseAction { get; set; }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string this[string propertyName]
        {
            get { return this.GetErrorForProperty(propertyName); }
        }

        /// <summary>
        /// The go home view.
        /// </summary>
        private void GoHomeView()
        {
            var newHomeView = new HomeView { WindowStartupLocation = WindowStartupLocation.CenterScreen };
            newHomeView.Show();
            this.CloseAction();
        }

        /// <summary>
        /// The go book holidays view.
        /// </summary>
        private void GoBookHolidaysView()
        {
            var newBookHolidayView = new BookHolidaysView { WindowStartupLocation = WindowStartupLocation.CenterScreen };
            newBookHolidayView.Show();
            this.CloseAction();
        }

        private void GoAddEmployeeView()
        {
            var newAddEmployeeView = new AddEmployeeView { WindowStartupLocation = WindowStartupLocation.CenterScreen };
            newAddEmployeeView.Show();
            this.CloseAction();
        }


        private void GoReportsView(object obj)
        {
            var newReportsView = new ReportsView { WindowStartupLocation = WindowStartupLocation.CenterScreen };
            newReportsView.Show();
            this.CloseAction();
        }

        /// <summary>
        /// The load employees.
        /// </summary>
        private void LoadEmployees()
        {
            this.EmployeesList = new ObservableCollection<EmployeeRecord>();
            
            // using ADO.NET
            //var result = this.dataService.GetEmployees();
            //this.EmployeesList = result.Data;
            

            // using EF
            using (var context = new HolidayBookingEntities())
            {
                var _empList = context.GetEmployees().ToList();
                foreach (var emp in _empList)
                	{
                        var _empRec = new EmployeeRecord();

                        _empRec.EmployeeId = emp.EmployeeID;
                        _empRec.EmployeeName = emp.EmployeeName;
                        _empRec.JoiningDate = (DateTime)emp.JoiningDate;
                        _empRec.HolidaysEntitled = (int)emp.HolidaysEntitled;
                        _empRec.Dormant = (bool)emp.Dormant;

                        this.EmployeesList.Add(_empRec);
                	}   
            }

            this.EmployeeNames = this.EmployeesList.Where(y => !y.Dormant).Select(x => x.EmployeeName).ToList();
        }

        /// <summary>
        /// The save leave.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        private void SaveLeave(object parameter)
        {
            var leaveRecord = new LeaveRecord
                                  {
                                      EmployeeId = this.selectedEmployeeId,
                                      DateFrom = this.DateFrom,
                                      DateTo = this.DateTo,
                                      Reason = this.Reason
                                  };

            TimeSpan ts = this.DateTo - this.DateFrom;
            this.DaysTaken = (int)ts.TotalDays;
            if (this.DaysTaken == 0)
            {
                this.DaysTaken = 1;
            }

            leaveRecord.RemainingLeaves = this.LeaveRemaining - this.DaysTaken;
            this.LeaveRemaining = leaveRecord.RemainingLeaves;

            if (this.ValidateLeave(leaveRecord))
            {
              
                // ADO.NET 
                // var response = this.dataService.BookHoliday(leaveRecord);

                // ADO.NET Dapper service
                //var response = this.holidayDbRepository.BookHoliday(leaveRecord);

                // EF 6

                try
                {
                    using (var context = new HolidayBookingEntities())
                    {
                        var result = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreCommand(
                            "exec [crud].[BookHoliday] @EmpID, @RemainingLeaves, @HolidayBookedFrom, @HolidayBookedTill, @Reason",
                            new SqlParameter("EmpID", leaveRecord.EmployeeId),
                            new SqlParameter("RemainingLeaves", leaveRecord.RemainingLeaves),
                            new SqlParameter("HolidayBookedFrom", leaveRecord.DateFrom),
                            new SqlParameter("HolidayBookedTill", leaveRecord.DateTo),
                            new SqlParameter("Reason", string.IsNullOrWhiteSpace(leaveRecord.Reason) ? "Not mentioned.." : leaveRecord.Reason));
                    }

                    //if (response.Success)
                    //{
                        MessageBox.Show("Leave booking successful", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                    //}
                    //else
                    //{
                    //    MessageBox.Show(response.Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    //}

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// The validate leave.
        /// </summary>
        /// <param name="leaveRecord">
        /// The leave record.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ValidateLeave(LeaveRecord leaveRecord)
        {
            var feedback = this.dataService.GetUpcomingHolidays();
            var leaveList = feedback.Data;
            bool alreadyAppliedFromDate = leaveList.Exists(x => x.DateFrom == leaveRecord.DateFrom && x.EmployeeId == leaveRecord.EmployeeId);
            bool alreadyAppliedToDate = leaveList.Exists(x => x.DateTo == leaveRecord.DateTo && x.EmployeeId == leaveRecord.EmployeeId);

            if (alreadyAppliedFromDate)
            {
                MessageBox.Show(
                    "Leave already applied on leave starting date! ",
                    "Holiday Booking Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (alreadyAppliedToDate)
            {
                MessageBox.Show(
                    "Leave already applied on leave ending date! ",
                    "Holiday Booking Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            return !alreadyAppliedFromDate && !alreadyAppliedToDate;
        }

        /// <summary>
        /// The can save.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanSave(object parameter)
        {
            return (this.LeaveRemaining >= this.DaysTaken) 
                   && (this.selectedEmployeeId != 0) 
                   && (this.DaysTaken > 0)
                   && (this.DateFrom >= DateTime.Today)
                   && (this.DateTo >= DateTime.Today);
        }

        /// <summary>
        /// The get error for property.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetErrorForProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "DateFrom":
                    return this.DateFrom < DateTime.Today ? "invalid date" : string.Empty;

                case "DateTo":
                    return this.DateTo < DateTime.Today ? "invalid date" : string.Empty;

                default:
                    return string.Empty;
            }
        }
    }
}
