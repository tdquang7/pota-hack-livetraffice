using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Entity
{
    public class TrafficReport: DataProvider
    {
        public List<string> GetStreetStatus(string country, string city, string district, string street, double latitude, double longitude, string mode)
        {
            const int LATEST_HOUR = 3;
            const string SEPERATOR = ",";

            List<string> list = new List<string>();

            DateTime currentTime = DateTime.Now; // Time of querying
            DateTime startTime = currentTime.AddHours(-LATEST_HOUR); // One hour a go


            if (_connect())
            {
                string sql = "select Latitude, Longtitude from TrafficReport where street=@Street and ReportTime beetween @StartTime and @CurrentTime";

                SqlCommand cmd = new SqlCommand(sql, _con);
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
