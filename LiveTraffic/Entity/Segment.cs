using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Entity
{
    public class Segment: DataProvider
    {
        public int SegmentID { get; set; }
        public int StartCrossRoadID { get; set; }
        public int EndCrossRoadID { get; set; }
        public string LatitudeList { get; set; }
        public string LongtitudeList { get; set; }

        public Segment()
        {
        }

        public bool Insert()
        {
            if (connect())
            {
                string sql = "insert into Segment values(@SegmentID, @StartCrossRoadID, @EndCrossRoadID, @LatitudeList, @LongtitudeList)";

                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add(new SqlParameter("@SegmentID", System.Data.SqlDbType.Int)).Value = SegmentID;
                cmd.Parameters.Add(new SqlParameter("@StartCrossRoadID", System.Data.SqlDbType.Int)).Value = StartCrossRoadID;
                cmd.Parameters.Add(new SqlParameter("@EndCrossRoadID", System.Data.SqlDbType.Int)).Value = EndCrossRoadID;
                cmd.Parameters.Add(new SqlParameter("@LatitudeList", System.Data.SqlDbType.NText)).Value = LatitudeList;
                cmd.Parameters.Add(new SqlParameter("@LongtitudeList", System.Data.SqlDbType.NText)).Value = LongtitudeList;

                bool result = cmd.ExecuteNonQuery() > 0;

                return result;
            }
            else
            {
                throw new Exception("Cannot connect to database");
            }

            return false;
        }
    }
}