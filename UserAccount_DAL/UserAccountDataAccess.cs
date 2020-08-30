using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace UserAccount_DAL
{
    public class UserAccountDataAccess
    {
        SqlConnection connection;
        SqlCommand command;

        public UserAccountDataAccess()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }

        public void AddNewAccount(string username, string password, string permission)
        {
            command = new SqlCommand(@"
IF NOT EXISTS (SELECT * FROM TblUserAccount WHERE UserName=@user)
INSERT INTO TblUserAccount 
VALUES (newid(),@user,@password, 'no', @permission )", connection);

            command.Parameters.AddWithValue("@user",username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@permission", permission);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateAccount(string username, string password)
        {
            command = new SqlCommand(@"UPDATE TblUserAccount SET  Password=@password, Active='yes' 
WHERE UserName=@user", connection);

            command.Parameters.AddWithValue("@user", username);
            command.Parameters.AddWithValue("@password", password);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IDataReader RetriveUserAccount(string username, string password)
        {
            command = new SqlCommand(@"SELECT * FROM TblUserAccount 
WHERE UserName=@user COLLATE SQL_Latin1_General_CP1_CS_AS AND Password=@password COLLATE SQL_Latin1_General_CP1_CS_AS ", connection);

            command.Parameters.AddWithValue("@user", username);
            command.Parameters.AddWithValue("@password", password);

            connection.Open();

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader SelectUserList()
        {
            command = new SqlCommand(@"SELECT * FROM TblUserAccount", connection);
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader SelectUserListbyName(string username)
        {
            command = new SqlCommand(@"SELECT UserName FROM TblUserAccount
            WHERE UserName=@username", connection);
            command.Parameters.AddWithValue("@username", username);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader SelectPermissionAccount()
        {
            command = new SqlCommand(@"SELECT COUNT(*) as Number FROM TblUserAccount WHERE Permission='yes' ", connection);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void DeleteUserAccount(string userid)
        {
            command = new SqlCommand(@"DELETE FROM TblUserAccount WHERE userid=@userid", connection);

            command.Parameters.AddWithValue("@userid", userid);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
