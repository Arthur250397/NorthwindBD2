using NorthwindProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 

namespace NorthwindProject.Repositorio
{
    internal class RepositorioOrderDetail
    { 
        SqlCommand cmd;
        String strSql;

        public void Insert(OrderDetail orderDetail, SqlConnection conn, SqlTransaction tran)
        {

            strSql = "INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount) " +
                                    "VALUES ((SELECT MAX(OrderID) FROM Orders), @ProductID, @UnitPrice, @Quantity, @Discount)";
            cmd = new SqlCommand(strSql, conn, tran);

            cmd.Parameters.AddWithValue("@ProductID", orderDetail.ProductID);
            cmd.Parameters.AddWithValue("@UnitPrice", orderDetail.UnitPrice);
            cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
            cmd.Parameters.AddWithValue("@Discount", orderDetail.Discount);

            cmd.ExecuteNonQuery();
        }
    }
}
