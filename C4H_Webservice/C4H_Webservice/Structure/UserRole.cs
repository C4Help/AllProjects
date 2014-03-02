using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace C4H_Webservice.Structure
{
    [DataContract]
    public enum UserRole
    {
        [EnumMember]
        Government = 1,
        [EnumMember]
        Charity = 2,
        [EnumMember]
        Donor = 3
    }
}