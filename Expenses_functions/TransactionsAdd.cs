using Npgsql;
using System;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE
{
    public partial class TransactionsAdd : Form
    {
        public TransactionsAdd()
        {
            InitializeComponent();
            LoadCategories();
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
                            comboBox1.Items.Clear(); 

                            while (reader.Read())
                            {
                                string category = reader["category"].ToString();
                                comboBox1.Items.Add(category);
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
            if (comboBox1.SelectedItem != null)
            {
                string selectedCategory = comboBox1.SelectedItem.ToString();
            }
        }

        private void CreateTransaction_Click(object sender, EventArgs e)
        {

        }
    }
}
