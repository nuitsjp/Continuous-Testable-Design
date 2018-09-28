using System;
using System.Threading.Tasks;

namespace HatPepper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var nearbyRestauranList =
                new NearbyRestauranList(
                    new SearchNearbyRestaurants(
                        new GeoCoordinator(),
                        new GooglePlaceRepository(Secrets.PlaceApiKey)));
            await nearbyRestauranList.Show();

            Console.ReadKey();
        }
    }
}
