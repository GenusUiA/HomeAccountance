using Course_project_HOME_ACCOUNTANCE.classes;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Interop.Excel;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;

namespace Course_project_HOME_ACCOUNTANCE.Expenses_functions
{
    public partial class Expenses : Form
    {

        private static bool switched = false;
        public Expenses()
        {
            InitializeComponent();
            LoadNames();
            Transactions.Columns["trans_id"].Visible = false;
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
                Transaction transaction = new Transaction();
                List<int> transactionIdsToDelete = new List<int>();
                foreach (DataGridViewRow row in Transactions.SelectedRows)
                {
                    int transactionId = Convert.ToInt32(row.Cells["trans_id"].Value); 
                    transactionIdsToDelete.Add(transactionId);
                }

                try
                {
                    foreach (int transactionId in transactionIdsToDelete)
                    {
                        transaction.DeleteTransactionFromDatabase(transactionId);
                    }

                    List<Transaction> transactions = transaction.GetUserTrans();
                    Transactions.DataSource = transactions;

                    if (transactionIdsToDelete.Count == 1)
                    {
                        MessageBox.Show("Транзакция успешно удалена.");
                    }
                    else
                    {
                        MessageBox.Show("Транзакции успешно удалены.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении транзакций: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите транзакции для удаления.");
            }
        }

        void LoadNames()         
        {
            List<String> Names = new List<String> { "Дате", "Сумме", "Категории", "Месту" };
            for(int i = 0; i < Names.Capacity; i++)
            {
                this.sorting_form.Items.Add(Names[i]);
            }
        }

        private List<Transaction> transactions = new List<Transaction>();
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
                if (transactions.Count == 0)
                {
                    Transaction transaction = new Transaction();
                    transactions = transaction.GetUserTrans();
                }

                switch (selectedColumn)
                {
                    case "Дате":
                        transactions = (sortDirection == "ASC")
                            ? transactions.OrderBy(t => t.date).ToList()
                            : transactions.OrderByDescending(t => t.date).ToList();
                        break;
                    case "Сумме":
                        transactions = (sortDirection == "ASC")
                            ? transactions.OrderBy(t => ConvertToInt(t.sum)).ToList()
                            : transactions.OrderByDescending(t => ConvertToInt(t.sum)).ToList();
                        break;
                    case "Категории":
                        transactions = (sortDirection == "ASC")
                            ? transactions.OrderBy(t => t.category).ToList()
                            : transactions.OrderByDescending(t => t.category).ToList();
                        break;
                    case "Месту":
                        transactions = (sortDirection == "ASC")
                            ? transactions.OrderBy(t => t.place).ToList()
                            : transactions.OrderByDescending(t => t.place).ToList();
                        break;
                }

                BindingSource TransBindingSource = new BindingSource();
                TransBindingSource.DataSource = transactions;
                Transactions.DataSource = TransBindingSource;
                switched = !switched;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении сортировки: " + ex.Message);
            }
        }

        private int ConvertToInt(string sumString)
        {
            if (int.TryParse(sumString, out int result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        private void Closer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Closer_MouseEnter_1(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Red;
        }

        private void Closer_MouseLeave(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Black;
        }

        private List<Transaction> LoadDataFromExcel()
        {
            string filePath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel файлы (*.xlsx; *.xls)|*.xlsx;*.xls";
            openFileDialog.Title = "Выберите файл Excel";
            List<Transaction> transactions = new List<Transaction>();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
            else
            {
                return new List<Transaction>();
            }
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                var workbook = excelApp.Workbooks.Open(filePath);
                var worksheet = workbook.Sheets[1]; 
                int rowCount = worksheet.UsedRange.Rows.Count;

                if (rowCount <= 1)
                {
                    MessageBox.Show("Файл Excel пуст или содержит только заголовок.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return transactions; 
                }

                int dateColumnIndex = FindColumnIndex(worksheet, "Дата");
                int sumColumnIndex = FindColumnIndex(worksheet, "Сумма");
                int categoryColumnIndex = FindColumnIndex(worksheet, "Категория");
                int placeColumnIndex = FindColumnIndex(worksheet, "Место");

                if (dateColumnIndex == -1 || sumColumnIndex == -1 || categoryColumnIndex == -1 || placeColumnIndex == -1)
                {
                    MessageBox.Show("Не найдены все необходимые столбцы в файле Excel.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return transactions;
                }


                for (int row = 2; row <= rowCount; row++)
                {
                    DateTime date;
                    string sum;
                    string category;
                    string place;

                    object dateValue = worksheet.Cells[row, dateColumnIndex].Value2;
                    object sumValue = worksheet.Cells[row, sumColumnIndex].Value2;
                    object categoryValue = worksheet.Cells[row, categoryColumnIndex].Value2;
                    object placeValue = worksheet.Cells[row, placeColumnIndex].Value2;

                    if (dateValue == null || !DateTime.TryParse(dateValue.ToString(), out date))
                    {
                        Console.WriteLine($"Ошибка чтения даты в строке {row}");
                        continue;
                    }
                    sum = sumValue?.ToString() ?? "0";
                    category = categoryValue?.ToString() ?? "Не указана";
                    place = placeValue?.ToString() ?? "Не указано";
                    int userId = Session.Id;
                    SaveToDatabase(date, sum, category, place, userId);
                    transactions.Add(new Transaction { date = date, sum = sum, category = category, place = place });
                }
                MessageBox.Show("Транзакциии успешно записаны" +
                    "!");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке файла Excel: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            return transactions;
        }


        private void SaveToDatabase(DateTime date, string sum, string category, string place, int id)
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

        private int FindColumnIndex(Microsoft.Office.Interop.Excel.Worksheet worksheet, string columnName)
        {
            Range foundCell = worksheet.Cells.Find(columnName, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            return foundCell == null ? -1 : foundCell.Column;
        }

        private void LoadTr_Click(object sender, EventArgs e)
        {
            LoadDataFromExcel();
            Transaction transaction = new Transaction();
            List<Transaction> transactions = transaction.GetUserTrans();
            Transactions.DataSource = transactions;
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