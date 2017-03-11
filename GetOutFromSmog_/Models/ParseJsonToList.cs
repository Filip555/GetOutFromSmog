using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GetOutFromSmog_.Models
{
    public class ParseJsonToList
    {
        public string stationLocation { get; private set; }
        public List<Dictionary<string, string>> listMeasurements { get; private set; }

        public List<ParseJsonToList> ParseStringToArray(string json)
        {


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
            //        stationLocation = value2.stationName,
            //        listMeasurements = valuesList
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
                    stationLocation = root["stationName"].ToString(),
                    listMeasurements = valuesList
                });
            }
            return model;
        }
    }
}