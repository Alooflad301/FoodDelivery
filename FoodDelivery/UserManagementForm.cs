using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodDelivery
{
    public partial class UserManagementForm : Form
    {
        private readonly string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FoodDelivery;Integrated Security=False";
        private DataTable userTable = new DataTable();

        public UserManagementForm()
        {
            InitializeComponent();
            HookEvents();
            ConfigureGrid();
            LoadUsers();
        }

        private void HookEvents()
        {
            btnEditUser.Click += btnEditUser_Click;
            btnDeleteUser.Click += btnDeleteUser_Click;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
        }

        private void ConfigureGrid()
        {
            if (dgvUsers != null)
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadUsers()
        {
            userTable.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        u.IDUser, u.Name, u.Login, u.televon, u.Email, u.Addres, u.IDRole,
                        r.Name AS RoleName
                    FROM [User] u
                    LEFT JOIN Role r ON u.IDRole = r.IDRole";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.Fill(userTable);
                    dgvUsers.DataSource = userTable;
                }
            }
        }

        private DataGridViewRow GetSelectedRow()
        {
            if (dgvUsers.SelectedRows.Count > 0)
                return dgvUsers.SelectedRows[0];

            if (dgvUsers.CurrentRow != null && dgvUsers.CurrentRow.Index >= 0)
                return dgvUsers.CurrentRow;

            return null;
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                var row = GetSelectedRow();
                if (row == null)
                {
                    MessageBox.Show("Выберите пользователя в таблице.");
                    return;
                }

                int id = Convert.ToInt32(row.Cells["IDUser"].Value);
                string name = row.Cells["Name"].Value?.ToString() ?? "";
                string login = row.Cells["Login"].Value?.ToString() ?? "";
                string phone = row.Cells["televon"].Value?.ToString() ?? "";
                string email = row.Cells["Email"].Value?.ToString() ?? "";
                string addr = row.Cells["Addres"].Value?.ToString() ?? "";
                int roleId = row.Cells["IDRole"].Value == DBNull.Value ? 0 : Convert.ToInt32(row.Cells["IDRole"].Value);

                MessageBox.Show(
                    $"Редактирование:\n{id}\n{name}\n{login}\n{phone}\n{email}\n{addr}\nRole: {roleId}",
                    "Проверка");

                // Здесь позже можешь открыть форму редактирования
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                var row = GetSelectedRow();
                if (row == null)
                {
                    MessageBox.Show("Выберите пользователя в таблице.");
                    return;
                }

                int id = Convert.ToInt32(row.Cells["IDUser"].Value);

                if (MessageBox.Show("Удалить пользователя?", "Подтвердите",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM [User] WHERE IDUser = @IDUser", conn))
                    {
                        cmd.Parameters.AddWithValue("@IDUser", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadUsers();
                MessageBox.Show("Пользователь удалён.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}