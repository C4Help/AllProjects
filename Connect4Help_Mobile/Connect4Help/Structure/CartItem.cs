using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveAndSocialize.Structure
{
    [DataContract]
    public class CartItem
    {

        #region Constructor

        public CartItem(SearchedItem Item, string AddedBy)  
        {
            this.Item = Item;
            this.AddedBy = AddedBy;
        }

        #endregion

        #region Variables

        private SearchedItem item;
        private string addedBy;

        #endregion

        #region Properties

        [DataMember]
        public SearchedItem Item    
        {
            get { return this.item; }
            set { this.item = value; }
        }

        public int ID               
        {
            get { return item.ID; }
            set { item.ID = value; }
        }
        public string Name          
        {
            get { return item.Name; }
            set { item.Name = value; }
        }

        public string Category      
        {
            get { return item.Category; }
            set { item.Category = value; }
        }
        public string Price         
        {
            get { return item.Price; }
            set { item.Price = value; }
        }

        [DataMember]
        public string AddedBy       
        {
            get { return addedBy; }
            set { addedBy = value; }
        }

        #endregion

    }
}
