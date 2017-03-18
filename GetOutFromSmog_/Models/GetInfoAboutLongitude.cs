using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace GetOutFromSmog_.Models
{
public class GetInfoAboutLongitude
{
    public List<ParseJsonToList> GetLongitudeAfterAdress(List<ParseJsonToList> adress)
    {
        var webClient = new System.Net.WebClient { Encoding = System.Text.Encoding.UTF8 };
        foreach (var item in adress)
        {
            var json = webClient.DownloadString(@"https://maps.googleapis.com/maps/api/geocode/json?address=" + item.StationLocation);
            var arrayJson = JObject.Parse(json);
            foreach (JToken latidute in arrayJson.FindTokens("location"))
            {
                item.LatAndLong = new LatitudesLongitudes
                {
                    Latitudes = latidute.FindTokens("lat").FirstOrDefault()?.ToString(),
                    Longitudes = latidute.FindTokens("lng").FirstOrDefault()?.ToString(),
                };
            }
        }
        return adress;
    }
}
}