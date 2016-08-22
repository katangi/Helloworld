using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingMvc.Models;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class OrderDetailsDL:DBHelper
    {
        public int SaveOrderDetails(OrderDetails oborderdetail)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpAddOrderDetails", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@OrderId", oborderdetail.OrderId);
                command.Parameters.AddWithValue("@PrductId", oborderdetail.ProductId);
                command.Parameters.AddWithValue("@Quantity", oborderdetail.Quantity);
                command.Parameters.AddWithValue("@Price", oborderdetail.Price);
                command.Parameters.AddWithValue("@OrderDate", oborderdetail.OrderDate);
            

                int reader = command.ExecuteNonQuery();
                if (reader > 0)
                {
                    returnVariable = 1;
                }
                else
                {
                    returnVariable = 0;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return returnVariable;
        }

        public List<OrderDetails> GetAllOrderDetail()
        {
            List<OrderDetails> orderdetailList = new List<OrderDetails>();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetAllOrderDetails", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
               
                reader = command.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read()) // Read data from database
                    {
                        var orderdetail = new OrderDetails();

                        //if (!DBNull.Value.Equals(reader["UserId"]))
                        //    orderdetail.Id = Convert.ToInt32(reader["UserId"]);

                        //if (!DBNull.Value.Equals(reader["OrderId"]))
                        //    orderdetail.OrderId = Convert.ToInt32(reader["OrderId"]);

                        if (!DBNull.Value.Equals(reader["UserName"]))
                            orderdetail.UserName = Convert.ToString(reader["UserName"]);

                        //if (!DBNull.Value.Equals(reader["ProductId"]))
                        //    orderdetail.ProductId = Convert.ToInt32(reader["ProductId"]);

                        if (!DBNull.Value.Equals(reader["ProductName"]))
                            orderdetail.ProductName = Convert.ToString(reader["ProductName"]);

                        if (!DBNull.Value.Equals(reader["Price"]))
                            orderdetail.Price = Convert.ToDecimal(reader["Price"]);


                        if (!DBNull.Value.Equals(reader["Quantity"]))
                            orderdetail.Quantity = Convert.ToInt32(reader["Quantity"]);

                        if (!DBNull.Value.Equals(reader["Date"]))
                            orderdetail.OrderDate = Convert.ToDateTime(reader["Date"]);

                       

                        orderdetailList.Add(orderdetail);
                    }

                    reader.Close();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return orderdetailList;


        }

        public OrderDetails GetOrderdetailsById(int Id)
        {
            var orderdetail = new OrderDetails();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetOrderDetailById", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", Id);
                reader = command.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read()) // Read data from database
                    {


                        if (!DBNull.Value.Equals(reader["Id"]))
                            orderdetail.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["OrderId"]))
                            orderdetail.OrderId = Convert.ToInt32(reader["OrderId"]);

                        if (!DBNull.Value.Equals(reader["ProductId"]))
                            orderdetail.ProductId = Convert.ToInt32(reader["ProductId"]);

                        if (!DBNull.Value.Equals(reader["Price"]))
                            orderdetail.Price = Convert.ToDecimal(reader["Price"]);


                        if (!DBNull.Value.Equals(reader["Quantity"]))
                            orderdetail.Quantity = Convert.ToInt32(reader["Quantity"]);

                        if (!DBNull.Value.Equals(reader["OrderDate"]))
                            orderdetail.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    }

                    return orderdetail;


                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return orderdetail;


        }
        public int UpdateOrderdetails(OrderDetails orderdetail)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpUpdateOrderdetails", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@OrderdetailId", orderdetail.Id);
               
                command.Parameters.AddWithValue("@Quantity", orderdetail.Quantity);
                command.Parameters.AddWithValue("@price", orderdetail.Price);
                command.Parameters.AddWithValue("@OrderDate", orderdetail.OrderDate);
             
                int reader = command.ExecuteNonQuery();
                if (reader > 0)
                {
                    returnVariable = 1;
                }
                else
                {
                    returnVariable = 0;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return returnVariable;
        }


        public List<OrderDetails> GetCartById(int Id)
        {
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetCartById", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@UserId", Id);
                reader = command.ExecuteReader();

                List<OrderDetails> orderList;

                if (reader != null)
                {
                    orderList = new List<OrderDetails>();
                    while (reader.Read()) // Read data from database
                    {
                        var cart = new OrderDetails();

                        if (!DBNull.Value.Equals(reader["OId"]))
                            cart.Id = Convert.ToInt32(reader["OId"]);

                        if (!DBNull.Value.Equals(reader["Id"]))
                            cart.ProductId = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["Image"]))
                            cart.Image = Convert.ToString(reader["Image"]);

                        if (!DBNull.Value.Equals(reader["ProductName"]))
                            cart.ProductName = Convert.ToString(reader["ProductName"]);

                        if (!DBNull.Value.Equals(reader["Quantity"]))
                            cart.Quantity = Convert.ToInt32(reader["Quantity"]);

                        if (!DBNull.Value.Equals(reader["Price"]))
                            cart.Price = Convert.ToDecimal(reader["Price"]);

                        orderList.Add(cart);
                    }

                    return orderList;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return null;
        }

        public int DeleteCart(int uid,int pid)
        {
            int returnVariable = 0;
          
            try
            {
                connection.Open();
                command = new SqlCommand("stpDeleteOrderdetailCart", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@ProductId", pid);
                command.Parameters.AddWithValue("@UserId", uid);
             
                int reader = command.ExecuteNonQuery();
                if (reader > 0)
                {
                    returnVariable = 1;
                }
                else
                {
                    returnVariable = 0;
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return returnVariable;


        }
    }
}
