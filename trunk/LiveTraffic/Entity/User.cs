using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Entity
{
    public class User: DataProvider
    {
        public string Username;
        public string Password;

        public User()
        {
        }

        public bool Login(string username, string password)
        {
            if (_connect())
            {
                string sql = "select * from Users where Username = @Username and Password = @Password";

                SqlCommand cmd = new SqlCommand(sql, _con);
                cmd.Parameters.Add(new SqlParameter("@Username", System.Data.SqlDbType.NVarChar)).Value = username;
                cmd.Parameters.Add(new SqlParameter("@Password", System.Data.SqlDbType.NVarChar)).Value = password;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    return true;
                else
                    return false;
            }
            else
            {
                throw new Exception("Error connection server.");
            }

            return false;
        }
    }
}
