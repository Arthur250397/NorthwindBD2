namespace NorthwindProject
{
    partial class formProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            this.txbx_Quantity = new System.Windows.Forms.TextBox();
            this.cmbx_Produto = new System.Windows.Forms.ComboBox();
            this.txbx_Discount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_SalvarItem = new System.Windows.Forms.Button();
            this.orderdetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbx_Quantity
            // 
            this.txbx_Quantity.Location = new System.Drawing.Point(79, 81);
            this.txbx_Quantity.Name = "txbx_Quantity";
            this.txbx_Quantity.Size = new System.Drawing.Size(121, 23);
            this.txbx_Quantity.TabIndex = 0;
            // 
            // cmbx_Produto
            // 
            this.cmbx_Produto.FormattingEnabled = true;
            this.cmbx_Produto.Location = new System.Drawing.Point(79, 52);
            this.cmbx_Produto.Name = "cmbx_Produto";
            this.cmbx_Produto.Size = new System.Drawing.Size(121, 23);
            this.cmbx_Produto.TabIndex = 1;
            this.cmbx_Produto.Click += new System.EventHandler(this.cmbx_Produto_Click);
            // 
            // txbx_Discount
            // 
            this.txbx_Discount.Location = new System.Drawing.Point(79, 110);
            this.txbx_Discount.Name = "txbx_Discount";
            this.txbx_Discount.Size = new System.Drawing.Size(121, 23);
            this.txbx_Discount.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Desconto";
            // 
            // btn_SalvarItem
            // 
            this.btn_SalvarItem.Location = new System.Drawing.Point(79, 139);
            this.btn_SalvarItem.Name = "btn_SalvarItem";
            this.btn_SalvarItem.Size = new System.Drawing.Size(121, 23);
            this.btn_SalvarItem.TabIndex = 6;
            this.btn_SalvarItem.Text = "Salvar";
            this.btn_SalvarItem.UseVisualStyleBackColor = true;
            this.btn_SalvarItem.Click += new System.EventHandler(this.btn_SalvarItem_Click);
            // 
            // orderdetails
            // 
            this.orderdetails.AutoSize = true;
            this.orderdetails.Font = new System.Drawing.Font("Script MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orderdetails.Location = new System.Drawing.Point(22, 9);
            this.orderdetails.Name = "orderdetails";
            this.orderdetails.Size = new System.Drawing.Size(222, 33);
            this.orderdetails.TabIndex = 7;
            this.orderdetails.Text = "Detalhes do pedido";
            // 
            // formProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(261, 180);
            this.Controls.Add(this.orderdetails);
            this.Controls.Add(this.btn_SalvarItem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbx_Discount);
            this.Controls.Add(this.cmbx_Produto);
            this.Controls.Add(this.txbx_Quantity);
            this.Name = "formProdutos";
            this.Text = "formProdutos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private TextBox txbx_Quantity;
        private ComboBox cmbx_Produto;
        private TextBox txbx_Discount;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_SalvarItem;
        private Label orderdetails;
    }
}