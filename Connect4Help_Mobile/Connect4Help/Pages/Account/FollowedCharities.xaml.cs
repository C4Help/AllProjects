using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Connect4Help.Managers;

namespace Connect4Help.Pages.Account
{
    public partial class FollowedCharities : PhoneApplicationPage
    {
        public FollowedCharities()
        {
            InitializeComponent();
            initializeControls();
        }

        private void initializeControls()   
        {
            this.items_listselector.ItemsSource = Managers.FollowedCharities.FollowedCharitiesList;
        }

        private void items_listselector_Tap(object sender, System.Windows.Input.GestureEventArgs e) 
        {
            C4H_Webservice.CharityProfile selectedItem = items_listselector.SelectedItem as C4H_Webservice.CharityProfile;
            if (selectedItem == null)
                return;

            SearchManager.curretnSearchItem = selectedItem;
            NavigationService.Navigate(new Uri("/Pages/Search/CharityProfilePage.xaml", UriKind.Relative));
        }
    }
}