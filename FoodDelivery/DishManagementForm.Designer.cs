namespace FoodDelivery
{
    partial class DishManagementForm
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
            this.dgvDishes = new System.Windows.Forms.DataGridView();
            this.btnAddDish = new System.Windows.Forms.Button();
            this.btnEditDish = new System.Windows.Forms.Button();
            this.btnDeleteDish = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDishes)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvDishes
            // 
            this.dgvDishes.AllowUserToAddRows = false;
            this.dgvDishes.AllowUserToDeleteRows = false;
            this.dgvDishes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDishes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDishes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDishes.Location = new System.Drawing.Point(12, 30);
            this.dgvDishes.Name = "dgvDishes";
            this.dgvDishes.ReadOnly = true;
            this.dgvDishes.RowHeadersWidth = 51;
            this.dgvDishes.Size = new System.Drawing.Size(590, 240);
            this.dgvDishes.TabIndex = 0;

            // 
            // btnAddDish
            // 
            this.btnAddDish.Location = new System.Drawing.Point(12, 278);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Size = new System.Drawing.Size(120, 25);
            this.btnAddDish.TabIndex = 1;
            this.btnAddDish.Text = "Добавить блюдо";
            this.btnAddDish.UseVisualStyleBackColor = true;

            // 
            // btnEditDish
            // 
            this.btnEditDish.Location = new System.Drawing.Point(138, 278);
            this.btnEditDish.Name = "btnEditDish";
            this.btnEditDish.Size = new System.Drawing.Size(120, 25);
            this.btnEditDish.TabIndex = 2;
            this.btnEditDish.Text = "Редактировать";
            this.btnEditDish.UseVisualStyleBackColor = true;

            // 
            // btnDeleteDish
            // 
            this.btnDeleteDish.Location = new System.Drawing.Point(264, 278);
            this.btnDeleteDish.Name = "btnDeleteDish";
            this.btnDeleteDish.Size = new System.Drawing.Size(120, 25);
            this.btnDeleteDish.TabIndex = 3;
            this.btnDeleteDish.Text = "Удалить блюдо";
            this.btnDeleteDish.UseVisualStyleBackColor = true;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Список блюд";

            // 
            // DishManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 315);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteDish);
            this.Controls.Add(this.btnEditDish);
            this.Controls.Add(this.btnAddDish);
            this.Controls.Add(this.dgvDishes);
            this.Name = "DishManagementForm";
            this.Text = "Управление блюдами";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDishes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #region Минимальная область компонентов

        private System.Windows.Forms.DataGridView dgvDishes;
        private System.Windows.Forms.Button btnAddDish;
        private System.Windows.Forms.Button btnEditDish;
        private System.Windows.Forms.Button btnDeleteDish;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}