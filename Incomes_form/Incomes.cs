using Course_project_HOME_ACCOUNTANCE.classes;
using Course_project_HOME_ACCOUNTANCE.Incomes_form;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE
{
    public partial class Incomes : Form
    {

        public Incomes()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Search_Click(object sender, System.EventArgs e)
        {
            BindingSource IncomeBindingSource = new BindingSource();
            Income income = new Income();
            string searchText = Searcher.Text;
            List<Income> incomes = income.searchCategory(searchText);
            IncomeBindingSource.DataSource = incomes;
        }

        private void Incomes_Load(object sender, System.EventArgs e)
        { 
            Income income = new Income();
            List<Income> incomes = income.GetUserIncome();
            Inc.DataSource = incomes;
        }

        private void addincome_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            IncomesAdd incomes = new IncomesAdd();
            incomes.Show();
        }

        private void removeincome_Click(object sender, System.EventArgs e)
        {
            if (Inc.SelectedRows.Count > 0)
            {
                DataGridViewRow row = Inc.SelectedRows[0];
                int sum = Convert.ToInt32(row.Cells["sum"].Value);
                string category = row.Cells["category"].Value.ToString();
                Income inc = new Income();
                try
                {
                    inc.DeleteIncomeFromDatabase(sum, category);
                    List<Income> income = inc.GetUserIncome();
                    Inc.DataSource = income;
                    MessageBox.Show("Доход успешно удален.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении дохода: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите доход для удаления.");
            }
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
