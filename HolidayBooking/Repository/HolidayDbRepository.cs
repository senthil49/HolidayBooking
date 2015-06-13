using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HolidayBooking.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HolidayBooking.Repository
{
   public class HolidayDbRepository : IHolidayDbRepository
    {
       private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["HolidayBookingDb"].ConnectionString);
       
       public List<LeaveRecord> GetUpcomingHolidays()
        {
            try
            {
                var result = this.db.Query<LeaveRecord>("[report].[GetUpcomingHolidays]", commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
            catch (Exception)
            {
                
                throw;
            }
         
        }

        public ObservableCollection<EmployeeRecord> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public int GetLeavesRemaining(int EmployeeID)
        {
            throw new NotImplementedException();
        }

        public int AddEmployee(EmployeeRecord empRecord)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployeeDormantFlag(int empID, bool dormantFlag)
        {
            throw new NotImplementedException();
        }

        public Feedback<string> BookHoliday(LeaveRecord leaveRecord)
        {
           if (string.IsNullOrWhiteSpace(leaveRecord.Reason))
           {
               leaveRecord.Reason = "not mentioned";
           }

           var result = this.db.Query("[crud].[BookHoliday]", 
               new  
               { 
                 EmpID  = leaveRecord.EmployeeId, 
                 RemainingLeaves = leaveRecord.RemainingLeaves, 
                 HolidayBookedFrom = leaveRecord.DateFrom, 
                 HolidayBookedTill = leaveRecord.DateTo, 
                 Reason = leaveRecord.Reason, 
                   
               },
               commandType: CommandType.StoredProcedure);

           return new Feedback<string> 
           { 
                Success = true,
           };
        }
    }
}
