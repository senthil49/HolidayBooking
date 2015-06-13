using HolidayBooking.ViewModels.RunTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HolidayBooking.Models;
using HolidayBooking.ViewModels;

namespace HolidayBooking.Views
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : Window
    {
        public ReportsView()
        {
            this.InitializeComponent();
            var viewModel = new ReportsViewModel();
            this.DataContext = viewModel;
            if (viewModel.CloseAction == null)
            {
                viewModel.CloseAction = new Action(() => this.Close());
            }
        }
    }
}
