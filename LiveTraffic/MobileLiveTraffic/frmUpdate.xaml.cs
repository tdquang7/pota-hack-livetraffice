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
                latitude = point.Latitude;
                longitude = point.Longitude;

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

            street = split[0].Trim();
            country = split[split.Length - 1].Trim();

            if (split.Length == 3)
            {
                city = split[1].Trim();
                district ="";
            }
            else
            {
                city = split[2].Trim();
                district = split[1].Trim();
            }


            lbCountry.Items.Add(country);
            lbCountry.SelectedIndex = 0;
            lbCity.Items.Add(city);
            lbCity.SelectedIndex = 0;
            lbDistrict.Items.Add(district);
            lbDistrict.SelectedIndex = 0;
            lbStreet.Items.Add(street);
            lbStreet.SelectedIndex = 0;
        }

        private string street;
        private string city;
        private string country;
        private string district;
        private double latitude;
        private double longitude;
        private void btnSlow_Click(object sender, RoutedEventArgs e)
        {
            string status = "slow";

            LiveTrafficService.MobileServiceClient service = new LiveTrafficService.MobileServiceClient();
            service.UpdateStreetStatusAsync(((App)App.Current).Username, lbCountry.SelectedItem.ToString(), lbCity.SelectedItem.ToString(), lbDistrict.SelectedItem.ToString(), lbStreet.SelectedItem.ToString(), latitude, longitude, status);
            service.UpdateStreetStatusCompleted += new EventHandler<LiveTrafficService.UpdateStreetStatusCompletedEventArgs>(service_UpdateStreetStatusCompleted);
        }

        void service_UpdateStreetStatusCompleted(object sender, LiveTrafficService.UpdateStreetStatusCompletedEventArgs e)
        {
            if (e.Result)
            {
                MessageBox.Show("Updating street status successfully");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Updating street status fail.");
            }
        }

        private void btnTrafficJam_Click(object sender, RoutedEventArgs e)
        {
            string status = "busy";

            LiveTrafficService.MobileServiceClient service = new LiveTrafficService.MobileServiceClient();
            service.UpdateStreetStatusAsync(((App)App.Current).Username, lbCountry.SelectedItem.ToString(), lbCity.SelectedItem.ToString(), lbDistrict.SelectedItem.ToString(), lbStreet.SelectedItem.ToString(), latitude, longitude, status);
            service.UpdateStreetStatusCompleted += new EventHandler<LiveTrafficService.UpdateStreetStatusCompletedEventArgs>(service_UpdateStreetStatusCompleted);
        }

        



    }
}