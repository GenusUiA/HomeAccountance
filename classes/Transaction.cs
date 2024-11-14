using System;
using Course_project_HOME_ACCOUNTANCE.classes;
using iTextSharp.text;
using System.Collections.Generic;
using Npgsql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE.classes
{
    internal class Transaction
    {
        public DateTime date { get; set; }
        public string sum { get; set; }
        public string category { get; set; }
        public string place { get; set; }

        public List<Transaction> GetUserTrans()
        {
            List<Transaction> returnThese = new List<Transaction>();
            Database db = new Database();
            db.OpenConnection();
            int id = Session.Id;
            NpgsqlCommand command = new NpgsqlCommand("SELECT date, sum, category, place FROM \"Transactions\" WHERE id = @id", db.ConnectionString());
            command.Parameters.AddWithValue("@id", id);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Transaction trans = new Transaction
                    {
                        date = reader.GetDateTime(0),
                        sum = reader.GetString(1),
                        category = reader.GetString(2),
                        place = reader.GetString(3),
                    };
                    returnThese.Add(trans);
                }
                db.CloseConnection();
            }
            return returnThese;
        }

        public List<Transaction> searchCategory(string searchCateg)
        {
            List<Transaction> returnThese = new List<Transaction>();
            Database db = new Database();
            db.OpenConnection();
            int id = Session.Id;
            NpgsqlCommand command = new NpgsqlCommand();
            string SubString = "%" + searchCateg + "%";
            command.CommandText = "SELECT * FROM \"Transactions\" WHERE id = @id AND category LIKE @searchCateg";
            command.Connection = db.ConnectionString();
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@searchCateg", SubString);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Transaction trans = new Transaction
                    {
                        date = reader.GetDateTime(1),
                        sum = reader.GetString(2),
                        category = reader.GetString(3),
                        place = reader.GetString(4),
                    };
                    returnThese.Add(trans);
                }
                db.CloseConnection();
            }
            return returnThese;
        }

        public void DeleteTransactionFromDatabase(int transactionId)
        {
            Database db = new Database();
            try
            {
                db.OpenConnection();
                string query = "DELETE FROM \"Transactions\" WHERE trans_id = @trans_id";
                using (NpgsqlCommand command = new NpgsqlCommand(query, db.ConnectionString()))
                {
                    command.Parameters.AddWithValue("@trans_id", transactionId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении транзакции: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }
}
