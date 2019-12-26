using AuslanAPI.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuslanAPI.Services
{
    public class UserService : DatabaseService
    {
        public List<UserDataModel> GetUsers(int? userID = null)
        {
            List<UserDataModel> userData = new List<UserDataModel>();
            string SqlQuery = "SELECT ID, Status, Username, Firstname, Lastname, Password FROM Users";

            // TODO: Test data while no database exists...
            if(true)
            {
                return ServiceHelper.LoadJson<UserDataModel>("userData.json");
            } 

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = CONNECTION_STRING;
                    conn.Open();

                    SqlCommand command;

                    //If a parameter (UserID) is passed, return data for that record else return ALL data.
                    if (userID.HasValue)
                    {
                        SqlQuery += " Where ID = @0";
                        command = new SqlCommand(SqlQuery, conn);
                        command.Parameters.Add(new SqlParameter("0", userID));
                    }
                    else
                    {
                        command = new SqlCommand(SqlQuery, conn);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                userData.Add(new UserDataModel()
                                {
                                    ID = Convert.ToInt32(reader[0]),
                                    Status = (Enums.RecordStatus)Convert.ToInt32(reader[1]),
                                    //Created = Convert.ToDateTime(reader[2]),
                                    Username = reader[2].ToString(),
                                    Firstname = reader[3].ToString(),
                                    Lastname = reader[4].ToString(),
                                    Password = reader[5].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Caught - " + ex.Message);
            }

            return userData;
        }

        public bool UpdateReport(UserDataModel userModel)
        {
            bool result = false;

            if (userModel != null && userModel.ID > 0)
            {
                string SqlQuery = "UPDATE Users SET Status = @status,";

                if (!string.IsNullOrEmpty(userModel.Lastname))
                {
                    SqlQuery += "Lastname = @lastname,";
                }
                if (!string.IsNullOrEmpty(userModel.Firstname))
                {
                    SqlQuery += "Firstname = @firstname,";
                }
                if (!string.IsNullOrEmpty(userModel.Password))
                {
                    SqlQuery += "Password = @password,";
                }
                if (SqlQuery.EndsWith(","))
                {
                    SqlQuery.Remove(SqlQuery.Length - 1);
                }
                
                SqlQuery += "WHERE ID = @id";

                try
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = CONNECTION_STRING;
                        conn.Open();

                        SqlCommand command = new SqlCommand(SqlQuery, conn);

                        if (SqlQuery.Length > 0)
                        {
                            command = new SqlCommand(SqlQuery, conn);
                            command.Parameters.AddWithValue("@firstname", userModel.Firstname = userModel.Firstname ?? "");
                            command.Parameters.AddWithValue("@lastname", userModel.Lastname = userModel.Lastname ?? "");
                            command.Parameters.AddWithValue("@Password", userModel.Password);
                        }
                        int sqlResult = command.ExecuteNonQuery();

                        result = sqlResult < 0 ? false : true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception Caught - " + ex.Message);
                }
            }

            if (!result)
                System.Diagnostics.Debug.WriteLine("Error - record not updated in database");

            return result;
        }

        //    public bool AddNewReport(UserDataModel report)
        //    {
        //        bool result = false;

        //        if (report != null)
        //        {
        //            if (report.Date == null || report.Date == DateTime.MinValue)
        //                report.Date = DateTime.Now;

        //            string SqlQuery = "INSERT INTO Report (responseID, Name, Report_file, Date) VALUES (@responseID, @Name, @Report_file, @Date)";

        //            try
        //            {
        //                using (SqlConnection conn = new SqlConnection())
        //                {
        //                    conn.ConnectionString = CONNECTION_STRING;
        //                    conn.Open();

        //                    SqlCommand command = new SqlCommand(SqlQuery, conn);

        //                    if (SqlQuery.Length > 0)
        //                    {
        //                        command = new SqlCommand(SqlQuery, conn);
        //                        command.Parameters.AddWithValue("@responseID", report.ResponseID);
        //                        command.Parameters.AddWithValue("@Name", report.Name = report.Name ?? "");
        //                        command.Parameters.AddWithValue("@Report_file", report.ReportFile = report.ReportFile ?? "");
        //                        command.Parameters.AddWithValue("@Date", report.Date);

        //                    }
        //                    int sqlResult = command.ExecuteNonQuery();

        //                    result = sqlResult < 0 ? false : true;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                System.Diagnostics.Debug.WriteLine("Exception Caught - " + ex.Message);
        //            }
        //        }

        //        if (!result)
        //            System.Diagnostics.Debug.WriteLine("Error - record not saved to database");

        //        return result;
        //    }

        //    public bool UpdateReport(UserDataModel report)
        //    {
        //        bool result = false;

        //        if (report != null)
        //        {
        //            if (report.Date == null || report.Date == DateTime.MinValue)
        //                report.Date = DateTime.Now;

        //            string SqlQuery = "UPDATE Report SET name = @name, report_file = @report_file, Date = @Date WHERE ReportID = " + report.ReportID;

        //            try
        //            {
        //                using (SqlConnection conn = new SqlConnection())
        //                {
        //                    conn.ConnectionString = CONNECTION_STRING;
        //                    conn.Open();

        //                    SqlCommand command = new SqlCommand(SqlQuery, conn);

        //                    if (SqlQuery.Length > 0)
        //                    {
        //                        command = new SqlCommand(SqlQuery, conn);
        //                        command.Parameters.AddWithValue("@name", report.Name = report.Name ?? "");
        //                        command.Parameters.AddWithValue("@report_file", report.ReportFile = report.ReportFile ?? "");
        //                        command.Parameters.AddWithValue("@Date", report.Date);
        //                    }
        //                    int sqlResult = command.ExecuteNonQuery();

        //                    result = sqlResult < 0 ? false : true;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                System.Diagnostics.Debug.WriteLine("Exception Caught - " + ex.Message);
        //            }
        //        }

        //        if (!result)
        //            System.Diagnostics.Debug.WriteLine("Error - record not updated in database");

        //        return result;
        //    }

        //    public bool DeleteReport(int ID)
        //    {
        //        bool result = false;

        //        string SqlQuery = "DELETE FROM Report WHERE ReportID = @reportID";

        //        try
        //        {
        //            using (SqlConnection conn = new SqlConnection())
        //            {
        //                conn.ConnectionString = CONNECTION_STRING;
        //                conn.Open();

        //                SqlCommand command = new SqlCommand(SqlQuery, conn);

        //                if (SqlQuery.Length > 0)
        //                {
        //                    command = new SqlCommand(SqlQuery, conn);
        //                    command.Parameters.AddWithValue("@reportID", ID);
        //                }

        //                int sqlResult = command.ExecuteNonQuery();

        //                result = sqlResult < 0 ? false : true;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Debug.WriteLine("Exception Caught - " + ex.Message);
        //        }

        //        if (!result)
        //            System.Diagnostics.Debug.WriteLine("Error - record not deleted");

        //        return result;
        //    }
        //}
    }
}
