using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace weatherApp.ViewModels
{
    [XmlRoot("weatherdata")]
    public class WeatherData
    {
        [XmlElement("product")]
        public Product Product { get; set; }
    }

}