using HolidayBooking.Models;
using HolidayBooking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HolidayBooking.ViewModels.RunTime
{
    using System.Collections.Specialized;
    using System.Windows;

    using HolidayBooking.Commands;
    using HolidayBooking.Views;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class AddEmployeeViewModel: BaseViewModel, IAddEmployeeViewModel
    {
       public AddEmployeeViewModel()
       {
           this.HomeCommand = new DelegateCommand(this.GoHomeView);
           this.BookHolidaysCommand = new DelegateCommand(this.GoBookHolidaysView);
           this.AddEmployeeCommand = new DelegateCommand(this.GoAddEmployeeView);
           this.ReportsCommand = new DelegateCommand(this.GoReportsView);
           this.AddEmployeeRecordCommand = new DelegateCommand(this.AddEmployeeRecord, this.CanExecute);
           this.Initialize();
       }

       private void Initialize()
       {
           EmployeeRecord = new EmployeeRecord { JoiningDate = DateTime.Today };

           var result = this.DataService.GetEmployees();

           var empList = result.Data;
         
           foreach (var emp in empList)
           {
               this.EmployeesList.Add(emp);
               emp.PropertyChanged += this.Emp_PropertyChanged;
           }

           this.EmployeesList.CollectionChanged += this.EmployeesListCollectionChanged;
       }

       private void EmployeesListCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
       {
           if (e.NewItems != null)
           {
               foreach (EmployeeRecord newEmp in e.NewItems)
               {
                   newEmp.PropertyChanged += this.Emp_PropertyChanged;
               }
           }

           if (e.OldItems != null)
           {
               foreach (EmployeeRecord oldEmp in e.OldItems)
               {
                   oldEmp.PropertyChanged += this.Emp_PropertyChanged;
               }
           }
       }

        private void Emp_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var empRecord = sender as EmployeeRecord;
            if (empRecord != null)
            {
                var empID = empRecord.EmployeeId;
                var dormantFlag = empRecord.Dormant;
                this.DataService.UpdateEmployeeDormantFlag(empID, dormantFlag);
            }

        }

       private bool CanExecute(object obj)
       {
           return (!string.IsNullOrWhiteSpace(this.EmployeeRecord.EmployeeName)) &&
                  (this.EmployeeRecord.JoiningDate != DateTime.MinValue);
       }

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

       private ObservableCollection<EmployeeRecord> employeesList = new ObservableCollection<EmployeeRecord>() ;

       public ObservableCollection<EmployeeRecord> EmployeesList 
       { 
           get
           {
               return this.employeesList;
           }

           set
           {
               this.employeesList = value;
               this.OnPropertyChanged("EmployeesList");
           }
       }

       private EmployeeRecord employeeRecord ;

       public EmployeeRecord EmployeeRecord 
       { 
           get 
           {
               return this.employeeRecord;
           }
               
           set
           {
               this.employeeRecord = value;
               this.employeeRecord.PropertyChanged += (sender, args) => ((DelegateCommand)this.AddEmployeeRecordCommand).RaiseCanExecuteChanged();
           }
       }

       public ICommand AddEmployeeCommand { get; set; }

       public ICommand AddEmployeeRecordCommand { get; set; }

       public void AddEmployeeRecord(object obj)
       {
           var newEmpID = this.DataService.AddEmployee(EmployeeRecord);

           if (newEmpID != -1)
           {
               MessageBox.Show("New Employee added", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

               EmployeeRecord.EmployeeId = newEmpID;
               this.EmployeesList.Add(EmployeeRecord);
           }
           else
           {
               MessageBox.Show("Add Employee Failed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
           }
       }

       /// <summary>
       /// The data service.
       /// </summary>
       public IDataService DataService = new DataService();

       /// <summary>
       /// The go home view.
       /// </summary>
       private void GoHomeView(object obj)
       {
           var newHomeView = new HomeView { WindowStartupLocation = WindowStartupLocation.CenterScreen };
           newHomeView.Show();
           this.CloseAction();
       }

       private void GoBookHolidaysView(object obj)
       {
           var newBookHolidaysView = new BookHolidaysView() { WindowStartupLocation = WindowStartupLocation.CenterScreen };
           newBookHolidaysView.Show();
           this.CloseAction();
       }

       private void GoAddEmployeeView(object obj)
       {
           var newAddEmployeeView = new AddEmployeeView() { WindowStartupLocation = WindowStartupLocation.CenterScreen };
           newAddEmployeeView.Show();
           this.CloseAction();
       }

       private void GoReportsView(object obj)
       {
           var newReportsView = new ReportsView { WindowStartupLocation = WindowStartupLocation.CenterScreen };
           newReportsView.Show();
           this.CloseAction();
       }

       public Action CloseAction { get; set; }
    }
}
