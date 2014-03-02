using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading.Tasks;
using Connect4Help.Managers;
using Connect4Help.C4H_Webservice;

namespace Connect4Help.Pages.Account
{
    public partial class SigningInPage : PhoneApplicationPage
    {
        private string username, password;

        public SigningInPage()  
        {
            InitializeComponent();
            initializeControls();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)                                    
        {
            base.OnNavigatedTo(e);

            this.username = String.Empty;
            this.password = String.Empty;
            NavigationContext.QueryString.TryGetValue("Username", out this.username);
            NavigationContext.QueryString.TryGetValue("Password", out this.password);

            SystemTray.ProgressIndicator.IsIndeterminate = true;
            SystemTray.ProgressIndicator.IsVisible = true;

            Service1Client client = new Service1Client();
            client.CheckUserAuthenticationCompleted += CheckAuthentication;
            client.CheckUserAuthenticationAsync(this.username, this.password);
        }
        private void CheckAuthentication(object sender, CheckUserAuthenticationCompletedEventArgs e)    
        {
            DonorProfile profile = e.Result;
            bool valid = profile != null;

            if (!valid)
                setupControls("Invalid username or password");
            else
            {
                SecurityManager.SetLocalAuthenticationInformation(profile);
                Home_Button_Click(null, null);
            }


            SystemTray.ProgressIndicator.IsIndeterminate = false;
            SystemTray.ProgressIndicator.IsVisible = false;
        }

        private void initializeControls()           
        {
            this.Sign_In_Button.Visibility = System.Windows.Visibility.Collapsed;
            this.Home_Button.Visibility = System.Windows.Visibility.Collapsed;
            this.Error_label.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void setupControls(string Message)  
        {
            this.Sign_In_Button.Visibility = System.Windows.Visibility.Visible;
            this.Home_Button.Visibility = System.Windows.Visibility.Visible;
            this.Error_label.Visibility = System.Windows.Visibility.Visible;
            this.Error_label.Text = Message;
        }

        private void Sign_In_Button_Click(object sender, RoutedEventArgs e) 
        {
            NavigationService.GoBack();
        }
        private void Home_Button_Click(object sender, RoutedEventArgs e)    
        {
            NavigationService.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.Relative));
        }


    }
}