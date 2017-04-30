using GetOutFromSmog_.Interfaces;
using GetOutFromSmog_.Models;
using System.Globalization;
using System.Web.Mvc;

namespace GetOutFromSmog_.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParseJsonToListAboutMeasureStation _parseJsonToListAboutMeasureStation;
        private readonly IGetInfoAboutCoordiateStation _getInfoAboutCoordiateStation;
        private readonly IReturnNearestStation _returnNearestStation;
        private readonly ICleanestAir _cleanestAir;

        public HomeController(IParseJsonToListAboutMeasureStation parseJsonToListAboutMeasureStation, IGetInfoAboutCoordiateStation getInfoAboutCoordiateStation,
            IReturnNearestStation returnNearestStation, ICleanestAir cleanestAir)
        {
            _parseJsonToListAboutMeasureStation = parseJsonToListAboutMeasureStation;
            _getInfoAboutCoordiateStation = getInfoAboutCoordiateStation;
            _returnNearestStation = returnNearestStation;
            _cleanestAir = cleanestAir;
        }
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Coordinate(string lat, string lon,float range)
        {
            var latitudes = double.Parse(lat, CultureInfo.InvariantCulture);
            var longitudes = double.Parse(lon, CultureInfo.InvariantCulture);
            var model = _parseJsonToListAboutMeasureStation.ParseStringToArray();
            model = _getInfoAboutCoordiateStation.GetLongitudeAfterAdress(model);
            model = _returnNearestStation.ReturnNearestStation(model, latitudes, longitudes,range);
            var leastPollutedPlace = _cleanestAir.CalculateCleanestAir(model);
            return View();
        }
    }
}