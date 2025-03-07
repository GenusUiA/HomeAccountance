﻿using Course_project_HOME_ACCOUNTANCE.classes;
using Course_project_HOME_ACCOUNTANCE.Expenses_functions;
using Npgsql;
using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Course_project_HOME_ACCOUNTANCE
{
    public partial class TransactionsAdd : Form
    {
        public TransactionsAdd()
        {
            InitializeComponent();
            LoadCategories();
            dateform.MaxDate = DateTime.Now;
            dateform.Value = DateTime.Now.AddDays(-1);
        }

        private void LoadCategories()
        {
            try
            {
                string connectionString = "Server=localhost;Port=1111;Database=users;User Id=postgres;Password=1111";

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT category FROM categories";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            categoryform.Items.Clear(); 

                            while (reader.Read())
                            {
                                string category = reader["category"].ToString();
                                this.categoryform.Items.Add(category);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке категорий: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryform.SelectedItem != null)
            {
                string selectedCategory = categoryform.SelectedItem.ToString();
            }
        }

        private void SaveToDatabase(DateTime date, decimal sum, string category, string place, int id)
        {
            string query = "INSERT INTO \"Transactions\" (date, sum, category, place, id) VALUES (@date, @sum, @category, @place, @id)";
            Database database = new Database();
            database.OpenConnection();
            try
            {
                using (var command = new NpgsqlCommand(query, database.ConnectionString()))
                {
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@sum", sum); 
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@place", place);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Транзакция успешно создана!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании транзакции: " + ex.Message);
            }
            finally
            {
                database.CloseConnection();
            }
        }

        private void CreateTransaction_Click(object sender, EventArgs e)
        {
            DateTime date = dateform.Value;
            string category = categoryform.Text.Trim(); 
            string place = placeform.Text.Trim(); 

            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Категория не может быть пустой!");
            }
            else if (string.IsNullOrWhiteSpace(place))
            {
                MessageBox.Show("Место не может быть пустым!");
            }
            else if (decimal.TryParse(sumform.Text, out decimal sum))
            {
                SaveToDatabase(date, sum, category, place, Session.Id);
                dateform.Value = DateTime.Now.AddDays(-1);
                categoryform.Text = string.Empty;
                placeform.Text = string.Empty;
                sumform.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Сумма должна быть числом!");
            }
        }

        private void Expenses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Expenses expenses = new Expenses();
            expenses.Show();
        }

        private void Closer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Closer_MouseLeave(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Black;
        }

        private void Closer_MouseEnter(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Red;
        }
    }
}
