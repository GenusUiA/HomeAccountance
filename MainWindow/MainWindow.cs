using Course_project_HOME_ACCOUNTANCE.classes;
using Course_project_HOME_ACCOUNTANCE.Expenses_functions;
using Course_project_HOME_ACCOUNTANCE.Goals_form;
using Course_project_HOME_ACCOUNTANCE.Properties;
using Course_project_HOME_ACCOUNTANCE.Reports_creating;
using Course_project_HOME_ACCOUNTANCE.Settings;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
using Session = Course_project_HOME_ACCOUNTANCE.classes.Session;

namespace Course_project_HOME_ACCOUNTANCE
{
    public partial class MainWindow : Form
    {
        private Panel menuPanel;
        private bool MenuClick = true;
        

        public MainWindow()
        {
            InitializeComponent();
            SetupPictureBoxClick();
            LoadGoals();
            DateTime minDate = new DateTime(1, 1, 1);
            DateTime maxDate = new DateTime(9999, 12, 31);

            LoadChartData(minDate, maxDate);
            LoadSum(minDate, maxDate);
            CheckAndDisplayWelcomeMessage();
            CreateMenuPanel();
            if (!Session.isGoalStatusChecked)
            {
                CheckGoalStatus();
            }

            From.MaxDate = DateTime.Now;
            For.MaxDate = DateTime.Now; 
            From.Value = DateTime.Now;  
            For.Value = DateTime.Now; 

            // Привязка обработчиков событий
            From.ValueChanged += From_ValueChanged;
            For.ValueChanged += For_ValueChanged;

            From1.MaxDate = DateTime.Now;
            For1.MaxDate = DateTime.Now;
            From1.Value = DateTime.Now;
            For1.Value = DateTime.Now;

            // Привязка обработчиков событий
            From1.ValueChanged += From1_ValueChanged;
            For1.ValueChanged += For1_ValueChanged;
            void From_ValueChanged(object sender, EventArgs e)
            {
                // Проверка: начальная дата не должна быть больше конечной
                if (From.Value > For.Value)
                {
                    // Если начальная дата больше конечной, то конечная приравнивается к начальной
                    For.Value = From.Value;
                }
                For.MinDate = From.Value;
            }

            void For_ValueChanged(object sender, EventArgs e)
            {
                // Проверка: Конечная дата не должна быть меньше начальной
                if (For.Value < From.Value)
                {
                    // Если конечная дата меньше начальной, то начальная приравнивается к конечной
                    From.Value = For.Value;
                }

            }

            void From1_ValueChanged(object sender, EventArgs e)
            {
                // Проверка: начальная дата не должна быть больше конечной
                if (From1.Value > For1.Value)
                {
                    // Если начальная дата больше конечной, то конечная приравнивается к начальной
                    For1.Value = From1.Value;
                }
                For1.MinDate = From1.Value;
            }

            void For1_ValueChanged(object sender, EventArgs e)
            {
                // Проверка: Конечная дата не должна быть меньше начальной
                if (For1.Value < From1.Value)
                {
                    // Если конечная дата меньше начальной, то начальная приравнивается к конечной
                    From1.Value = For1.Value;
                }

            }
        }


