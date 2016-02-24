using X.Insert.Helper;

namespace X.Insert.Reader.Services
{
    public abstract class ReadService
    {
        protected string ConnectionStringName { get; private set; }

        public ReadService()
        {
            ConnectionStringName = DatabaseHelper.DefaultConnectionStringName;
        }

        public ReadService(string connectionStringName)
        {
            ConnectionStringName = connectionStringName;
        }

        protected dynamic GetDatabaseConnection()
        {
            return DatabaseHelper.GetDatabaseConnection(ConnectionStringName);
        }
    }
}
