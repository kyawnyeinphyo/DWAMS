using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DWAMS_DAL
{
    public class StaffDataController : MyConnection
    {

        public IDataReader SelectStaff()
        {
            command = new SqlCommand(@"SELECT StaffId FROM TblStaff", connection);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void Insert(string PostId, string AddId, string DeptId, string StaffCode, string staffName, string StaffPhone, double BSalary, DateTime HireDate, string Desp)
        {
            command = new SqlCommand("spdStaffInsert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@PositionId", SqlDbType.Char).Value = PostId;
            command.Parameters.Add("@AddressId", SqlDbType.Char).Value = AddId;
            command.Parameters.Add("@DepId", SqlDbType.Char).Value = DeptId;
            command.Parameters.Add("@StaffCode", SqlDbType.NVarChar).Value = StaffCode;
            command.Parameters.Add("@StaffName", SqlDbType.NVarChar).Value = staffName;
            command.Parameters.Add("@StaffPh", SqlDbType.NVarChar).Value = StaffPhone;
            command.Parameters.Add("@BasicSalary", SqlDbType.Float).Value = BSalary;
            command.Parameters.Add("@HireDate", SqlDbType.DateTime).Value = HireDate;
            command.Parameters.Add("@Desp", SqlDbType.NVarChar).Value = Desp;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(string staffId, string PostId, string AddId, string DeptId, string StaffCode, string staffName, string StaffPhone, double BSalary, DateTime HireDate, string Desp)
        {
            command = new SqlCommand("spdStaffUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@staffid", SqlDbType.Char).Value = staffId;
            command.Parameters.Add("@positionid", SqlDbType.Char).Value = PostId;
            command.Parameters.Add("@addressid", SqlDbType.Char).Value = AddId;
            command.Parameters.Add("@depid", SqlDbType.Char).Value = DeptId;
            command.Parameters.Add("@staffcode", SqlDbType.NVarChar).Value = StaffCode;
            command.Parameters.Add("@staffname", SqlDbType.NVarChar).Value = staffName;
            command.Parameters.Add("@staffph", SqlDbType.NVarChar).Value = StaffPhone;
            command.Parameters.Add("@basicsalary", SqlDbType.Decimal).Value = BSalary;
            command.Parameters.Add("@hiredate", SqlDbType.DateTime).Value = HireDate;
            command.Parameters.Add("@desp", SqlDbType.NVarChar).Value = Desp;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(string staffId)
        {
            command = new SqlCommand("spdStaffDelete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@staffid", SqlDbType.Char).Value = staffId;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public IDataReader SelectList()
        {
            command = new SqlCommand("spdStaffSelect", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader SelectList(string staffcode)
        {
            command = new SqlCommand("spdStaffSelectbyCode", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@staffcode", staffcode);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader StaffSelectbyStaffId(string staffid)
        {
            command = new SqlCommand("spdStaffSelectbyStaffId", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@staffid", staffid);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader StaffSelectbyStaffCode(string staffcode)
        {
            command = new SqlCommand("spdStaffSelectbyStaffCode", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@staffcode", staffcode);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader StaffListForPayrollSelect(int month, int year)
        {
            command = new SqlCommand("spdStaffListForPayrollSelect", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@month", month);
            command.Parameters.AddWithValue("@year", year);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }


        
    }
}
