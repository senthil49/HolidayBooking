using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayBooking.Models
{
    using System.Windows.Documents;

    public class Feedback<T>  
    {
       public bool Success { get; set; }
       public string Error { get; set; }

       public T Data { get; set; }
    }
}
