using GetOutFromSmog_.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GetOutFromSmogTests
{
    public class CalculateDistanceBetweenLatiduteAndLongitudeTest
    {
        [Fact]
        public void Distance_between_main_market_square_and_wawel_dragon_should_be_1km_and_12meters()
        {
            double _mainMarketSquareCracovLatitude = 50.061858;
            double _mainMarketSquareCracovlongtitude = 19.936833;
            double _wawelDragonLatitude = 50.053001;
            double _wawelDragonLongtitude = 19.933568;
            List<ParseJsonToList> model = new List<ParseJsonToList>();
            LatitudesLongitudes testLatAndLong = new LatitudesLongitudes();
            testLatAndLong.Latitudes = _mainMarketSquareCracovLatitude;
            testLatAndLong.Longitudes = _mainMarketSquareCracovlongtitude;
            model.Add(new ParseJsonToList()
            {
                LatAndLong = testLatAndLong
            });

            ReturnFiveNearestStationsInKm calc = new ReturnFiveNearestStationsInKm();

            var result = calc.ReturnNearestStation(model, _wawelDragonLatitude, _wawelDragonLongtitude);

            Assert.Equal(1.012d, result.FirstOrDefault().DistanceBetweenUserAndStation);
        }
    }
}
