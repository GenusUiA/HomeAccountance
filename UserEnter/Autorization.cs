using Course_project_HOME_ACCOUNTANCE.classes;
using Npgsql;
using System;
using System.Data.SqlTypes;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE
{
    public partial class Autorization : Form
    {
        public int id;
        public Autorization()
        {
            InitializeComponent();
            LinkLabelRegister.LinkClicked += LinkLabelRegister_Click;
            EnterButton.Click += EnterButton_Click;
        }
        
        private void LinkLabelRegister_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm RegistrationForm = new LoginForm();
            RegistrationForm.Show();
        }

        private void CompareWithDataFromDB(string username, string hashedPassword)
        {
            string connectionString = "Server=localhost;Port=1111;Database=users;User Id=postgres;Password=1111";
            string query = "SELECT id FROM Users WHERE login = @login AND password = @password";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = int.Parse(reader["id"].ToString());
                                Session.Id = id;
                                this.Hide();
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
        private void EnterButton_Click(object sender, EventArgs e)
        {
            string username = LoginField.Text;
            string password = PasswordField.Text;
            string hashedPassword = HashPassword(password);
            CompareWithDataFromDB(username, hashedPassword);
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
