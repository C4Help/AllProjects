using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace C4H_Webservice.Structure
{
    [DataContract]
    public class CharityDesignation
    {

        #region Constructor

        public CharityDesignation(int ID, string Description)   
        {
            this.ID = ID;
            this.Description = Description;
        }

        #endregion

        #region Variables

        int id;
        string description;

        #endregion

        #region Properties

        [DataMember]
        public int ID               
        {
            get { return this.id; }
            set { this.id = value; }
        }
        [DataMember]
        public string Description   
        {
            get { return this.description; }
            set { this.description = value; }
        }

        #endregion

    }
}