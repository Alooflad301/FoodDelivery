using System;

namespace FoodDelivery
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProductCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrderHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDishManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuCatalog,
            this.mnuCart,
            this.mnuOrderHistory,
            this.mnuAdministration});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(48, 20);
            this.mnuFile.Text = "Файл";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(200, 22);
            this.mnuLogin.Text = "Сменить пользователя";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(200, 22);
            this.mnuExit.Text = "Выход";
            // 
            // mnuCatalog
            // 
            this.mnuCatalog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProductCatalog});
            this.mnuCatalog.Name = "mnuCatalog";
            this.mnuCatalog.Size = new System.Drawing.Size(62, 20);
            this.mnuCatalog.Text = "Каталог";
            // 
            // mnuProductCatalog
            // 
            this.mnuProductCatalog.Name = "mnuProductCatalog";
            this.mnuProductCatalog.Size = new System.Drawing.Size(150, 22);
            this.mnuProductCatalog.Text = "Каталог блюд";
            // 
            // mnuCart
            // 
            this.mnuCart.Name = "mnuCart";
            this.mnuCart.Size = new System.Drawing.Size(65, 20);
            this.mnuCart.Text = "Корзина";
            // 
            // mnuOrderHistory
            // 
            this.mnuOrderHistory.Name = "mnuOrderHistory";
            this.mnuOrderHistory.Size = new System.Drawing.Size(110, 20);
            this.mnuOrderHistory.Text = "История заказов";
            // 
            // mnuAdministration
            // 
            this.mnuAdministration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUserManagement,
            this.mnuDishManagement,
            this.mnuReports});
            this.mnuAdministration.Name = "mnuAdministration";
            this.mnuAdministration.Size = new System.Drawing.Size(134, 20);
            this.mnuAdministration.Text = "Администрирование";
            // 
            // mnuUserManagement
            // 
            this.mnuUserManagement.Name = "mnuUserManagement";
            this.mnuUserManagement.Size = new System.Drawing.Size(152, 22);
            this.mnuUserManagement.Text = "Пользователи";
            // 
            // mnuDishManagement
            // 
            this.mnuDishManagement.Name = "mnuDishManagement";
            this.mnuDishManagement.Size = new System.Drawing.Size(152, 22);
            this.mnuDishManagement.Text = "Блюда";
            // 
            // mnuReports
            // 
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Size = new System.Drawing.Size(152, 22);
            this.mnuReports.Text = "Отчёты";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.Location = new System.Drawing.Point(10, 10);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(481, 29);
            this.labelWelcome.TabIndex = 1;
            this.labelWelcome.Text = "FoodDelivery — Система доставки еды";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(684, 336);
            this.panel1.TabIndex = 2;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLogo.Location = new System.Drawing.Point(450, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(200, 24);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 3;
            this.pictureBoxLogo.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 360);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "FoodDelivery — Система доставки еды";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            this.mnuProductCatalog.Click += new System.EventHandler(this.mnuProductCatalog_Click);
            this.mnuCart.Click += new System.EventHandler(this.mnuCart_Click);
            this.mnuOrderHistory.Click += new System.EventHandler(this.mnuOrderHistory_Click);
            this.mnuUserManagement.Click += new System.EventHandler(this.mnuUserManagement_Click);
            this.mnuDishManagement.Click += new System.EventHandler(this.mnuDishManagement_Click);
            this.mnuReports.Click += new System.EventHandler(this.mnuReports_Click);

        }

        #region Minimal Constructor Region

        private void MainForm_Load(object sender, EventArgs e)
        {
            string roleName;
            switch (CurrentUser.IDRole)
            {
                case 1:
                    roleName = "Администратор";
                    break;
                case 2:
                    roleName = "Менеджер";
                    break;
                case 3:
                    roleName = "Клиент";
                    break;
                default:
                    roleName = "Пользователь";
                    break;
            }

            this.labelWelcome.Text = $"Добро пожаловать, {roleName}: {CurrentUser.Name}";
        }

        #endregion

        #region Components

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuCatalog;
        private System.Windows.Forms.ToolStripMenuItem mnuProductCatalog;
        private System.Windows.Forms.ToolStripMenuItem mnuCart;
        private System.Windows.Forms.ToolStripMenuItem mnuOrderHistory;
        private System.Windows.Forms.ToolStripMenuItem mnuAdministration;
        private System.Windows.Forms.ToolStripMenuItem mnuUserManagement;
        private System.Windows.Forms.ToolStripMenuItem mnuDishManagement;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxLogo;

        #endregion
    }
}