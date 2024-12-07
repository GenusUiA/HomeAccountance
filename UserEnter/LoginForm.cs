using Course_project_HOME_ACCOUNTANCE.classes;
using Npgsql;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
//taskkill /im Course_project_HOME_ACCOUNTANCE.exe /f
namespace Course_project_HOME_ACCOUNTANCE
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Closer.Click += Closer_Click;
        }

        private void Closer_MouseLeave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

        private void SaveToDatabase(string username, string hashedPassword)
        {
            string connectionString = "Server=localhost;Port=1111;Database=users;User Id=postgres;Password=1111";
            string query = "INSERT INTO Users (login, password) VALUES (@login, @password)";
            if (UserExists(username, connectionString))
            {
                MessageBox.Show("User already exist");
                this.Hide();
                LoginForm temp = new LoginForm();
                temp.ShowDialog();
            }
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Registration pass correct");
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while saving the data.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private bool UserExists(string username, string connectionString)
        {
            string query = "SELECT 1 FROM Users WHERE login = @login";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", username);

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            return reader.Read();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при проверке пользователя: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            string password = PasswordField.Text;
            string confirmPassword = ConfirmPasswordField.Text; 

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            user User = new user();
            User.login = LoginField.Text;
            User.password = PasswordField.Text;
            string hashedPassword = HashPassword(User.password);
            SaveToDatabase(User.login, hashedPassword);
            Autorization Autoriz = new Autorization();
            this.Hide();
            Autoriz.ShowDialog();
            this.Hide();
        }

        private void Closer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Closer_MouseEnter(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Red; 
        }

        private void Closer_MouseLeave_1(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Black;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization autoriz = new Autorization();
            autoriz.Show();
        }

        private bool passwordVisible = false;
        private void pictureBoxEye_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            if (passwordVisible)
            {
                PasswordField.PasswordChar = '\0'; // Показать пароль
                pictureBoxEye.Image = Properties.Resources.eye;
            }
            else
            {
                PasswordField.PasswordChar = '*'; // Скрыть пароль
                pictureBoxEye.Image = Properties.Resources.eyebrow;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            if (passwordVisible)
            {
                ConfirmPasswordField.PasswordChar = '\0'; // Показать пароль
                PictureEye.Image = Properties.Resources.eye;
            }
            else
            {
                ConfirmPasswordField.PasswordChar = '*'; // Скрыть пароль
                PictureEye.Image = Properties.Resources.eyebrow;
            }
        }
    }
}