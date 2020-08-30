using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DWAMS_DAL
{
    public class AttendanceDataController : MyConnection
    {

        public void InsertOutdoorStaff(string staffid, DateTime attendanceDate)
        {
            command = new SqlCommand("spdOutdoorStaffInsert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@staffid", staffid);
            command.Parameters.AddWithValue("@attendancedate", attendanceDate);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DutyIn(string staffid, DateTime date, DateTime dutyin, double latedutyin, string remark, char late)
        {
            command = new SqlCommand("spdDailyAttendanceDutyIn", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@staffid",staffid);
            command.Parameters.AddWithValue("@attendancedate", date);
            command.Parameters.AddWithValue("@dutyIn", dutyin);
            command.Parameters.AddWithValue("@lateDutyIn", latedutyin);
            command.Parameters.AddWithValue("@remark1", remark);
            command.Parameters.AddWithValue("@late", late); // late has two values >> Y and N

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DutyOut(string staffid, DateTime date, DateTime dutyout, double earlydutyout, string remark, char late)
        {
            command = new SqlCommand("spdDailyAttendanceDutyOut", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@staffid", staffid);
            command.Parameters.AddWithValue("@attendancedate", date);
            command.Parameters.AddWithValue("@dutyout", dutyout);
            command.Parameters.AddWithValue("@earlydutyout", earlydutyout);
            command.Parameters.AddWithValue("@remark2", remark);
            command.Parameters.AddWithValue("@late", late);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IDataReader DailyAttendanceSelect()
        {
        command = new SqlCommand("spdDailyAttendanceSelect",connection);
        command.CommandType = CommandType.StoredProcedure;

        connection.Open();
        return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader DailyAttendanceSelectbyDate(DateTime startdate, DateTime enddate)
        {
        command = new SqlCommand("spdDailyAttendanceSelectbyDate",connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@startdate", startdate);
        command.Parameters.AddWithValue("@enddate", enddate);

        connection.Open();
        return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader DailyAttendanceSelectbyStaffId(string staffid)
        {
        command = new SqlCommand("spdDailyAttendanceSelectbyStaffId",connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@staffid", staffid);

        connection.Open();
        return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader DailyAttendanceSelectbyStaffIdDate(string staffid, DateTime startdate, DateTime enddate)
        {
        command = new SqlCommand("spdDailyAttendanceSelectbyStaffIdDate",connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@staffid", staffid);
        command.Parameters.AddWithValue("@startdate", startdate);
        command.Parameters.AddWithValue("@enddate", enddate);

        connection.Open();
        return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader AttendanceCheckStatus(string staffid, DateTime date)
        {
            //to check duty in or duty out or full duty
            command = new SqlCommand("spdDailyAttendanceCheck", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@staffid", staffid);
            command.Parameters.AddWithValue("@attendancedate", date);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader UnNormalAttendanceSelect()
        {
            command = new SqlCommand("spdUnnormalAttendanceSelect", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader UnNormalAttendanceCount()
        {
            command = new SqlCommand("spdUnnormalAttendanceCount", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void UnNormalAttendanceUpdate(string attendanceid, int latedutyin, int earlydutyout, string type)
        {
            command = new SqlCommand("spdUnnormalAttendanceUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;
            //type >>
            //NL NE
            //NL
            //NE
            command.Parameters.AddWithValue("@attid",attendanceid);
            command.Parameters.AddWithValue("@latedutyin",latedutyin);
            command.Parameters.AddWithValue("@earlydutyout",earlydutyout);
            command.Parameters.AddWithValue("@type", type);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IDataReader UnNormalAttendanceSelectbyStaffid(string staffid)
        {
            command = new SqlCommand("spdUnnormalAttendanceSelectbyStaffid", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@staffid", staffid);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

    }
}
