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
using System.Collections.ObjectModel;
using MobileLiveTraffic.Models;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;
using MobileLiveTraffic.Converters;

namespace RnD
{
    public partial class TestPushPin : PhoneApplicationPage
    {
        private static GeoCoordinate DefaultLocation = new GeoCoordinate(47.639631, -122.127713);
        private static double DefaultZoom = 18;
        private GeoCoordinate _userLocation;

        public GeoCoordinate UserLocation
        {
            get { return _userLocation; }
            set { _userLocation = value; }
        }

        private PushpinCatalog _catalog = new PushpinCatalog();
        public TestPushPin()
        {
            InitializeComponent();

            MoveTo(GetUserLocation(), DefaultZoom);
            CreateNewPushpin(_catalog.GetPrototype("PushpinBicycle"), _userLocation);
        }

        private void MoveTo(GeoCoordinate location, double zoom)
        {
            map.Center = location;
            map.ZoomLevel = zoom;
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

        private void CreateNewPushpin(PushpinModel prototype, GeoCoordinate location)
        {
            Pushpin pin = new Pushpin();
            pin.Location = location;
            pin.Style = (Style)(Application.Current.Resources["PushpinStyle"]);
            pin.Background = (Brush)(Application.Current.Resources[string.Format("{0}Brush", prototype.TypeName)]);
            map.Children.Add(pin);
        }

    }
}