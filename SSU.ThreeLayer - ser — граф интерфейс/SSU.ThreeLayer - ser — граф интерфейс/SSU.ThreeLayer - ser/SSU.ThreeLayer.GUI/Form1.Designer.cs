namespace SSU.ThreeLayer.GUI
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.numProductQuantity = new System.Windows.Forms.NumericUpDown();
            this.dtpProductStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpProductEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lstProducts = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numProductQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(13, 13);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(200, 22);
            this.txtClientName.TabIndex = 0;
            this.txtClientName.TextChanged += new System.EventHandler(this.txtClientName_TextChanged);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(13, 40);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(200, 23);
            this.btnAddClient.TabIndex = 1;
            this.btnAddClient.Text = "Add Client";
            this.btnAddClient.UseVisualStyleBackColor = true;
            // 
            // lstClients
            // 
            this.lstClients.FormattingEnabled = true;
            this.lstClients.ItemHeight = 16;
            this.lstClients.Location = new System.Drawing.Point(13, 70);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(200, 84);
            this.lstClients.TabIndex = 2;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(13, 172);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(200, 22);
            this.txtProductName.TabIndex = 3;
            // 
            // numProductQuantity
            // 
            this.numProductQuantity.Location = new System.Drawing.Point(13, 199);
            this.numProductQuantity.Name = "numProductQuantity";
            this.numProductQuantity.Size = new System.Drawing.Size(200, 22);
            this.numProductQuantity.TabIndex = 4;
            // 
            // dtpProductStartDate
            // 
            this.dtpProductStartDate.Location = new System.Drawing.Point(13, 226);
            this.dtpProductStartDate.Name = "dtpProductStartDate";
            this.dtpProductStartDate.Size = new System.Drawing.Size(200, 22);
            this.dtpProductStartDate.TabIndex = 5;
            // 
            // dtpProductEndDate
            // 
            this.dtpProductEndDate.Location = new System.Drawing.Point(13, 253);
            this.dtpProductEndDate.Name = "dtpProductEndDate";
            this.dtpProductEndDate.Size = new System.Drawing.Size(200, 22);
            this.dtpProductEndDate.TabIndex = 6;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(13, 280);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(200, 23);
            this.btnAddProduct.TabIndex = 7;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            // 
            // lstProducts
            // 
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.ItemHeight = 16;
            this.lstProducts.Location = new System.Drawing.Point(13, 310);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(200, 84);
            this.lstProducts.TabIndex = 8;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 450);
            this.Controls.Add(this.lstProducts);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.dtpProductEndDate);
            this.Controls.Add(this.dtpProductStartDate);
            this.Controls.Add(this.numProductQuantity);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lstClients);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.txtClientName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numProductQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.NumericUpDown numProductQuantity;
        private System.Windows.Forms.DateTimePicker dtpProductStartDate;
        private System.Windows.Forms.DateTimePicker dtpProductEndDate;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.ListBox lstProducts;
    }
}
