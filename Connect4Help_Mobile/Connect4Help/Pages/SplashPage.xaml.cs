using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading;
using Connect4Help.Managers;
using System.Threading.Tasks;

namespace Connect4Help.Pages
{
    public partial class SplashPage : PhoneApplicationPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Load locally saved authentication information if exists
            await SecurityManager.LoadLocalAuthenticaionInformation();
            await FollowedCharities.LoadLocalWatchlistInformation();

            //Wait 2 seconds then navigate to the home page
            Thread.Sleep(2000);
            NavigationService.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.Relative));
        }
    }
}