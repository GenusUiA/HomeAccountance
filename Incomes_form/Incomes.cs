using Course_project_HOME_ACCOUNTANCE.classes;
using Course_project_HOME_ACCOUNTANCE.Incomes_form;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE
{
    public partial class Incomes : Form
    {

        public Incomes()
        {
            InitializeComponent();
            LoadNames();
            Inc.AutoGenerateColumns = false;
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
            Inc.DataSource = IncomeBindingSource;
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
                Income income = new Income();
                List<int> incomeIdsToDelete = new List<int>();

                foreach (DataGridViewRow row in Inc.SelectedRows)
                {
                    int incomeId = Convert.ToInt32(row.Cells["income_id"].Value);
                    incomeIdsToDelete.Add(incomeId);
                }

                try
                {
                    foreach (int incomeId in incomeIdsToDelete)
                    {
                        income.DeleteIncomeFromDatabase(incomeId);
                    }

                    List<Income> incomes = income.GetUserIncome();
                    Inc.DataSource = incomes;

                    if (incomeIdsToDelete.Count == 1)
                    {
                        MessageBox.Show("Доход успешно удален.");
                    }
                    else
                    {
                        MessageBox.Show("Доходы успешно удалены.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении доходов: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите доходы для удаления.");
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

        void LoadNames()
        {
            List<String> Names = new List<String> { "Сумме", "Категории", "Дате" };
            for (int i = 0; i < 3; i++)
            {
                this.sorting_form.Items.Add(Names[i]);
            }
        }

        private bool switched = false;

        private void Sorting_Click(object sender, EventArgs e)
        {
            string selectedColumn = sorting_form.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedColumn))
            {
                MessageBox.Show("Пожалуйста, выберите параметр для сортировки.");
                return;
            }
            string sortDirection = switched ? "DESC" : "ASC";

            try
            {
                List<Income> Incomes = new List<Income>();
                Income income = new Income();
                Incomes = income.GetUserIncome();

                switch (selectedColumn)
                {
                    case "Сумме":
                        Incomes = (sortDirection == "ASC")
                            ? Incomes.OrderBy(t => t.sum).ToList()
                            : Incomes.OrderByDescending(t => t.sum).ToList();
                        break;
                    case "Категории":
                        Incomes = (sortDirection == "ASC")
                            ? Incomes.OrderBy(t => t.category).ToList()
                            : Incomes.OrderByDescending(t => t.category).ToList();
                        break;
                    case "Дате":
                        Incomes = (sortDirection == "ASC")
                            ? Incomes.OrderBy(t => t.date).ToList()
                            : Incomes.OrderByDescending(t => t.date).ToList();
                        break;
                }
                BindingSource IncBindingSource = new BindingSource();
                IncBindingSource.DataSource = Incomes;
                Inc.DataSource = IncBindingSource;
                switched = !switched;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении сортировки: " + ex.Message);
            }
        }

        private void Searcher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Search.PerformClick();
                e.Handled = true;
            }
        }
    }
}
