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
        public bool UpdateStreetStatus(string username, string country, string city, string district, string street,
                                    double latitude, double longitude, string status)
        {
            if (connect())
            {
                string sql = "insert into TrafficReport(Reporter, ReportTime, Latitude, Longtitude, Status, SegmentID, Country, City, District, Street) " +
                    "values(@Reporter, @ReportTime, @Latitude, @Longtitude, @Status, @SegmentID, @Country, @City, @District, @Street)";

                SqlCommand cmd = new SqlCommand(sql, _connection);
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
                return result;
            }
            else
            {
                //throw new Exception("Cannot connect to server");
                return false;
            }

            return false;
        }

        public List<string> GetStreetStatus(string country, string city, string district, string street, double latitude, double longitude, string mode)
        {
            const int LATEST_HOUR = 3;
            const string SEPERATOR = ",";

            List<string> list = new List<string>();

            DateTime currentTime = DateTime.Now; // Time of querying
            DateTime startTime = currentTime.AddHours(-LATEST_HOUR); // x hour a go


            if (connect())
            {
                string sql = "select Latitude, Longtitude from TrafficReport where street=@Street and ReportTime between @StartTime and @EndTime";

                SqlCommand cmd = new SqlCommand(sql, _connection);
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

        public void GenerateData()
        {
            double[] gpsLocations = new double[] { 10.85417,106.794252, 
                    10.854043,106.794037, 
                    10.854191,106.794402,
                    10.854191,106.794402,
                    10.851725,106.798178,
                    10.85143,106.798436};

            string connectionString = "workstation id=LiveTraffic.mssql.somee.com;packet size=4096;user id=hatu;pwd=iloveyou;data source=LiveTraffic.mssql.somee.com;persist security info=False;initial catalog=LiveTraffic";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Clear all previous data
            string sql = "delete from TrafficReport";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.ExecuteNonQuery();

            // Insert new data
            int count = gpsLocations.Length / 2; // Number of gps location pair of latitude and longitude
            string username = "Tester1";
            string status = "busy";
            string country = "Vietnam";
            string city = "Thành Phố Hồ Chí Minh";
            string district = "Quận 9";
            string street = "ĐƯỜNG D1";

            for (int i = 0; i < count; i++)
            {
                double latitude = gpsLocations[i * 2];
                double longitude = gpsLocations[i * 2 + 1];

                UpdateStreetStatus(username, country, city, district, street, latitude, longitude, "busy");
            }

            string[] data = new string[] { "10.856783", "106.784185", "Linh Trung", "Thu Duc",
                "10.856625", "106.784319", "Linh Trung", "Thu Duc",
                "10.856599", "106.784324", "Linh Trung", "Thu Duc",
                "10.859986", "106.789726", "Đường 17", "Thu Duc",
                "10.859954", "106.788899", "Đường 17", "Thu Duc",
                "10.859933", "106.788749", "Đường 17", "Thu Duc"};

            count = data.Length / 4;

            for (int i = 0; i < count; i++)
            {
                double latitude = double.Parse(data[i * 4]);
                double longitude = double.Parse(data[i * 4 + 1]);
                street = data[i * 4 + 2];
                district = data[i * 4 + 3];

                UpdateStreetStatus(username, country, city, district, street, latitude, longitude, "slow");
            }

            connection.Close();
        }

        // Finding gps locations of traffic jam near current location
        public List<string> GetNearbyTrafficJam(double latitude, double longitude, string city, string district, string street)
        {
            List<string> list = new List<string>();
            const string SEPERATOR = ",";
            const int MIN_RADIUS = 1; // Minimum radius to get in km
            const int EARTH_RADIUS = 6371; // km

            if (connect())
            {
                // Current problem is sometimes no gps district info, so this time only, based on city to group records
                string sql = "select Latitude, Longtitude from TrafficReport where city like @City and street not like @Street";

                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar)).Value = city;
                cmd.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar)).Value = street;

                // Convert to radian
                double d2r = Math.PI / 180;
                double oldLat = latitude;
                double oldLon = longitude;

                latitude *= d2r;
                longitude *= d2r;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double lat = reader.GetDouble(0) * d2r;
                    double lon = reader.GetDouble(1) * d2r;
                    
                    // Calculate radius from two gps locations 
                    double dlat = (latitude - lat); 
                    double dlon = (longitude - lon); 
                    double a = Math.Pow(Math.Sin(dlat / 2.0), 2) + Math.Cos(latitude) * Math.Cos(lat) * Math.Pow(Math.Sin(dlon / 2.0), 2);
                    double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                    double radius = EARTH_RADIUS * c;

                    if (radius <= MIN_RADIUS) // Inside wanted radius
                    {
                        list.Add(oldLat + SEPERATOR + oldLon);
                    }
                }

                reader.Close();
                _connection.Close();
            }
            else
            {
                throw new Exception("Cannot conenct to serrver");
            }

            
            return list;
        }

    }
}
