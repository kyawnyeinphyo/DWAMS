using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DWAMS_DAL
{
    public class UnPaidListDataAccess : MyConnection
    {

        public IDataReader Select_total_late_early(string staffid, DateTime pay_date, int month, int year)
        {
            command = new SqlCommand("spdCalculateLateEarly", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@staffid", staffid);
            command.Parameters.AddWithValue("@paymentdate", pay_date);
            command.Parameters.AddWithValue("@month", month);
            command.Parameters.AddWithValue("@year", year);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader Select_total_present(string staffid, int month, int year)
        {
            command = new SqlCommand("spdCalculatePresent", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@staffid", staffid);
            command.Parameters.AddWithValue("@month", month);
            command.Parameters.AddWithValue("@year", year);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader Select_total_absent(string staffid, int month, int year)
        {
            command = new SqlCommand("spdCalculateAbsent", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@staffid", staffid);
            command.Parameters.AddWithValue("@month", month);
            command.Parameters.AddWithValue("@year", year);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void UpdatePaidStatus(string staffid, int month, int year)
        {
            command = new SqlCommand("spdPaidStatusUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@staffid", staffid);
            command.Parameters.AddWithValue("@month", month);
            command.Parameters.AddWithValue("@year", year);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateAbsentPaidStatus(string staffid, int month, int year)
        {
            command = new SqlCommand("spdAbsentUpdatePaidStatus", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@staffid", staffid);
            command.Parameters.AddWithValue("@month", month);
            command.Parameters.AddWithValue("@year", year);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IDataReader SelectUnPaidList(int pay_for_month, int pay_for_year)
        {
            command = new SqlCommand("spdUnPaidListSelect", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@pay_for_month", pay_for_month);
            command.Parameters.AddWithValue("@pay_for_year", pay_for_year);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader SelectUnPaidList(string departmentid, int pay_for_month, int pay_for_year)
        {
            command = new SqlCommand("spdUnPaidListSelectbyDepartment", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@departmentid", departmentid);
            command.Parameters.AddWithValue("@pay_for_month", pay_for_month);
            command.Parameters.AddWithValue("@pay_for_year", pay_for_year);


            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader CheckPaid(string staffid, int day, int month, int year)
        {
            //check is he paid or not

            command = new SqlCommand("spdPayrollCheck", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@staffid",staffid);
            command.Parameters.AddWithValue("@day",day);
            command.Parameters.AddWithValue("@month",month);
            command.Parameters.AddWithValue("@year", year);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
