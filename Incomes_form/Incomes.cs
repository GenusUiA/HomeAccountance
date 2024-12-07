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
            Inc.Columns["income_id"].Visible = false;
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
                int IncomeId = Convert.ToInt32(row.Cells[0].Value);
                Income income = new Income(); 
                try
                {
                    income.DeleteIncomeFromDatabase(IncomeId);
                    List<Income> incomes = income.GetUserIncome();
                    Inc.DataSource = incomes;
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

        void LoadNames()
        {
            List<String> Names = new List<String> { "Sum", "Category" };
            for (int i = 0; i < 2; i++)
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
                    case "Sum":
                        Incomes = (sortDirection == "ASC")
                            ? Incomes.OrderBy(t => t.sum).ToList()
                            : Incomes.OrderByDescending(t => t.sum).ToList();
                        break;
                    case "Category":
                        Incomes = (sortDirection == "ASC")
                            ? Incomes.OrderBy(t => t.category).ToList()
                            : Incomes.OrderByDescending(t => t.category).ToList();
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
    }
}
