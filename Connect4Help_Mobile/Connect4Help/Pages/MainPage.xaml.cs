using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Connect4Help.Resources;
using Connect4Help.Managers;

namespace Connect4Help.Pages
{
    public partial class MainPage : PhoneApplicationPage    
    {
        public MainPage()                                               
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)    
        {
            base.OnNavigatedTo(e);
            while (NavigationService.CanGoBack)
                NavigationService.RemoveBackEntry();

            initializeControls();
            initializeWelcomeMenu();
        }

        private void initializeControls()                                       
        {
            this.account_welcome_label.Content = SecurityManager.CheckIfSignedIn() ? "hello, " + SecurityManager.GetClientName() : "welcome. sign in";
        }
        private void Account_Button_Click(object sender, RoutedEventArgs e)     
        {
            NavigationService.Navigate(new Uri("/Pages/Account/AccountPage.xaml", UriKind.Relative));
        }
        private void Search_Button_GotFocus(object sender, RoutedEventArgs e)   
        {
            NavigationService.Navigate(new Uri("/Pages/Search/SearchPage.xaml", UriKind.Relative));
        }

        //Welcome
        private void initializeWelcomeMenu()                                                        
        {
            List<MenuListItem> menu = new List<MenuListItem>();
            menu.Add(new MenuListItem { ID = 1, Text = "followed charities " + (FollowedCharities.GetFollowedCharitiesCount() == 0 ? "" : "(" + FollowedCharities.GetFollowedCharitiesCount().ToString("N0") + ")"), Image = "/Assets/Menu/cart.png" });
            menu.Add(new MenuListItem { ID = 2, Text = "notifications", Image = "/Assets/Menu/notifications.png" });
            menu.Add(new MenuListItem { ID = 3, Text = "your account", Image = "/Assets/Menu/account.png" });

            this.menu_listselector.ItemsSource = menu;
        }
        private void menu_listselector_Tap(object sender, System.Windows.Input.GestureEventArgs e)  
        {
            MenuListItem selectedItem = this.menu_listselector.SelectedItem as MenuListItem;
            if (selectedItem == null)
                return;

            switch(selectedItem.ID)
            {
                case 1: //Cart
                    NavigationService.Navigate(new Uri("/Pages/Account/FollowedCharities.xaml", UriKind.Relative));
                    break;

                case 2: //Notifications
                    MessageBox.Show("Charities are still updating their information. This feature will be available soon and you will be notified based on the services you offered.");
                    break;
                case 3: //Your account
                    Account_Button_Click(null, null);
                    break;
            }
        }


    }

    public class MenuListItem   
    {
        public int ID { set; get; }
        public string Text { set; get; }
        public string Image { set; get; }
    }
}