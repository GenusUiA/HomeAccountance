using Course_project_HOME_ACCOUNTANCE.classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Npgsql;
using System.Linq;
using DocumentFormat.OpenXml.ExtendedProperties;
using System.Drawing;

namespace Course_project_HOME_ACCOUNTANCE.Reports_creating
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            dateform.MaxDate = DateTime.Now;

            From.MaxDate = DateTime.Now;
            dateform.MaxDate = DateTime.Now;
            From.Value = DateTime.Now;
            dateform.Value = DateTime.Now;

            // Привязка обработчиков событий
            From.ValueChanged += From_ValueChanged;
            dateform.ValueChanged += For_ValueChanged;

            void From_ValueChanged(object sender, EventArgs e)
            {
                // Проверка: начальная дата не должна быть больше конечной
                if (From.Value > dateform.Value)
                {
                    // Если начальная дата больше конечной, то конечная приравнивается к начальной
                    dateform.Value = From.Value;
                }
                dateform.MinDate = From.Value;
            }

            void For_ValueChanged(object sender, EventArgs e)
            {
                // Проверка: Конечная дата не должна быть меньше начальной
                if (dateform.Value < From.Value)
                {
                    // Если конечная дата меньше начальной, то начальная приравнивается к конечной
                    From.Value = dateform.Value;
                }

            }
        }

        private void MainWindow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private async Task<List<Transaction>> LoadTransactionsAsync(int userId, DateTime startDate, DateTime endDate)
        {
            List<Transaction> transactions = new List<Transaction>();
            var db = new Database();
          
            try
            {
                await db.OpenConnectionAsync();

                using (var command = await db.CreateCommandAsync(
                    @"SELECT date, sum, category, place 
                    FROM ""Transactions"" 
                    WHERE id = @userId AND date >= @startDate AND date <= @endDate",
                    new NpgsqlParameter("@userId", userId),
                    new NpgsqlParameter("@startDate", startDate),
                    new NpgsqlParameter("@endDate", endDate)))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            transactions.Add(new Transaction
                            {
                                date = reader.GetDateTime(reader.GetOrdinal("date")),
                                sum = reader.GetString(reader.GetOrdinal("sum")),
                                category = reader.IsDBNull(reader.GetOrdinal("category")) ? "Не указана" : reader.GetString(reader.GetOrdinal("category")),
                                place = reader.IsDBNull(reader.GetOrdinal("place")) ? "Не указано" : reader.GetString(reader.GetOrdinal("place"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке транзакций: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
            transactions = transactions.OrderBy(t => t.date).ToList();
            return transactions;
        }

        private void CreateExcelReport(List<Transaction> transactions, string filePath, DateTime startDate, DateTime endDate)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook workbook = excel.Workbooks.Add(Type.Missing);
                Worksheet worksheet = (Worksheet)workbook.ActiveSheet;
                worksheet.Name = "Отчет";
                worksheet.Cells[1, 1] = "Дата";
                worksheet.Cells[1, 2] = "Сумма";
                worksheet.Cells[1, 3] = "Категория";
                worksheet.Cells[1, 4] = "Место";
                int row = 2;
                foreach (var transaction in transactions)
                {
                    worksheet.Cells[row, 1] = transaction.date.ToString("dd.MM.yyyy");
                    worksheet.Cells[row, 2] = transaction.sum;
                    worksheet.Cells[row, 3] = transaction.category;
                    worksheet.Cells[row, 4] = transaction.place;
                    row++;
                }
                Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range["A1", "D1"];
                headerRange.Font.Bold = true;
                headerRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                headerRange.VerticalAlignment = XlVAlign.xlVAlignCenter;

                Microsoft.Office.Interop.Excel.Range dataRange = worksheet.Range["A1", "D" + (row - 1)];
                dataRange.Columns.AutoFit();

                workbook.SaveAs(filePath);

                workbook.Close();
                excel.Quit();

                MessageBox.Show("Отчет успешно создан: " + filePath, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании отчета: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void CreateReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = From.Value;
            DateTime endDate = dateform.Value;
            int userId = Session.Id; // ID пользователя для загрузки транзакций
            List<Transaction> transactions = await LoadTransactionsAsync(userId, startDate, endDate);

            if (transactions == null || transactions.Count == 0)
            {
                MessageBox.Show("Нет транзакций за выбранный период.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Диалог сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel файлы (*.xlsx)|*.xlsx",
                FileName = $"TransactionsReport_{startDate + "-" + endDate}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                CreateExcelReport(transactions, filePath, startDate, endDate);
            }
        }

        private void Closer_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Closer_MouseEnter(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Red;
        }

        private void Closer_MouseLeave(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();   
            mainWindow.Show();
        }
    }
}