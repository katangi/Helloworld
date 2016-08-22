using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Data;
using ShoppingMvc.Models;

namespace DataAccessLayer
{
  public class CountryDL:DBHelper
    {
        public List<Country> GetAllCountry()
        {
            List<Country> countryList = new List<Country>();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetCountry", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                reader = command.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read()) // Read data from database
                    {
                        var country = new Country();
                        if (!DBNull.Value.Equals(reader["Id"]))
                            country.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["CountryName"]))
                            country.CountryName = Convert.ToString(reader["CountryName"]);

                        countryList.Add(country);
                    }
                    reader.Close();
                    connection.Close();
                   
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

            return countryList;


        }
        public int SaveCountry(Country obcountry)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpAddCountry", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@CountryName", obcountry.CountryName);
               

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
        public Country GetCountryById(int Id)
        {
            var country = new Country();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetCountryyById", connection)
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
                            country.Id = Convert.ToInt32(reader["Id"]);
                        if (!DBNull.Value.Equals(reader["CountryName"]))
                            country.CountryName = Convert.ToString(reader["CountryName"]);

                       }

                    return country;


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

            return country;


        }

        #region UpdateCountry
        public int DeleteCountry(Country obcountry)
        {
            int returnVariable = 0;
            var user = new User();
            try
            {
                connection.Open();
                command = new SqlCommand("stpDeleteCountry", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", obcountry.Id);
              
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
        public int UpdateCountry(Country country)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpUpdateCountry", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", country.Id);
                command.Parameters.AddWithValue("@CountryName", country.CountryName);
                

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

        #endregion UpdateCountry
    }
}
