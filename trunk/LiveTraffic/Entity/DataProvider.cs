using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Entity
{
    public class DataProvider
    {
        static string _connectionString = "workstation id=LiveTraffic.mssql.somee.com;packet size=4096;user id=hatu;pwd=iloveyou;data source=LiveTraffic.mssql.somee.com;persist security info=False;initial catalog=LiveTraffic";
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
