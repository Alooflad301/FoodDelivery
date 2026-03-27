using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodDelivery
{
    public partial class LoginForm : Form
    {
        private DataSet userSet = new DataSet();
        private SqlDataAdapter adapter;
        private string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FoodDelivery;Integrated Security=False";

        public LoginForm()
        {
            InitializeComponent();

            InitDatabase();
        }

        private void InitDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string selectQuery = "SELECT IDUser, Name, Login, Password, IDRole FROM [User]";
                    adapter = new SqlDataAdapter(selectQuery, conn);
                    adapter.Fill(userSet, "User");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к БД: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
        private void BtnRegister_Click_1(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void BtnLogin_Click_1(object sender, EventArgs e)
        {
            string login = this.textBox1.Text.Trim();
            string password = this.textBox2.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = false;
            foreach (DataRow row in userSet.Tables["User"].Rows)
            {
                if (row["Login"].ToString() == login && row["Password"].ToString() == password)
                {
                    CurrentUser.IDUser = Convert.ToInt32(row["IDUser"]);
                    CurrentUser.Name = row["Name"].ToString();
                    CurrentUser.IDRole = Convert.ToInt32(row["IDRole"]);

                    success = true;
                    break;
                }
            }

            if (success)
            {
                string roleName;
                switch (CurrentUser.IDRole)
                {
                    case 1:
                        roleName = "Администратор";
                        break;
                    case 2:
                        roleName = "Менеджер";
                        break;
                    case 3:
                        roleName = "Клиент";
                        break;
                    default:
                        roleName = "Пользователь";
                        break;
                }

                MessageBox.Show($"Добро пожаловать, {roleName}: {CurrentUser.Name}", "Авторизация пройдена",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Авторизация не пройдена",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}