using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using weatherApp.ViewModels;

namespace weatherApp.Controllers
{
    public class WetherController : Controller
    {
        // GET: Wether
        public ActionResult Index()
        {
            return View();
        }

        private static void GetData(string lat ,string lon)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://api.met.no/weatherapi/locationforecast/1.9/?lat=" + lat + ";lon=" + lon +""));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

           // List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonString);

            //Console.WriteLine(items.Count);     //returns 921, the number of items on that page
        }
        public Location GetXmlData(string url)
        {
            Location loc;
            using (var wc = new WebClient())
            {
                // Type you want to deserialize
                var ser = new XmlSerializer(typeof(WeatherData));
                using (var stream = wc.OpenRead(url))
                {
                    // create the object, cast the result
                    var w = (WeatherData)ser.Deserialize(stream);
                    // w.Dump(); // linqpad testing
                    // what do we need
                    loc = w.Product.ForeCasts.First().Location;
                }
            }
            return loc;
        }
    }
}