using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FoodDelivery
{
    public partial class RegisterForm : Form
    {
        private string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FoodDelivery;Integrated Security=False";

        public RegisterForm()
        {
            InitializeComponent();

            // По требованиям: новая роль по умолчанию = 3 (Клиент/Пользователь)
            cmbIDRole.Items.AddRange(new object[] { "3 — Клиент" });
            cmbIDRole.SelectedIndex = 0;
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Имя, логин и пароль обязательны.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Пароль должен быть не короче 6 символов.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                MessageBox.Show("Некорректный формат email.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Вставка нового пользователя (по умолчанию роль = 3 — клиент)
                    string insertQuery = @"
                        INSERT INTO [User]
                        ([Name], [Login], [Password], [IDRole], [televon], [Email], [Addres])
                        VALUES
                        (@Name, @Login, @Password, 3, @televon, @Email, @Addres)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Login", login ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@televon", phone ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Addres", address ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Пользователь успешно зарегистрирован.", "Регистрация",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (SqlException ex)
                {
                    // например, если Login уже занят
                    MessageBox.Show("Ошибка при регистрации: " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неизвестная ошибка: " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.txtName.Focus();
        }
    }
}