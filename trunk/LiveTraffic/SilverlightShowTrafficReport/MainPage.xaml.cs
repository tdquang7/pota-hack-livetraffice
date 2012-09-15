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

            Pushpin pin = new Pushpin();
            pin.Location = new Location(10.8594589233398, 106.790100097656);

            MyMap.Children.Add(pin);
        }
    }
}
