using Course_project_HOME_ACCOUNTANCE.Expenses_functions;
using System;
using System.Drawing;
using System.Windows.Forms;

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
    }
}