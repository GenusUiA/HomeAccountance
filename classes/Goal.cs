using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE.classes
{
    public class Goal
    {
        public int goal_id { get; set; }
        public string definition { get; set; }
        public decimal sum { get; set; }
        public decimal current_sum { get; set; }
        public DateTime[] period { get; set; }

        public List<Goal> GetGoalsFromDatabase(NpgsqlConnection connection)
        {
            List<Goal> goals = new List<Goal>();
            try
            {
                using (var command = new NpgsqlCommand("SELECT definition, current_sum, sum, period FROM \"Goals\" WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", Session.Id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime[] period = reader.GetFieldValue<DateTime[]>(2);

                            goals.Add(new Goal
                            {
                                definition = reader.GetString(0),
                                current_sum = reader.GetDecimal(1),
                                sum = reader.GetDecimal(2),
                                period = period,
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching goals from database: {ex.Message}");
            }
            return goals;
        }

        public DateTime[] GetPeriod(NpgsqlConnection connection)
        {
            DateTime[] period = null;
            try
            {
                using (var command = new NpgsqlCommand("SELECT period FROM \"Goals\" WHERE id = @id AND definition = @definition", connection))
                {
                    command.Parameters.AddWithValue("@id", Session.Id);
                    command.Parameters.AddWithValue("@definition", definition);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            period = reader.GetFieldValue<DateTime[]>(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка доставания цели из БД: {ex.Message}");
            }
            return period;
        }
    }
}