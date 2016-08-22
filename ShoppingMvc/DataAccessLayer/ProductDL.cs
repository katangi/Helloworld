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
  public class ProductDL:DBHelper
    {
        public List<Product> GetAllProduct()
        {
            List<Product> productList = new List<Product>();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetAllProduct", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                reader = command.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read()) // Read data from database
                    {
                        var product = new Product();
                        if (!DBNull.Value.Equals(reader["Id"]))
                            product.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["Name"]))
                            product.Name = Convert.ToString(reader["Name"]);

                        if (!DBNull.Value.Equals(reader["CategoryName"]))
                            product.Categoryname = Convert.ToString(reader["CategoryName"]);

                        if (!DBNull.Value.Equals(reader["Description"]))
                            product.Desc = Convert.ToString(reader["Description"]);

                        if (!DBNull.Value.Equals(reader["Image"]))
                            product.Image = Convert.ToString(reader["Image"]);

                        if (!DBNull.Value.Equals(reader["Price"]))
                            product.price = Convert.ToDecimal(reader["Price"]);

                        if (!DBNull.Value.Equals(reader["Quantity"]))
                            product.Quantity = Convert.ToInt32(reader["Quantity"]);

                        productList.Add(product);
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

            return productList;


        }
        #region SaveProduct

        public int SaveProduct(Product obproduct)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpAddProduct", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Name", obproduct.Name);
                command.Parameters.AddWithValue("@Description", obproduct.Desc);
                command.Parameters.AddWithValue("@Image", obproduct.Image);
                command.Parameters.AddWithValue("@price", obproduct.price);
                command.Parameters.AddWithValue("@Quantity", obproduct.Quantity);
                command.Parameters.AddWithValue("@CategoryId", obproduct.categoryId);
               
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

        #endregion SaveProduct

        public Product GetProdyctById(int Id)
        {
            var product = new Product();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetProductById", connection)
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
                            product.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["CategoryId"]))
                            product.categoryId = Convert.ToInt32(reader["CategoryId"]);

                        if (!DBNull.Value.Equals(reader["Name"]))
                            product.Name = Convert.ToString(reader["Name"]);

                        if (!DBNull.Value.Equals(reader["Description"]))
                            product.Desc = Convert.ToString(reader["Description"]);

                        if (!DBNull.Value.Equals(reader["Image"]))
                            product.Image = Convert.ToString(reader["Image"]);

                        if (!DBNull.Value.Equals(reader["price"]))
                            product.price = Convert.ToDecimal(reader["price"]);

                        if (!DBNull.Value.Equals(reader["Quantity"]))
                            product.Quantity = Convert.ToInt32(reader["Quantity"]);
                    }

                    return product;


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

            return product;


        }
        public int DeleteProduct(Product obproduct)
        {
            int returnVariable = 0;
            var user = new User();
            try
            {
                connection.Open();
                command = new SqlCommand("stpDeleteproduct", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", obproduct.Id);
              
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
        public int UpdateProduct(Product product)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpUpdateProduct", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@CategoryId", product.categoryId);
                command.Parameters.AddWithValue("@Description", product.Desc);
               command.Parameters.AddWithValue("@image", product.Image);
                command.Parameters.AddWithValue("@price", product.price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                
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
