using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using HolidayBooking.Models;
using HolidayBooking.Services;
using HolidayBooking.Views;
using HolidayBooking.Commands;
using System;

namespace HolidayBooking.ViewModels.RunTime
{
   public class ReportsViewModel : BaseViewModel 
    {
       public Action CloseAction { get; set; }

       public ReportsViewModel()
       {
           this.ReportsCommand = new DelegateCommand(this.GoReportsView);
           this.HomeCommand = new DelegateCommand(this.GoHomeView);
           this.BookHolidaysCommand = new DelegateCommand(this.GoBookHolidaysView);
           this.AddEmployeeCommand = new DelegateCommand(this.GoAddEmployeeView);
       }

       /// <summary>
       /// Gets or sets the book holidays command.
       /// </summary>
       public ICommand ReportsCommand { get; set; }
       
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

       private void GoReportsView()
       {
           var newReportsView = new ReportsView { WindowStartupLocation = WindowStartupLocation.CenterScreen };
           newReportsView.Show();
           this.CloseAction();
       }

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

       private void GoAddEmployeeView()
        {
            var newAddEmployeeView = new AddEmployeeView
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            newAddEmployeeView.Show();
            this.CloseAction();
        }
    }
}
