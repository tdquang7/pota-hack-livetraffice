using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

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

        public void UpdateStreetStatus(string username, string country, string city, string district, string street, 
                                    double latitude, double longitude, string status)
        {
            if (_connect())
            {
                string sql = "insert into TrafficReport(Reporter, ReportTime, Latitude, Longtitude, Status, SegmentID, Country, City, District, Street) " + 
                    "values(@Reporter, @ReportTime, @Latitude, @Longtitude, @Status, @SegmentID, @Country, @City, @District, @Street)";

                SqlCommand cmd = new SqlCommand(sql, _con);
                cmd.Parameters.Add(new SqlParameter("@Reporter", SqlDbType.NVarChar)).Value = username;
                cmd.Parameters.Add(new SqlParameter("@ReportTime", SqlDbType.Date)).Value = DateTime.Now;
                cmd.Parameters.Add(new SqlParameter("@Latitude", SqlDbType.Real)).Value = longitude;
                cmd.Parameters.Add(new SqlParameter("@Longtitude", SqlDbType.Real)).Value = username;
                cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar)).Value = status;
                cmd.Parameters.Add(new SqlParameter("@SegmentID", SqlDbType.NVarChar)).Value = ""; // Temporary not used
                cmd.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar)).Value = country;
                cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar)).Value = city;
                cmd.Parameters.Add(new SqlParameter("@District", SqlDbType.NVarChar)).Value = district;
                cmd.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar)).Value = street;

                bool result = cmd.ExecuteNonQuery() > 0;
            }
            else{
                throw new Exception("Cannot connect to server");
            }
        }
    }
}
