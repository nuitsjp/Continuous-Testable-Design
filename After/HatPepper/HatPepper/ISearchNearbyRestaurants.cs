using System.Collections.Generic;
using System.Threading.Tasks;

namespace HatPepper
{
    public interface ISearchNearbyRestaurants
    {
        Task<IEnumerable<Restaurant>> SearchAsync();
    }
}