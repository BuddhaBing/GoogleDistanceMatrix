using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
public class ApiCaller
{
    private JObject jsonObj;

    public ApiCaller(String url)
    {
        Request(url).Wait();
    }
    
    public async Task Request(String url)
    {
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Google Maps Distance Matrix Reporter");

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseText = await response.Content.ReadAsStringAsync();
            StringToJson(responseText);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private void StringToJson(string responseText)
    {
        jsonObj = JObject.Parse(responseText);
    }

    public JObject Response
    {
        get
        {
            return jsonObj;
        }
    }
    
}