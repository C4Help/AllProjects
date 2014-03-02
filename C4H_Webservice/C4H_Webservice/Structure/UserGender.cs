using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace C4H_Webservice.Structure
{
    [DataContract]
    public enum UserGender
    {
        [EnumMember]
        Male = 1,
        [EnumMember]
        Female = 2
    }
}