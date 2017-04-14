using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GoogleDistanceMatrix
{
    class Program
    {

        static string Distance(JObject obj)
        {
            if (IsGoodResponse(obj))
            {
                return GetDistance(obj);
            } else
            {
                return "Error - unable to calculate using information entered";
            }
        }

        static bool IsGoodResponse(JObject obj)
        {
            return (string) obj["rows"][0]["elements"][0]["status"] == "OK";
        }

        static string GetDistance(JObject obj)
        {
            return (string) obj["rows"][0]["elements"][0]["distance"]["text"];
        }

        static void Main (string[] args)
        {
            ConsoleIo consoleIo = new ConsoleIo();
            ApiCaller apiCaller = new ApiCaller();
            DistanceMatrixConfig matrixConf = new DistanceMatrixConfig();

            var userResponses = consoleIo.Start();
            String url = matrixConf.Configure(userResponses);
            apiCaller.ProcessRequest(url).Wait();
            var response = apiCaller.GetResponse();
            var distance = Distance(response);
            consoleIo.Output(distance);
        }
    }
}