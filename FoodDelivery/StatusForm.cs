using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodDelivery
{
    public partial class StatusForm : Form
    {
        private int orderId;
        private string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FoodDelivery;Integrated Security=False";

        public StatusForm(int orderId, string currentStatus)
        {
            InitializeComponent();

            this.orderId = orderId;
            this.Text = $"Изменить статус заказа #{orderId}";

            // Заполнение выпадающего списка статусов
            cmbStatus.Items.Add("Новый");
            cmbStatus.Items.Add("Готовится");
            cmbStatus.Items.Add("Готов");
            cmbStatus.Items.Add("Доставлен");

            // Выбираем текущий статус
            cmbStatus.SelectedItem = currentStatus;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedStatus = cmbStatus.SelectedItem.ToString();
            int statusId = StatusNameToId(selectedStatus);

            if (statusId == -1)
            {
                MessageBox.Show("Неизвестный статус.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateQuery = @"
                        UPDATE [Order]
                        SET IDStatysOrder = @IDStatysOrder
                        WHERE IDOrder = @IDOrder";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@IDStatysOrder", statusId);
                    cmd.Parameters.AddWithValue("@IDOrder", orderId);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("Статус заказа изменён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Заказ не найден.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления статуса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private int StatusNameToId(string statusName)
        {
            switch (statusName)
            {
                case "Новый": return 1;
                case "Готовится": return 2;
                case "Готов": return 3;
                case "Доставлен": return 4;
                default: return -1;
            }
        }
    }
}