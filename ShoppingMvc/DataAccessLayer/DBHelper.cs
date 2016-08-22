using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataAccessLayer
{
  public  class DBHelper
    {
        SqlConnection _connection;
        public string connectionString { get; set; }
        public SqlConnection connection { get; set; }
        public SqlCommand command { get; set; }
        public SqlDataReader reader { get; set; }

        public DBHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ShoppingConnection"].ConnectionString;
            connection = dbConection;
            command = null;
            reader = null;
        }

        public SqlConnection dbConection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(connectionString);
                }
                return _connection;
            }
        }

        public void OpenConnection()
        {
            connection = connection;
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        public void CloseConnection()
        {
            CloseReader();
            if (connection != null)
            {
                connection.Close();
            }
        }

        public void CloseReader()
        {
            if (reader != null)
            {
                reader.Close();
            }
        }

    }
}
