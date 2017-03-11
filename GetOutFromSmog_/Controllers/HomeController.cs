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
        private readonly ParseJsonToList _parse = new ParseJsonToList();
        // GET: Home
        public ActionResult Index()
        {
var webClient = new System.Net.WebClient();
webClient.Encoding = System.Text.Encoding.UTF8;
var json = webClient.DownloadString(@"http://powietrze.gios.gov.pl/pjp/current/getAQIDetailsList?param=AQI");
            _parse.ParseStringToArray(json);
            return View();
        }
    }
}