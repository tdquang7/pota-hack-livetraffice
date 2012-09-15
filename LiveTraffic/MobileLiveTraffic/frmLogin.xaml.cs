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

namespace MobileLiveTraffic
{
    public partial class frmLogin : PhoneApplicationPage
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //if (txtUsername.Text=="123")
            //{
            //    ((App)App.Current).Username = txtUsername.Text;
            //    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            //}
            //else
            //    ((App)App.Current).Username = null;

            LiveTrafficService.MobileServiceClient service = new LiveTrafficService.MobileServiceClient();
            service.LoginAsync(txtUsername.Text, txtPassword.Text);
            service.LoginCompleted += new EventHandler<LiveTrafficService.LoginCompletedEventArgs>(service_LoginCompleted);
        }

        void service_LoginCompleted(object sender, LiveTrafficService.LoginCompletedEventArgs e)
        {
            bool result = e.Result;
            if (result == true)
            {
                ((App)App.Current).Username = txtUsername.Text;
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative)); 
            }
            else
                ((App)App.Current).Username = null;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).Username = null;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
                btnLogin.IsEnabled = true;
            else
                btnLogin.IsEnabled = false;
        }

        
    }
}