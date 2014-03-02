using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Help.Structure
{
    [DataContract]
    public class CartCharityItem
    {

        #region Constructor

        public CartCharityItem(CharitySearchedItem Item, string AddedBy)  
        {
            this.Item = Item;
            this.AddedBy = AddedBy;
        }

        #endregion

        #region Variables

        private CharitySearchedItem item;
        private string addedBy;

        #endregion

        #region Properties

        [DataMember]
        public CharitySearchedItem Item    
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
     
        [DataMember]
        public string AddedBy       
        {
            get { return addedBy; }
            set { addedBy = value; }
        }

        #endregion

    }
}
