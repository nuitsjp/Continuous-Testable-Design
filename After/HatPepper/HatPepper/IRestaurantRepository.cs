using System.Collections.Generic;
using System.Threading.Tasks;

namespace HatPepper
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> SearchNearbyAsync(Location location, double radius);
    }
}