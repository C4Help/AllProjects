using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Help.Structure
{
    [DataContract]
    public class Client
    {

        #region Constructors

        public Client(int ID, string Name)  
        {
            this.id = ID;
            this.name = Name;
        }

        #endregion

        #region Variables

        private int id;
        private string name;

        #endregion

        #region Properties

        [DataMember]
        public int ID       
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string Name  
        {
            get { return name; }
            set { name = value; }
        }

        #endregion

    }
}
