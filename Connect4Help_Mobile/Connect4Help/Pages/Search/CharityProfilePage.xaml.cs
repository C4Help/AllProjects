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

namespace Connect4Help.Pages.Search
{
    public partial class CharityProfilePage : PhoneApplicationPage
    {
        public CharityProfilePage() 
        {
            InitializeComponent();
            intializeControls(SearchManager.curretnSearchItem);
        }

        private void intializeControls(C4H_Webservice.CharityProfile Profile)
        {
            //Profile
            this.regnumber_label.Text = Profile.RegNumber;
            this.fullname_label.Text = Profile.FullName;

            //Category
            this.type_label.Text = Profile.Category.Name;
            this.description_label.Text = Profile.Category.Description;
            this.designation_label.Text = Profile.Designation.Description;

            //Contact Information
            this.email_label.Text = Profile.Email;
            this.phone_label.Text = Profile.Phone;
            this.website_label.Text = Profile.Website;

            //Address
            this.province_label.Text = Profile.Province;
            this.city_label.Text = Profile.City;
            this.address1_label.Text = Profile.Address1;
            this.address2_label.Text = Profile.Address2;
            this.postalcode_label.Text = Profile.PostalCode;

            //Check if followed
            if (FollowedCharities.CheckIfAddedToCart(Profile.UserID))
            {
                Follow_Button.IsEnabled = false;
                Follow_Button.Content = "Followed";
            }
        }

        private void Follow_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!SecurityManager.CheckIfSignedIn())
            {
                MessageBox.Show("Please sign in first.");
            }
            else
            {
                FollowedCharities.AddToCart(SearchManager.curretnSearchItem);
                intializeControls(SearchManager.curretnSearchItem);
            }
        }
    }
}