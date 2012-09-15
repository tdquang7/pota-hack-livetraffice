using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Entity
{
    public class TrafficReport: DataProvider
    {
        public void UpdateStreetStatus(string username, string country, string city, string district, string street,
                                    double latitude, double longitude, string status)
        {
            if (_connect())
            {
                string sql = "insert into TrafficReport(Reporter, ReportTime, Latitude, Longtitude, Status, SegmentID, Country, City, District, Street) " +
                    "values(@Reporter, @ReportTime, @Latitude, @Longtitude, @Status, @SegmentID, @Country, @City, @District, @Street)";

                SqlCommand cmd = new SqlCommand(sql, _con);
                cmd.Parameters.Add(new SqlParameter("@Reporter", SqlDbType.NVarChar)).Value = username;
                cmd.Parameters.Add(new SqlParameter("@ReportTime", SqlDbType.DateTime)).Value = DateTime.Now;
                cmd.Parameters.Add(new SqlParameter("@Latitude", SqlDbType.Float)).Value = latitude;
                cmd.Parameters.Add(new SqlParameter("@Longtitude", SqlDbType.Float)).Value = longitude;
                cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar)).Value = status;
                cmd.Parameters.Add(new SqlParameter("@SegmentID", SqlDbType.NVarChar)).Value = ""; // Temporary not used
                cmd.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar)).Value = country;
                cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar)).Value = city;
                cmd.Parameters.Add(new SqlParameter("@District", SqlDbType.NVarChar)).Value = district;
                cmd.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar)).Value = street;

                bool result = cmd.ExecuteNonQuery() > 0;
            }
            else
            {
                throw new Exception("Cannot connect to server");
            }
        }

        public List<string> GetStreetStatus(string country, string city, string district, string street, double latitude, double longitude, string mode)
        {
            const int LATEST_HOUR = 3;
            const string SEPERATOR = ",";

            List<string> list = new List<string>();

            DateTime currentTime = DateTime.Now; // Time of querying
            DateTime startTime = currentTime.AddHours(-LATEST_HOUR); // x hour a go


            if (_connect())
            {
                string sql = "select Latitude, Longtitude from TrafficReport where street=@Street and ReportTime between @StartTime and @EndTime";

                SqlCommand cmd = new SqlCommand(sql, _con);
                cmd.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar)).Value = street;
                cmd.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.DateTime)).Value = startTime;
                cmd.Parameters.Add(new SqlParameter("@EndTime", SqlDbType.DateTime)).Value = currentTime;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string lat = reader.GetDouble(0).ToString();
                    string lgn = reader.GetDouble(1).ToString();

                    list.Add(lat + SEPERATOR + lgn);
                }
            }
            else
            {
                throw new Exception("Cannot connect to server.");
            }

            return list;
        }
    }
}
