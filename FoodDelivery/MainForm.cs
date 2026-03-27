using System;
using System.Windows.Forms;

namespace FoodDelivery
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            SetupMenuByRole();
        }

        private void SetupMenuByRole()
        {
            // скрываем специфические пункты по умолчанию
            mnuUserManagement.Visible = false;
            mnuDishManagement.Visible = false;
            mnuReports.Visible = false;

            if (CurrentUser.IDRole == 1) // Администратор
            {
                mnuUserManagement.Visible = true;
                mnuDishManagement.Visible = true;
                mnuReports.Visible = true;
            }
            else if (CurrentUser.IDRole == 2) // Менеджер
            {
                mnuReports.Visible = true;
            }
            // Клиент – только базовый функционал
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            // выход текущего пользователя
            CurrentUser.IDUser = 0;
            CurrentUser.Name = null;
            CurrentUser.IDRole = 0;

            LoginForm login = new LoginForm();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuProductCatalog_Click(object sender, EventArgs e)
        {
            ProductCatalogForm catalog = new ProductCatalogForm();
            catalog.Show();
        }

        private void mnuCart_Click(object sender, EventArgs e)
        {
            CartForm cart = new CartForm();
            cart.Show();
        }

        private void mnuOrderHistory_Click(object sender, EventArgs e)
        {
            OrderHistoryForm history = new OrderHistoryForm();
            history.Show();
        }

        private void mnuUserManagement_Click(object sender, EventArgs e)
        {
            UserManagementForm users = new UserManagementForm();
            users.Show();
        }

        private void mnuDishManagement_Click(object sender, EventArgs e)
        {
            DishManagementForm dishes = new DishManagementForm();
            dishes.Show();
        }

        private void mnuReports_Click(object sender, EventArgs e)
        {
            // заготовка формы отчётов (можно реализовать позже)
            OrderManagementForm reports = new OrderManagementForm();
            reports.Show();
        }
    }
}