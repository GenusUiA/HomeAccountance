using Course_project_HOME_ACCOUNTANCE.classes;
using Course_project_HOME_ACCOUNTANCE.Expenses_functions;
using Course_project_HOME_ACCOUNTANCE.Goals_form;
using Course_project_HOME_ACCOUNTANCE.Properties;
using Course_project_HOME_ACCOUNTANCE.Reports_creating;
using Course_project_HOME_ACCOUNTANCE.Settings;
using DocumentFormat.OpenXml.InkML;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
            LoadChartData();
            LoadGoals();
            LoadSum(Session.Id);
            CheckAndDisplayWelcomeMessage();
            CreateMenuPanel();
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

            string[] menuItems = { "Incomes", "Expenses", "Reports", "Goals", "Settings" };
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
                    case "Expenses":
                        this.Hide();
                        Expenses expenses = new Expenses();
                        expenses.Show();
                        break;
                    case "Incomes":
                        this.Hide();
                        Incomes incomes = new Incomes();
                        incomes.Show();
                        break;
                    case "Reports":
                        this.Hide();
                        Reports reports = new Reports();
                        reports.Show();
                        break;
                    case "Goals":
                        this.Hide();
                        Goals goals = new Goals();
                        goals.Show();
                        break;
                    case "Settings":
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

        private void LoadChartData()
        {
            try
            {

                Database database = new Database();
                database.OpenConnection();
                string query = @"SELECT category, sum FROM ""Transactions"" WHERE id = @id";
                NpgsqlCommand cmd = new NpgsqlCommand(query, database.ConnectionString());
                cmd.Parameters.AddWithValue("@id", Session.Id);

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
                        Text = $"{totalSum}$", // Общая сумма с форматированием валюты
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.Black,
                        Alignment = ContentAlignment.MiddleCenter,
                        AnchorX = 29,
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
                MessageBox.Show($"Error loading chart data: {ex.Message}");
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


        private void AddGoalProgressBar(string goalName, int yOffset)
        {
            ProgressBar progressBar = new ProgressBar();
            Label goalLabel = new Label();

            progressBar.Width = 75; 
            progressBar.Minimum = 0;
            progressBar.Maximum = 100; 
            progressBar.Step = 1;
            goalLabel.Text = goalName;
            goalLabel.AutoSize = true;
            goalLabel.Text = ShortenGoalName(goalName);
            int labelWidth = goalLabel.Width;   
            goalLabel.Location = new Point(100, yOffset);
            progressBar.Location = new Point(labelWidth, yOffset); 

            this.Controls.Add(goalLabel);
            this.Controls.Add(progressBar);
            goalProgress.Add(Tuple.Create(progressBar, goalLabel));
        }

        private void UpdateGoalProgress(string goalName, decimal currentSum, decimal totalSum)
        {
            if (totalSum <= 0) return; 

            var goal = goalProgress.FirstOrDefault(g => g.Item2.Text == goalName);
            if (goal != null)
            {
                decimal progressPercent = (currentSum / totalSum) * 100;
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
                        AddGoalProgressBar(goal.definition, yOffset);
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
                using (var command = new NpgsqlCommand("SELECT definition, current_sum, sum FROM \"Goals\" WHERE id = @id", connection))
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
                                sum = reader.GetDecimal(2)
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
        //private void LoadGoals()
        //{
        //    try
        //    {
        //        using (var connection = new NpgsqlConnection(Database.connectionString))
        //        {
        //            connection.Open();
        //            Goal goales = new Goal();
        //            Database db = new Database();
        //            List<Goal> goals = goales.GetGoalsFromDatabase(db.ConnectionString());
        //            int yOffset = 110;
        //            foreach (var goal in goals)
        //            {
        //                AddGoalProgressBar(goal.definition, yOffset);
        //                UpdateGoalProgress(goal.definition, goal.current_sum, goal.sum);
        //                yOffset += 40;
        //                DateTime expirationDate = (DateTime)goal.period[1];

        //                if (expirationDate < DateTime.Now && !goal.isNotified)
        //                {
        //                    MessageBox.Show($"Цель \"{goal.definition}\" просрочена!");
        //                    goal.isNotified = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error loading goals: {ex.Message}");
        //    }
        //}
        private class GoalData
        {
            public string definition { get; set; }
            public decimal current_sum { get; set; }
            public decimal sum { get; set; }
        }

        private void LoadSum(int id)
        {
            Database db = new Database();
            string query = "SELECT COALESCE(SUM(sum), 0) FROM \"Incomes\" WHERE id = @id";

            Label totalsum = new Label();
            totalsum.Name = "totalsum";
            totalsum.Font = new Font("Microsoft Sans Serif", 16F);
            totalsum.AutoSize = true;
            totalsum.Text = "Общая сумма доходов: "; 

            totalsum.Location = new Point(140, this.ClientSize.Height - 50);

            this.Controls.Add(totalsum);

            using (NpgsqlConnection connection = new NpgsqlConnection(db.constring()))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@id", id);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            decimal sum = Convert.ToDecimal(result);
                            totalsum.Text = totalsum.Text + sum;
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
                // Создаем Panel для центрального сообщения
                Panel welcomePanel = new Panel
                {
                    Width = this.ClientSize.Width - 150, // Ширина минус ширина меню
                    Height = this.ClientSize.Height - 100,
                    Location = new Point(130, 50), // Отступ слева от меню
                    BackColor = Color.FromArgb(169, 227, 243)
                };

                // Создаем Label с приветственным сообщением
                Label welcomeLabel = new Label
                {
                    Text = "Добро пожаловать в Home Accountance!\n\n" +
                           "Чтобы начать пользоваться приложением:\n\n" +
                           "1. Перейдите в раздел 'Доходы' и добавьте первые поступления\n" +
                           "2. В разделе 'Расходы' внесите свои траты\n" +
                           "3. Установите финансовые цели в разделе 'Цели'\n\n" +
                           "Это поможет вам эффективно управлять личными финансами",
                    Font = new Font("Microsoft Sans Serif", 16F),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                // Добавляем Label на Panel
                welcomePanel.Controls.Add(welcomeLabel);

                // Добавляем Panel на форму
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
    }
}
