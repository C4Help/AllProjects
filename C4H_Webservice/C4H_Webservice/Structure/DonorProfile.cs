using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace C4H_Webservice.Structure
{
    [DataContract]
    public class DonorProfile : User
    {

        #region Constructor

        public DonorProfile(int UserID, string UserName, UserRole Role,
            string FullName,
            string City, string Province, string PostalCode, string Address1, string Address2,
            string Phone, string Website, string Email,
            UserGender Gender, int BirthYear) : 
            base (UserID, UserName, Role, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email)  
        {
            this.Gender = Gender;
            this.BirthYear = BirthYear;
        }

        #endregion

        #region Variables

        UserGender gender;
        int birthYear;

        #endregion

        #region Properties

        [DataMember]
        public UserGender Gender    
        {
            get { return this.gender; }
            set { this.gender = value; }
        }
        [DataMember]
        public int BirthYear        
        {
            get { return this.birthYear; }
            set { this.birthYear = value; }
        }

        #endregion

    }
}