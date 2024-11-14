using Course_project_HOME_ACCOUNTANCE.classes;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE.Expenses_functions
{
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
        }

        private void AddIncome_Click(object sender, EventArgs e)
        {
            this.Close();
            TransactionsAdd transactionsAdd = new TransactionsAdd();
            transactionsAdd.ShowDialog();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            BindingSource TransBindingSource = new BindingSource();
            Transaction transaction = new Transaction();
            string searchText = Searcher.Text;
            List<Transaction> transactions = transaction.searchCategory(searchText);
            TransBindingSource.DataSource = transactions;
            Transactions.DataSource = TransBindingSource;
        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction();
            List<Transaction> transactions = transaction.GetUserTrans();
            Transactions.DataSource = transactions;
        }

        private void Closer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Closer_MouseEnter(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Red;
        }

        private void Closer_MouseMove(object sender, MouseEventArgs e)
        {
            Closer.ForeColor = Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (Transactions.SelectedRows.Count > 0)
            {
                DataGridViewRow row = Transactions.SelectedRows[0];
                int transactionId = Convert.ToInt32(row.Cells[0].Value);
                Transaction transaction = new Transaction();

                try
                {
                    transaction.DeleteTransactionFromDatabase(transactionId);
                    List<Transaction> transactions = transaction.GetUserTrans();
                    Transactions.DataSource = transactions;
                    MessageBox.Show("Транзакция успешно удалена.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении транзакции: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите транзакцию для удаления.");
            }
        }
    }
}