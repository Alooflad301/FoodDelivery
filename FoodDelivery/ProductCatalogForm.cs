using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FoodDelivery
{
    public partial class ProductCatalogForm : Form
    {
        private string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FoodDelivery;Integrated Security=False";
        private DataTable dishTable = new DataTable();

        public ProductCatalogForm()
        {
            InitializeComponent();
            LoadDishes();
        }

        private void LoadDishes()
        {
            // очищаем старые данные
            this.dishTable.Clear();
            this.dgvDishes.DataSource = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            d.IDDish, d.Name, d.Description, d.Pric, c.Name AS CategoryName,
                            r.Name AS RestaurantName
                        FROM Dish d
                            LEFT JOIN Category c ON d.IDCategory = c.IDCategory
                            LEFT JOIN Restaurant r ON d.IDRestauran = r.IDRestaurant
                        WHERE 1=1";

                    // если нужно, сюда добавить фильтр по поиску/textFilter.Text

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dishTable);

                    dgvDishes.DataSource = dishTable;

                    // AutoSizeColumnsMode и пр. можно настроить в дизайнере или тут
                    // dgvDishes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки каталога: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProductCatalogForm_Load(object sender, EventArgs e)
        {
            dgvDishes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDishes.MultiSelect = false;
            dgvDishes.ReadOnly = true;
            dgvDishes.AllowUserToAddRows = false;
            dgvDishes.AllowUserToDeleteRows = false;

            dgvDishes.ClearSelection();
        }

        private void dgvDishes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDishes.Columns[e.ColumnIndex].Name == "Pric" && e.Value != null)
            {
                if (Convert.ToDouble(e.Value) > 1000.0)
                {
                    e.CellStyle.BackColor = Color.LightSalmon;
                    e.CellStyle.Font = new Font(dgvDishes.DefaultCellStyle.Font, FontStyle.Bold);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(filter))
                LoadDishes();
            else
            {
                DataView dv = dishTable.DefaultView;
                dv.RowFilter = $"Name LIKE '%{filter}%' OR RestaurantName LIKE '%{filter}%' OR CategoryName LIKE '%{filter}%'";
                dgvDishes.DataSource = dv;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDishes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите блюдо в таблице.");
                    return;
                }

                var row = dgvDishes.SelectedRows[0];

                int dishId = Convert.ToInt32(row.Cells["IDDish"].Value);
                string dishName = row.Cells["Name"].Value?.ToString() ?? "";
                double price = Convert.ToDouble(row.Cells["Pric"].Value);

                CartForm cart = new CartForm();
                cart.AddDish(dishId, dishName, price, 1);
                cart.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}