        private void CreateMenuPanel()               //создание кнопок и панелек меню
        {
            menuPanel = new Panel
            {
                Width = 200,
                Height = this.Height,
                Location = new Point(-200, 0),
                BackColor = Color.FromArgb(214, 238, 245)
            };

            string[] menuItems = { "Доходы", "Расходы", "Отчеты", "Цели", "Настройки" };
            for (int i = 0; i < menuItems.Length; i++)
            {
                Button menuButton = new Button
                {
                    Text = menuItems[i],
                    Name = menuItems[i],
                    Size = new Size(180, 45),
                    Location = new Point(10, 20 + (i * 55)),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(214, 238, 245),
                    ForeColor = Color.FromArgb(44, 62, 80),
                    Font = new Font("Segoe UI", 12),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(15, 0, 0, 0)
                };
                menuButton.FlatAppearance.BorderSize = 0;
                menuButton.MouseEnter += (s, e) =>
                    ((Button)s).BackColor = Color.FromArgb(169, 227, 243);
                menuButton.MouseLeave += (s, e) =>
                    ((Button)s).BackColor = Color.FromArgb(214, 238, 245);
                menuButton.Click += MenuButton_Click;
                menuButton.BringToFront();
                menuPanel.Controls.Add(menuButton);
            }

            this.Controls.Add(menuPanel);
            menuPanel.BringToFront();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                switch (button.Name)
                {
                    case "Расходы":
                        this.Hide();
                        Expenses expenses = new Expenses();
                        expenses.Show();
                        break;
                    case "Доходы":
                        this.Hide();
                        Incomes incomes = new Incomes();
                        incomes.Show();
                        break;
                    case "Отчеты":
                        this.Hide();
                        Reports reports = new Reports();
                        reports.Show();
                        break;
                    case "Цели":
                        this.Hide();
                        Goals goals = new Goals();
                        goals.Show();
                        break;
                    case "Настройки":
                        this.Hide();
                        SettingsUser settings = new SettingsUser();
                        settings.Show();
                        break;
                }
            }
        }

        private void SetupPictureBoxClick()
        {
            Home.Cursor = Cursors.Hand;
            Home.Click += (s, e) =>
            {
                if (MenuClick)
                {
                    Timer slideTimer = new Timer();
                    slideTimer.Interval = 1;
                    int targetX = 80;
                    slideTimer.Tick += (sender, args) =>
                    {
                        if (menuPanel.Left < targetX)
                        {
                            menuPanel.Left += 10;
                            if (menuPanel.Left >= targetX)
                            {
                                menuPanel.Left = targetX;
                                slideTimer.Stop();
                            }
                        }
                    };
                    slideTimer.Start();
                }
                else
                {
                    Timer slideTimer = new Timer();
                    slideTimer.Interval = 1;
                    slideTimer.Tick += (sender, args) =>
                    {
                        if (menuPanel.Left > -200)
                        {
                            menuPanel.Left -= 10;
                            if (menuPanel.Left <= -200)
                            {
                                menuPanel.Left = -200;
                                slideTimer.Stop();
                            }
                        }
                    };
                    slideTimer.Start();
                }
                MenuClick = !MenuClick;
            };
            Home.MouseEnter += (s, e) =>
            {
                Home.BackColor = Color.FromArgb(72, 159, 181);
            };

            Home.MouseLeave += (s, e) =>
            {
                Home.BackColor = Color.Transparent;
            };
        }
        private void Closer_MouseEnter(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Red;
        }
        private void Closer_MouseLeave(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Black;
        }

