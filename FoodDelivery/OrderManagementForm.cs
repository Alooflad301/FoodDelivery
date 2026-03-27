using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodDelivery
{
    public partial class OrderManagementForm : Form
    {
        private string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FoodDelivery;Integrated Security=False";
        private DataTable orderTable = new DataTable();

        public OrderManagementForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            this.orderTable.Clear();

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
                        ORDER BY o.OrderDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(orderTable);

                    dgvOrders.DataSource = orderTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки заказов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        d.Name AS DishName, di.Quantity, d.Pric, 
                        (d.Pric * di.Quantity) AS LineTotal
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

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;

            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["IDOrder"].Value);
            string oldStatus = dgvOrders.CurrentRow.Cells["Statys"].Value.ToString();

            StatusForm statusForm = new StatusForm(orderId, oldStatus);
            statusForm.ShowDialog();

            LoadOrders(); // обновляем, если статус изменился
        }
    }
}