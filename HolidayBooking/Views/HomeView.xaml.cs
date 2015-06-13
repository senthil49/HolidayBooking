namespace HolidayBooking.Views
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using HolidayBooking.Models;
    using HolidayBooking.ViewModels;
    using HolidayBooking.ViewModels.RunTime;

    /// <summary>
    /// The main window.
    /// </summary>
    public partial class HomeView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeView"/> class.
        /// </summary>
        public HomeView()
        {
            this.InitializeComponent();
            var viewModel = new HomeViewModel();
            this.DataContext = viewModel;
            if (viewModel.CloseAction == null)
            {
                viewModel.CloseAction = new Action( () => this.Close());
            }
        }
    }
}
