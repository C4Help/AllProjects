using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C4H_Website.C4H_Service;

namespace C4H_Website.Managers
{
    public static class DonorSearchManager
    {

        public static List<CharityProfile> SearchCharitiesByQuery(string Query, string Province, bool LooseSearch, 
            int PageNumber, int RowsPerPageCount, out int TotalResults, out Dictionary<string, int> GeoStatistics,
            out Dictionary<CharityDesignation, int> DesignationStatistics)                                              
        {
            TotalResults = 0;
            GeoStatistics = new Dictionary<string, int>();
            DesignationStatistics = new Dictionary<CharityDesignation, int>();

            try
            {
                Service1Client client = new Service1Client();
                CharityProfile[] profiles = client.SearchCharitiesByQueryPageByPage(out TotalResults, out GeoStatistics, out DesignationStatistics, Query, Province, LooseSearch, PageNumber, RowsPerPageCount);

                return profiles == null ? null : profiles.ToList();
            }
            catch { return null; }
        }
        
        public static CharityProfile GetCharityProfile(int UserID)                                                      
        {
            try
            {
                Service1Client client = new Service1Client();
                return client.GetCharityProfileByUserID(UserID);
            }
            catch { return null; }
        }

    }
}