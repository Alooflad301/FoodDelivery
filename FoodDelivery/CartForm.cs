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
            HookButtons();
            UpdateGrid();
        }

        private void HookButtons()
        {
            btnIncrease.Click += btnIncrease_Click;
            btnDecrease.Click += btnDecrease_Click;
            btnOrder.Click += btnOrder_Click;
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
            var item = cartItems.FirstOrDefault(x => x.DishId == dishId);
            if (item == null)
            {
                cartItems.Add(new CartItem
                {
                    DishId = dishId,
                    DishName = dishName,
                    Price = price,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            if (dgvCart == null || lblTotal == null) return;

            dgvCart.DataSource = null;
            dgvCart.DataSource = cartItems.Select(x => new
            {
                x.DishId,
                x.DishName,
                x.Price,
                x.Quantity,
                LineTotal = x.LineTotal
            }).ToList();

            lblTotal.Text = "Итого: " + cartItems.Sum(x => x.LineTotal).ToString("N2") + " ₽";
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Increase clicked");
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Decrease clicked");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order clicked");
        }
    }
}