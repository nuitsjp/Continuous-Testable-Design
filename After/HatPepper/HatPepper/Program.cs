using System;
using System.Threading.Tasks;

namespace HatPepper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var restaurants = await new SearchNearbyRestaurants().SearchAsync();
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"{restaurant.Name} - {restaurant.Rating}");
            }

            Console.ReadKey();
        }
    }
}
