using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GoogleDistanceMatrix
{
    class Program
    {
        static ConsoleIo consoleIo;
        static List<String> values = new List<String>();

        static void AddValues()
        {
            values.Add("distance");
            values.Add("duration");
        }

        static string Url(List<string> userResponses) {
            DistanceMatrixConfig matrixConf = new DistanceMatrixConfig();
            foreach (String inputText in userResponses)
            {
                matrixConf.AddParam = inputText;
            }
            return matrixConf.Url;
        }

        static string Extract(JObject obj, String dataType)
        {
            try
            {
                return (string) obj["rows"][0]["elements"][0][$"{dataType}"]["text"];
            }
            catch
            {
                return "Error - unable to calculate using information entered";
            }
        }

        static void Finalise(JObject obj)
        {
            foreach(String value in values)
            {
                var extractedVal = Extract(obj, value);
                consoleIo.Output($"The {value} is: {extractedVal}");
            }
        }

        static void Main (string[] args)
        {
            AddValues();
            consoleIo = new ConsoleIo();
            String url = Url(consoleIo.UserReponses);
            ApiCaller apiCaller = new ApiCaller(url);
            var jsonObj = apiCaller.Response;
            Finalise(jsonObj);
        }
    }
}