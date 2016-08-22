using System;
using System.Collections.Generic;
using System.Data;
using ShoppingMvc.Models;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class StateDL:DBHelper
    {

        public List<State> GetAllState()
        {
            List<State> stateList = new List<State>();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetAllState", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                reader = command.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read()) // Read data from database
                    {
                        var state = new State();
                        if (!DBNull.Value.Equals(reader["Id"]))
                            state.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["StateName"]))
                            state.StateName = Convert.ToString(reader["StateName"]);

                        if (!DBNull.Value.Equals(reader["CountryId"]))
                            state.CountryId = Convert.ToInt32(reader["CountryId"]);


                        stateList.Add(state);
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

            return stateList;
        

        }

        public List<State> GetStateByCountryId(int Id)
        {            
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetStateByCountryId", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@CountryId", Id);
                reader = command.ExecuteReader();

                List<State> stateList;

                if (reader != null)
                {
                    stateList = new List<State>();
                    while (reader.Read()) // Read data from database
                    {
                        var state = new State();

                        if (!DBNull.Value.Equals(reader["Id"]))
                            state.Id = Convert.ToInt32(reader["Id"]);

                       
                        if (!DBNull.Value.Equals(reader["StateName"]))
                            state.StateName = Convert.ToString(reader["StateName"]);

                        stateList.Add(state);
                    }

                    return stateList;
                   
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

        public int DeleteState(State obstate)
        {
            int returnVariable = 0;
            var user = new User();
            try
            {
                connection.Open();
                command = new SqlCommand("stpDeleteState", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", obstate.Id);

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
        public State GetStateById(int Id)
        {
            var state = new State();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetStateById", connection)
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
                            state.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["CountryId"]))
                            state.CountryId = Convert.ToInt32(reader["CountryId"]);

                        if (!DBNull.Value.Equals(reader["CountryName"]))
                            state.CountryName = Convert.ToString(reader["CountryName"]);

                        if (!DBNull.Value.Equals(reader["StateName"]))
                            state.StateName = Convert.ToString(reader["StateName"]);
                    }

                    return state;


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

            return state;


        }
        public int SaveState(State obstate)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpAddState", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@StateName", obstate.StateName);
                command.Parameters.AddWithValue("@CountryId", obstate.CountryId);

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
        public int UpdateState(State state)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpUpdateState", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", state.Id);
                command.Parameters.AddWithValue("@CountryId", state.CountryId);
                command.Parameters.AddWithValue("@StateName", state.StateName);


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
