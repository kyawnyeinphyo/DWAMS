using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DWAMS_DAL
{
    public class DepartmentDataController : MyConnection
    {

        public void Insert(string Name, string Desp)
        {
            command = new SqlCommand("spdDepartmentInsert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@depname", SqlDbType.NVarChar).Value = Name;
            command.Parameters.Add("@desp", SqlDbType.NVarChar).Value = Desp;


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(string Id, string Name, string Desp)
        {
            command = new SqlCommand("spdDepartmentUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@depid", SqlDbType.Char).Value = Id;
            command.Parameters.Add("@depname", SqlDbType.NVarChar).Value = Name;
            command.Parameters.Add("@desp", SqlDbType.NVarChar).Value = Desp;


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(string Id)
        {
            command = new SqlCommand("spdDepartmentDelete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@depid", SqlDbType.Char).Value = Id;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public IDataReader SelectList()
        {
            command = new SqlCommand("spdDepartmentSelect", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader SelectList(string department)
        {
            sqlString = @"SELECT * FROM TblDepartment WHERE DepName LIKE @department  ORDER BY DepName ";
            command = new SqlCommand(sqlString, connection);

            command.Parameters.AddWithValue("@department", "%" + department + "%");

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
