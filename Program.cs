using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        static List<String> paramList = new List<String>();
        static String urlParams;
        static String distance;
        static JObject jsonObj;

        private static async Task ProcessRequest(String url)
        {
            HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Google Maps Distance Matrix Reporter");
                var stringTask = client.GetStringAsync(url);
                jsonObj = JObject.Parse(await stringTask);
        }

        static void ProcessDistance() {
            distance = (string) jsonObj["rows"][0]["elements"][0]["distance"]["text"];
        }

        static void SetParams() {
            paramList.Add($"units={unit}");
            paramList.Add($"origins={origin}");
            paramList.Add($"destinations={destination}");
            paramList.Add($"key={key}");
        }

        static void CompileParams() {
            foreach(String param in paramList) {
                if (paramList.IndexOf(param) == 0) {
                    urlParams += (@"?" + param);
                } else {
                    urlParams += (@"&" + param);
                } 
            }
        }

        static void PrintResult()
        {
            Console.WriteLine(distance);
        }

        static void UserInput()
        {
            Console.WriteLine("Please enter the origin location: ");
            origin = Console.ReadLine();

            Console.WriteLine("Please enter the destination location: ");
            destination = Console.ReadLine();
        }

        static void Main (string[] args)
        {
            UserInput();
            SetParams();
            CompileParams();
            ProcessRequest(baseUrl + urlParams).Wait();
            ProcessDistance();
            PrintResult();
        }
    }
}