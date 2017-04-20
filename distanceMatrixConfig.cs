using System;
using System.Collections.Generic;
public class DistanceMatrixConfig
{
    private String baseUrl = @"https://maps.googleapis.com/maps/api/distancematrix/json";
    private String unit = "imperial";
    private String apiKey = @"AIzaSyDYNG45WSHzldnr6HzwHkdjP4lIXGFlZb4";
    private List<String> paramList = new List<String>();
    private String urlParams;
    private Queue<String> paramNames = new Queue<String>();

    public DistanceMatrixConfig()
    {
        paramNames.Enqueue("origins");
        paramNames.Enqueue("destinations");
        paramNames.Enqueue("mode"); // defaults to driving if left blank
        paramList.Add($"units={unit}");
        paramList.Add($"key={apiKey}");
    }

    public String AddParam
    {
        set
        {
            paramList.Insert(0, $"{paramNames.Dequeue()}={value}");
            CompileParams();
        }
    }

    private void CompileParams()
    {
        urlParams = "";
        foreach(String param in paramList) {
            if (paramList.IndexOf(param) == 0) {
                urlParams += (@"?" + param);
            } else {
                urlParams += (@"&" + param);
            } 
        }
    }

    public string Url
    {
        get{ return baseUrl + urlParams; }
    }

}