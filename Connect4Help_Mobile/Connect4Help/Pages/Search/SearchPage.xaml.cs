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
using Connect4Help.Structure;

namespace Connect4Help.Pages.Search
{
    public partial class SearchPage : PhoneApplicationPage
    {
        public SearchPage()                                                 
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)        
        {
            base.OnNavigatedTo(e);
            initializeSearchControls();
        }

        #region Search

        private void initializeSearchControls()                             
        {
            this.Search_Button.Visibility = System.Windows.Visibility.Visible;
            this.Search_Textbox.IsEnabled = true;
            this.Error_label.Visibility = System.Windows.Visibility.Collapsed;

            SystemTray.ProgressIndicator.IsIndeterminate = false;
            SystemTray.ProgressIndicator.IsVisible = false;
        }
        private void prepareSearchControls()                                
        {
            this.Search_Button.Visibility = System.Windows.Visibility.Collapsed;
            this.Search_Textbox.IsEnabled = true;
            this.Error_label.Visibility = System.Windows.Visibility.Collapsed;

            SystemTray.ProgressIndicator.IsIndeterminate = true;
            SystemTray.ProgressIndicator.IsVisible = true;
            SystemTray.ProgressIndicator.Text = "Searching ...";
        }
        private void setupSearchControls(string Message)                    
        {
            this.Search_Button.Visibility = System.Windows.Visibility.Visible;
            this.Search_Textbox.IsEnabled = true;
            this.Error_label.Visibility = System.Windows.Visibility.Visible;
            this.Error_label.Text = Message;

            SystemTray.ProgressIndicator.IsIndeterminate = false;
            SystemTray.ProgressIndicator.IsVisible = false;
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)  
        {
            prepareSearchControls();

            string query = this.Search_Textbox.Text;
            bool looseSearch = !(bool)StrongSearch_Checkbox.IsChecked;


            C4H_Webservice.Service1Client client = new C4H_Webservice.Service1Client();
            SearchManager.SearchQuery = query;

            prepareSearchControls();
            

            client.SearchCharitiesByQueryCompleted += client_SearchCharitiesByQueryCompleted;
            client.SearchCharitiesByQueryAsync(query, "0", looseSearch);
        }

        void client_SearchCharitiesByQueryCompleted(object sender, C4H_Webservice.SearchCharitiesByQueryCompletedEventArgs e)   
        {
            if (e.Result == null) //Search done
            {
                setupSearchControls("An error occured while searching. Make sure you have internet connection.");
            }
            else //Error
            {
                SearchManager.SearchItems = e.Result;
                initializeSearchControls();
                NavigationService.Navigate(new Uri("/Pages/Search/SearchResults.xaml", UriKind.Relative));
            }
        }


        #endregion

    }
}