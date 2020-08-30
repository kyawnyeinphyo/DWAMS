using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DWAMS_DAL
{
    public class AddressDataController : MyConnection
    {

        public void Insert(string Name, string Desp)
        {
            command = new SqlCommand("spdAddressInsert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@addressname", SqlDbType.NVarChar).Value = Name;
            command.Parameters.Add("@desp", SqlDbType.NVarChar).Value = Desp;


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(string Id, string Name, string Desp)
        {
            command = new SqlCommand("spdAddressUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@addressid", SqlDbType.Char).Value = Id;
            command.Parameters.Add("@addressname", SqlDbType.NVarChar).Value = Name;
            command.Parameters.Add("@desp", SqlDbType.NVarChar).Value = Desp;


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(string Id)
        {
            command = new SqlCommand("spdAddressDelete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@addressid", SqlDbType.Char).Value = Id;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IDataReader SelectList()
        {
            command = new SqlCommand("spdAddressSelect", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader SelectList(string address)
        {
            sqlString = @"SELECT * FROM TblAddress WHERE AddressName LIKE @address  ORDER BY AddressName ";
            command = new SqlCommand( sqlString, connection);

            command.Parameters.AddWithValue("@address", "%"+address+"%");

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
