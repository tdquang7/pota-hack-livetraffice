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
using MobileLiveTraffic.Utility;

namespace MobileLiveTraffic
{
    public partial class frmSearch : PhoneApplicationPage
    {
        public frmSearch()
        {
            InitializeComponent();
            //((App)App.Current).SearchInfo = null;
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
                searchInfo.Latitude = point.Latitude;
                searchInfo.Longitude = point.Longitude;

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
            searchInfo.Street = split[0].Trim();
            searchInfo.Country = split[split.Length - 1].Trim();

            if (split.Length == 3)
            {
                searchInfo.City = split[1].Trim();
                searchInfo.District = "";
            }
            else
            {
                searchInfo.City = split[2].Trim();
                searchInfo.District = split[1].Trim();
            }


            lbCountry.Items.Add(searchInfo.Country);
            lbCountry.SelectedIndex = 0;
            lbCity.Items.Add(searchInfo.City);
            lbCity.SelectedIndex = 0;
            lbDistrict.Items.Add(searchInfo.District);
            lbDistrict.SelectedIndex = 0;
            lbStreet.Items.Add(searchInfo.Street);
            lbStreet.SelectedIndex = 0;
        }

        private SearchCriteria searchInfo = new SearchCriteria();

        private void btnNear_Click(object sender, RoutedEventArgs e)
        {
            searchInfo.Mode = "near";
            ((App)App.Current).SearchInfo = searchInfo;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnSame_Click(object sender, RoutedEventArgs e)
        {
            searchInfo.Mode = "same";
            ((App)App.Current).SearchInfo = searchInfo;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}