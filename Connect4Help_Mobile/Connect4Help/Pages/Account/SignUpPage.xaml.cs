using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Connect4Help.C4H_Webservice;
using System.ComponentModel;
using Connect4Help.Managers;

namespace Connect4Help.Pages.Account
{
    public partial class SignUpPage : PhoneApplicationPage
    {
        public SignUpPage() 
        {
            InitializeComponent();

            loadOnlineServices();
        }

        #region Services

        private List<UserServiceView> myServices;

        private void loadOnlineServices()                                                   
        {
            Service1Client client = new Service1Client();
            client.GetServicesCompleted += client_GetServicesCompleted;
            client.GetServicesAsync();
        }
        private void client_GetServicesCompleted
            (object sender, GetServicesCompletedEventArgs e)                                
        {
            if (e.Result == null)
            {
                services_Error_Label.Visibility = System.Windows.Visibility.Visible;
                services_Error_Label.Text = "An error occured while loading the services.";
                return;
            }

            services_Error_Label.Visibility = System.Windows.Visibility.Collapsed;
            List<C4H_Webservice.Service> services = e.Result.ToList();

            myServices = new List<UserServiceView>();
            foreach (C4H_Webservice.Service service in services)
                myServices.Add(new UserServiceView(service, false));
            this.services_listselector.ItemsSource = myServices;
        }
        private void Panorama_Tap(object sender, System.Windows.Input.GestureEventArgs e)   
        {
            if (this.services_listselector.SelectedItem == null)
                return;

            UserServiceView service = services_listselector.SelectedItem as UserServiceView;
            if (service == null)
                return;

            service.Added = !service.Added;
            this.services_listselector.SelectedItem = false;
        }

        #endregion

        #region Error

        private void setErrorMessage(string Message)    
        {
            this.Error_label.Text = Message;
            this.Error_label.Visibility = System.Windows.Visibility.Visible;
        }
        private void hideErrorMessage()                 
        {
            this.Error_label.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion

        private void Submit_Button_Click(object sender, RoutedEventArgs e)  
        {
            //Account
            string userName = this.username_textbox.Text;
            string password = this.password_textbox.Text;

            if (userName.Length == 0) { setErrorMessage("Username can not be left empty"); return; }
            if (password.Length == 0) { setErrorMessage("Password can not be left empty"); return; }

            //Basic Info
            string fullName = this.fullname_textbox.Text;
            string birthYear = this.birthyear_textbox.Text;
            int birthYearValue;
            bool maleGender = (bool)this.male_gender_radiobutton.IsChecked;

            if (fullName.Length == 0) { setErrorMessage("Full name can not be left empty"); return; }
            if (!int.TryParse(birthYear, out birthYearValue)) { setErrorMessage("Birth year should have an integer value"); return; }

            //Contact Info
            string email = this.email_textbox.Text;
            string phone = this.phone_textbox.Text;
            string website = this.website_textbox.Text;

            //Address
            string province = this.province_textbox.Text;
            string city = this.city_textbox.Text;
            string address1 = this.address1_textbox.Text;
            string address2 = this.address2_textbox.Text;
            string postalCode = this.postalcode_textbox.Text;

            //Services
            List<int> services = new List<int>();
            if (myServices != null)
                foreach (UserServiceView service in myServices)
                    if (service.Added)
                        services.Add(service.ID);

            //Confirmation
            bool accepted = (bool)this.Accept_Checkbox.IsChecked;
            if (!accepted) { setErrorMessage("You should accept the agreement first."); return; }

            hideErrorMessage();

            Service1Client client = new Service1Client();
            client.CreateDonorProfileCompleted += client_CreateDonorProfileCompleted;
            client.CreateDonorProfileAsync(userName, password, fullName, city, province, postalCode, address1, address2, phone, website, email, maleGender ? UserGender.Male : UserGender.Female, birthYearValue);
        }

        void client_CreateDonorProfileCompleted(object sender, CreateDonorProfileCompletedEventArgs e)  
        {
            DonorProfile profile = e.Result;

            if (profile == null)
            {
                setErrorMessage("An error occurred while trying to create the profile.");
            }
            else
            {
                SecurityManager.SetLocalAuthenticationInformation(profile);
                NavigationService.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.Relative));
            }
        }

        
    }

    public class UserServiceView : INotifyPropertyChanged   
    {

        #region Constructor

        public UserServiceView(C4H_Webservice.Service Service, bool Added)  
        {
            this.service = Service;
            this.Added = Added;
        }

        #endregion

        #region Variables

        C4H_Webservice.Service service;
        bool added;

        #endregion

        #region Properties

        public int ID       
        {
            get { return this.service.ID; }
        }
        public string Name  
        {
            set { service.Name = value; }
            get { return service.Name; }
        }
        public string Type  
        {
            set { service.Type.Name = value; }
            get { return service.Type.Name; }
        }

        public bool Added   
        {
            set     
            { 
                added = value;

                NotifyPropertyChanged("Added");
                NotifyPropertyChanged("AddToListVisibility");
                NotifyPropertyChanged("RemoveFromListVisibility");
            }
            get { return added; }
        }

        public Visibility AddToListVisibility       
        {
            get { return Added ? Visibility.Collapsed : Visibility.Visible; }
        }
        public Visibility RemoveFromListVisibility  
        {
            get { return Added ? Visibility.Visible : Visibility.Collapsed; }
        }

        #endregion

        #region Notification

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName) 
        {
            if (null != this.PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}