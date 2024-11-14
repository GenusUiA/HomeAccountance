using Course_project_HOME_ACCOUNTANCE.classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE.Incomes_form
{
    public partial class IncomesAdd : Form
    {
        public IncomesAdd()
        {
            InitializeComponent();
        }

        private void Incomes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Incomes incomes = new Incomes();
            incomes.Show();
        }

        void SaveToDatabase(int sum, string category, int id)
        {
            string query = "INSERT INTO \"Incomes\" (sum, category, id) VALUES (@sum, @category, @id)";
            Database database = new Database();
            database.OpenConnection();
            try
            {
                using (var command = new NpgsqlCommand(query, database.ConnectionString()))
                {
                    command.Parameters.AddWithValue("@sum", sum);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Доход успешно создан!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании дохода: " + ex.Message);
            }
            finally
            {
                database.CloseConnection();
            }
        }

        private void AddIncome_Click(object sender, EventArgs e)
        {
            string summa = sumform.Text;
            int sum;
            int.TryParse(summa, out sum);
            string category = categoryform.Text;
            SaveToDatabase(sum, category, Session.Id);
        }
    }
}
