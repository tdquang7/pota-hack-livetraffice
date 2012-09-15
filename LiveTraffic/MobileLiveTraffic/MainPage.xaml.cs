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

namespace MobileLiveTraffic
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            _lastMode = new AerialMode();
            _gpsWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            _gpsWatcher.MovementThreshold = 20;
            _gpsWatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(_gpsWatcher_PositionChanged);
            _gpsWatcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(_gpsWatcher_StatusChanged);
            _gpsWatcher.Start();

            ApplicationBarMenuItem login = ((ApplicationBarMenuItem)(ApplicationBar.MenuItems[3]));
            ApplicationBarMenuItem update = ((ApplicationBarMenuItem)(ApplicationBar.MenuItems[0]));
            ApplicationBarMenuItem updateuser = ((ApplicationBarMenuItem)(ApplicationBar.MenuItems[2]));

            if (((App)App.Current).Username != null)
            {
                login.IsEnabled = false;
                update.IsEnabled = true;
                updateuser.IsEnabled = true;
            }
            else
            {
                login.IsEnabled = true;
                update.IsEnabled = false;
                updateuser.IsEnabled = false;
            }
        }

        private MapMode _lastMode;
        private GeoCoordinateWatcher _gpsWatcher;

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

        void _gpsWatcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    MessageBox.Show("Location Service is not enabled on the device");
                    break;

                case GeoPositionStatus.NoData:
                    MessageBox.Show(" The Location Service is working, but it cannot get location data.");
                    break;
            }
        }

        void _gpsWatcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            map.Center = new GeoCoordinate(e.Position.Location.Latitude, e.Position.Location.Longitude);

            if (this.map.Children.Count != 0)
            {
                var pushpin = map.Children.FirstOrDefault(p => (p.GetType() == typeof(Pushpin) && ( (string) ((Pushpin)p).Tag) == "locationPushpin"));

                if (pushpin != null)
                {
                    this.map.Children.Remove(pushpin);
                }
            }

            Pushpin locationPushpin = new Pushpin();
            locationPushpin.Tag = "locationPushpin";
            locationPushpin.Location = _gpsWatcher.Position.Location;
            this.map.Children.Add(locationPushpin);
            this.map.SetView(_gpsWatcher.Position.Location, 15.0);
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
            _gpsWatcher.Start();
        }

    }
}