using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodDelivery
{
    public partial class DishManagementForm : Form
    {
        private string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FoodDelivery;Integrated Security=False";
        private DataTable dishTable = new DataTable();

        public DishManagementForm()
        {
            InitializeComponent();
            LoadDishes();
        }

        private void LoadDishes()
        {
            this.dishTable.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            d.IDDish, d.Name, d.Description, d.Pric,
                            r.Name AS Restaurant, c.Name AS Category
                        FROM Dish d
                            LEFT JOIN Restaurant r ON d.IDRestauran = r.IDRestaurant
                            LEFT JOIN Category c ON d.IDCategory = c.IDCategory";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dishTable);

                    dgvDishes.DataSource = dishTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки блюд: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            // DishCreateForm createForm = new DishCreateForm();
            // createForm.ShowDialog();
            // LoadDishes();
        }

        private void btnEditDish_Click(object sender, EventArgs e)
        {
            if (dgvDishes.CurrentRow == null) return;

            // int dishId = Convert.ToInt32(dgvDishes.CurrentRow.Cells["IDDish"].Value);
            // DishEditForm editForm = new DishEditForm(dishId);
            // editForm.ShowDialog();
            // LoadDishes();
        }

        private void btnDeleteDish_Click(object sender, EventArgs e)
        {
            if (dgvDishes.CurrentRow == null) return;

            int dishId = Convert.ToInt32(dgvDishes.CurrentRow.Cells["IDDish"].Value);
            string dishName = dgvDishes.CurrentRow.Cells["Name"].Value.ToString();

            // F4: не удалять блюдо, если есть в заказах
            if (!IsDishAvailableToDelete(dishId))
            {
                MessageBox.Show(
                    "Невозможно удалить товар, так как он присутствует в одном или нескольких заказах.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Удалить блюдо '{dishName}'?", "Подтвердите", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string cmdText = "DELETE FROM Dish WHERE IDDish = @IDDish";
                        SqlCommand cmd = new SqlCommand(cmdText, conn);
                        cmd.Parameters.AddWithValue("@IDDish", dishId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Блюдо удалено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDishes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsDishAvailableToDelete(int dishId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string cmdText = @"
                    SELECT COUNT(*) 
                    FROM DishOrder
                    WHERE IDDish = @IDDish";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@IDDish", dishId);

                int count = (int)cmd.ExecuteScalar();
                return count == 0;
            }
        }
    }
}