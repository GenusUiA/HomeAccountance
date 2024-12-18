using Course_project_HOME_ACCOUNTANCE.classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE.Settings
{
    public partial class SettingsUser : Form
    {
        public SettingsUser()
        {
            InitializeComponent();
        }

        private void DeleteUserFromDB(string username, string hashedPassword, int id)
        {
            string connectionString = "Server=localhost;Port=1111;Database=users;User Id=postgres;Password=1111";
            string query = "DELETE FROM Users WHERE login = @login AND password = @password AND id = @id";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ваш аккаунт успешно удален");
                            this.Hide();
                            Autorization autorization = new Autorization();
                            autorization.Show();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин, пароль");
                            return;
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

        private void delete_Click(object sender, EventArgs e)
        {
            string Login = login.Text;
            string Password = password.Text;
            int id = Session.Id;
            DeleteUserFromDB(Login, HashPassword(Password), id);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization autorization = new Autorization();
            autorization.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        void SaveChangesToDatabase(int id, string oldPassword, string newPassword)
        {
            string connectionString = "Server=localhost;Port=1111;Database=users;User Id=postgres;Password=1111";
            string hashedOldPassword = HashPassword(oldPassword);
            string hashedNewPassword = HashPassword(newPassword);
            string queryVerify = "SELECT 1 FROM Users WHERE id = @id AND password = @hashedOldPassword";

            using (var connectionVerify = new NpgsqlConnection(connectionString))
            {
                using (var commandVerify = new NpgsqlCommand(queryVerify, connectionVerify))
                {
                    commandVerify.Parameters.AddWithValue("@id", id);
                    commandVerify.Parameters.AddWithValue("@hashedOldPassword", hashedOldPassword);
                    try
                    {
                        connectionVerify.Open();
                        if (commandVerify.ExecuteScalar() == null) 
                        {
                            MessageBox.Show("Неверный старый пароль.");
                            return; 
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка проверки пароля: {ex.Message}");
                        return;
                    }
                }
            }

            string queryUpdate = "UPDATE Users SET password = @hashedNewPassword WHERE id = @id";
            using (var connectionUpdate = new NpgsqlConnection(connectionString))
            {
                using (var commandUpdate = new NpgsqlCommand(queryUpdate, connectionUpdate))
                {
                    commandUpdate.Parameters.AddWithValue("@id", id);
                    commandUpdate.Parameters.AddWithValue("@hashedNewPassword", hashedNewPassword);
                    try
                    {
                        connectionUpdate.Open();
                        int result = commandUpdate.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Пароль изменен");
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при изменении пароля");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка обновления пароля: {ex.Message}");
                    }
                }
            }
        }
        private void confchang_Click(object sender, EventArgs e)
        {
            string password = oldpass.Text;
            string confirmPassword = newpass.Text;

            string newpassword = newpass.Text;
            string reppassword = reppass.Text;
            if (password == "" || newpassword == "" || reppassword == "")
            {
                MessageBox.Show("Пароль не введен");
                return;
            }
            if (password == confirmPassword)
            {
                MessageBox.Show("Пароли совпадают");
                return;
            }
            if (newpassword != reppassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            SaveChangesToDatabase(Session.Id, password, newpassword);
        }

        private void Closer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Closer_MouseLeave(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Black;
        }

        private void Closer_MouseEnter(object sender, EventArgs e)
        {
            Closer.ForeColor = Color.Red;
        }
    }
}
