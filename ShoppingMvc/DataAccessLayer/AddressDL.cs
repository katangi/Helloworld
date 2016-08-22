using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ShoppingMvc.Models;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
   public class AddressDL:DBHelper
    {
        public int SaveAddress(Address obAddress)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpAddAddress", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@UserId", obAddress.UserId);
                command.Parameters.AddWithValue("@PinCode", obAddress.Pin);
                command.Parameters.AddWithValue("@UserAddress", obAddress.userAddress);
                command.Parameters.AddWithValue("@AddressType", obAddress.Addresstype);
               

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
        public List<Address> GetAllAddress()
        {
            List<Address> addressList = new List<Address>();
            try
            {
                connection.Open();
                command = new SqlCommand("stpGetAllAddress", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                reader = command.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read()) // Read data from database
                    {
                        var address = new Address();

                        if (!DBNull.Value.Equals(reader["Id"]))
                            address.Id = Convert.ToInt32(reader["Id"]);
                                              

                        if (!DBNull.Value.Equals(reader["Name"]))
                            address.UserName = Convert.ToString(reader["Name"]);

                        if (!DBNull.Value.Equals(reader["CityName"]))
                            address.City = Convert.ToString(reader["CityName"]);

                        if (!DBNull.Value.Equals(reader["StateName"]))
                            address.State = Convert.ToString(reader["StateName"]);

                        if (!DBNull.Value.Equals(reader["CountryName"]))
                            address.Country = Convert.ToString(reader["CountryName"]);

                        if (!DBNull.Value.Equals(reader["UserAddress"]))
                            address.userAddress= Convert.ToString(reader["UserAddress"]);

                        if (!DBNull.Value.Equals(reader["AddressType"]))
                            address.Addresstype = Convert.ToString(reader["AddressType"]);

                        addressList.Add(address);
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

            return addressList;


        }
        public List<Address> GetAddressById(int Id)
        {
            List<Address> addressList = new List<Address>();

            try
            {
                connection.Open();
                command = new SqlCommand("stpGetAddressById", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@UserId", Id);
                reader = command.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read()) // Read data from database
                    {
                        var address = new Address();

                        if (!DBNull.Value.Equals(reader["Id"]))
                            address.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["CityName"]))
                            address.City = Convert.ToString(reader["CityName"]);

                        if (!DBNull.Value.Equals(reader["CountryName"]))
                            address.Country = Convert.ToString(reader["CountryName"]);

                        if (!DBNull.Value.Equals(reader["StateName"]))
                            address.State = Convert.ToString(reader["StateName"]);

                        if (!DBNull.Value.Equals(reader["PinCode"]))
                            address.Pin = Convert.ToInt32(reader["PinCode"]);


                        if (!DBNull.Value.Equals(reader["UserAddress"]))
                            address.userAddress = Convert.ToString(reader["UserAddress"]);

                        if (!DBNull.Value.Equals(reader["AddressType"]))
                            address.Addresstype = Convert.ToString(reader["AddressType"]);

                        addressList.Add(address);

                    }

                    return addressList;


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

            return addressList;


        }
        public Address BindAddressById(int Id)
        {
            var address = new Address();

            try
            {
                connection.Open();
                command = new SqlCommand("stpGetEditAddressById", connection)
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
                            address.Id = Convert.ToInt32(reader["Id"]);

                        if (!DBNull.Value.Equals(reader["PinCode"]))
                            address.Pin = Convert.ToInt32(reader["PinCode"]);

                        if (!DBNull.Value.Equals(reader["UserAddress"]))
                            address.userAddress = Convert.ToString(reader["UserAddress"]);

                        if (!DBNull.Value.Equals(reader["AddressType"]))
                            address.Addresstype = Convert.ToString(reader["AddressType"]);
                      

                    }
                
                    return address;


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

            return address;


        }
        public int UpdateAddress(Address obaddress)
        {
            int returnVariable = 0;
            try
            {
                connection.Open();
                command = new SqlCommand("stpUpdateAddress", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 6000
                };
                command.Parameters.AddWithValue("@Id", obaddress.Id);
                command.Parameters.AddWithValue("@PinCode", obaddress.Pin);
                command.Parameters.AddWithValue("@UserAddress", obaddress.userAddress);
                command.Parameters.AddWithValue("@AddressType", obaddress.Addresstype);
              

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
