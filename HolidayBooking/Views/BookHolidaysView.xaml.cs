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
using System.Windows.Shapes;

namespace HolidayBooking.Views
{
    /// <summary>
    /// Interaction logic for BookHolidays.xaml
    /// </summary>
    public partial class BookHolidaysView : Window
    {
        public BookHolidaysView()
        {
            InitializeComponent();
            var viewModel = new BookHolidaysViewModel();
            this.DataContext = viewModel;
            if (viewModel.CloseAction == null)
            {
               viewModel.CloseAction = new Action ( () => this.Close());
            }
        }
    }
}
