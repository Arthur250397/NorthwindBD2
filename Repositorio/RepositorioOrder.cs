using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NorthwindProject.Model;

namespace NorthwindProject.Repositorio
{
    internal class RepositorioOrder
    { 
        SqlCommand cmd;  
        String strSql;

        public void Insert(Order order, SqlConnection conn, SqlTransaction tran)
        {

            try
            {

                strSql = "INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, " +
                                                "Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) " +
                                        "VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, " +
                                                "@Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)";
                cmd = new SqlCommand(strSql, conn, tran);


                cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                cmd.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@RequiredDate", order.RequiredDate);
                cmd.Parameters.AddWithValue("@ShippedDate", order.ShippedDate);
                cmd.Parameters.AddWithValue("@ShipVia", order.ShipVia);
                cmd.Parameters.AddWithValue("@Freight", order.Freight);
                cmd.Parameters.AddWithValue("@ShipName", order.CustomerID);
                cmd.Parameters.AddWithValue("@ShipAddress", order.ShipAddress);
                cmd.Parameters.AddWithValue("@ShipCity", order.ShipCity);
                cmd.Parameters.AddWithValue("@ShipRegion", order.ShipRegion);
                cmd.Parameters.AddWithValue("@ShipPostalCode", order.ShipPostalCode);
                cmd.Parameters.AddWithValue("@ShipCountry", order.ShipCountry);

                cmd.ExecuteNonQuery();

                tran.Commit();
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
        }
    }
}
