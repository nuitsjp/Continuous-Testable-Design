using System.Collections.Generic;
using System.Threading.Tasks;

namespace HatPepper
{
    public class SearchNearbyRestaurants : ISearchNearbyRestaurants
    {
        public Task<IEnumerable<Restaurant>> SearchAsync()
        {
            var location = new GeoCoordinator().GetCurrent();
            var repository = new GooglePlaceRepository(Secrets.PlaceApiKey);
            return repository.SearchNearbyAsync(location, 1500);
        }
    }
}
