using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodDelivery
{
    public partial class UserManagementForm : Form
    {
        private string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FoodDelivery;Integrated Security=False";
        private DataTable userTable = new DataTable();

        public UserManagementForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            this.userTable.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            u.IDUser, u.Name, u.Login, u.televon, u.Email, u.Addres,
                            r.Name AS RoleName
                        FROM [User] u
                            LEFT JOIN Role r ON u.IDRole = r.IDRole";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(userTable);

                    dgvUsers.DataSource = userTable;

                    // прячем IDRole, если нужно, но в реальности лучше отобразить
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки пользователей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["IDUser"].Value);
            string name = dgvUsers.CurrentRow.Cells["Name"].Value.ToString();
            string login = dgvUsers.CurrentRow.Cells["Login"].Value.ToString();
            string phone = dgvUsers.CurrentRow.Cells["televon"].Value?.ToString() ?? "";
            string email = dgvUsers.CurrentRow.Cells["Email"].Value?.ToString() ?? "";
            string addr = dgvUsers.CurrentRow.Cells["Addres"].Value?.ToString() ?? "";

            // форма редактирования UserEditForm (можно сделать как CartForm)
            // UserEditForm edit = new UserEditForm(id, name, login, phone, email, addr);
            // edit.ShowDialog();
            // LoadUsers(); // обновить таблицу
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["IDUser"].Value);

            // в твоих требованиях удаление разрешено, но можно добавить подтверждение
            if (MessageBox.Show("Удалить пользователя?", "Подтвердите", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string cmdText = "DELETE FROM [User] WHERE IDUser = @IDUser";
                        SqlCommand cmd = new SqlCommand(cmdText, conn);
                        cmd.Parameters.AddWithValue("@IDUser", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Пользователь удалён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}