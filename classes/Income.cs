using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE.classes
{
    internal class Income
    {
        public int sum { get; set; }
        public string category { get; set; }
        public List<Income> GetUserIncome()
        {
            List<Income> returnThese = new List<Income>();
            Database db = new Database();
            db.OpenConnection();
            int id = Session.Id;
            NpgsqlCommand command = new NpgsqlCommand("SELECT sum, category FROM \"Incomes\" WHERE id = @id", db.ConnectionString());
            command.Parameters.AddWithValue("@id", id);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Income income = new Income
                    {
                        sum = reader.GetInt32(0),
                        category = reader.GetString(1),
                    };
                    returnThese.Add(income);
                }
                db.CloseConnection();
            }
            return returnThese;
        }

        public List<Income> searchCategory(string searchCateg)
        {
            List<Income> returnThese = new List<Income>();
            Database db = new Database();
            db.OpenConnection();
            int id = Session.Id;
            NpgsqlCommand command = new NpgsqlCommand();
            string SubString = "%" + searchCateg + "%";
            command.CommandText = "SELECT * FROM \"Incomes\" WHERE id = @id AND category LIKE @searchCateg";
            command.Connection = db.ConnectionString();
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@searchCateg", SubString);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Income income = new Income
                    {
                        sum = reader.GetInt32(1),
                        category = reader.GetString(2),
                    };
                    returnThese.Add(income);
                }
                db.CloseConnection();
            }
            return returnThese;
        }

        public void DeleteIncomeFromDatabase(int summ, string categories)
        {
            Database db = new Database();
            try
            {
                db.OpenConnection();
                string query = "DELETE FROM \"Incomes\" WHERE sum = @sum AND category = @category";
                using (NpgsqlCommand command = new NpgsqlCommand(query, db.ConnectionString()))
                {
                    command.Parameters.AddWithValue("@sum", summ);
                    command.Parameters.AddWithValue("@category", categories);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении дохода: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }
}
