using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE.classes
{
    public class Income
    {
        public int income_id { get; set; }
        public decimal sum { get; set; }
        public string category { get; set; }
        public DateTime date {get; set;}

        public List<Income> GetUserIncome()
        {
            List<Income> returnThese = new List<Income>();
            Database db = new Database();
            db.OpenConnection();
            int id = Session.Id;
            NpgsqlCommand command = new NpgsqlCommand("SELECT income_id, sum, category, date FROM \"Incomes\" WHERE id = @id", db.ConnectionString());
            command.Parameters.AddWithValue("@id", id);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Income income = new Income
                    {
                        income_id = reader.GetInt32(0),
                        sum = reader.GetDecimal(1),
                        category = reader.GetString(2),
                        date = reader.GetDateTime(3)
                    };
                    returnThese.Add(income);
                }
                db.CloseConnection();
            }
            return returnThese;
        }

        public List<Income> searchCategory(string searchCateg)
        {
            Income income = new Income();
            List<Income> incomes = income.GetUserIncome();
            return incomes.Where(X => X.category.Contains(searchCateg)).ToList();  
        }

        public void DeleteIncomeFromDatabase(int income_id)
        {
            Database db = new Database();
            try
            {
                db.OpenConnection();
                string query = "DELETE FROM \"Incomes\" WHERE income_id = @income_id";
                using (NpgsqlCommand command = new NpgsqlCommand(query, db.ConnectionString()))
                {
                    command.Parameters.AddWithValue("@income_id", income_id);
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
