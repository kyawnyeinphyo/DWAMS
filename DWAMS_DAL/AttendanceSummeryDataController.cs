using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DWAMS_DAL
{
    public class AttendanceSummeryDataController : MyConnection
    {

        public IDataReader AttendanceSummerySelect(int month, int year)
        {
            command = new SqlCommand("spdAttendanceSummery", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@month", month);
            command.Parameters.AddWithValue("@year", year);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

    }
}
