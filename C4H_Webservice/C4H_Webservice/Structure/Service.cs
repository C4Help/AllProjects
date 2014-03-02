using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace C4H_Webservice.Structure
{
    [DataContract]
    public class Service
    {

        #region Constructor

        public Service(int ID, string Name, ServiceType Type)   
        {
            this.ID = ID;

            this.Name = Name;
            this.Type = Type;
        }

        #endregion

        #region Variables

        int id;

        string name;
        ServiceType type;

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
        [DataMember]
        public ServiceType Type 
        {
            get { return this.type; }
            set { this.type = value; }
        }

        #endregion

    }
}