        private void Closer_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void LoadChartData(DateTime startDate, DateTime endDate)
        {
            chartPie.Series["Series2"].Points.Clear();
            chartPie.Series["Series2"].LegendText = string.Empty;
            chartPie.Annotations.Clear();
            try
            {
                Database database = new Database();
                database.OpenConnection();
                string query = @"SELECT category, sum FROM ""Transactions"" WHERE id = @id AND date BETWEEN @startDate AND @endDate";

                NpgsqlCommand cmd = new NpgsqlCommand(query, database.ConnectionString());
                cmd.Parameters.AddWithValue("@id", Session.Id);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    var categorySums = new Dictionary<string, double>();
                    var colorMap = new Dictionary<string, Color>
            {
                { "Финансы", Color.Red },
                { "быт и дом", Color.Green },
                { "Ежедневные расходы", Color.Blue },
                { "Транспорт", Color.Orange },
                { "Здоровье", Color.Purple },
                { "Досуг и учеба", Color.Brown },
                { "Одежда и подарки", Color.Gray },
                { "Платежи", Color.Pink }
            };

                    double totalSum = 0;

                    while (reader.Read())
                    {
                        string category = reader["category"].ToString();
                        double amount = Convert.ToDouble(reader["sum"]);
                        string group = MapCategoryToGroup(category);
                        if (categorySums.ContainsKey(group))
                            categorySums[group] += amount;
                        else
                            categorySums[group] = amount;
                    }
                    reader.Close();

                    chartPie.Series["Series2"].Points.Clear();
                    foreach (var entry in categorySums)
                    {
                        if (entry.Value > 0)
                        {
                            totalSum += entry.Value;
                            var point = chartPie.Series["Series2"].Points.AddXY(entry.Key, entry.Value);
                            chartPie.Series["Series2"]["PieLabelStyle"] = "Disabled";
                        }
                    }

                    ChartArea chartArea = chartPie.ChartAreas[0];

                    TextAnnotation annotation = new TextAnnotation
                    {
                        Text = $"{totalSum}",
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.Black,
                        Alignment = ContentAlignment.MiddleCenter,
                        AnchorX = 31,
                        AnchorY = 54,
                    };
                    chartPie.Annotations.Add(annotation);

                    chartPie.Legends[0].Docking = Docking.Right;
                    chartPie.Legends[0].Alignment = StringAlignment.Center;
                    chartPie.Legends[0].IsTextAutoFit = true;
                    chartPie.Legends[0].BackColor = Color.Ivory;
                    foreach (var seriesPoint in chartPie.Series["Series2"].Points)
                    {
                        string categoryName = seriesPoint.AxisLabel;
                        double categoryValue = seriesPoint.YValues[0];
                        double percentage = (categoryValue / totalSum) * 100;
                        seriesPoint.LegendText = $"{categoryName} ({percentage:F2}%)";
                    }

                }
                database.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пончиковой диаграммы: {ex.Message}");
            }
        }

        public string MapCategoryToGroup(string category)
        {
            switch (category)
            {
                case "Инвестиции":
                case "Кредиты":
                case "Платежи":
                    return "Финансы";
                case "Жилье":
                case "Коммунальные услуги":
                case "Бытовая техника":
                    return "быт и дом";
                case "Питание":
                case "Прочие":
                    return "Питание";
                case "Транспорт":
                    return "Транспорт";
                case "Здоровье":
                    return "Здоровье";
                case "Спорт":
                case "Образование":
                case "Развлечения":
                case "Отдых":
                    return "Досуг и учеба";
                case "Одежда":
                case "Подарки":
                    return "Одежда и подарки";
                default:
                    return "Неизвестная категория";
            }
        }

        public string MapCategoryToGroup(int index)
        {
            return new[] { "Финансы", "быт и дом", "Ежедневные расходы", "Транспорт", "Здоровье", "Досуг и учеба", "Одежда и подарки", "Платежи" }[index];
        }

        private List<Tuple<ProgressBar, Label>> goalProgress = new List<Tuple<ProgressBar, Label>>();
        private Database db = new Database();


        private void AddGoalProgressBar(string goalName, int yOffset, DateTime[] period)
        {
            // Прогресс-бар для суммы
            ProgressBar progressBar = new ProgressBar();
            Label goalLabel = new Label();

            progressBar.Width = 75;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Step = 1;
            goalLabel.Text = goalName;
            goalLabel.Height = 13;
            goalLabel.Text = ShortenGoalName(goalName);
            int labelWidth = goalLabel.Width;
            goalLabel.Location = new Point(100, yOffset);
            progressBar.Location = new Point(labelWidth, yOffset);

            this.Controls.Add(goalLabel);
            this.Controls.Add(progressBar);
            goalProgress.Add(Tuple.Create(progressBar, goalLabel));

            // Прогресс-бар для времени
            ProgressBar dateBar = new ProgressBar();
            dateBar.Width = 75;
            dateBar.Minimum = 0;
            dateBar.Maximum = 100;
            dateBar.Step = 1;
            dateBar.Location = new Point(100, yOffset+10);

            DateTime currentDate = DateTime.Now;
            DateTime startDate = period[0];
            DateTime endDate = period[1];

            double progressValue = ((currentDate - startDate).TotalDays / (endDate - startDate).TotalDays) * 100;
            dateBar.Value = (int)Math.Min(Math.Max(progressValue, 0), 100); // Ограничиваем значение от 0 до 100
            this.Controls.Add(dateBar);
        }

        private void UpdateGoalProgress(string goalName, decimal currentSum, decimal totalSum)
        {
            if (totalSum <= 0) return;

            var goal = goalProgress.FirstOrDefault(g => g.Item2.Text == goalName);
            if (goal != null)
            {

                decimal progressPercent = (currentSum / totalSum) * 100;
                progressPercent = Math.Min(progressPercent, 100);
                goal.Item1.Value = (int)Math.Min(progressPercent, 100);
                goal.Item2.Text = $"{goalName} ({progressPercent:F2}%)";
            }
        }


        private string ShortenGoalName(string goalName, int maxLength = 20)
        {
            if (goalName.Length > maxLength)
            {
                return goalName.Substring(0, maxLength - 3) + "...";
            }
            return goalName;
        }

        private void LoadGoals()
        {
            try
            {
                using (var connection = new NpgsqlConnection(Database.connectionString))
                {
                    connection.Open();
                    List<GoalData> goals = GetGoalsFromDatabase(connection);
                    int yOffset = 110;
                    foreach (var goal in goals)
                    {
                        AddGoalProgressBar(goal.definition, yOffset, goal.period);
                        UpdateGoalProgress(goal.definition, goal.current_sum, goal.sum);
                        yOffset += 40;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading goals: {ex.Message}");
            }
        }

        List<GoalData> GetGoalsFromDatabase(NpgsqlConnection connection)
        {
            List<GoalData> goals = new List<GoalData>();
            try
            {
                using (var command = new NpgsqlCommand("SELECT definition, current_sum, sum, period FROM \"Goals\" WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", Session.Id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            goals.Add(new GoalData
                            {
                                definition = reader.GetString(0),
                                current_sum = reader.GetDecimal(1),
                                sum = reader.GetDecimal(2),
                                period = (DateTime[])reader.GetValue(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching goals from database: {ex.Message}");
            }
            return goals;
        }

        private class GoalData
        {
            public string definition { get; set; }
            public decimal current_sum { get; set; }
            public decimal sum { get; set; }
            public DateTime[] period { get; set; }
        }

        private void LoadSum(DateTime startDate, DateTime endDate)
        {
            Database db = new Database();
            string query = "SELECT COALESCE(SUM(sum), 0) FROM \"Incomes\" WHERE id = @id AND date >= @startDate AND date <= @endDate";

            // Проверяем, существует ли уже Label с именем "totalsum"
            Label totalsum = this.Controls.Find("totalsum", true).FirstOrDefault() as Label;

            if (totalsum == null)
            {
                // Если Label не существует, создаем новый
                totalsum = new Label();
                totalsum.Name = "totalsum";
                totalsum.Font = new Font("Microsoft Sans Serif", 16F);
                totalsum.AutoSize = true;
                totalsum.Text = "Общая сумма доходов: ";
                totalsum.Location = new Point(85, this.ClientSize.Height - 50);
                this.Controls.Add(totalsum);
            }

            using (NpgsqlConnection connection = new NpgsqlConnection(db.constring()))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@id", Session.Id);
                        command.Parameters.AddWithValue("@startDate", startDate);
                        command.Parameters.AddWithValue("@endDate", endDate);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            decimal sum = Convert.ToDecimal(result);
                            totalsum.Text = "Общая сумма доходов: " + sum;
                        }
                        else
                        {
                            totalsum.Text = "Общая сумма доходов: 0";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке суммы: {ex.Message}");
                        totalsum.Text = "Ошибка загрузки";
                    }
                }
            }
        }

        private void CheckAndDisplayWelcomeMessage()
        {
            bool hasTransactions = CheckUserHasTransactions();
            bool hasGoals = CheckUserHasGoals();

            if (!hasTransactions && !hasGoals)
            {
                Panel welcomePanel = new Panel
                {
                    Width = this.ClientSize.Width - 140, 
                    Height = this.ClientSize.Height - 70,
                    Location = new Point(90, 55), 
                    BackColor = Color.FromArgb(169, 227, 243)
                };

                Label welcomeLabel = new Label
                {
                    Text = "Добро пожаловать в Домашнюю бухгалтерию!\n\n" +
                           "Чтобы начать пользоваться приложением:\n\n" +
                           "1. Перейдите в раздел 'Доходы' и добавьте первые поступления\n" +
                           "2. В разделе 'Расходы' внесите свои траты\n" +
                           "3. Установите финансовые цели в разделе 'Цели'\n\n" +
                           "Это поможет вам эффективно управлять личными финансами",
                    Font = new Font("Microsoft Sans Serif", 18F),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                welcomePanel.Controls.Add(welcomeLabel);

                this.Controls.Add(welcomePanel);
                welcomePanel.BringToFront();
            }
        }

        private bool CheckUserHasTransactions()
        {
            try
            {
                using (var connection = new NpgsqlConnection(Database.connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(
                        "SELECT COUNT(*) FROM \"Transactions\" WHERE id = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", Session.Id);
                        long count = Convert.ToInt64(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка проверки транзакций: {ex.Message}");
                return false;
            }
        }

        private bool CheckUserHasGoals()
        {
            try
            {
                using (var connection = new NpgsqlConnection(Database.connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(
                        "SELECT COUNT(*) FROM \"Goals\" WHERE id = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", Session.Id);
                        long count = Convert.ToInt64(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка проверки целей: {ex.Message}");
                return false;
            }
        }

        private void CheckGoalStatus()
        {
            if (!Session.isGoalStatusChecked)
            {
                try
                {
                    using (var connection = new NpgsqlConnection(Database.connectionString))
                    {
                        connection.Open();
                        List<Goal> goals = GetGoalsFromDatabaseForStatus(connection);
                        foreach (var goal in goals)
                        {
                            if (goal.current_sum >= goal.sum)
                            {
                                MessageBox.Show($"Цель '{goal.definition}' выполнена!");
                            }
                            else if (goal.period[1] < DateTime.Now)
                            {
                                int daysOverdue = (DateTime.Now - goal.period[1]).Days;
                                string daysText = GetDaysText(daysOverdue);
                                MessageBox.Show($"Цель '{goal.definition}' просрочена на {daysOverdue} {daysText}!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка проверки статуса целей: {ex.Message}");
                }

                Session.isGoalStatusChecked = true;
            }
        }

        private string GetDaysText(int daysOverdue)
        {
            if (daysOverdue == 1)
            {
                return "день";
            }
            else if (daysOverdue % 100 >= 2 && daysOverdue % 100 <= 4)
            {
                return "дня";
            }
            else
            {
                return "дней";
            }
        }

        private List<Goal> GetGoalsFromDatabaseForStatus(NpgsqlConnection connection)
        {
            List<Goal> goals = new List<Goal>();
            try
            {
                using (var command = new NpgsqlCommand("SELECT definition, current_sum, sum, period FROM \"Goals\" WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", Session.Id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime[] period = (DateTime[])reader.GetValue(3);

                            goals.Add(new Goal
                            {
                                definition = reader.GetString(0),
                                current_sum = reader.GetDecimal(1),
                                sum = reader.GetDecimal(2),
                                period = period,
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching goals from database: {ex.Message}");
            }
            return goals;
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            DateTime startDate = From.Value;
            DateTime endDate = For.Value;
            LoadChartData(startDate, endDate);
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            DateTime startDate = From1.Value;
            DateTime endDate = For1.Value;
            LoadSum( startDate, endDate);
        }
    }
}
