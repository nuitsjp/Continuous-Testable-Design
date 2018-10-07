using System.Collections.Generic;
using System.Threading.Tasks;

namespace HatPepper
{
    public interface IRestaurantRepository
    {
        Task<SearchResult> SearchNearbyAsync(Location location, double radius);
    }
}