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
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин, пароль");
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
            this.Hide();
            Autorization autorization = new Autorization();
            autorization.Show();
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
    }
}
