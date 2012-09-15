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

namespace RnD
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DateTime d = DateTime.Now;
            DateTime b = d.AddHours(-1);
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ResultPage.xaml", UriKind.Relative));
        }
    }
}