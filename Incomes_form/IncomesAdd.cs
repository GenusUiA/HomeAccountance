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
            dateform.MaxDate = DateTime.Now;
        }

        private void Incomes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Incomes incomes = new Incomes();
            incomes.Show();
        }

        void SaveToDatabase(int sum, string category, int id, DateTime date)
        {
            string query = "INSERT INTO \"Incomes\" (sum, category, id, date) VALUES (@sum, @category, @id, @date)";
            Database database = new Database();
            database.OpenConnection();
            try
            {
                using (var command = new NpgsqlCommand(query, database.ConnectionString()))
                {
                    command.Parameters.AddWithValue("@sum", sum);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@date", date);
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
            string dateString = dateform.Text;
            DateTime date;
            DateTime.TryParse(dateString, out date);
            SaveToDatabase(sum, category, Session.Id, date);
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
    }
}
