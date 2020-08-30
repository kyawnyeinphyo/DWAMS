using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DWAMS_DAL
{
    public class SettingDataController : MyConnection  
    {
        public void UpdateSetting(DateTime dutyintime, DateTime dutyouttime)
        {
            command = new SqlCommand(@"UPDATE TblSetting SET DutyInTime=@dutyintime, DutyOutTime=@dutyouttime", connection);

            command.Parameters.AddWithValue("@dutyintime", dutyintime);
            command.Parameters.AddWithValue("@dutyouttime", dutyouttime);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IDataReader SelectSetting()
        {
            command = new SqlCommand("SELECT * FROM TblSetting", connection);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

    }
}
