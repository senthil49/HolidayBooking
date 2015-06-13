namespace HolidayBooking.ViewModels.RunTime
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    using HolidayBooking.Models;
    using HolidayBooking.Services;
    using HolidayBooking.Views;
    using HolidayBooking.Commands;
    using System;
using HolidayBooking.Repository;

    /// <summary>
    /// The home view model.
    /// </summary>
    public class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        /// <summary>
        /// The upcoming holidays.
        /// </summary>
        public List<LeaveRecord> UpcomingHolidays 
        {
            get 
            {
                return this.upcomingHolidays ;
            }

            set 
            { 
                this.upcomingHolidays = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The data service.
        /// </summary>
        public IDataService DataService = new DataService();

        public IHolidayDbRepository HolidayDbRepository = new HolidayDbRepository();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        public HomeViewModel()
        {
            this.HomeCommand = new DelegateCommand(this.GoHomeView);
            this.BookHolidaysCommand = new DelegateCommand(this.GoBookHolidaysView);
            this.AddEmployeeCommand = new DelegateCommand(this.GoAddEmployeeView);
            this.ReportsCommand = new DelegateCommand(this.GoReportsView);

            LoadUpcomingHolidays();
        }

        private void LoadUpcomingHolidays()
        {
            //(ADO.NET) with Dapper
            //this.UpcomingHolidays = HolidayDbRepository.GetUpcomingHolidays();


            // ADO.NET
            //var feedback = this.DataService.GetUpcomingHolidays();
            //this.UpcomingHolidays = feedback.Data;

            //EF6
            using (var context = new HolidayBookingEntities())
            {
                List<GetUpcomingHolidays_Result> result = context.GetUpcomingHolidays().ToList();

                this.UpcomingHolidays = new List<LeaveRecord>();

                foreach (var item in result)
                {
                    LeaveRecord _leaveRecord = new LeaveRecord();

                    _leaveRecord.DateFrom = (DateTime)item.DateFrom;
                    _leaveRecord.DateTo = (DateTime)item.DateTo;
                    _leaveRecord.EmployeeId = item.EmployeeID;
                    _leaveRecord.EmployeeName = item.EmployeeName;
                    _leaveRecord.Reason = item.Reason;
                    _leaveRecord.RemainingLeaves = (int)item.RemainingLeaves;

                    this.UpcomingHolidays.Add(_leaveRecord);
                }

            }
        }

        /// <summary>
        /// The go add employee view.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void GoAddEmployeeView()
        {
            var newAddEmployeeView = new AddEmployeeView
                                         {
                                             WindowStartupLocation = WindowStartupLocation.CenterScreen
                                         };
            newAddEmployeeView.Show();
            this.CloseAction();
        }

        /// <summary>
        /// Gets or sets the home command.
        /// </summary>
        public ICommand HomeCommand { get; set; }

        /// <summary>
        /// Gets or sets the add employee command.
        /// </summary>
        public ICommand AddEmployeeCommand { get; set; }

        /// <summary>
        /// Gets or sets the book holidays command.
        /// </summary>
        public ICommand BookHolidaysCommand { get; set; }

        /// <summary>
        /// Gets or sets the Reports command.
        /// </summary>
        public ICommand ReportsCommand { get; set; }

        /// <summary>
        /// The go home view.
        /// </summary>
        private void GoHomeView()
        {
            var newHomeView = new HomeView { WindowStartupLocation = WindowStartupLocation.CenterScreen };
            newHomeView.Show();
            this.CloseAction();
        }

        private void GoBookHolidaysView()
        {
            var newBookHolidaysView = new BookHolidaysView { WindowStartupLocation = WindowStartupLocation.CenterScreen };
            newBookHolidaysView.Show();
            this.CloseAction();
        }

        private void GoReportsView(object obj)
        {
            var newReportsView = new ReportsView { WindowStartupLocation = WindowStartupLocation.CenterScreen };
            newReportsView.Show();
            this.CloseAction();
        }

        private List<LeaveRecord> upcomingHolidays { get; set; }

        public Action CloseAction { get; set; }

    }
}

