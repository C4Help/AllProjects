using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Connect4Help.Structure
{
    [DataContract]
    public class CharitySearchedItem : INotifyPropertyChanged
    {
        #region Constructors

        public CharitySearchedItem(int Counter, int RegNum, string FullName,string Category, string Address1,string Address2,
            string Phone,string Email,string Website,string Designation,bool AddedToCart) 
        {
            this.Counter = Counter;

            this.regNum = RegNum;
            this.name = FullName;
            this.category = Category;
            this.addedToCart = AddedToCart;
            this.address1=Address1;
            this.address1 = Address2;
            this.phone = Phone;
            this.email = Email;
            this.website = Website;
            this.designation = Designation;
        }

        #endregion

        #region Variables

        private int regNum;
        private string name;
        private string category;
        private string address1;
        private string address2;
        private string phone;
        private string email;
        private string website;
        private string designation;
        private bool addedToCart;

        #endregion

        #region Properties

        public int Counter { set; get; }
        [DataMember]
        public int ID           
        {
            set { regNum = value; }
            get { return regNum; }
        }
        [DataMember]
        public string Name      
        {
            get { return name; }
            set { name = value; }
        }  
        [DataMember]
        public string Category  
        {
            get { return category; }
            set { category = value; }
        }
        [DataMember]
        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }
        [DataMember]
        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }
        [DataMember]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        [DataMember]
        public string Website
        {
            get { return website; }
            set { website = value; }
        }
        [DataMember]
        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
        [DataMember]
        public bool AddedToCart 
        {
            set 
            {
                this.addedToCart = value;
                NotifyPropertyChanged("AddedToCart");
                NotifyPropertyChanged("ShowAddToCart");
                NotifyPropertyChanged("ShowInCart");
            }
            get { return addedToCart; }
        }
        public Visibility ShowAddToCart 
        {
            get { return AddedToCart ? Visibility.Collapsed : Visibility.Visible; }
        }
        public Visibility ShowInCart    
        {
            get { return AddedToCart ? Visibility.Visible : Visibility.Collapsed; }
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
