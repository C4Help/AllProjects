using Connect4Help.Structure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Connect4Help.Managers
{
    public static class SearchManager
    {

        public static string SearchQuery;
        public static ObservableCollection<C4H_Webservice.CharityProfile> SearchItems;

        public static C4H_Webservice.CharityProfile curretnSearchItem;

    }
}
