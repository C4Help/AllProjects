using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C4H_Webservice.Structure;
using System.Data.SqlClient;
using System.Data;

namespace C4H_Webservice.Managers
{
    public static class SearchManager
    {

        private static List<string> ProcessQuery(string Query)                                          
        {
            if (Query == null)
                return new List<string>();

            string[] values = Query.Split(' ');

            List<string> queries = new List<string>();
            foreach (string value in values)
                if (value != null && value.Trim().Length > 0)
                    queries.Add(value.Trim().ToLower());
            return queries;
        }
        public static bool CheckIfValid(List<string> Queries, List<string> Fields, bool LooseSearch)    
        {
            if (LooseSearch)
            {
                foreach (string query in Queries)
                    foreach (string field in Fields)
                        if (field.ToLower().IndexOf(query.ToLower()) != -1 || query.ToLower().IndexOf(field.ToLower()) != -1)
                            return true;

                return false;
            }
            else
            {
                foreach (string query in Queries)
                {
                    bool found = false;
                    foreach (string field in Fields)
                        if (field.ToLower().IndexOf(query.ToLower()) != -1 || query.ToLower().IndexOf(field.ToLower()) != -1)
                        {
                            found = true;
                            break;
                        }

                    if (!found)
                        return false;
                }

                return true;
            }
        }

        public static List<CharityProfile> SearchCharities(string Query, string Provice, bool LooseSearch,
            int PageNumber, int RowsPerPageCount, out int TotalResults, 
            out Dictionary<string, int> GeographicalStatistics,
            out Dictionary<CharityDesignation, int> DesignationStatistics)    
        {
            TotalResults = 0;
            GeographicalStatistics = new Dictionary<string, int>();
            List<int> avaialableDesignationIDs = new List<int>();
            DesignationStatistics = new Dictionary<CharityDesignation, int>();

            Provice = Provice == "0" ? null : Provice;
            Query = Query == null ? "" : Query;

            try
            {

                //###########
                //# Command #
                //###########

                string command = "SELECT userID, userName, userRoleID, userFullName, userCity, userProvince, userPostalCode, userAddress1, userAddress2, userPhone, userWebsite, userEmail, "

                    + "(SELECT regNumber FROM [CharityProfile] WHERE [CharityProfile].userID = [User].userID) as regNumber, "

                    + "(SELECT charityCategoryID FROM [CharityProfile] WHERE [CharityProfile].userID = [User].userID) as charityCategoryID, "
                    + "(SELECT charityType FROM [CharityCategory] WHERE categoryID in (SELECT charityCategoryID FROM [CharityProfile] WHERE [CharityProfile].userID = [User].userID)) as charityCategoryName, "
                    + "(SELECT description FROM [CharityCategory] WHERE categoryID in (SELECT charityCategoryID FROM [CharityProfile] WHERE [CharityProfile].userID = [User].userID)) as charityCategoryDescription, "

                    + "(SELECT charityDesignationID FROM [CharityProfile] WHERE [CharityProfile].userID = [User].userID) as charityDesignationID,  "
                    + "(SELECT description FROM [Designation] WHERE designationID in (SELECT charityDesignationID FROM [CharityProfile] WHERE [CharityProfile].userID = [User].userID)) as charityDesignationName "

                    + "FROM [User] WHERE userRoleID = 2 " + (Provice == null ? "" : "AND userProvince LIKE @userProvince ORDER BY regNumber");

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                if (Provice != null)
                    parameters.Add(new SqlParameter("@userProvince", Provice));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null || table.Rows.Count == 0)
                    return null;

                List<string> queries = ProcessQuery(Query);

                List<CharityProfile> profiles = new List<CharityProfile>();

                foreach (DataRow row in table.Rows)
                {
                    try
                    {
                        int UserID = int.Parse(row["userID"].ToString());
                        string UserName = row["userName"].ToString();

                        int userRoleID = int.Parse(row["userRoleID"].ToString());
                        string FullName = row["userFullName"].ToString();

                        string City = row["userCity"].ToString();
                        string Province = row["userProvince"].ToString();
                        string PostalCode = row["userPostalCode"].ToString();
                        string Address1 = row["userAddress1"].ToString();
                        string Address2 = row["userAddress2"].ToString();

                        string Phone = row["userPhone"].ToString();
                        string Website = row["userWebsite"].ToString();
                        string Email = row["userEmail"].ToString();

                        string RegNumber = row["regNumber"].ToString();

                        int charityCategoryID = int.Parse(row["charityCategoryID"].ToString());
                        string charityCategoryName = row["charityCategoryName"].ToString();
                        string charityCategoryDescription = row["charityCategoryDescription"].ToString();

                        int charityDesignationID = int.Parse(row["charityDesignationID"].ToString());
                        string charityDesignationName = row["charityDesignationName"].ToString();

                        if (Query.Length == 0 || CheckIfValid(queries,
                            new List<string> { FullName, RegNumber, charityCategoryName, charityDesignationName, City, charityCategoryDescription, PostalCode }, LooseSearch)) 
                                profiles.Add(new CharityProfile(UserID, UserName, (UserRole)userRoleID, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email,
                                        RegNumber, new CharityCategory(charityCategoryID, charityCategoryName, charityCategoryDescription), new CharityDesignation(charityDesignationID, charityDesignationName)));
                    }
                    catch { }
                }

                foreach (CharityProfile profile in profiles)
                {
                    if (!GeographicalStatistics.ContainsKey(profile.Province))
                        GeographicalStatistics.Add(profile.Province, 0);

                    if (avaialableDesignationIDs.IndexOf(profile.Designation.ID) == -1)
                    {
                        avaialableDesignationIDs.Add(profile.Designation.ID);
                        DesignationStatistics.Add(profile.Designation, 0);
                    }

                    DesignationStatistics[DesignationStatistics.Keys.ToArray()[avaialableDesignationIDs.IndexOf(profile.Designation.ID)]]++;
                    GeographicalStatistics[profile.Province]++;
                }

                TotalResults = profiles.Count();
                return profiles.Skip(PageNumber * RowsPerPageCount).Take(RowsPerPageCount).ToList();
            }
            catch { return null; }
        }
        
    }
}