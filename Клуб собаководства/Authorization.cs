using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Клуб_собаководства
{
    public partial class Authorization : Form
    {
     

        private static string connectionString = "Data Source = DESKTOP-JDC2774; Initial Catalog = Клуб; Integrated Security = True";
        public Authorization()
        {
            InitializeComponent();
    
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Login()
        {
            string username = textBox1.Text;
            var password = textBox2.Text;

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT Password FROM Профиль WHERE Login = @Login", connection);
                    command.Parameters.AddWithValue("@Login", username);

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        var storedPassword = reader.GetString(0);

                        if (password == storedPassword)
                        {
                            MessageBox.Show("Вы вошли");

                            if (username == "admin") // Проверка учетных данных администратора
                            {
                                AdminForm adminForm = new AdminForm();
                                adminForm.Show();
                            }
                            else // Открытие формы для обычного пользователя
                            {
                                Prilozhenie userForm = new Prilozhenie(username);
                                userForm.Show();
                            }
                            this.Hide(); // Скрыть текущую форму
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Имя не найдено");
                    }
                    reader.Close(); // Закрытие SqlDataReader
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Registration registerForm = new Registration();
            registerForm.Show();
        }
    }
}
