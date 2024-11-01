using Npgsql;
using System;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE
{
    public partial class Goals : Form
    {
        private string id;
        public Goals(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void SaveToDatabase(int id, string definition, decimal sum, string period, string status, decimal currentSum)
        {
            string connectionString = "Server=localhost;Port=1111;Database=users;User Id=postgres;Password=1111";
            string query = "INSERT INTO Goals (id, definition, sum, period, status, current_sum) VALUES (@id, @definition, @sum, @period, @status, @current_sum)";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@definition", definition);
                    command.Parameters.AddWithValue("@sum", sum);
                    command.Parameters.AddWithValue("@period", period);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@current_sum", currentSum);
                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Цель успешно добавлена");
                        }
                        else
                        {
                            MessageBox.Show("Произошла ошибка при добавлении цели.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
        }

    }
}
