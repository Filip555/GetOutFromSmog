using GetOutFromSmog_.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetOutFromSmog_.Controllers
{
    public class HomeController : Controller
    {
        private readonly GetInfoAboutLongitude _longitude = new GetInfoAboutLongitude();
        private readonly ParseJsonToList _parse = new ParseJsonToList();
        // GET: Home
        public ActionResult Index()
        {
            var model = _parse.ParseStringToArray();
            model = _longitude.GetLongitudeAfterAdress(model);
            return View(model);
        }
    }
}