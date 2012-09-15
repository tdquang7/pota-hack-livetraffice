using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Entity
{
    public class DataProvider
    {
        static string _connectionString = "";
        protected SqlConnection _con;

        protected bool _connect()
        {
            _con = new SqlConnection(_connectionString);

            try
            {
                _con.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
