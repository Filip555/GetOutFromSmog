using GetOutFromSmog_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GetOutFromSmogIntTests
{
    public class ParseJsonToListTest
    {
        string json;
        public ParseJsonToListTest()
        {
            var webClient = new System.Net.WebClient();
            webClient.Encoding = Encoding.UTF8;
            json = webClient.DownloadString(@"http://powietrze.gios.gov.pl/pjp/current/getAQIDetailsList?param=AQI");
        }
        [Fact]
        public void count_measure_from_cracov_should_be_8()
        {
            ParseJsonToList _parse = new ParseJsonToList();

            var result = _parse.ParseStringToArray(json);

            Assert.Equal(8, result.Where(x => x.stationLocation.Contains("Kraków")).Count());

        }
    }
}
