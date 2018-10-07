using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HatPepper
{
    public class SearchNearbyRestaurants : ISearchNearbyRestaurants
    {
        private readonly IGeoCoordinator _geoCoordinator;
        private readonly IRestaurantRepository _restaurantRepository;

        public SearchNearbyRestaurants(IGeoCoordinator geoCoordinator, IRestaurantRepository restaurantRepository)
        {
            _geoCoordinator = geoCoordinator;
            _restaurantRepository = restaurantRepository;
        }

        public Task<SearchResult> SearchAsync()
        {
            var location =_geoCoordinator.GetCurrent(TimeSpan.FromSeconds(10));

            return location == null 
                ? Task.FromResult(new SearchResult(SearchResultStatus.Timeout)) 
                : _restaurantRepository.SearchNearbyAsync(location, 1500);
        }
    }
}
