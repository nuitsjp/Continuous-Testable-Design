using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatPepper
{
    public class SearchResult
    {
        public SearchResultStatus Status { get; }

        public IList<Restaurant> Restaurants { get; }

        public SearchResult(SearchResultStatus status, IList<Restaurant> restaurants = null)
        {
            Status = status;
            Restaurants = restaurants;
        }

    }
}
