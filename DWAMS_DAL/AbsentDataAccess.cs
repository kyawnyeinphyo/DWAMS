using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DWAMS_DAL
{
     public class AbsentDataAccess :MyConnection
    {
         public void UpdateToAbsent(string staffid, DateTime absentdate)
         {
             command = new SqlCommand("spdAbsentUpdate", connection);

             command.CommandType = CommandType.StoredProcedure;
             command.Parameters.AddWithValue("@staffid", staffid);
             command.Parameters.AddWithValue("@absentdate", absentdate);

             connection.Open();
             command.ExecuteNonQuery();
             connection.Close();
         }

         public void InsertToAbsent(string staffid, DateTime absentdate)
         {
             command = new SqlCommand("spdAbsentInsert", connection);

             command.CommandType = CommandType.StoredProcedure;
             command.Parameters.AddWithValue("@staffid", staffid);
             command.Parameters.AddWithValue("@absentdate", absentdate);

             connection.Open();
             command.ExecuteNonQuery();
             connection.Close();
         }

         public IDataReader SelectAbsent(int month, int year)
         {
             command = new SqlCommand("spdAbsentSelect", connection);

             command.CommandType = CommandType.StoredProcedure;
             command.Parameters.AddWithValue("@month", month);
             command.Parameters.AddWithValue("@year", year);

             connection.Open();
             return command.ExecuteReader(CommandBehavior.CloseConnection);
         }

    }
}
