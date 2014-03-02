using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace C4H_Webservice.Structure
{
    [DataContract]
    public class CharityProfile : User
    {

        #region Constructors

        public CharityProfile(int UserID, string UserName, UserRole Role,
            string FullName,
            string City, string Province, string PostalCode, string Address1, string Address2,
            string Phone, string Website, string Email,
            string RegNumber,
            CharityCategory Category, CharityDesignation Designation,
            List<CharityProgram> Programs, List<CharityActivityCountry> Countries) : 
            base (UserID, UserName, Role, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email)  
        {
            this.RegNumber = RegNumber;

            this.Category = Category;
            this.Designation = Designation;

            this.Programs = Programs;
            this.Countries = Countries;
        }

        public CharityProfile(int UserID, string UserName, UserRole Role,
            string FullName,
            string City, string Province, string PostalCode, string Address1, string Address2,
            string Phone, string Website, string Email,
            string RegNumber,
            CharityCategory Category, CharityDesignation Designation) : 
            this (UserID, UserName, Role, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email,
                    RegNumber, Category, Designation, new List<CharityProgram>(), new List<CharityActivityCountry>())       
        {
        }

        #endregion

        #region Variables

        string regNumber;

        CharityCategory category;
        CharityDesignation designation;

        List<CharityProgram> programs;
        List<CharityActivityCountry> countries;

        #endregion

        #region Properties

        [DataMember]
        public string RegNumber                 
        {
            get { return this.regNumber; }
            set { this.regNumber = value; }
        }

        [DataMember]
        public CharityCategory Category         
        {
            get { return this.category; }
            set { this.category = value; }
        }
        [DataMember]
        public CharityDesignation Designation   
        {
            get { return this.designation; }
            set { this.designation = value; }
        }

        [DataMember]
        public List<CharityProgram> Programs            
        {
            get { return this.programs; }
            set { this.programs = value; }
        }
        [DataMember]
        public List<CharityActivityCountry> Countries   
        {
            get { return this.countries; }
            set { this.countries = value; }
        }

        #endregion

    }
}