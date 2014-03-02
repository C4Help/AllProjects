using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C4H_Webservice.Structure;
using System.Data.SqlClient;
using System.Data;

namespace C4H_Webservice.Managers
{
    public static class UserManager
    {

        #region General

        //Users
        private static User AddUser(string UserName, string Password, int UserRoleID, string FullName,
            string City, string Province, string PostalCode, string Address1, string Address2,
            string Phone, string Website, string Email) 
        {

            try
            {
                //###########
                //# Command #
                //###########

                string command = "INSERT INTO [User] (userName, userRoleID, userFullName, userCity, userProvince, userPostalCode, userAddress1, userAddress2, userPhone, userWebsite, userEmail) "
                    + "output INSERTED.userID "
                    + "VALUES (@userName, @userRoleID, @userFullName, @userCity, @userProvince, @userPostalCode, @userAddress1, @userAddress2, @userPhone, @userWebsite, @userEmail)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userName", UserName));
                parameters.Add(new SqlParameter("@userRoleID", UserRoleID));

                parameters.Add(new SqlParameter("@userFullName", FullName));

                parameters.Add(new SqlParameter("@userCity", City));
                parameters.Add(new SqlParameter("@userProvince", Province));
                parameters.Add(new SqlParameter("@userPostalCode", PostalCode));
                parameters.Add(new SqlParameter("@userAddress1", Address1));
                parameters.Add(new SqlParameter("@userAddress2", Address2));

                parameters.Add(new SqlParameter("@userPhone", Phone));
                parameters.Add(new SqlParameter("@userWebsite", Website));
                parameters.Add(new SqlParameter("@userEmail", Email));

                //#############
                //# Execution #
                //#############
                int ID = DatabaseManager.ExecuteScalarQueryCommand(command, parameters.ToArray());

                if (ID == -1)
                    return null;

