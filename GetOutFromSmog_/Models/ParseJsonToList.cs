using GetOutFromSmog_.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GetOutFromSmog_.Models
{
    public class ParseJsonToList : IParseJsonToListAboutMeasureStation
    {
        private readonly GetInfoAboutLongitude _parse = new GetInfoAboutLongitude();
        public string StationLocation { get; private set; }
        public List<Dictionary<string, string>> ListMeasurements { get; private set; }
        public LatitudesLongitudes LatAndLong { get; set; }
        public double DistanceBetweenUserAndStation { get; set; }

        public List<ParseJsonToList> ParseStringToArray()
        {
            var webClient = new System.Net.WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            var json = webClient.DownloadString(@"http://powietrze.gios.gov.pl/pjp/current/getAQIDetailsList?param=AQI");
            #region solution based on dynamic
            //dynamic api = JArray.Parse(json);
            //dynamic check = JsonConvert.DeserializeObject(json);
            //
            //
            //foreach (var value2 in check)
            //{
            //    List<Dictionary<string, string>> valuesList = new List<Dictionary<string, string>>();
            //    foreach (var item in value2.values)
            //    {
            //        Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //        var dynamicName = item.Name;
            //        var dynamicValue = item.Value.ToString();
            //        dictionary.Add(dynamicName, dynamicValue);
            //        valuesList.Add(dictionary);
            //    }
            //    model.Add(new ParseJsonToList()
            //    {
            //        StationLocation = value2.stationName,
            //        ListMeasurements = valuesList
            //    });
            //}
            #endregion
            var arrayJson = JArray.Parse(json);
            List<ParseJsonToList> model = new List<ParseJsonToList>();
            foreach (JObject root in arrayJson)
            {
                List<Dictionary<string, string>> valuesList = new List<Dictionary<string, string>>();
                var values​​Measurements = JObject.Parse(root["values"].ToString());
                foreach (var item2 in values​​Measurements)
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    dictionary.Add(item2.Key, item2.Value.ToString());
                    valuesList.Add(dictionary);
                }
                model.Add(new ParseJsonToList()
                {
                    StationLocation = root["stationName"].ToString(),
                    ListMeasurements = valuesList,
                });
            }
            return model;
        }
    }
}