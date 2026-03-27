using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodDelivery
{
    public partial class OrderHistoryForm : Form
    {
        private string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FoodDelivery;Integrated Security=False";

        public OrderHistoryForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            DataTable ordersTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            o.IDOrder, o.OrderDate, o.Pric, s.Statys
                        FROM [Order] o
                            INNER JOIN StatysOrder s ON o.IDStatysOrder = s.IDStatysOrder
                        WHERE o.IDUser = @IDUser
                        ORDER BY o.OrderDate DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDUser", CurrentUser.IDUser);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ordersTable);

                    dgvOrders.DataSource = ordersTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки истории заказов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;

            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["IDOrder"].Value);
            ShowOrderDetails(orderId);
        }

        private void ShowOrderDetails(int orderId)
        {
            DataTable detailTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        di.IDDish, d.Name, di.Quantity, d.Pric, 
                        dbo.CalculateLineTotal(d.Pric, di.Quantity) AS LineTotal -- если есть такая функция в БД
                    FROM DishOrder di
                        INNER JOIN Dish d ON di.IDDish = d.IDDish
                    WHERE di.IDOrder = @IDOrder";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDOrder", orderId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(detailTable);

                dgvOrderDetails.DataSource = detailTable;
            }
        }
    }
}