using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Crossroad
    {
        public int CrossRoadID { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public string SegmentList { get; set; }
    }
}
