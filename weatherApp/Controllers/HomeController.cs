using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using weatherApp.ViewModels;

namespace weatherApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

 
        public string ReturnData(string lat, string lon)
        {
            var latLon = "lat=" + lat + "&lon=" + lon;
            var url = $@"https://api.met.no/weatherapi/locationforecast/1.9/?"+ latLon;
            var loc = GetXmlData(url);
            //Double f = loc.Fog;
            // Double t = loc.Temperature;

            return JsonConvert.SerializeObject(loc);
        }

        public Location GetXmlData(string url)
        {
            Location loc;
            using (var wc = new WebClient())
            {
                var ser = new XmlSerializer(typeof(WeatherData));
                using (var stream = wc.OpenRead(url))
                {                   
                    var w = (WeatherData)ser.Deserialize(stream);
                    loc = w.Product.ForeCasts.First().Location;
                }
            }
            return loc;
        }     
    }
}