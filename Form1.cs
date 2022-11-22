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
using System.Net;
using System.Diagnostics.Metrics;
using NorthwindProject.Model;
using NorthwindProject.Repositorio;

namespace NorthwindProject
{
    public partial class Form1 : Form
    {    
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader dr;
        SqlTransaction tran;
        String strConn = "Server=ARTHUR-PC;Database=Northwind;User Id=sa;Password=sysadmin;";
        String strSql;


        RepositorioOrder repOrd = new RepositorioOrder();
        RepositorioOrderDetail repOrdDet = new RepositorioOrderDetail();
        static Order order = new Order();
        static List<OrderDetail> lstOrderDet = new List<OrderDetail>();
        BindingSource orderDetBS = new BindingSource();


        public Form1()
        {
            InitializeComponent(); 
        }
        
        #region Private
        private void lbl_CustomerId_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txbx_CustomerId_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_CustomerId_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txbx_CompanyName_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Clientes

        private void CarregarClientes()
        { 
            try
            {
                conn = new SqlConnection(strConn);

                strSql = "SELECT * FROM Customers";

                DataSet ds = new DataSet();

                adapter = new SqlDataAdapter(strSql, strConn);

                conn.Open();

                adapter.Fill(ds);

                grid_Customers.DataSource = ds.Tables[0];
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

        private void LimparCampos()
        {
            txbx_CustomerId.Text = String.Empty;
            txbx_CompanyName.Text = String.Empty;
            txbx_ContactName.Text = String.Empty;
            txbx_ContactTitle.Text = String.Empty;
            txbx_Address.Text = String.Empty;
            txbx_City.Text = String.Empty;
            txbx_Region.Text = String.Empty;
            txbx_PostalCode.Text = String.Empty;
            txbx_Phone.Text = String.Empty;
            txbx_Country.Text = String.Empty;
            txbx_Fax.Text = String.Empty;
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(strConn);

                strSql = "INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) " +
                                       "VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";
                cmd = new SqlCommand(strSql, conn);

                cmd.Parameters.AddWithValue("@CustomerID", txbx_CustomerId.Text);
                cmd.Parameters.AddWithValue("@CompanyName", txbx_CompanyName.Text);
                cmd.Parameters.AddWithValue("@ContactName", txbx_ContactName.Text);
                cmd.Parameters.AddWithValue("@ContactTitle", txbx_ContactTitle.Text);
                cmd.Parameters.AddWithValue("@Address", txbx_Address.Text);
                cmd.Parameters.AddWithValue("@City", txbx_City.Text);
                cmd.Parameters.AddWithValue("@Region", txbx_Region.Text);
                cmd.Parameters.AddWithValue("@PostalCode", txbx_PostalCode.Text);
                cmd.Parameters.AddWithValue("@Country", txbx_Country.Text);
                cmd.Parameters.AddWithValue("@Phone", txbx_Phone.Text);
                cmd.Parameters.AddWithValue("@Fax", txbx_Fax.Text);

                conn.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cliente inserido com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close(); 
                CarregarClientes();
                LimparCampos();
                conn = null;
                cmd = null;
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            CarregarClientes();
        }


        private void grid_Customers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                conn = new SqlConnection(strConn);

                var CustomerID = grid_Customers.Rows[e.RowIndex].Cells[0].Value;


                strSql = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";

                cmd = new SqlCommand(strSql, conn);

                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txbx_CustomerId.Text = dr["CustomerID"].ToString();
                    txbx_CompanyName.Text = dr["CompanyName"].ToString();
                    txbx_ContactName.Text = dr["ContactName"].ToString();
                    txbx_ContactTitle.Text = dr["ContactTitle"].ToString();
                    txbx_Address.Text = dr["Address"].ToString();
                    txbx_City.Text = dr["City"].ToString();
                    txbx_Region.Text = dr["Region"].ToString();
                    txbx_PostalCode.Text = dr["PostalCode"].ToString();
                    txbx_Phone.Text = dr["Phone"].ToString();
                    txbx_Country.Text = dr["Country"].ToString();
                    txbx_Fax.Text = dr["Fax"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn = null;
                cmd = null;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        { 
            try
            {
                conn = new SqlConnection(strConn);

                strSql = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                cmd = new SqlCommand(strSql, conn);

                cmd.Parameters.AddWithValue("@CustomerID", txbx_CustomerId.Text); 

                conn.Open();
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Cliente deletado com sucesso");  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close(); 
                CarregarClientes();
                LimparCampos();
                conn = null;
                cmd = null;
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        { 
            try
            {
                conn = new SqlConnection(strConn);


                strSql = "UPDATE Customers SET CompanyName = @CompanyName, ContactName = @ContactName, " +
                                              "ContactTitle = @ContactTitle, Address = @Address, City = @City, " +
                                              "Region = @Region, PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax " +
                                              "WHERE CustomerID = @CustomerID";

                cmd = new SqlCommand(strSql, conn);

                cmd.Parameters.AddWithValue("@CustomerID", txbx_CustomerId.Text);
                cmd.Parameters.AddWithValue("@CompanyName", txbx_CompanyName.Text);
                cmd.Parameters.AddWithValue("@ContactName", txbx_ContactName.Text);
                cmd.Parameters.AddWithValue("@ContactTitle", txbx_ContactTitle.Text);
                cmd.Parameters.AddWithValue("@Address", txbx_Address.Text);
                cmd.Parameters.AddWithValue("@City", txbx_City.Text);
                cmd.Parameters.AddWithValue("@Region", txbx_Region.Text);
                cmd.Parameters.AddWithValue("@PostalCode", txbx_PostalCode.Text);
                cmd.Parameters.AddWithValue("@Country", txbx_Country.Text);
                cmd.Parameters.AddWithValue("@Phone", txbx_Phone.Text);
                cmd.Parameters.AddWithValue("@Fax", txbx_Fax.Text);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //MessageBox.Show("Cliente inserido com sucesso");
                conn.Close();
                CarregarClientes();
                LimparCampos();
                conn = null;
                cmd = null;
            }
        }
        #endregion

        #region Compras
        private void btn_SelectOrders_Click(object sender, EventArgs e)
        { 
            try
            {
                conn = new SqlConnection(strConn);

                strSql = "SELECT \r\nO.OrderID AS Pedido,\r\nE.FirstName + ' ' + E.LastName AS Vendedor," +
                            "\r\nC.CompanyName AS cliente,\r\nO.OrderDate AS [Data Pedido], " +
                            "O.ShipName AS [Nome navio],\r\nO.ShipCity AS Cidade, " +
                            "O.ShipRegion AS Região, O.ShipCountry AS País\r\nFROM " +
                            "Orders O join Employees E on E.EmployeeID = O.EmployeeID\r\n\t\t\t  " +
                                     "join Customers C on C.CustomerID = O.CustomerID";

                DataSet ds = new DataSet();

                adapter = new SqlDataAdapter(strSql, strConn);

                conn.Open();

                adapter.Fill(ds);

                grid_Compras.DataSource = ds.Tables[0];
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
        #endregion

        #region Relatorio de vendas  
        private void btn_SelectRelatorio_Click(object sender, EventArgs e)
        {

            try
            {
                conn = new SqlConnection(strConn);

                strSql = "EXEC sp_vendas_funcionario '"+ dted_DataIni.Value.ToString("MM/dd/yyyy") + "', '"+ dted_DataFim.Value.ToString("MM/dd/yyyy") + "', "+cmbx_Employees.SelectedValue+";";

                cmd = new SqlCommand(strSql, conn);
                 

                DataSet ds = new DataSet();

                adapter = new SqlDataAdapter(strSql, strConn);

                conn.Open();

                adapter.Fill(ds);

                grid_Relatorios.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //MessageBox.Show("Cliente inserido com sucesso");
                conn.Close();
                CarregarClientes();
                LimparCampos();
                conn = null;
                cmd = null;
            }
        } 

        private void cmbx_Employees_Click(object sender, EventArgs e)
        { 
            try
            {
                conn = new SqlConnection(strConn);

                strSql = "SELECT EmployeeID AS ID, FirstName + ' ' + LastName AS Nome  FROM Employees";
                  
                cmd = new SqlCommand(strSql, conn);
                
                conn.Open();

                dr = cmd.ExecuteReader();
                
                DataTable dt = new DataTable();

                dt.Load(dr);

                DataRow linha = dt.NewRow();
                linha["Nome"] = ""; 
                dt.Rows.InsertAt(linha, 0);

                cmbx_Employees.DataSource = dt;
                cmbx_Employees.ValueMember = "ID";
                cmbx_Employees.DisplayMember = "Nome";
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
        #endregion

        #region Vendas 
        private void btn_SalvarCompra_Click(object sender, EventArgs e)
        { 
            conn = new SqlConnection(strConn);
            conn.Open();
            tran = conn.BeginTransaction();

            order.CustomerID = cmbx_Customers.SelectedValue.ToString();
            order.EmployeeID = Convert.ToInt32(cmbx_Employees2.SelectedValue.ToString());
            order.ShipVia = Convert.ToInt32(cmbx_Shippers.SelectedValue.ToString());
            order.OrderDate = dted_OrderDate.Value;
            order.RequiredDate = dted_OrderDate.Value;
            order.ShippedDate = dted_OrderDate.Value;
            order.Freight = Convert.ToDecimal(txbx_Freight.Text);
            order.ShipCity = txbx_ShipCity.Text;
            order.ShipCountry = txbx_ShipCountry.Text;
            order.ShipPostalCode = txbx_ShipPostalCode.Text;
            order.ShipName = txbx_ShipName.Text;
            order.ShipRegion = txbx_ShipRegion.Text;
            order.ShipAddress = txbx_ShipAdderess.Text;

            repOrd.Insert(order, conn, tran);  


            conn = new SqlConnection(strConn);
            conn.Open();
            tran = conn.BeginTransaction();

            try
            { 
                if (lstOrderDet.Count != 0)
                {
                    foreach (var ordDet in lstOrderDet)
                    {
                        repOrdDet.Insert(ordDet, conn, tran);  
                    }

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn = null;
                cmd = null;
                tran = null;
            }


            LimparCamposProdutos();
            MessageBox.Show("Pedido realizado com sucesso!"); 
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            formProdutos formProd = new formProdutos();
            formProd.StartPosition = FormStartPosition.CenterParent;
            formProd.ShowDialog();
        }

        private void cmbx_Customers_Click(object sender, EventArgs e)
        { 
            try
            {
                conn = new SqlConnection(strConn);

                strSql = "SELECT CustomerID AS ID, CompanyName AS Nome from Customers";
                cmd = new SqlCommand(strSql, conn);

                conn.Open();

                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dr);

                //DataRow linha = dt.NewRow();
                //linha["Nome"] = "";
                //dt.Rows.InsertAt(linha, 0);

                cmbx_Customers.DataSource = dt;
                cmbx_Customers.ValueMember = "ID";
                cmbx_Customers.DisplayMember = "Nome";
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

        private void cmbx_Employees2_Click(object sender, EventArgs e)
        { 
            try
            {
                conn = new SqlConnection(strConn);

                strSql = "SELECT EmployeeID AS ID, FirstName + ' ' + LastName AS Nome  FROM Employees";

                cmd = new SqlCommand(strSql, conn);

                conn.Open();

                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dr);

                DataRow linha = dt.NewRow();
                linha["Nome"] = "";
                dt.Rows.InsertAt(linha, 0);

                cmbx_Employees2.DataSource = dt;
                cmbx_Employees2.ValueMember = "ID";
                cmbx_Employees2.DisplayMember = "Nome";
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

        private void cmbx_Shippers_Click(object sender, EventArgs e)
        { 
            try
            {
                conn = new SqlConnection(strConn);

                strSql = "SELECT ShipperID AS ID, CompanyName AS Nome FROM Shippers";

                cmd = new SqlCommand(strSql, conn);

                conn.Open();

                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dr);

                DataRow linha = dt.NewRow();
                linha["Nome"] = "";
                dt.Rows.InsertAt(linha, 0);

                cmbx_Shippers.DataSource = dt;
                cmbx_Shippers.ValueMember = "ID";
                cmbx_Shippers.DisplayMember = "Nome";
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

        private void Form1_Load(object sender, EventArgs e)
        {
            orderDetBS.DataSource = lstOrderDet;

            gdvw_OrderDetails.DataSource = orderDetBS;
        }

        internal void AddOrderDetail(OrderDetail orderDetail)
        {
            lstOrderDet.Add(orderDetail);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            orderDetBS.ResetBindings(false);
        }

        private void LimparCamposProdutos()
        {
            txbx_ShipAdderess.Text = null;
            txbx_ShipCity.Text = null;
            txbx_ShipCountry.Text = null;
            txbx_ShipName.Text = null;
            txbx_ShipPostalCode.Text = null;
            txbx_ShipRegion.Text = null;  
            dted_OrderDate.Value  = DateTime.Now;
        }
        #endregion
    }
}
