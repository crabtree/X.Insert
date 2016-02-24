using Simple.Data;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace X.Insert.Helper
{
    public static class DatabaseHelper
    {
        public const string DefaultConnectionStringName = "Default";

        public static dynamic GetDatabaseConnection(string connectionStringName = DefaultConnectionStringName)
        {
            if (string.IsNullOrWhiteSpace(connectionStringName)) throw new ArgumentNullException("connectionStringName");

            return Database.OpenConnection(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString);
        }

        public static SqlConnectionStringBuilder GetConnectionStringBuilder(string connectionStringName = DefaultConnectionStringName)
        {
            if (string.IsNullOrWhiteSpace(connectionStringName)) throw new ArgumentNullException("connectionStringName");

            return new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString);
        }
    }
}
