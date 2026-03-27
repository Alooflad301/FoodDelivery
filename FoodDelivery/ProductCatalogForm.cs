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
            // подписка для визуального F3: выделить Price > 1000
            dgvDishes.CellFormatting += dgvDishes_CellFormatting;

            // для ролей Клиент/Менеджер возможно скрытие кнопок редактирования
            if (CurrentUser.IDRole == 3) // Клиент
            {
                // например, скрыть btnEditDish, btnAddDish
            }
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
            if (dgvDishes.CurrentRow == null)
                return;

            int dishId = Convert.ToInt32(dgvDishes.CurrentRow.Cells["IDDish"].Value);
            string dishName = dgvDishes.CurrentRow.Cells["Name"].Value.ToString();
            double price = Convert.ToDouble(dgvDishes.CurrentRow.Cells["Pric"].Value);

            // передать в корзину или открыть форму корзины
            CartForm cart = new CartForm();
            cart.AddDish(dishId, dishName, price, 1);
            cart.Show();
        }
    }
}