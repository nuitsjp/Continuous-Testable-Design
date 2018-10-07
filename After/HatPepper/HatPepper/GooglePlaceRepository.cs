using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;

namespace HatPepper
{
    public class GooglePlaceRepository : IRestaurantRepository
    {
        private readonly string _key;

        public GooglePlaceRepository(string key)
        {
            _key = key;
        }

        public async Task<SearchResult> SearchNearbyAsync(Location location, double radius)
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = Secrets.PlaceApiKey,
                Location = new GoogleApi.Entities.Common.Location(location.Latitude, location.Longitude),
                Radius = radius,
                Language = Language.Japanese,
                Type = SearchPlaceType.Restaurant
            };
            var response = await GooglePlaces.NearBySearch.QueryAsync(request);
            if (response.Status == Status.Ok)
            {
                return new SearchResult(
                    SearchResultStatus.OK,
                    response.Results
                        .Select(nearByResult => new Restaurant { Name = nearByResult.Name, Rating = nearByResult.Rating })
                        .ToList());
            }
            else
            {
                return new SearchResult(SearchResultStatus.ErrorFromRepository);
            }
        }
    }
}
