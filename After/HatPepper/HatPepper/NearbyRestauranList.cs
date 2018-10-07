using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatPepper
{
    public class NearbyRestauranList
    {
        private readonly ISearchNearbyRestaurants _searchNearbyRestaurants;

        public NearbyRestauranList(ISearchNearbyRestaurants searchNearbyRestaurants)
        {
            _searchNearbyRestaurants = searchNearbyRestaurants;
        }

        public async Task Show()
        {
            var result = await _searchNearbyRestaurants.SearchAsync();
            Console.WriteLine($"Status:{result.Status}");
            Console.WriteLine();

            if (result.Status == SearchResultStatus.OK)
            {
                foreach (var restaurant in result.Restaurants)
                {
                    Console.WriteLine($"{restaurant.Name} - {restaurant.Rating}");
                }
            }
        }
    }
}
