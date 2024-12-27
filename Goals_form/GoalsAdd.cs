using Course_project_HOME_ACCOUNTANCE.classes;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Wordprocessing;
using iText.Layout.Element;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace Course_project_HOME_ACCOUNTANCE.Goals_form
{
    public partial class Goals : Form
    {
        public Goals()
        {
            InitializeComponent();
            from.MaxDate = DateTime.Now;
            from.MinDate = DateTime.Now;
            For.MinDate = from.Value;
        }

        private void SaveGoalToDatabase(string definition, decimal sum, DateTime[] period, int id)
        {
            string query = "INSERT INTO \"Goals\" (definition, sum, period, id) VALUES (@definition, @sum, @period, @id)";
            Database database = new Database();
            database.OpenConnection();
            try
            {
                using (var command = new NpgsqlCommand(query, database.ConnectionString()))
                {
                    command.Parameters.AddWithValue("@definition", definition);
                    command.Parameters.AddWithValue("@sum", sum);
                    command.Parameters.AddWithValue("@period", period);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Цель успешно создана!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании цели: " + ex.Message);
            }
            finally
            {
                database.CloseConnection();
            }
        }

        private void AddGoal_Click(object sender, EventArgs e)
        {
            int maxGoals = 6;
            int currentGoalCount = GetCurrentGoalCountFromDatabase(Session.Id);

            if (currentGoalCount >= maxGoals)
            {
                MessageBox.Show($"Вы достигли максимального количества целей ({maxGoals}).");
                return;
            }

            Goal goal = new Goal();
            goal.definition = defform.Text.Trim();
            goal.period = new DateTime[] { from.Value, For.Value };


            if (string.IsNullOrWhiteSpace(goal.definition))
            {
                MessageBox.Show("Название не может быть пустым!");
            }
            else if (goal.definition.Length > 16)
            {
                MessageBox.Show("Название цели не может быть больше 16 символов!");
            }
            else if (IsGoalDuplicate(goal.definition, Session.Id))
            {
                MessageBox.Show("Цель с таким названием уже существует. Пожалуйста, выберите другое название.");
            }
            else if (decimal.TryParse(sumform.Text, out decimal sum))
            {
                SaveGoalToDatabase(goal.definition, sum, goal.period, Session.Id);
                defform.Text = string.Empty; 
                For.Value = DateTime.Now;
                sumform.Text = string.Empty; 
            }
            else
            {
                MessageBox.Show("Сумма должна быть числом!");
            }
        }

        private bool IsGoalDuplicate(string definition, int id)
        {
            bool isDuplicate = false;

            Database db = new Database();
            using (var connection = db.ConnectionString())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM \"Goals\" WHERE id = @id AND definition = @definition";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@definition", definition);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    isDuplicate = count > 0;
                }
            }
            return isDuplicate;
        }

        private int GetCurrentGoalCountFromDatabase(int id)
        {
            int count = 0;
            Database db = new Database();
            using (var connection = db.ConnectionString()) 
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM \"Goals\" WHERE id = @id"; 
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    count = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return count;
        }

        private void Closer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Closer_MouseEnter(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Red;
        }

        private void Closer_MouseLeave(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Black;
        }

        private void UpdateGoalSumByDef(string definition, decimal current_sum, int id)
        {
            string query = "UPDATE \"Goals\" SET current_sum = current_sum + @current_sum WHERE definition = @definition AND id = @id";
            Database database = new Database();
            database.OpenConnection();
            try
            {
                using (var command = new NpgsqlCommand(query, database.ConnectionString()))
                {
                    command.Parameters.AddWithValue("@current_sum", current_sum);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@definition", definition);
                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Нет цели с таким определением");
                        }
                        else
                        {
                            MessageBox.Show("Сумма успешно добавлена");
                        }
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show($"Ошибка при добавлении суммы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении суммы: " + ex.Message);
            }
            finally
            {
                database.CloseConnection();
            }
        }

        private void DeleteGoalFromDatabase(string definition, int id)
        {
            string query = "DELETE FROM \"Goals\" WHERE id = @id AND definition = @definition";
            Database database = new Database();
            database.OpenConnection();
            try
            {
                using (var command = new NpgsqlCommand(query, database.ConnectionString()))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@definition", definition);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Цель успешно удалена!");
                    }
                    else
                    {
                        MessageBox.Show("Цель не найдена.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении цели: " + ex.Message);
            }
            finally
            {
                database.CloseConnection();
            }
        }

        private void DelGoal_Click(object sender, EventArgs e)
        {
            Goal goal = new Goal();
            goal.definition = deldef.Text.Trim();
            if (string.IsNullOrWhiteSpace(goal.definition))
            {
                MessageBox.Show("Название не может быть пустым!");
            }
            else
            {
                DeleteGoalFromDatabase(goal.definition, Session.Id);
                deldef.Text = string.Empty;
            }
        }

        private void SumAdd_Click(object sender, EventArgs e)
        {
            Goal goal = new Goal();
            goal.definition = sumdef.Text.Trim();
            if (string.IsNullOrWhiteSpace(goal.definition))
            {
                MessageBox.Show("Название не может быть пустым!");
            }
            else if (decimal.TryParse(addsum.Text, out decimal sum))
            {
                UpdateGoalSumByDef(goal.definition, sum, Session.Id);
                sumdef.Text = string.Empty;
                addsum.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Сумма должна быть числом!");
            }
        }

        private void Main_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
