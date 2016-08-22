using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ShoppingMvc.Models;

namespace DataAccessLayer
{
  public  class CategoryDL:DBHelper
    {
        public int SaveCategory(Catogery obcategory)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpAddCategory", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@CategoryName", obcategory.CategoryName);
                command.Parameters.AddWithValue("@Description", obcategory.Description);

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

        public List<Catogery> GetAllCategory()
        {
            List<Catogery> categoryList = new List<Catogery>();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetAllCategory", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                reader = command.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read()) // Read data from database
                    {

                        var category = new Catogery();

                        if (!DBNull.Value.Equals(reader["Id"]))
                            category.Id= Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["CategoryName"]))
                            category.CategoryName = Convert.ToString(reader["CategoryName"]);

                        if (!DBNull.Value.Equals(reader["Description"]))
                            category.Description= Convert.ToString(reader["Description"]);


                        categoryList.Add(category);
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

            return categoryList;


        }

        public Catogery GetCategoryById(int Id)
        {
            var category = new Catogery();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetCategoryById", connection)
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
                            category.Id = Convert.ToInt32(reader["Id"]); 

                        if (!DBNull.Value.Equals(reader["CategoryName"]))
                            category.CategoryName = Convert.ToString(reader["CategoryName"]);

                        if (!DBNull.Value.Equals(reader["Description"]))
                            category.Description = Convert.ToString(reader["Description"]);

                    }

                    return category;


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

            return category;


        }

        #region UpdateCategory

        public int UpdateCategory(Catogery category)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpUpdateCategory", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", category.Id);
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.Parameters.AddWithValue("@Description", category.Description);
               
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

        #endregion UpdateCategory
    }
}
