using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaveAndSocialize.Structure
{
    [DataContract]
    public class SearchedItem : INotifyPropertyChanged
    {
        #region Constructors

        public SearchedItem(int Counter, int ID, string Name, string Price, string Category, bool AddedToCart) 
        {
            this.Counter = Counter;

            this.ID = ID;
            this.Name = Name;

            this.Price = Price;
            this.Category = Category;

            this.AddedToCart = AddedToCart;
        }

        #endregion

        #region Variables

        private int id;
        private string name;

        private string price;
        private string category;

        private bool addedToCart;

        #endregion

        #region Properties

        public int Counter { set; get; }

        [DataMember]
        public int ID           
        {
            set { id = value; }
            get { return id; }
        }
        [DataMember]
        public string Name      
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Price     
        {
            set { price = value; }
            get { return price; }
        }
        [DataMember]
        public string Category  
        {
            get { return category; }
            set { category = value; }
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
