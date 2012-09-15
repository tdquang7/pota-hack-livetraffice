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
            LiveTrafficeService.MobileServiceClient service = new LiveTrafficeService.MobileServiceClient();
            service.LoginAsync(txtUsername.Text, txtPassword.Text);
            service.LoginCompleted += new EventHandler<LiveTrafficeService.LoginCompletedEventArgs>(service_LoginCompleted);
        }

        void service_LoginCompleted(object sender, LiveTrafficeService.LoginCompletedEventArgs e)
        {
            
        }

        
    }
}