using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DWAMS_DAL
{
    public class SalaryPaymentDataController : MyConnection
    {

        public IDataReader SelectMonthlyPayment(int month , int year)
        {
            command = new SqlCommand("spdSalaryPaymentSelect", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@month", month);
            command.Parameters.AddWithValue("@year", year);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void InsertMonthlyPayment(string staffid, DateTime paymentdate, DateTime monthdate, double fine, double bonus, double netsalary)
        {
            command = new SqlCommand("spdSalaryPaymentInsert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@staffid", staffid);
            command.Parameters.AddWithValue("@paymentdate", paymentdate);
            command.Parameters.AddWithValue("@monthdate", monthdate);
            command.Parameters.AddWithValue("@fine", fine);
            command.Parameters.AddWithValue("@bonus", bonus);
            command.Parameters.AddWithValue("@netsalary", netsalary);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
