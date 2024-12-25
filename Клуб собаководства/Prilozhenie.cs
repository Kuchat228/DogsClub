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
    public partial class Prilozhenie : Form
    {

        private static string connectionString = "Data Source = DESKTOP-JDC2774; Initial Catalog = Клуб; Integrated Security = True";

        private string userLogin;
        public Prilozhenie(string username)
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            userLogin = username;

            

        }

        private void Prilozhenie_Load(object sender, EventArgs e)
        {


            LoadData();

        }

        private void LoadProfile()
        {

        }
        private void LoadData()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("DogShows", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ExecuteProcedure("SortByDate");
            }

            if (radioButton2.Checked)
            {
                ExecuteProcedure1("SortByDate1");
            }


            string venue = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(venue))
            {
                ExecuteProcedure2("WhereCity", venue);
            }
        }


        private void ExecuteProcedure2(string procedureName, string parameterValue)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("WhereCity", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Место_Проведения", parameterValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }


            }
        }

        private void ExecuteProcedure(string procedureName)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SortByDate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }
        }

        private void ExecuteProcedure1(string procedureName)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SortByDate1", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            LoadData1();


        }


        private void LoadData1()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Rewards", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string breed = textBox2.Text;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SelectNot", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ФИО_Получателя", breed);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView2.DataSource = dataTable;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            string breed1 = textBox3.Text;
            string breed2 = textBox4.Text;
            string breed3 = textBox5.Text;
            string breed4 = textBox6.Text;
            string breed5 = textBox7.Text;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Application1", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", breed1);
                command.Parameters.AddWithValue("@ФИО_Участника", breed2);
                command.Parameters.AddWithValue("@Номер_Телефона", breed3);
                command.Parameters.AddWithValue("@Парода_Собаки", breed4);
                command.Parameters.AddWithValue("@Кличка_Собаки", breed5);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                MessageBox.Show("Заявка отправлена");



            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string b = textBox8.Text;
            string d = textBox9.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("WhereMn", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ФИО_Получателя", b);

                    command.Parameters.AddWithValue("@Награда", d);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;





            LoadUserData();


            byte[] imageData = LoadImageByLogin(userLogin);

            if (imageData != null)
            {

                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                MessageBox.Show("Изображение не найдено для текущего пользователя.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //

            byte[] imageData1 = LoadImageByLogin1(userLogin);

            if (imageData1 != null)
            {

                using (MemoryStream ms = new MemoryStream(imageData1))
                {
                    pictureBox2.Image = Image.FromStream(ms);
                }
            }
            else
            {
                MessageBox.Show("Изображение не найдено для текущего пользователя.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private byte[] LoadImageByLogin(string username)
        {
            byte[] imageData = null;

            string query = "SELECT Фото_профиля FROM Профиль WHERE Login = @Login";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Login", username);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            imageData = (byte[])result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки изображения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return imageData;




        }



            private byte[] LoadImageByLogin1(string username)
            {
                byte[] imageData1 = null;

                string query = "SELECT Фото_собаки FROM Профиль WHERE Login = @Login";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Login", username);

                            object result = command.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                imageData1 = (byte[])result;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки изображения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return imageData1;
            }




        


            private void LoadUserData()
            {


                string query = "SELECT Имя, Фамилия, Кличка_собаки, Порода_собаки FROM Профиль WHERE Login = @Login";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Login", userLogin);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    textBox11.Text = reader["Имя"].ToString();
                                    textBox12.Text = reader["Фамилия"].ToString();
                                    textBox10.Text = reader["Кличка_собаки"].ToString();
                                    textBox16.Text = reader["Порода_собаки"].ToString();

                                }
                                else
                                {
                                    MessageBox.Show("Пользователь не найден.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }




            private void button9_Click(object sender, EventArgs e)
            {
                Authorization authorizationForm = new Authorization();
                authorizationForm.Show();
                this.Hide();
            }

            private void button10_Click(object sender, EventArgs e)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = true;
            }

            private void panel5_Paint(object sender, PaintEventArgs e)
            {

            }

            private void panel4_Paint(object sender, PaintEventArgs e)
            {

            }

            private void label8_Click(object sender, EventArgs e)
            {

            }

            private void label28_Click(object sender, EventArgs e)
            {

            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {


            }




            private void button11_Click(object sender, EventArgs e)
            {

            }
        } 
    }

