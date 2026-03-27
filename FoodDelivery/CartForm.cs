using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FoodDelivery
{
    public partial class CartForm : Form
    {
        private List<CartItem> cartItems = new List<CartItem>();

        public CartForm()
        {
            InitializeComponent();
            UpdateGrid();
        }

        public class CartItem
        {
            public int DishId { get; set; }
            public string DishName { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }

            public double LineTotal => Price * Quantity;
        }

        public void AddDish(int dishId, string dishName, double price, int quantity)
        {
            var exists = cartItems.Find(x => x.DishId == dishId);
            if (exists != null)
                exists.Quantity += quantity;
            else
                cartItems.Add(new CartItem { DishId = dishId, DishName = dishName, Price = price, Quantity = quantity });

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = cartItems;

            double total = cartItems.Sum(x => x.LineTotal);
            lblTotal.Text = $"Итого: {total:N2} ₽";
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;

            var item = (CartItem)dgvCart.CurrentRow.DataBoundItem;
            if (item.Quantity > 1)
                item.Quantity--;
            else
                cartItems.Remove(item);

            UpdateGrid();
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;

            var item = (CartItem)dgvCart.CurrentRow.DataBoundItem;
            item.Quantity++;
            UpdateGrid();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (CurrentUser.IDUser == 0 || cartItems.Count == 0)
            {
                MessageBox.Show("Корзина пуста или не авторизован.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // здесь логика добавления в Order + DishOrder
            // см. пример InsertOrder ниже

            MessageBox.Show("Заказ оформлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // или очистить корзину
        }
    }
}