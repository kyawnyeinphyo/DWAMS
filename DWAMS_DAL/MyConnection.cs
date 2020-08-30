using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Configuration;

namespace DWAMS_DAL
{
    public class MyConnection
    {
        protected SqlConnection connection;
        protected SqlCommand command;
        protected String sqlString;

        public MyConnection()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        }
    }
}
