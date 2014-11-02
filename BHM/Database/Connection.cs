using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using DapperExtensions;

namespace BHM.Database
{
    public sealed class Connection
    {
        private static readonly Connection instance = new Connection();
        private readonly MySqlConnection connection;

        static Connection()
        {
        }

        private Connection()
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(BHM.Extensions.CustomPluralizedMapper<>);
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();
            var connectionString = new StringBuilder();
            connectionString.AppendFormat("server={0};",Properties.Settings.Default.DBServer);
            connectionString.AppendFormat("uid={0};",Properties.Settings.Default.DBUser);
            connectionString.AppendFormat("database={0};",Properties.Settings.Default.DBName);
            connectionString.AppendFormat("port={0};",Properties.Settings.Default.DBPort);
            connectionString.AppendFormat("password={0};",Properties.Settings.Default.DBPassword);            
               
            connection = new MySqlConnection(connectionString.ToString());
        }

        public static Connection Instance
        {
            get { return instance; }
        }

        public MySqlConnection GetMySqlConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                return connection;
            }
            else
            {
                connection.Open();
                return connection;
            }
        }
    }
}
