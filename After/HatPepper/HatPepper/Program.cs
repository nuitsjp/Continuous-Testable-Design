using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using Newtonsoft.Json;

namespace HatPepper
{
    class Program
    {
        private const string Uri = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius=1500&type=restaurant&language=ja&key={2}";
        static async Task Main(string[] args)
        {
            var location = await new GeoCoordinator().GetCurrent();

            var request = new PlacesNearBySearchRequest
            {
                Key = Secrets.PlaceApiKey,
                Location = new GoogleApi.Entities.Common.Location(location.Latitude, location.Longitude),
                Radius = 1500,
                Language = Language.Japanese,
                Type = SearchPlaceType.Restaurant
            };
            var response = await GooglePlaces.NearBySearch.QueryAsync(request);
            foreach (var nearByResult in response.Results)
            {
                Console.WriteLine($"{nearByResult.Name} - {nearByResult.Rating}");
            }
            Console.ReadKey();
        }
    }


    public class Rootobject
    {
        public object[] html_attributions { get; set; }
        public string next_page_token { get; set; }
        public Result[] results { get; set; }
        public string status { get; set; }
    }

    public class Result
    {
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public Photo[] photos { get; set; }
        public string place_id { get; set; }
        public Plus_Code plus_code { get; set; }
        public float rating { get; set; }
        public string reference { get; set; }
        public string scope { get; set; }
        public string[] types { get; set; }
        public string vicinity { get; set; }
        public Opening_Hours opening_hours { get; set; }
        public int price_level { get; set; }
    }

    public class Geometry
    {
        public Viewport viewport { get; set; }
    }

    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Northeast
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Southwest
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Plus_Code
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }

    public class Opening_Hours
    {
        public bool open_now { get; set; }
    }

    public class Photo
    {
        public int height { get; set; }
        public string[] html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }

}
