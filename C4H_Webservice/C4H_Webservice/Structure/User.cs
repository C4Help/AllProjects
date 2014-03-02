using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace C4H_Webservice.Structure
{
    [KnownType(typeof(CharityProfile)), KnownType(typeof(DonorProfile))]
    [DataContract]
    public class User
    {

        #region Constructor

        public User(int UserID, string UserName, UserRole Role,
            string FullName,
            string City, string Province, string PostalCode, string Address1, string Address2,
            string Phone, string Website, string Email)   
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Role = Role;

            this.FullName = FullName;

            this.City = City;
            this.Province = Province;
            this.PostalCode = PostalCode;
            this.Address1 = Address1;
            this.Address2 = Address2;

            this.Phone = Phone;
            this.Website = Website;
            this.Email = Email;
        }

        #endregion

        #region Variables

        int userID;
        string userName;
        UserRole role;

        string fullName;

        string city;
        string province;
        string postalCode;
        string address1;
        string address2;

        string phone;
        string website;
        string email;

        #endregion

        #region Properties

        [DataMember]
        public int UserID               
        {
            get { return this.userID; }
            set { this.userID = value; }
        }
        [DataMember]
        public string UserName          
        {
            get { return this.userName; }
            set { this.userName = value; }
        }
        [DataMember]
        public UserRole Role            
        {
            get { return this.role; }
            set { this.role = value; }
        }

        [DataMember]
        public string FullName          
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        [DataMember]
        public string City              
        {
            get { return this.city; }
            set { this.city = value; }
        }
        [DataMember]
        public string Province          
        {
            get { return this.province; }
            set { this.province = value; }
        }
        [DataMember]
        public string PostalCode        
        {
            get { return this.postalCode; }
            set { this.postalCode = value; }
        }
        [DataMember]
        public string Address1          
        {
            get { return this.address1; }
            set { this.address1 = value; }
        }
        [DataMember]
        public string Address2          
        {
            get { return this.address2; }
            set { this.address2 = value; }
        }

        [DataMember]
        public string Phone             
        {
            get { return this.phone; }
            set { this.phone = value; }
        }
        [DataMember]
        public string Website           
        {
            get { return this.website; }
            set { this.website = value; }
        }
        [DataMember]
        public string Email             
        {
            get { return this.email; }
            set { this.email = value; }
        }

        #endregion

    }
}