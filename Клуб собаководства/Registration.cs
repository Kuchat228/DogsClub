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
using System.IO;

namespace Клуб_собаководства
{
    public partial class Registration : Form
    {
        private static string connectionString = "Data Source = DESKTOP-JDC2774; Initial Catalog = Клуб; Integrated Security = True";
        private byte[] selectedImageData;
        private byte[] selectedImageData1;
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string username = textBox1.Text;
            var password = textBox2.Text;
            string name = textBox3.Text;
            string surname = textBox4.Text;
            string klichka = textBox5.Text;
            string poroda = textBox6.Text;


            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (var command = new SqlCommand("Profile", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Login", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Имя", name);
                    command.Parameters.AddWithValue("@Фамилия", surname);
                    command.Parameters.AddWithValue("@Кличка_собаки", klichka);
                    command.Parameters.AddWithValue("@Порода_собаки", poroda);
                    command.Parameters.AddWithValue("@Фото_профиля", selectedImageData);
                    command.Parameters.AddWithValue("@Фото_собаки", selectedImageData1);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Вы не зарегистрировались");
                    }
                    else
                    {
                        MessageBox.Show("Вы зарегистрировались");
                        this.Close();
                    }
                }
            }
        }







        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog.FileName;


                    pictureBox1.Image = Image.FromFile(selectedFilePath);


                    selectedImageData = File.ReadAllBytes(selectedFilePath);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog.FileName;


                    pictureBox2.Image = Image.FromFile(selectedFilePath);


                    selectedImageData1 = File.ReadAllBytes(selectedFilePath);
                }
            }
        }



    }
}

