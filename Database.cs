using Npgsql;
using System.Data;

namespace Database
{
    internal class Database
    {
        static string ConnectionString = "Server=localhost;Port=1111;Database=users; User Id = postgres; Password=1111";
        NpgsqlConnection sqlConnection = new NpgsqlConnection(ConnectionString);
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

        public void sql_connection_reader()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(ConnectionString);
            sqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM users";
            NpgsqlDataReader datareader = command.ExecuteReader();
            if (datareader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(datareader);
            }
            command.Dispose();
            sqlConnection.Close();
        }
    }
}
