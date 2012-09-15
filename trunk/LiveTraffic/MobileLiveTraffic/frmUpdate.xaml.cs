using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;

namespace MobileLiveTraffic
{
    public partial class frmUpdate : PhoneApplicationPage
    {
        public frmUpdate()
        {
            InitializeComponent();

            MakeReverseGeocodeRequest();   
        }


        private void MakeReverseGeocodeRequest()
        {
            try
            {
                // Set a Bing Maps key before making a request
                string key = App.Id;

                GeocodeService1.ReverseGeocodeRequest reverseGeocodeRequest = new GeocodeService1.ReverseGeocodeRequest();

                // Set the credentials using a valid Bing Maps key
                reverseGeocodeRequest.Credentials = new Credentials();
                reverseGeocodeRequest.Credentials.ApplicationId = key;

                // Set the point to use to find a matching address
                GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                watcher.Start();
                GeocodeService1.UserLocation point = new GeocodeService1.UserLocation();
                point.Latitude = watcher.Position.Location.Latitude;
                point.Longitude = watcher.Position.Location.Longitude;
                watcher.Stop();
                reverseGeocodeRequest.Location = point;

                // Make the reverse geocode request
                GeocodeService1.GeocodeServiceClient geocodeService = new GeocodeService1.GeocodeServiceClient("BasicHttpBinding_IGeocodeService");
                geocodeService.ReverseGeocodeAsync(reverseGeocodeRequest);
                geocodeService.ReverseGeocodeCompleted += new EventHandler<GeocodeService1.ReverseGeocodeCompletedEventArgs>(geocodeService_ReverseGeocodeCompleted);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception occurred: " + ex.Message);
            }

        }

        void geocodeService_ReverseGeocodeCompleted(object sender, GeocodeService1.ReverseGeocodeCompletedEventArgs e)
        {
            string result = e.Result.Results[0].DisplayName;
            string[] split = result.Split(',');

            string street = split[0];
            string city = split[1];
            string country = split[2];

            lbCountry.Content = country;
            lbCity.Content = city;
            lbStreet.Content = street;
        }

        private void btnSlow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTrafficJam_Click(object sender, RoutedEventArgs e)
        {

        }

        



    }
}