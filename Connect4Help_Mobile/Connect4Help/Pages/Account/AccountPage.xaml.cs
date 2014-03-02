using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using Connect4Help.Managers;

namespace Connect4Help.Pages.Account
{
    public partial class AccountPage : PhoneApplicationPage
    {
        public AccountPage()    
        {
            InitializeComponent();
            initializeControls();
            initializeDesignControls();
        }

        private void initializeControls()   
        {
            if (!SecurityManager.CheckIfSignedIn())
            {
                SigninLayoutRoot.Visibility = System.Windows.Visibility.Visible;
                AccountLayoutRoot.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                SigninLayoutRoot.Visibility = System.Windows.Visibility.Collapsed;
                AccountLayoutRoot.Visibility = System.Windows.Visibility.Visible;
                Name_TextBlock.Text = SecurityManager.GetClientName();
            }
        }

        private void Sign_In_Button_Click(object sender, RoutedEventArgs e)     
        {
            string Username = this.Username_Tetxbox.Text;
            string Password = this.Password_Textbox.Text;

            NavigationService.Navigate(new Uri("/Pages/Account/SigningInPage.xaml?Username=" + Username + "&Password=" + Password, UriKind.Relative));
        }
        private void Sign_Out_Button_Click(object sender, RoutedEventArgs e)    
        {
            SecurityManager.Signout();
            NavigationService.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.Relative));
        }

        #region Design

        private void initializeDesignControls()   
        {
            Password_Password.Visibility = (bool)Show_Password_Checkbox.IsChecked ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
            Password_Textbox.Visibility = (bool)Show_Password_Checkbox.IsChecked ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        private void Username_Tetxbox_GotFocus(object sender, RoutedEventArgs e)        
        {
            Username_Tetxbox.Background = new SolidColorBrush(Colors.White);
            Username_Tetxbox.BorderBrush = new SolidColorBrush(Colors.Green);
        }
        private void Username_Tetxbox_LostFocus(object sender, RoutedEventArgs e)       
        {
            Username_Tetxbox.Background = new SolidColorBrush(GetColor("#BFF4F4F4"));
            Username_Tetxbox.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void Password_Tetxbox_GotFocus(object sender, RoutedEventArgs e)        
        {
            Password_Textbox.Background = new SolidColorBrush(Colors.White);
            Password_Textbox.BorderBrush = new SolidColorBrush(Colors.Green);
            Password_Password.Background = new SolidColorBrush(Colors.White);
            Password_Password.BorderBrush = new SolidColorBrush(Colors.Green);
        }
        private void Password_Tetxbox_LostFocus(object sender, RoutedEventArgs e)       
        {
            Password_Textbox.Background = new SolidColorBrush(GetColor("#BFF4F4F4"));
            Password_Textbox.BorderBrush = new SolidColorBrush(Colors.Black);
            Password_Password.Background = new SolidColorBrush(GetColor("#BFF4F4F4"));
            Password_Password.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void Show_Password_Checkbox_Checked(object sender, RoutedEventArgs e)   
        {
            initializeDesignControls();
        }

        private Color GetColor(string hexColor)   
        {
            byte alpha;
            byte pos = 0;

            string hex = hexColor.ToString().Replace("#", "");

            if (hex.Length == 8)
            {
                alpha = System.Convert.ToByte(hex.Substring(pos, 2), 16);
                pos = 2;
            }
            else
            {
                alpha = System.Convert.ToByte("ff", 16);
            }

            byte red = System.Convert.ToByte(hex.Substring(pos, 2), 16);

            pos += 2;
            byte green = System.Convert.ToByte(hex.Substring(pos, 2), 16);

            pos += 2;
            byte blue = System.Convert.ToByte(hex.Substring(pos, 2), 16);

            return Color.FromArgb(alpha, red, green, blue);
        }

        #endregion

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Account/SignUpPage.xaml", UriKind.Relative));

        }


    }
}