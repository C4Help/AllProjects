using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C4H_DataInsertion.Structure   
{
    public class Charity    
    {

        #region Constructors

        public Charity(string RegNumber,
            string UserFullName,
            string UserCity, string UserProvince, string UserPostalCode, string UserAddress1, string UserAddress2,
            string UserPhone, string UserWebsite, string UserEmail,
            int CharityCategoryID, int CharityDesignationID)   
        {
            this.RegNumber = RegNumber;
            this.UserRoleID = 2;

            this.UserFullName = UserFullName;

            this.UserCity = UserCity;
            this.UserProvince = UserProvince;
            this.UserPostalCode = UserPostalCode;
            this.UserAddress1 = UserAddress1;
            this.UserAddress2 = UserAddress2;

            this.UserPhone = UserPhone;
            this.UserWebsite = UserWebsite;
            this.UserEmail = UserEmail;

            this.CharityCategoryID = CharityCategoryID;
            this.CharityDesignationID = CharityDesignationID;

            this.CharityPrograms = new List<string>();
            this.CharityCountries = new List<string>();
        }

        #endregion

        #region Variables

        string regNumber;
        int userRoleID;

        string userFullName;

        string userCity;
        string userProvince;
        string userPostalCode;
        string userAddress1;
        string userAddress2;

        string userPhone;
        string userWebsite;
        string userEmail;

        int charityCategoryID;
        int charityDesignationID;

        List<string> charityPrograms;
        List<string> charityCountries;

        #endregion

        #region Properties

        public string RegNumber         
        {
            get { return this.regNumber; }
            set { this.regNumber = value; }
        }
        public int UserRoleID           
        {
            get { return this.userRoleID; }
            set { this.userRoleID = value; }
        }

        public string UserFullName      
        {
            get { return this.userFullName; }
            set { this.userFullName = value; }
        }

        public string UserCity          
        {
            get { return this.userCity; }
            set { this.userCity = value; }
        }
        public string UserProvince      
        {
            get { return this.userProvince; }
            set { this.userProvince = value; }
        }
        public string UserPostalCode    
        {
            get { return this.userPostalCode; }
            set { this.userPostalCode = value; }
        }
        public string UserAddress1      
        {
            get { return this.userAddress1; }
            set { this.userAddress1 = value; }
        }
        public string UserAddress2      
        {
            get { return this.userAddress2; }
            set { this.userAddress2 = value; }
        }

        public string UserPhone         
        {
            get { return this.userPhone; }
            set { this.userPhone = value; }
        }
        public string UserWebsite       
        {
            get { return this.userWebsite; }
            set { this.userWebsite = value; }
        }
        public string UserEmail         
        {
            get { return this.userEmail; }
            set { this.userEmail = value; }
        }

        public int CharityCategoryID    
        {
            get { return this.charityCategoryID; }
            set { this.charityCategoryID = value; }
        }
        public int CharityDesignationID 
        {
            get { return this.charityDesignationID; }
            set { this.charityDesignationID = value; }
        }

        public List<string> CharityPrograms     
        {
            get { return this.charityPrograms; }
            set { this.charityPrograms = value; }
        }
        public List<string> CharityCountries    
        {
            get { return this.charityCountries; }
            set { this.charityCountries = value; }
        }

        #endregion

    }
}
