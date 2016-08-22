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
   public class UserDL:DBHelper
    {
        #region SaveUser

        public int SaveUser(User obuser)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpAddUser", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Name", obuser.UserName);
                command.Parameters.AddWithValue("@Email", obuser.Email);
                command.Parameters.AddWithValue("@Password",obuser.Password);
                command.Parameters.AddWithValue("@CityId",obuser.CityId);
                command.Parameters.AddWithValue("@PhoneNo", obuser.PhoneNo);
                command.Parameters.AddWithValue("@StateId", obuser.StateId);
                command.Parameters.AddWithValue("@CountryId", obuser.CountryId);
            

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

        #endregion SaveUser

        public List<User> GetAllUser()
        {
            List<User> userList = new List<User>();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetAllUsers", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                reader = command.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read()) // Read data from database
                    {
                        var user = new User();
                        if (!DBNull.Value.Equals(reader["Id"]))
                            user.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["Name"]))
                            user.UserName = Convert.ToString(reader["Name"]);

                        if (!DBNull.Value.Equals(reader["Email"]))
                            user.Email = Convert.ToString(reader["Email"]);

                       
                        if (!DBNull.Value.Equals(reader["CityName"]))
                            user.CityName = Convert.ToString(reader["CityName"]);

                        if (!DBNull.Value.Equals(reader["StateName"]))
                            user.StateName = Convert.ToString(reader["StateName"]);

                        if (!DBNull.Value.Equals(reader["CountryName"]))
                            user.CountryName = Convert.ToString(reader["CountryName"]);

                        if (!DBNull.Value.Equals(reader["PhoneNo"]))
                            user.PhoneNo = Convert.ToString(reader["PhoneNo"]);
                        userList.Add(user);
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

            return userList;


        }

        public DataTable GetLoginDetail(UserLogin user)
        {
            DataTable dtUser = null;
            try
            {
                connection.Open();
                command = new SqlCommand("stpUserLogin", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };

                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtUser = new DataTable();
                    dtUser.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return dtUser;
        }

        public User GetUserById(int Id)
        {
            var user = new User();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetUserById", connection)
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
                            user.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["Name"]))
                            user.UserName = Convert.ToString(reader["Name"]);

                        if (!DBNull.Value.Equals(reader["Email"]))
                            user.Email = Convert.ToString(reader["Email"]);


                        if (!DBNull.Value.Equals(reader["CityId"]))
                            user.CityId = Convert.ToInt32(reader["CityId"]);

                        if (!DBNull.Value.Equals(reader["StateId"]))
                            user.StateId = Convert.ToInt32(reader["StateId"]);

                        if (!DBNull.Value.Equals(reader["CountryId"]))
                            user.CountryId = Convert.ToInt32(reader["CountryId"]);

                        if (!DBNull.Value.Equals(reader["PhoneNo"]))
                            user.PhoneNo = Convert.ToString(reader["PhoneNo"]);
                    }

                    return user;


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

            return user;


        }
        public User MyProfileById(int Id)
        {
            var user = new User();
            try
            {
                connection.Open();
                command = new SqlCommand("stpMyProfileById", connection)
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
                            user.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["Name"]))
                            user.UserName = Convert.ToString(reader["Name"]);

                        if (!DBNull.Value.Equals(reader["Email"]))
                            user.Email = Convert.ToString(reader["Email"]);


                        if (!DBNull.Value.Equals(reader["CityName"]))
                            user.CityName = Convert.ToString(reader["CityName"]);

                        if (!DBNull.Value.Equals(reader["StateName"]))
                            user.StateName = Convert.ToString(reader["StateName"]);

                        if (!DBNull.Value.Equals(reader["CountryName"]))
                            user.CountryName = Convert.ToString(reader["CountryName"]);

                        if (!DBNull.Value.Equals(reader["PhoneNo"]))
                            user.PhoneNo = Convert.ToString(reader["PhoneNo"]);
                    }

                    return user;


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

            return user;


        }

        public int DeleteUser(User obuser)
        {
            int returnVariable = 0;
            var user = new User();
            try
            {
                connection.Open();
                command = new SqlCommand("stpDeleteUser", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", obuser.Id);
                command.Parameters.AddWithValue("@IsActive", obuser.IsActive);
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
        
        public int UpdateUser(User user)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpUpdateUser", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Name", user.UserName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@CityId", user.CityId);
                command.Parameters.AddWithValue("@PhoneNo", user.PhoneNo);
                command.Parameters.AddWithValue("@StateId", user.StateId);
                command.Parameters.AddWithValue("@CountryId", user.CountryId);


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
