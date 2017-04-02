using GetOutFromSmog_.Interfaces;
using GetOutFromSmog_.Models;
using System.Globalization;
using System.Web.Mvc;

namespace GetOutFromSmog_.Controllers
{
    public class HomeController : Controller
    {
        private readonly GetInfoAboutLongitude _longitude = new GetInfoAboutLongitude();
        private readonly ParseJsonToList _parse = new ParseJsonToList();
        private readonly IParseJsonToListAboutMeasureStation _parseJsonToListAboutMeasureStation;
        private readonly IGetInfoAboutCoordiateStation _getInfoAboutCoordiateStation;
        private readonly IReturnNearestStation _returnNearestStation;

        public HomeController(IParseJsonToListAboutMeasureStation parseJsonToListAboutMeasureStation, IGetInfoAboutCoordiateStation getInfoAboutCoordiateStation,
            IReturnNearestStation returnNearestStation)
        {
            _parseJsonToListAboutMeasureStation = parseJsonToListAboutMeasureStation;
            _getInfoAboutCoordiateStation = getInfoAboutCoordiateStation;
            _returnNearestStation = returnNearestStation;
        }
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Coordinate(string lat, string lon)
        {
            var latitudes = double.Parse(lat, CultureInfo.InvariantCulture);
            var longitudes = double.Parse(lon, CultureInfo.InvariantCulture);
            var model = _parseJsonToListAboutMeasureStation.ParseStringToArray();
            model = _getInfoAboutCoordiateStation.GetLongitudeAfterAdress(model);
            model = _returnNearestStation.ReturnNearestStation(model, latitudes, longitudes);
            return View();
        }
    }
}