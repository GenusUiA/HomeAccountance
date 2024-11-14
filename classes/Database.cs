using Npgsql;
namespace Course_project_HOME_ACCOUNTANCE
{
    internal class Database
    {
        public static string connectionString = "Server=localhost;Port=1111;Database=users; User Id = postgres; Password=1111";
        NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString);
        public NpgsqlConnection ConnectionString()
        {
            return sqlConnection;
        }
        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
    }
}
