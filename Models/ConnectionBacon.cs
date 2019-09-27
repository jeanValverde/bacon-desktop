using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bacon_desktop.Models
{
    public class ConnectionBacon 
    {
        //string conString = "User Id=admin;Password=sistemabacon;" +
        //        "Data Source=bacon.csaengiwk4kq.us-east-1.rds.amazonaws.com:1521/ORCL;";

        private static string id = "admin";
        private static string password = "sistemabacon";
        private static string host = "bacon.csaengiwk4kq.us-east-1.rds.amazonaws.com";
        private static string puerto = "1521";
        private static string sid = "ORCL";
        private string conn = $"User Id={id};Password={password}; Data Source={host}:{puerto}/{sid};";

        public OracleConnection connection ; 

        public ConnectionBacon()
        {
            connection = new OracleConnection(conn);
        }

        public OracleConnection Connection()
        {
            connection.Open();
            return connection;
        }
       
        public void CloseConnection()
        {
            connection.Open();
        }
    }
}
