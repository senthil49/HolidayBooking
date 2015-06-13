namespace HolidayBooking.Services
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    using HolidayBooking.Models;
    using System.Collections.ObjectModel;

    /// <summary>
    /// The data service.
    /// </summary>
    public class DataService: IDataService
    {
        /// <summary>
        /// The get upcoming holidays.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public Feedback<List<LeaveRecord>> GetUpcomingHolidays()
       {
           var leaveRecordTable = new DataTable("LeaveRecordTable");
           List<LeaveRecord> leaveRecords = new List<LeaveRecord>();

            var feedback = new Feedback<List<LeaveRecord>>();

                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HolidayBookingDb"].ConnectionString))
                using (var command = new SqlCommand("[report].[GetUpcomingHolidays]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var da = new SqlDataAdapter(command);
                    var result = da.Fill(leaveRecordTable);

                   foreach (DataRow row in leaveRecordTable.Rows)
                    {
                        var leaveRecord = new LeaveRecord
                                              {
                                                  EmployeeId = Convert.ToInt32(row["EmployeeID"]),
                                                  EmployeeName = Convert.ToString(row["EmployeeName"]),
                                                  DateFrom = Convert.ToDateTime(row["DateFrom"]),
                                                  DateTo = Convert.ToDateTime(row["DateTo"]),
                                                  Reason = Convert.ToString(row["Reason"]),
                                                  RemainingLeaves = Convert.ToInt32(row["RemainingLeaves"])
                                              };

                        leaveRecords.Add(leaveRecord);
                    }
                }

            feedback.Success = true;
            feedback.Data = leaveRecords;
            return feedback;
       }

        public Feedback<ObservableCollection<EmployeeRecord>> GetEmployees()
        {
            var feedback = new Feedback<ObservableCollection<EmployeeRecord>>();

            var EmployeeTable = new DataTable("EmployeeTable");
            ObservableCollection<EmployeeRecord> employeeRecords = new ObservableCollection<EmployeeRecord>();
            
            using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HolidayBookingDb"].ConnectionString))
            using(var command = new SqlCommand("[report].[GetEmployees]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                var da = new SqlDataAdapter(command);
                var result = da.Fill(EmployeeTable);

               

                foreach (DataRow row in EmployeeTable.Rows)
                {
                    var employeeRecord = new EmployeeRecord();

                    employeeRecord.EmployeeId = Convert.ToInt32(row["EmployeeID"]);
                    employeeRecord.EmployeeName = Convert.ToString(row["EmployeeName"]);
                    employeeRecord.JoiningDate = Convert.ToDateTime(row["JoiningDate"]);
                    employeeRecord.HolidaysEntitled = Convert.ToInt32(row["HolidaysEntitled"]);
                    employeeRecord.Dormant = Convert.ToBoolean(row["Dormant"]);

                    employeeRecords.Add(employeeRecord);
                    
                }
            }

            feedback.Success = true;
            feedback.Data = employeeRecords;
            return feedback;
        }

        public int GetLeavesRemaining(int EmployeeID)
        {
            var RemainingLeavesTable = new DataTable("RemainingLeavesTable");
            int remainingLeaves = 99;

            using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HolidayBookingDb"].ConnectionString))
            using (var command = new SqlCommand("select RemainingLeaves from [crud].[EmployeeHolidays] where ID in (select Max(ID) from [crud].[EmployeeHolidays] where EmpID = @EmpID)", connection))
            {
                command.Parameters.Add(new SqlParameter("EmpID", SqlDbType.Int));
                command.Parameters["EmpID"].Value = EmployeeID;

                var da = new SqlDataAdapter(command);
                var result = da.Fill(RemainingLeavesTable);

                foreach (DataRow row in RemainingLeavesTable.Rows)
                {
                    remainingLeaves = Convert.ToInt32(row["RemainingLeaves"]);
                }

                if (remainingLeaves == 99)
                {
                    var HolidaysEntitledTable = new DataTable("HolidaysEntitledTable ");
                    using (var command2 = new SqlCommand("select HolidaysEntitled from [crud].[Employee] where ID = @EmpID", connection))
                    {
                        command2.Parameters.Add(new SqlParameter("EmpID", SqlDbType.Int));
                        command2.Parameters["EmpID"].Value = EmployeeID;

                        var da2 = new SqlDataAdapter(command2);
                        var result2 = da2.Fill(HolidaysEntitledTable);
                    }

                    foreach (DataRow row in HolidaysEntitledTable.Rows)
                    {
                        remainingLeaves = Convert.ToInt32(row["HolidaysEntitled"]);
                    }
                }

                return remainingLeaves;
            }
        }

        /// <summary>
        /// The add employee.
        /// </summary>
        /// <param name="empRecord">
        /// The emp record.
        /// </param>
        public int AddEmployee(EmployeeRecord empRecord)
       {
           var employeeTable = new DataTable("EmployeeTable");
           var newEmployeeId =  -1;

           try
           {
               using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HolidayBookingDb"].ConnectionString))
               using (var command = new SqlCommand("[crud].[AddEmployee]", connection))
               {
                   command.CommandType = CommandType.StoredProcedure;
                   command.Parameters.AddWithValue("EmpName", empRecord.EmployeeName);
                   command.Parameters.AddWithValue("DateOfJoining", empRecord.JoiningDate);
                   command.Parameters.AddWithValue("HolidaysEntitled", empRecord.HolidaysEntitled);
                   command.Parameters.AddWithValue("Dormant", empRecord.Dormant);

                   //connection.Open();
                   //command.ExecuteNonQuery();

                   var da = new SqlDataAdapter(command);
                   var result = da.Fill(employeeTable);

                   foreach (DataRow row in employeeTable.Rows)
                   {
                       newEmployeeId = Convert.ToInt32(row["newEmpID"]);
                   }

                   return newEmployeeId;
               }
           }
           catch (Exception)
           {
               return newEmployeeId;
           }
       }


        /// <summary>
        /// The add employee.
        /// </summary>
        /// <param name="empRecord">
        /// The emp record.
        /// </param>
        public void UpdateEmployeeDormantFlag(int empID, bool dormantFlag)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HolidayBookingDb"].ConnectionString))
                using (var command = new SqlCommand("[crud].[UpdateEmployee]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("EmpID", empID);
                    command.Parameters.AddWithValue("Dormant", dormantFlag);

                    connection.Open();
                    command.ExecuteNonQuery();
                    
                }
            }

            catch (Exception ex)
            {
            }
        }

       public Feedback<string> BookHoliday(LeaveRecord leaveRecord)
       {
           try
           {
               using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HolidayBookingDb"].ConnectionString))
               using (var command = new SqlCommand("[crud].[BookHoliday]", connection))
               {
                   command.CommandType = CommandType.StoredProcedure;
                   command.Parameters.AddWithValue("EmpID", leaveRecord.EmployeeId);
                   command.Parameters.AddWithValue("RemainingLeaves", leaveRecord.RemainingLeaves);
                   command.Parameters.AddWithValue("HolidayBookedFrom", leaveRecord.DateFrom);
                   command.Parameters.AddWithValue("HolidayBookedTill", leaveRecord.DateTo);

                   if (string.IsNullOrWhiteSpace(leaveRecord.Reason))
                   {
                       leaveRecord.Reason = "not mentioned";
                   }

                   command.Parameters.AddWithValue("Reason", leaveRecord.Reason);
                   connection.Open();
                   command.ExecuteNonQuery();

                   var feedback = new Feedback<string>();
                   feedback.Success = true;

                   return feedback;
               }
           }

           catch (Exception ex)
           {
               var feedback = new Feedback<string>();
               feedback.Success = false;
               feedback.Error = ex.ToString();

               return feedback;
           }

          
       }
    }
}
