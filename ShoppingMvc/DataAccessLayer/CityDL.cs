using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ShoppingMvc.Areas.User.Models;
using System.Data.SqlClient;
using System.Data;
using ShoppingMvc.Models;

namespace DataAccessLayer
{
  public class CityDL:DBHelper
    {
        public List<City> GetCityByStateId(int Id)
        {
            List<City> citylist = new List<City>();
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("stpGetCityByStateId", connection)
                    {
                        CommandType=CommandType.StoredProcedure 
                    };
                    command.Parameters.AddWithValue("@StateId", Id);
                    reader = command.ExecuteReader();
                    if(reader!=null)
                    {
                        while(reader.Read())
                        {
                            var city = new City();
                            if (!DBNull.Value.Equals(reader["Id"]))
                                city.Id = Convert.ToInt32(reader["Id"]);

                            if (!DBNull.Value.Equals(reader["CityName"]))
                                city.CityName = Convert.ToString(reader["CityName"]);

                           
                            citylist.Add(city);
                        }
                    }
                }
                catch
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
            }
            return citylist;
        }
        public List<City> GetAllCity()
        {
            List<City> citylist = new List<City>();
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("stpGetAllCity", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                 
                    reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            var city = new City();
                            if (!DBNull.Value.Equals(reader["Id"]))
                                city.Id = Convert.ToInt32(reader["Id"]);

                            if (!DBNull.Value.Equals(reader["StateId"]))
                                city.StateId = Convert.ToInt32(reader["StateId"]);

                            if (!DBNull.Value.Equals(reader["CityName"]))
                                city.CityName = Convert.ToString(reader["CityName"]);


                            citylist.Add(city);
                        }
                    }
                }
                catch
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
            }
            return citylist;
        }

        public int DeleteCity(City obcity)
        {
            int returnVariable = 0;
            var user = new User();
            try
            {
                connection.Open();
                command = new SqlCommand("stpDeletecity", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", obcity.Id);

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
        public int SaveCity(City obcity)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpAddCity", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Name", obcity.CityName);
                command.Parameters.AddWithValue("@StateId", obcity.StateId);

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

        public int UpdateCity(City city)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpUpdateCity", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", city.Id);
                command.Parameters.AddWithValue("@StateId", city.StateId);
                command.Parameters.AddWithValue("@CityName", city.CityName);


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

        public City GetCityById(int Id)
        {
            var city = new City();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetCityById", connection)
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
                            city.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["StateId"]))
                            city.StateId = Convert.ToInt32(reader["StateId"]);

                        if (!DBNull.Value.Equals(reader["CityName"]))
                            city.CityName = Convert.ToString(reader["CityName"]);

                        //if (!DBNull.Value.Equals(reader["StateName"]))
                        //    state.StateName = Convert.ToString(reader["StateName"]);
                    }

                    return city;


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

            return city;


        }
    }
}