                return new User(ID, UserName, (UserRole)UserRoleID, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email);
            }
            catch { return null; }
        }

        private static User GetUser(int UserID)         
        {
            try
            {
                //###########
                //# Command #
                //###########

                string command = "SELECT userName, userRoleID, userFullName, userCity, userProvince, userPostalCode, userAddress1, userAddress2, userPhone, userWebsite, userEmail "
                    + "FROM [User] WHERE userID = @UserID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@UserID", UserID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null || table.Rows.Count == 0)
                    return null;

                string UserName = table.Rows[0]["userName"].ToString();

                int userRoleID = int.Parse(table.Rows[0]["userRoleID"].ToString());
                string FullName = table.Rows[0]["userFullName"].ToString();

                string City = table.Rows[0]["userCity"].ToString();
                string Province = table.Rows[0]["userProvince"].ToString();
                string PostalCode = table.Rows[0]["userPostalCode"].ToString();
                string Address1 = table.Rows[0]["userAddress1"].ToString();
                string Address2 = table.Rows[0]["userAddress2"].ToString();

                string Phone = table.Rows[0]["userPhone"].ToString();
                string Website = table.Rows[0]["userWebsite"].ToString();
                string Email = table.Rows[0]["userEmail"].ToString();

                return new User(UserID, UserName, (UserRole)userRoleID, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email);
            }
            catch { return null; }
        }
        private static User GetUser(string UserName)    
        {
            try
            {
                //###########
                //# Command #
                //###########

                string command = "SELECT userID, userName, userRoleID, userFullName, userCity, userProvince, userPostalCode, userAddress1, userAddress2, userPhone, userWebsite, userEmail "
                    + "FROM [User] WHERE userName = @userName";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userName", UserName));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null || table.Rows.Count == 0)
                    return null;

                int userID = int.Parse(table.Rows[0]["userID"].ToString());

                int userRoleID = int.Parse(table.Rows[0]["userRoleID"].ToString());
                string FullName = table.Rows[0]["userFullName"].ToString();

                string City = table.Rows[0]["userCity"].ToString();
                string Province = table.Rows[0]["userProvince"].ToString();
                string PostalCode = table.Rows[0]["userPostalCode"].ToString();
                string Address1 = table.Rows[0]["userAddress1"].ToString();
                string Address2 = table.Rows[0]["userAddress2"].ToString();

                string Phone = table.Rows[0]["userPhone"].ToString();
                string Website = table.Rows[0]["userWebsite"].ToString();
                string Email = table.Rows[0]["userEmail"].ToString();

                return new User(userID, UserName, (UserRole)userRoleID, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email);
            }
            catch { return null; }
        }

        //Watchlist
        public static List<User> GetUserWatchlist(int UserID)                       
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT followedUserID, (SELECT userRoleID FROM [User] WHERE [User].userID = [WatchList].followedUserID) as userRoleID FROM [WatchList] WHERE userID = @userID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", UserID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null)
                    return null;

                //############
                //# Analysis #
                //############
                List<User> users = new List<User>();

                foreach (DataRow row in table.Rows)
                {
                    int followedUserID = int.Parse(row["followedUserID"].ToString());
                    int userRoleID = int.Parse(row["userRoleID"].ToString());
                    UserRole role = (UserRole)userRoleID;

                    User user = null;

                    if (role == UserRole.Donor)
                        user = GetDonorProfile(followedUserID);
                    else if (role == UserRole.Charity)
                        user = GetCharityProfile(followedUserID);

                    if (user != null)
                        users.Add(user);
                }

                return users;
            }
            catch { return null; }
        }
        public static bool AddToUserWatchList(int UserID, int FollowedUserID)       
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "INSERT INTO [WatchList] (userID, followedUserID) "
                    + "VALUES (@userID, @followedUserID)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", UserID));
                parameters.Add(new SqlParameter("@followedUserID", FollowedUserID));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return valid;
            }
            catch { return false; }
        }
        public static bool RemoveFromUserWatchList(int UserID, int FollowedUserID)  
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "DELETE FROM [WatchList] WHERE userID = @userID AND followedUserID = @followedUserID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", UserID));
                parameters.Add(new SqlParameter("@followedUserID", FollowedUserID));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return valid;
            }
            catch { return false; }
        }

        //User Services
        public static List<Structure.Service> GetUserServicesList(int UserID)       
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT serviceID, serviceName, serviceTypeID, (SELECT serviceTypeName FROM [ServiceType] WHERE [ServiceType].serviceTypeID = [Service].serviceTypeID) as serviceTypeName FROM [Service] WHERE "
                    + "serviceID in (SELECT serviceID FROM [UserService] WHERE userID = @userID)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", UserID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null)
                    return null;

                //############
                //# Analysis #
                //############
                List<Structure.Service> services = new List<Structure.Service>();

                foreach (DataRow row in table.Rows)
                {
                    int serviceID = int.Parse(row["serviceID"].ToString());
                    string serviceName = row["serviceName"].ToString();

                    int serviceTypeID = int.Parse(row["serviceTypeID"].ToString());
                    string serviceTypeName = row["serviceTypeName"].ToString();

                    services.Add(new Structure.Service(serviceID, serviceName, new ServiceType(serviceTypeID, serviceTypeName)));
                }

                return services;
            }
            catch { return null; }
        }
        public static bool AddToUserServicesList(int UserID, int ServiceID)         
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "INSERT INTO [UserService] (userID, serviceID) "
                    + "VALUES (@userID, @serviceID)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", UserID));
                parameters.Add(new SqlParameter("@serviceID", ServiceID));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return valid;
            }
            catch { return false; }
        }
        public static bool RemoveromUserServicesList(int UserID, int ServiceID)     
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "DELETE FROM [UserService] WHERE userID = @userID AND serviceID = @serviceID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", UserID));
                parameters.Add(new SqlParameter("@serviceID", ServiceID));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return valid;
            }
            catch { return false; }
        }

        #endregion

        #region Charity

        //Categories
        public static List<CharityCategory> GetCharityCategories()                          
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT categoryID, charityType, description FROM [CharityCategory]";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null)
                    return null;

                //############
                //# Analysis #
                //############
                List<CharityCategory> categories = new List<CharityCategory>();

                foreach (DataRow row in table.Rows)
                {
                    int categoryID = int.Parse(row["categoryID"].ToString());
                    string charityType = row["charityType"].ToString();
                    string description = row["description"].ToString();

                    categories.Add(new CharityCategory(categoryID, charityType, description));
                }

                return categories;
            }
            catch { return null; }
        }
        private static CharityCategory GetCharityCategory(int CharityCategoryID)            
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT categoryID, charityType, description FROM [CharityCategory] WHERE categoryID = @CategoryID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@CategoryID", CharityCategoryID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null)
                    return null;

                //############
                //# Analysis #
                //############
                CharityCategory category = null;

                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];

                    int categoryID = int.Parse(row["categoryID"].ToString());
                    string charityType = row["charityType"].ToString();
                    string description = row["description"].ToString();

                    category = new CharityCategory(categoryID, charityType, description);
                }

                return category;
            }
            catch { return null; }
        }

        //Designations
        public static List<CharityDesignation> GetCharityDesignations()                     
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT designationID, description FROM [Designation]";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null)
                    return null;

                //############
                //# Analysis #
                //############
                List<CharityDesignation> designations = new List<CharityDesignation>();

                foreach (DataRow row in table.Rows)
                {
                    int designationID = int.Parse(row["designationID"].ToString());
                    string description = row["description"].ToString();

                    designations.Add(new CharityDesignation(designationID, description));
                }

                return designations;
            }
            catch { return null; }
        }
        private static CharityDesignation GetCharityDesignation(int CharityDesignationID)   
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT designationID, description FROM [Designation] WHERE designationID = @DesignationID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@DesignationID", CharityDesignationID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null)
                    return null;

                //############
                //# Analysis #
                //############
                CharityDesignation designation = null;

                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];

                    int designationID = int.Parse(row["designationID"].ToString());
                    string description = row["description"].ToString();

                    designation = new CharityDesignation(designationID, description);
                }

                return designation;
            }
            catch { return null; }
        }

        //Programs
        public static List<CharityProgram> GetCharityPrograms(int UserID)                   
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT charityProgramID, charityProgramDescription FROM [CharityProgram] WHERE userID = @userID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", UserID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null)
                    return null;

                //############
                //# Analysis #
                //############
                List<CharityProgram> programs = new List<CharityProgram>();

                foreach (DataRow row in table.Rows)
                {
                    int charityProgramID = int.Parse(row["charityProgramID"].ToString());
                    string charityProgramDescription = row["charityProgramDescription"].ToString();

                    if (charityProgramDescription.Trim().Length > 0)
                        programs.Add(new CharityProgram(charityProgramID, charityProgramDescription));
                }

                return programs;
            }
            catch { return null; }
        }

        //Countries
        public static List<CharityActivityCountry> GetCharityActivityCountries(int UserID)  
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT charityActivityCountryID, charityActivityCountryName FROM [CharityActivityCountry] WHERE userID = @userID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", UserID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null)
                    return null;

                //############
                //# Analysis #
                //############
                List<CharityActivityCountry> countries = new List<CharityActivityCountry>();

                foreach (DataRow row in table.Rows)
                {
                    int charityActivityCountryID = int.Parse(row["charityActivityCountryID"].ToString());
                    string charityActivityCountryName = row["charityActivityCountryName"].ToString();

                    countries.Add(new CharityActivityCountry(charityActivityCountryID, charityActivityCountryName));
                }

                return countries;
            }
            catch { return null; }
        }

        //Charities
        public static CharityProfile CreateCharityProfile(string UserName, string Password, 
            string FullName,
            string City, string Province, string PostalCode, string Address1, string Address2,
            string Phone, string Website, string Email,
            string RegNumber, int CatetgoryID, int DesignationID)                           
        {
            City = City == null ? "" : City;
            Province = Province == null ? "" : Province;
            PostalCode = PostalCode == null ? "" : PostalCode;
            Address1 = Address1 == null ? "" : Address1;
            Address2 = Address2 == null ? "" : Address2;

            Phone = Phone == null ? "" : Phone;
            Website = Website == null ? "" : Website;
            Email = Email == null ? "" : Email;

            User user = AddUser(UserName, Password, 2, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email);

            if (user == null)
                return null;

            try
            {
                //###########
                //# Command #
                //###########
                string command = "INSERT INTO [CharityProfile] (userID, regNumber, charityCategoryID, charityDesignationID) "
                    + "VALUES (@userID, @regNumber, @charityCategoryID, @charityDesignationID)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", user.UserID));
                parameters.Add(new SqlParameter("@regNumber", RegNumber));
                parameters.Add(new SqlParameter("@charityCategoryID", CatetgoryID));
                parameters.Add(new SqlParameter("@charityDesignationID", DesignationID));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return new CharityProfile(user.UserID, UserName, (UserRole)2, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email, RegNumber, GetCharityCategory(CatetgoryID), GetCharityDesignation(DesignationID));
            }
            catch { return null; }
        }

        public static CharityProfile GetCharityProfile(int UserID)                          
        {
            User user = GetUser(UserID);

            if (user == null)
                return null;

            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT regNumber, charityCategoryID, charityDesignationID "
                    + "FROM CharityProfile WHERE userID = @userID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", user.UserID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null || table.Rows.Count == 0)
                    return null;

                string RegNumber = table.Rows[0]["regNumber"].ToString();
                int CatetgoryID = int.Parse(table.Rows[0]["charityCategoryID"].ToString());
                int DesignationID = int.Parse(table.Rows[0]["charityDesignationID"].ToString());
                
                CharityProfile profile = new CharityProfile(user.UserID, user.UserName, user.Role, user.FullName, user.City, user.Province, user.PostalCode, user.Address1, user.Address2, user.Phone, user.Website, user.Email,
                    RegNumber, GetCharityCategory(CatetgoryID), GetCharityDesignation(DesignationID));

                profile.Programs = GetCharityPrograms(profile.UserID);
                profile.Countries = GetCharityActivityCountries(profile.UserID);

                return profile;
            }
            catch { return null; }
        }
        public static CharityProfile GetCharityProfile(string UserName)                     
        {
            User user = GetUser(UserName);

            if (user == null)
                return null;

            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT regNumber, charityCategoryID, charityDesignationID "
                    + "FROM CharityProfile WHERE userID = @userID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", user.UserID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null || table.Rows.Count == 0)
                    return null;

                string RegNumber = table.Rows[0]["regNumber"].ToString();
                int CatetgoryID = int.Parse(table.Rows[0]["charityCategoryID"].ToString());
                int DesignationID = int.Parse(table.Rows[0]["charityDesignationID"].ToString());

                CharityProfile profile = new CharityProfile(user.UserID, user.UserName, user.Role, user.FullName, user.City, user.Province, user.PostalCode, user.Address1, user.Address2, user.Phone, user.Website, user.Email,
                    RegNumber, GetCharityCategory(CatetgoryID), GetCharityDesignation(DesignationID));

                profile.Programs = GetCharityPrograms(profile.UserID);
                profile.Countries = GetCharityActivityCountries(profile.UserID);

                return profile;
            }
            catch { return null; }
        }

        #endregion

        #region Donor

        public static DonorProfile CreateDonorProfile(string UserName, string Password,
            string FullName,
            string City, string Province, string PostalCode, string Address1, string Address2,
            string Phone, string Website, string Email,
            UserGender Gender, int BirthYear)                       
        {
            City = City == null ? "" : City;
            Province = Province == null ? "" : Province;
            PostalCode = PostalCode == null ? "" : PostalCode;
            Address1 = Address1 == null ? "" : Address1;
            Address2 = Address2 == null ? "" : Address2;

            Phone = Phone == null ? "" : Phone;
            Website = Website == null ? "" : Website;
            Email = Email == null ? "" : Email;

            User user = AddUser(UserName, Password, 2, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email);

            if (user == null)
                return null;

            try
            {
                //###########
                //# Command #
                //###########
                string command = "INSERT INTO [DonorProfile] (userID, donorGender, donorBirthYear) "
                    + "VALUES (@userID, @donorGender, @donorBirthYear)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", user.UserID));
                parameters.Add(new SqlParameter("@donorGender", (int)Gender));
                parameters.Add(new SqlParameter("@donorBirthYear", BirthYear));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return new DonorProfile(user.UserID, UserName, (UserRole)2, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email, Gender, BirthYear);
            }
            catch { return null; }
        }

        public static DonorProfile GetDonorProfile(int UserID)      
        {
            User user = GetUser(UserID);

            if (user == null)
                return null;

            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT donorGender, donorBirthYear) "
                    + "FROM DonorProfile WHERE userID = @userID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", user.UserID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null || table.Rows.Count == 0)
                    return null;

                int donorGender = int.Parse(table.Rows[0]["donorGender"].ToString());
                int donorBirthYear = int.Parse(table.Rows[0]["donorBirthYear"].ToString());

                return new DonorProfile(user.UserID, user.UserName, user.Role, user.FullName, user.City, user.Province, user.PostalCode, user.Address1, user.Address2, user.Phone, user.Website, user.Email,
                    (UserGender)donorGender, donorBirthYear);
            }
            catch { return null; }
        }
        public static DonorProfile GetDonorProfile(string UserName) 
        {
            User user = GetUser(UserName);

            if (user == null)
                return null;

            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT donorGender, donorBirthYear "
                    + "FROM DonorProfile WHERE userID = @userID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", user.UserID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null || table.Rows.Count == 0)
                    return null;

                int donorGender = int.Parse(table.Rows[0]["donorGender"].ToString());
                int donorBirthYear = int.Parse(table.Rows[0]["donorBirthYear"].ToString());

                DonorProfile profile = new DonorProfile(user.UserID, user.UserName, user.Role, user.FullName, user.City, user.Province, user.PostalCode, user.Address1, user.Address2, user.Phone, user.Website, user.Email,
                    (UserGender)donorGender, donorBirthYear);

                return profile;
            }
            catch { return null; }
        }

        #endregion

    }
}