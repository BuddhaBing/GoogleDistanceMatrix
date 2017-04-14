using System;
using System.Collections.Generic;
public class DistanceMatrixConfig
{
    private String baseUrl = @"https://maps.googleapis.com/maps/api/distancematrix/json";
    private String unit = "imperial";
    private String apiKey = @"";
    private List<String> paramList = new List<String>();
    private String urlParams;

    public string Configure(List<string> userResponses)
    {
        SetParams(userResponses[0], userResponses[1]);
        CompileParams();
        return CompileUrl();
    }

    private void SetParams(string origin, string destination)
    {
        paramList.Add($"units={unit}");
        paramList.Add($"origins={origin}");
        paramList.Add($"destinations={destination}");
        paramList.Add($"key={apiKey}");
    }

    private void CompileParams()
    {
        foreach(String param in paramList) {
            if (paramList.IndexOf(param) == 0) {
                urlParams += (@"?" + param);
            } else {
                urlParams += (@"&" + param);
            } 
        }
    }
    private string CompileUrl()
    {
        return baseUrl + urlParams;
    }

}