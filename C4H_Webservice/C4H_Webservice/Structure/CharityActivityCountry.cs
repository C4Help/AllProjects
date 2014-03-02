using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace C4H_Webservice.Structure
{
    [DataContract]
    public class CharityActivityCountry
    {

        #region Constructor

        public CharityActivityCountry(int ID, string Name)   
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

        [DataMember]
        public int ID       
        {
            get { return this.id; }
            set { this.id = value; }
        }
        [DataMember]
        public string Name  
        {
            get { return this.name; }
            set { this.name = value; }
        }

        #endregion

    }
}