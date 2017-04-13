using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GoogleDistanceMatrix
{
    class Program
    {
        static String baseUrl = @"https://maps.googleapis.com/maps/api/distancematrix/json";

        // https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=Washington,DC&destinations=New+York+City,NY&key=
        
        static String unit = "imperial";
        static String key = @""; // TODO: correctly get/set environment variables

        static String origin;
        static String destination;

        static String urlParams;

        private static async Task ProcessRequest()
        {
            var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Google Maps Distance Matrix Reporter");

                var stringTask = client.GetStringAsync(baseUrl + urlParams);

                var msg = await stringTask;
                Console.Write(msg);
        }

        static void SetParams() {
            urlParams = $"?units={unit}&origins={origin}&destinations={destination}&key={key}";
        }

        static void Main (string[] args)
        {
            Console.WriteLine("Please enter the origin location: ");
            origin = Console.ReadLine();

            Console.WriteLine("Please enter the destination location: ");
            destination = Console.ReadLine();

            SetParams();
            ProcessRequest().Wait();
        
            // Console.WriteLine("Hit ENTER to exit...");
            // Console.ReadLine();
        }
    }
}