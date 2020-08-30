using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DWAMS_DAL
{
    public class PositionDataController: MyConnection
    {

        public void Insert(string departmentid, string Name, string Desp)
        {
            command = new SqlCommand("spdPositionInsert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@departmentid", SqlDbType.VarChar).Value = departmentid;
            command.Parameters.Add("@position", SqlDbType.NVarChar).Value = Name;
            command.Parameters.Add("@desp", SqlDbType.NVarChar).Value = Desp;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(string positionid, string departmentid, string Name, string Desp)
        {
            command = new SqlCommand("spdPositionUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@positionid", SqlDbType.Char).Value = positionid;
            command.Parameters.Add("@departmentid", SqlDbType.Char).Value = departmentid;
            command.Parameters.Add("@position", SqlDbType.NVarChar).Value = Name;
            command.Parameters.Add("@desp", SqlDbType.NVarChar).Value = Desp;


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(string Id)
        {
            command = new SqlCommand("spdPositionDelete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@positionid", SqlDbType.Char).Value = Id;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IDataReader SelectList()
        {
            command = new SqlCommand("spdPositionSelect", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
       
        public IDataReader SelectPositionbyDepartment(string depId)
        {
            sqlString = @"	SELECT     dbo.TblDepartment.DepName, dbo.TblDepartment.DepId, dbo.TblPosition.PositionId, dbo.TblPosition.Position, dbo.TblPosition.Desp
	FROM         dbo.TblDepartment INNER JOIN
	dbo.TblPosition ON dbo.TblDepartment.DepId = dbo.TblPosition.DepId  WHERE TblDepartment.DepId=@depId ORDER BY TblDepartment.DepName,TblPosition.Position";

            command = new SqlCommand(sqlString, connection);

            command.Parameters.AddWithValue("@depId", depId);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader SelectList(string departmentid) //for staff
        {
            sqlString = @"	SELECT      dbo.TblPosition.PositionId, dbo.TblPosition.Position
            FROM         dbo.TblDepartment INNER JOIN
            dbo.TblPosition ON dbo.TblDepartment.DepId = dbo.TblPosition.DepId WHERE TblDepartment.DepId=@departmentid ORDER BY TblPosition.Position";

            command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@departmentid", departmentid);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
