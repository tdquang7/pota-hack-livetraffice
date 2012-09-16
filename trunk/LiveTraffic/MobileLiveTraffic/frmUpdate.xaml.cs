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

                //LoadNearbyAddress(new GeoCoordinate(point.Latitude, point.Longitude), 10);
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

            //List<string> districts = new List<string>();
            //districts.Add("Thu Duc");
            //districts.Add("Quận 9");
            //bool flag = true;

            //foreach (string temp in districts)
            //{
            //    flag = true;
            //    foreach (string d in lbDistrict.Items)
            //        if (d.Equals(temp))
            //        {
            //            flag = false;
            //            break;
            //        }

            //    if(flag)
            //        lbDistrict.Items.Add(temp);
            //}

            //List<string> streets = new List<string>();
            //streets.Add("ĐƯỜNG D1");
            //streets.Add("XA LỘ Hà Nội");

            //foreach (string temp in streets)
            //{
            //    flag = true;
            //    foreach (string d in lbStreet.Items)
            //        if (d.Equals(temp))
            //        {
            //            flag = false;
            //            break;
            //        }

            //    if(flag)
            //        lbStreet.Items.Add(temp);
            //}

            //lbDistrict.SelectedIndex = 0;
            //lbStreet.SelectedIndex = 0;
        }

        private void LoadNearbyAddress(GeoCoordinate location, double radious)
        {
            double d2r = Math.PI / 180;
            double increment = 90*d2r;
            const int EARTH_RADIUS = 6371; // km

            double rlat0, rlon0, rlat, rlon, lat, lon;
            rlat0 = location.Latitude*Math.PI/180;
            rlon0 = location.Longitude*Math.PI/180;

            double x0, y0, x, y, z;
            x0 = Math.Cos(rlat0) * Math.Cos(rlon0);
            y0 = Math.Cos(rlat0) * Math.Sin(rlon0);
            z = Math.Sin(rlat0);

            double hyp;

            string key = App.Id;
            GeocodeService1.ReverseGeocodeRequest reverseGeocodeRequest = new GeocodeService1.ReverseGeocodeRequest();
            GeocodeService1.GeocodeServiceClient geocodeService = new GeocodeService1.GeocodeServiceClient("BasicHttpBinding_IGeocodeService");
            // Set the credentials using a valid Bing Maps key
            reverseGeocodeRequest.Credentials = new Credentials();
            reverseGeocodeRequest.Credentials.ApplicationId = key;
            
            for (double alpha = 0; alpha < Math.PI; alpha = alpha + increment)
            {
                x = radious * Math.Sin(alpha) + x0;
                y = radious * Math.Cos(alpha) + y0;

                rlon = Math.Atan2(y, x);
                hyp = Math.Sqrt(x*x+y*y);
                rlat = Math.Atan2(z, hyp);

                lat = rlat * 180 / Math.PI;
                lon = rlon * 180 / Math.PI;

                GeocodeService1.UserLocation point = new GeocodeService1.UserLocation();
                point.Latitude = lat;
                point.Longitude = lon;
                latitude = point.Latitude;
                longitude = point.Longitude;

                reverseGeocodeRequest.Location = point;
                geocodeService.ReverseGeocodeAsync(reverseGeocodeRequest);
                geocodeService.ReverseGeocodeCompleted += new EventHandler<GeocodeService1.ReverseGeocodeCompletedEventArgs>(geocodeService_ReverseGeocodeCompleted);
            }

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