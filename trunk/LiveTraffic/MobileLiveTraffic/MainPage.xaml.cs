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
using Microsoft.Phone.Shell;
using Microsoft.Phone.Controls.Maps.Core;
using System.Device.Location;
using MobileLiveTraffic.Utility;
using MobileLiveTraffic.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using MobileLiveTraffic.Converters;

namespace MobileLiveTraffic
{
    public partial class MainPage : PhoneApplicationPage
    {
        #region Constants
        private static GeoCoordinate DefaultLocation = new GeoCoordinate(47.639631, -122.127713);
        private static double DefaultZoom = 18;
        #endregion

        #region ApplicationBars
        ApplicationBarMenuItem lastLogin = null;

        ApplicationBarMenuItem login = null;
        ApplicationBarMenuItem logoff = null;
        ApplicationBarMenuItem update = null;
        ApplicationBarMenuItem updateuser = null;
        #endregion

        private PushpinCatalog _catalog = new PushpinCatalog();
        private Pushpin _userPushPin = null;
        private GeoCoordinate _userLocation;

        public GeoCoordinate UserLocation
        {
            get { return _userLocation; }
            set { _userLocation = value; }
        }

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            lastLogin = new ApplicationBarMenuItem("Log out");
            lastLogin.Click += new EventHandler(logoff_Click);

            _lastMode = new AerialMode();

            MoveTo(GetUserLocation(), DefaultZoom);
            CreateUserPushPin();
            

            update = ((ApplicationBarMenuItem)(ApplicationBar.MenuItems[0]));
            updateuser = ((ApplicationBarMenuItem)(ApplicationBar.MenuItems[2]));

            if (((App)App.Current).Username != null)
            {
                SwapLogin();
                update.IsEnabled = true;
                updateuser.IsEnabled = true;
            }
            else
            {
                update.IsEnabled = false;
                updateuser.IsEnabled = false;
            }

            Search(((App)App.Current).SearchInfo);
        }

        private void CreateUserPushPin()
        {
            if (_userPushPin == null)
                _userPushPin = CreateNewPushpin(_catalog.GetPrototype("PushpinLocation"), _userLocation);
            else
            {
                _userPushPin.Location = GetUserLocation();
                map.Children.Add(_userPushPin);
            }
        }

        private void CreateTrafficPushPin(GeoCoordinate location)
        {
            CreateNewPushpin(_catalog.GetPrototype("PushpinFuel"), location);
        }

        private void SwapLogin()
        {
            ApplicationBarMenuItem temp = (ApplicationBarMenuItem)ApplicationBar.MenuItems[ApplicationBar.MenuItems.Count - 1];
            ApplicationBar.MenuItems[ApplicationBar.MenuItems.Count - 1] = lastLogin;
            lastLogin = temp;
        }

        private GeoCoordinate GetUserLocation()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            watcher.Start();

            if (watcher.Status == GeoPositionStatus.Disabled)
            {
                MessageBox.Show("GPS is disable");
                watcher.Stop();
                _userLocation = null;
                return null;
            }

            watcher.Stop();
            _userLocation = watcher.Position.Location;
            return watcher.Position.Location;
        }

        private Pushpin CreateNewPushpin(PushpinModel prototype, GeoCoordinate location)
        {
            Pushpin pin = new Pushpin();
            pin.Location = location;
            pin.Style = (Style)(Application.Current.Resources["PushpinStyle"]);
            pin.Background = (Brush)(Application.Current.Resources[string.Format("{0}Brush", prototype.TypeName)]);
            map.Children.Add(pin);

            return pin;
        }

        #region event handlers
        private void logoff_Click(object sender, EventArgs e)
        {
            ((App)App.Current).Username = null;
            SwapLogin();
            update.IsEnabled = false;
            updateuser.IsEnabled = false;
        }
        #endregion

        

        private void Search(SearchCriteria searchInfo)
        {
            if (searchInfo != null)
            {
                LiveTrafficService.MobileServiceClient service = new LiveTrafficService.MobileServiceClient();
                service.GetStreetStatusAsync(searchInfo.Country, searchInfo.City, searchInfo.District, searchInfo.Street, searchInfo.Latitude, searchInfo.Longitude, searchInfo.Mode);
                service.GetStreetStatusCompleted += new EventHandler<LiveTrafficService.GetStreetStatusCompletedEventArgs>(service_GetStreetStatusCompleted);
            }
        }

        void service_GetStreetStatusCompleted(object sender, LiveTrafficService.GetStreetStatusCompletedEventArgs e)
        {
            string[] split = null;
            double lat, log;
            Pushpin pin = null;

            map.Children.Clear();

            foreach (string location in e.Result)
            {
                split = location.Split(',');
                lat = double.Parse(split[0]);
                log = double.Parse(split[1]);

                CreateTrafficPushPin(new GeoCoordinate(double.Parse(split[0]), double.Parse(split[1])));
            }

            CreateUserPushPin();
        }

        private void MoveTo(GeoCoordinate location, double zoom)
        {
            map.Center = location;
            map.ZoomLevel = zoom;
        }


        private MapMode _lastMode;

        private void btnUpdateTraffic_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/frmUpdate.xaml", UriKind.Relative));
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/frmAbout.xaml", UriKind.Relative));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/frmLogin.xaml", UriKind.Relative));
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/frmUpdateUserInfo.xaml", UriKind.Relative));
        }


        private void btnMode_Click(object sender, EventArgs e)
        {
            MapMode temp = _lastMode;
            _lastMode=map.Mode;
            map.Mode= temp;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/frmSearch.xaml", UriKind.Relative));
        }

        private void btnYourLocation_Click(object sender, EventArgs e)
        {
            MoveTo(GetUserLocation(), DefaultZoom);
        }

    }
}