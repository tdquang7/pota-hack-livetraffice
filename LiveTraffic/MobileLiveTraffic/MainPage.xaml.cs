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

namespace MobileLiveTraffic
{
    public partial class MainPage : PhoneApplicationPage
    {
        

        // Constructor
        public MainPage()
        {
            InitializeComponent();

           // LoadApplicationBarImages();
        }

        private double _zoom;

        public double Zoom
        {
            get { return _zoom; }
            set
            {
                //var coercedZoom = Math.Max(MinZoomLevel, Math.Min(MaxZoomLevel, value));
                //if (_zoom != coercedZoom)
                //{
                //    _zoom = value;
                //}
            }
        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/frmSearch.xaml", UriKind.Relative));
        }

        private void Update_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/frmUpdate.xaml", UriKind.Relative));
        }

        private void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/frmAbout.xaml", UriKind.Relative));
        }

        private void Login_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/frmLogin.xaml", UriKind.Relative));
        }

        
    }
}