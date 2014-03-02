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
using Connect4Help.Structure;

namespace Connect4Help.Pages.Search
{
    public partial class SearchResults : PhoneApplicationPage
    {
        public SearchResults()  
        {
            InitializeComponent();
            initializeControls();
        }

        private void initializeControls()   
        {
            this.Query_TextBlock.Text = "\"" + SearchManager.SearchQuery + "\"(" + SearchManager.SearchItems.Count().ToString("N0") + ")";
            this.items_listselector.ItemsSource = SearchManager.SearchItems;
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