using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ShoppingMvc.Models;


namespace DataAccessLayer
{
   public class OrderDL:DBHelper
    {
        int a;
        int OrderId;
        public int SaveOrders(Orders oborder)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpAddOrders", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@UserId", oborder.UserId);
                command.Parameters.AddWithValue("@AddressId", oborder.AddressId);
                command.Parameters.AddWithValue("@TotalOrder", oborder.TotalOrder);

                              command.Parameters.AddWithValue("@OrDate", oborder.Orderdate);

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
        public int SaveCardDetail(Orders oborder)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpAddCartDetail", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@UserId", oborder.UserId);
                command.Parameters.AddWithValue("@CvcNo", oborder.CvcNo);
                command.Parameters.AddWithValue("@CreditNo", oborder.CreditCardNo);
                command.Parameters.AddWithValue("@ExpiryDate", oborder.ExpityDate);

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
        public int MaxId()
        {
            
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetmaxOrdersId", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
             
                reader = command.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read()) // Read data from database
                    {
                        a = Convert.ToInt32(reader[0]);
                    }
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

            return a;
        }

        public List<Orders> GetAllOrder()
        {
            List<Orders> orderlist = new List<Orders>();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetAllOrder", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                reader = command.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read()) // Read data from database
                    {
                        var order = new Orders();

                        if (!DBNull.Value.Equals(reader["Id"]))
                            order.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["UserId"]))
                            order.UserId = Convert.ToInt32(reader["UserId"]);

                        if (!DBNull.Value.Equals(reader["Name"]))
                            order.UserName = Convert.ToString(reader["Name"]);

                        if (!DBNull.Value.Equals(reader["TotalOrder"]))
                            order.TotalOrder = Convert.ToInt32(reader["TotalOrder"]);
                      
                        if (!DBNull.Value.Equals(reader["OrDate"]))
                            order.Orderdate = Convert.ToDateTime(reader["OrDate"]);



                        orderlist.Add(order);
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

            return orderlist;


        }
        public int GetOrderId(int pid,int uid)
        {
           

            try
            {
                connection.Open();
                command = new SqlCommand("stpGetOrderId", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
             
                command.Parameters.AddWithValue("@ProductId", pid);
                command.Parameters.AddWithValue("@UserId", uid);
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    while(reader.Read())
                    {
                        OrderId = Convert.ToInt32(reader[0]);
                    }
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

            return OrderId;


        }
        public int DeleteOrderCart(int orderId)
        {
            int returnVariable = 0;
           
            try
            {
                connection.Open();
                command = new SqlCommand("stpDeleteOrderCart", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
             
                command.Parameters.AddWithValue("@Id", orderId);

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
