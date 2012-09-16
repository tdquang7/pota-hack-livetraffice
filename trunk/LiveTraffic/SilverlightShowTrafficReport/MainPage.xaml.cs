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
using Microsoft.Maps.MapControl;

namespace SilverlightShowTrafficReport
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            MyMap.Center = new Location(10.8594589233398, 106.790100097656);
            
            MyMap.ZoomLevel = 14;            
        }

        private void hbtnCheckTrafficStatus_Click(object sender, RoutedEventArgs e)
        {
            string address = txtAddress.Text;

            ServiceReference1.MobileServiceClient client = new ServiceReference1.MobileServiceClient();
            client.GetTrafficFromAdrressAsync(address);
            client.GetTrafficFromAdrressCompleted += new EventHandler<ServiceReference1.GetTrafficFromAdrressCompletedEventArgs>(client_GetTrafficFromAdrressCompleted);
        }

        void client_GetTrafficFromAdrressCompleted(object sender, ServiceReference1.GetTrafficFromAdrressCompletedEventArgs e)
        {
            for (int i = 0; i < e.Result.Count; i++)
            {
                string coordinate = e.Result[i];

                string latitude;
                string longitude;

                Split(coordinate, out latitude, out longitude);

                Location location = new Location(double.Parse(latitude), double.Parse(longitude));

                if (i==0) MyMap.Center = location;

                Pushpin pin = new Pushpin();
                pin.Location = location;

                MyMap.Children.Add(pin);

            }
        }

        void Split(string coordinate, out string latitude, out string longitude)
        {
            string SEPERATOR = ",";

            string[] parts = coordinate.Split(new string[] { SEPERATOR }, StringSplitOptions.None);

            latitude = parts[0];
            longitude = parts[1];
        }
    }
}
