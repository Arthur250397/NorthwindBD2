using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NorthwindProject.Model;

namespace NorthwindProject
{
    public partial class formProdutos : Form
    { 
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader dr;
        String strConn = "Server=ARTHUR-PC;Database=Northwind;User Id=sa;Password=sysadmin;";
        String strSql;
        OrderDetail orderDetail = new OrderDetail();

        public formProdutos()
        {
            InitializeComponent(); 
        }

        private void btn_SalvarItem_Click(object sender, EventArgs e)
        { 
            Form1 form1 = new Form1();  

            if(cmbx_Produto.SelectedValue != null && txbx_Discount.Text != String.Empty && txbx_Quantity.Text != String.Empty)
            {
                string[] ID = cmbx_Produto.SelectedValue.ToString().Split(";");
                orderDetail.ProductID = Convert.ToInt32(ID[0]);
                orderDetail.UnitPrice = Convert.ToDecimal(ID[1].Replace(".", ","));
                orderDetail.Discount = Convert.ToDecimal(txbx_Discount.Text) / 100; 
                orderDetail.Quantity = Convert.ToInt32(txbx_Quantity.Text);

                form1.AddOrderDetail(orderDetail);

                this.Close();
            }
            else
            { 
                MessageBox.Show("Insira todas as informações do pedido");
            }

        }
         

        private void cmbx_Produto_Click(object sender, EventArgs e)
        { 
            try
            {
                conn = new SqlConnection(strConn);

                strSql = "SELECT CAST(ProductID as varchar(10)) + ';' + CAST(UnitPrice as varchar(10)) AS ID, " +
                                "ProductName AS Nome FROM Products";

                cmd = new SqlCommand(strSql, conn);

                conn.Open();

                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dr);

                DataRow linha = dt.NewRow();
                linha["Nome"] = "";
                dt.Rows.InsertAt(linha, 0);

                cmbx_Produto.DataSource = dt;
                cmbx_Produto.ValueMember = "ID";
                cmbx_Produto.DisplayMember = "Nome";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //MessageBox.Show("Cliente inserido com sucesso");
                conn.Close();
                conn = null;
                cmd = null;
            }
        }
    }
}
