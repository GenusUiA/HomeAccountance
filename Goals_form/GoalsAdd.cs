using Course_project_HOME_ACCOUNTANCE.classes;
using DocumentFormat.OpenXml.Wordprocessing;
using iText.Layout.Element;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            from.Value = DateTime.Now;
 
            For.Value = DateTime.Now;
        }

        private void SaveToDatabase(string definition, decimal sum, DateTime[] period, int id)
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
            Goal goal = new Goal();
            goal.definition = defform.Text;
            goal.sum = decimal.Parse(sumform.Text); 
            goal.period = new DateTime[] { from.Value, For.Value };
            SaveToDatabase(goal.definition, goal.sum, goal.period, Session.Id);
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
                        MessageBox.Show("Цель не найдена или произошла ошибка при удалении.");
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
            goal.definition = defform.Text;
            DeleteGoalFromDatabase(goal.definition, Session.Id);
        }

        private void SumAdd_Click(object sender, EventArgs e)
        {
            Goal goal = new Goal();
            goal.definition = sumdef.Text;
            goal.current_sum = decimal.Parse(addsum.Text);
            UpdateGoalSumByDef(goal.definition, goal.current_sum, Session.Id);
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
