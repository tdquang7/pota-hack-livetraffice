using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MobileLiveTraffic.Utility
{
    public class SearchCriteria
    {
        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string district;

        public string District
        {
            get { return district; }
            set { district = value; }
        }
        private string street;

        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        private string mode;

        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }
    }
}
