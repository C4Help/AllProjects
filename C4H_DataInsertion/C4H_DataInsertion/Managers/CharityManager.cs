using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C4H_DataInsertion.Structure;
using System.Data.SqlClient;

namespace C4H_DataInsertion.Managers
{
    public static class CharityManager
    {

        public static bool AddCharity(Charity charity)  
        {
            int ID = addCharity(charity.RegNumber, charity.UserRoleID, charity.UserFullName, charity.UserCity, charity.UserProvince, charity.UserPostalCode, charity.UserAddress1, charity.UserAddress2, charity.UserPhone, charity.UserWebsite, charity.UserEmail);

            if (ID == -1)
                return false;

            if (!addCharityProfile(ID, charity.RegNumber, charity.CharityCategoryID, charity.CharityDesignationID))
                return false;

            foreach (string Program in charity.CharityPrograms)
            {
                bool valid = addCharityProgram(ID, Program);
            }

            foreach (string Country in charity.CharityCountries)
            {
                bool valid = addCharityActivityCountry(ID, Country);
            }

            return true;
        }

        private static int addCharity(string userName, int userRoleID,
            string userFullName,
            string userCity, string userProvince, string userPostalCode, string Address1, string Address2,
            string userPhone, string userWebsite, string userEmail)                                                             
        {
            try
            {
                //###########
                //# Command #
                //###########

                string command = "INSERT INTO [User] (userName, userRoleID, userFullName, userCity, userProvince, userPostalCode, userAddress1, userAddress2, userPhone, userWebsite, userEmail) "
                    + "output INSERTED.userID "
                    + "VALUES (@userName, @userRoleID, @userFullName, @userCity, @userProvince, @userPostalCode, @userAddress1, @userAddress1, @userPhone, @userWebsite, @userEmail)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userName", userName));
                parameters.Add(new SqlParameter("@userRoleID", userRoleID));

                parameters.Add(new SqlParameter("@userFullName", userFullName));

                parameters.Add(new SqlParameter("@userCity", userCity));
                parameters.Add(new SqlParameter("@userProvince", userProvince));
                parameters.Add(new SqlParameter("@userPostalCode", userPostalCode));
                parameters.Add(new SqlParameter("@userAddress1", Address1));
                parameters.Add(new SqlParameter("@userAddress2", Address2));

                parameters.Add(new SqlParameter("@userPhone", userPhone));
                parameters.Add(new SqlParameter("@userWebsite", userWebsite));
                parameters.Add(new SqlParameter("@userEmail", userEmail));

                //#############
                //# Execution #
                //#############
                int ID = DatabaseManager.ExecuteScalarQueryCommand(command, parameters.ToArray());

                return ID;
            }
            catch { return -1; }
        }

        private static bool addCharityProfile(int userID, string regNumber, int charityCatetgoryID, int charityDesignationID)   
        {
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
                parameters.Add(new SqlParameter("@userID", userID));
                parameters.Add(new SqlParameter("@regNumber", regNumber));
                parameters.Add(new SqlParameter("@charityCategoryID", charityCatetgoryID));
                parameters.Add(new SqlParameter("@charityDesignationID", charityDesignationID));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return valid;
            }
            catch { return false; }
        }
        private static bool addCharityProgram(int userID, string charityProgramDescription)                                     
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "INSERT INTO [CharityProgram] (userID, charityProgramDescription) "
                    + "VALUES (@userID, @charityProgramDescription)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", userID));
                parameters.Add(new SqlParameter("@charityProgramDescription", charityProgramDescription));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return valid;
            }
            catch { return false; }
        }
        private static bool addCharityActivityCountry(int userID, string charityActivityCountryName)                            
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "INSERT INTO [CharityActivityCountry] (userID, charityActivityCountryName) "
                    + "VALUES (@userID, @charityActivityCountryName)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@userID", userID));
                parameters.Add(new SqlParameter("@charityActivityCountryName", charityActivityCountryName));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return valid;
            }
            catch { return false; }
        }

        public static bool addDesignation(int designationID, string description)                        
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "INSERT INTO [Designation] (designationID, description) "
                    + "VALUES (@designationID, @description)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@designationID", designationID));
                parameters.Add(new SqlParameter("@description", description));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return valid;
            }
            catch { return false; }
        }
        public static bool addCharityCategory(int categoryID, string charityType, string description)   
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "INSERT INTO [CharityCategory] (categoryID, charityType, description) "
                    + "VALUES (@categoryID, @charityType, @description)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@categoryID", categoryID));
                parameters.Add(new SqlParameter("@charityType", charityType));
                parameters.Add(new SqlParameter("@description", description));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return valid;
            }
            catch { return false; }
        }

    }
}
