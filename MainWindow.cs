using Course_project_HOME_ACCOUNTANCE.classes;
using Course_project_HOME_ACCOUNTANCE.Expenses_functions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Course_project_HOME_ACCOUNTANCE
{
    public partial class MainWindow : Form
    {
        private Panel menuPanel;
        private bool MenuClick = true;

        public MainWindow()
        {
            InitializeComponent();
            CreateMenuPanel();
            SetupPictureBoxClick();
            LoadChartData();
        }


        private void CreateMenuPanel()               //создание кнопок и панельки меню
        {
            menuPanel = new Panel
            {
                Width = 200,
                Height = this.Height,
                Location = new Point(-200, 0),
                BackColor = Color.FromArgb(214, 238, 245)
            };

            string[] menuItems = { "Incomes", "Expenses", "Budget", "Reports", "Settings" };
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
                menuPanel.Controls.Add(menuButton);
            }

            this.Controls.Add(menuPanel);
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(button != null)
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
                { "Жилье и коммунальные услуги", Color.Green },
                { "Ежедневные расходы", Color.Blue },
                { "Транспорт", Color.Orange },
                { "Здоровье и спорт", Color.Purple },
                { "Образование и развлечения", Color.Brown },
                { "Одежда и подарки", Color.Gray },
                { "Платежи", Color.Pink }
            };

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
                            chartPie.Series["Series2"].Points.AddXY(entry.Key, entry.Value);
                            chartPie.Series["Series2"].Points.Last().Color = colorMap[entry.Key];
                            chartPie.Series["Series2"].Points.Last().LegendText = $"{entry.Key} ({entry.Value})";
                        }
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
                    return "Финансы";
                case "Жилье":
                case "Коммунальные услуги":
                    return "Жилье и коммунальные услуги";
                case "Питание":
                case "Бытовая техника":
                case "Прочие":
                    return "Ежедневные расходы";
                case "Транспорт":
                    return "Транспорт";
                case "Здоровье":
                case "Спорт":
                    return "Здоровье и спорт";
                case "Образование":
                case "Развлечения":
                case "Отдых":
                    return "Образование и развлечения";
                case "Одежда":
                case "Подарки":
                    return "Одежда и подарки";
                case "Платежи":
                    return "Платежи";
                default:
                    return "Неизвестная категория";
            }
        }

        public string MapCategoryToGroup(int index)
        {
            return new[] { "Финансы", "Жилье и коммунальные услуги", "Ежедневные расходы", "Транспорт", "Здоровье и спорт", "Образование и развлечения", "Одежда и подарки", "Платежи" }[index];
        }
    }
}