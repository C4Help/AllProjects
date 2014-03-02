using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Help.Structure
{
    public class ItemCategory
    {

        #region Constructor

        public ItemCategory(int ID, string Name)    
        {
            this.ID = ID;
            this.Name = Name;
        }

        #endregion

        #region Variables

        int id;
        string name;

        #endregion

        #region Properties

        public int ID       
        {
            get { return id; }
            set { id = value; }
        }
        public string Name  
        {
            get { return name; }
            set { name = value; }
        }

        #endregion

    }
}
