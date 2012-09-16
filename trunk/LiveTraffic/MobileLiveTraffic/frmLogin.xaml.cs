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

            txtNoMaskPass = new TextBox();
            txtNoMaskPass.TextChanged+=new TextChangedEventHandler(txtUsername_TextChanged);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LiveTrafficService.MobileServiceClient service = new LiveTrafficService.MobileServiceClient();
            service.LoginAsync(txtUsername.Text, txtPassword.Password);
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
            if (txtUsername.Text != "")
            {
                if (pnlPasswordContainer.Children[0] is PasswordBox && txtPassword.Password != "")
                {
                    btnLogin.IsEnabled = true;
                    return;
                }
                else if (pnlPasswordContainer.Children[0] is TextBox && txtNoMaskPass.Text != "")
                {
                    btnLogin.IsEnabled = true;
                    return;
                }
            }

            btnLogin.IsEnabled = false;
        }

        private TextBox txtNoMaskPass = null;

        private void chkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = txtNoMaskPass.Text;
            txtPassword.Margin = txtNoMaskPass.Margin;

            pnlPasswordContainer.Children.Clear();
            pnlPasswordContainer.Children.Add(txtPassword);
        }

        private void chkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtNoMaskPass.Text = txtPassword.Password;
            txtNoMaskPass.Margin = txtPassword.Margin;

            pnlPasswordContainer.Children.Clear();
            pnlPasswordContainer.Children.Add(txtNoMaskPass);
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text != "")
            {
                if (pnlPasswordContainer.Children[0] is PasswordBox && txtPassword.Password != "")
                {
                    btnLogin.IsEnabled = true;
                    return;
                }
                else if (pnlPasswordContainer.Children[0] is TextBox && txtNoMaskPass.Text != "")
                {
                    btnLogin.IsEnabled = true;
                    return;
                }
            }

            btnLogin.IsEnabled = false;
        }

    }
}