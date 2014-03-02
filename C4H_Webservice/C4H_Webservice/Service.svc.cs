using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using C4H_Webservice.Structure;
using C4H_Webservice.Managers;

namespace C4H_Webservice
{
    [ServiceContract]
    public class Service
    {

        #region Services

        [OperationContract]
        public List<ServiceType> GetServiceTypes()                                      
        {
            return ServiceManager.GetServiceTypes();
        }

        [OperationContract]
        public List<Structure.Service> GetServices()                                    
        {
            return ServiceManager.GetServices();
        }

        [OperationContract]
        public List<Structure.Service> GetServicesForSpecificType(int ServiceTypeID)    
        {
            return ServiceManager.GetServices(ServiceTypeID);
        }

        #endregion

        #region All Users

        //Watch list
        [OperationContract]
        public List<User> GetUserWatchlist(int UserID)                      
        {
            return UserManager.GetUserWatchlist(UserID);
        }
        [OperationContract]
        public bool AddToUserWatchList(int UserID, int FollowedUserID)      
        {
            return UserManager.AddToUserWatchList(UserID, FollowedUserID);
        }
        [OperationContract]
        public bool RemoveFromUserWatchList(int UserID, int FollowedUserID) 
        {
            return UserManager.RemoveFromUserWatchList(UserID, FollowedUserID);
        }

        //User services
        [OperationContract]
        public List<Structure.Service> GetUserServices(int UserID)          
        {
            return UserManager.GetUserServicesList(UserID);
        }
        [OperationContract]
        public bool AddToUserServicesList(int UserID, int ServiceID)        
        {
            return UserManager.AddToUserServicesList(UserID, ServiceID);
        }
        [OperationContract]
        public bool RemoveromUserServicesList(int UserID, int ServiceID)    
        {
            return UserManager.RemoveromUserServicesList(UserID, ServiceID);
        }

        #endregion

        #region Charities

        [OperationContract]
        public List<CharityDesignation> GetCharityDesignations()    
        {
            return UserManager.GetCharityDesignations();
        }

        [OperationContract]
        public List<CharityCategory> GetCharityCategories()         
        {
            return UserManager.GetCharityCategories();
        }

        [OperationContract]
        public CharityProfile CreateCharityProfile(string UserName, string Password, string FullName,
            string City, string Province, string PostalCode, string Address1, string Address2,
            string Phone, string Website, string Email,
            string RegNumber, int CatetgoryID, int DesignationID)   
        {
            return UserManager.CreateCharityProfile(UserName, Password, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email, RegNumber, CatetgoryID, DesignationID);
        }

        [OperationContract]
        public CharityProfile GetCharityProfileByUserID(int UserID)         
        {
            return UserManager.GetCharityProfile(UserID);
        }
        [OperationContract]
        public CharityProfile GetCharityProfileByUsername(string UserName)  
        {
            return UserManager.GetCharityProfile(UserName);
        }

        #endregion

        #region Donors

        [OperationContract]
        public DonorProfile CreateDonorProfile(string UserName, string Password, string FullName,
            string City, string Province, string PostalCode, string Address1, string Address2,
            string Phone, string Website, string Email,
            UserGender Gender, int BirthYear)                           
        {
            return UserManager.CreateDonorProfile(UserName, Password, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email, Gender, BirthYear);
        }
        [OperationContract]
        public DonorProfile GetDonorProfileByUsername(string UserName)  
        {
            return UserManager.GetDonorProfile(UserName);
        }

        #endregion

        #region Search

        [OperationContract]
        public List<CharityProfile> SearchCharitiesByQueryPageByPage(string Query, string Province, bool LooseSearch, 
            int PageNumber, int RowsPerPageCount, out int TotalRows, out Dictionary<string, int> Statistics,
            out Dictionary<CharityDesignation, int> DesignationStatistics)    
        {
            return SearchManager.SearchCharities(Query, Province, LooseSearch, PageNumber, RowsPerPageCount, out TotalRows, out Statistics, out DesignationStatistics);
        }

        [OperationContract]
        public List<CharityProfile> SearchCharitiesByQuery(string Query, string Province, bool LooseSearch)     
        {
            int totalRows = 0;
            Dictionary<string, int> GeoStatistics;
            Dictionary<CharityDesignation, int> DesignationStatistics;
            return SearchManager.SearchCharities(Query, Province, LooseSearch, -1, -1, out totalRows, out GeoStatistics, out DesignationStatistics);
        }

        #endregion

    }
}
