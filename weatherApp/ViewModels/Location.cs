using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace weatherApp.ViewModels
{
    public class Location
    {
        [XmlAttribute("altitude")]
        public string Altitude { get; set; }
        [XmlElement("temperature")]
        public Value Temperature { get; set; }
        [XmlElement("windDirection")]
        public Measurement WindDirection { get; set; }
        [XmlElement("pressure")]
        public Measurement Pressure { get; set; }
        [XmlElement("fog")]
        public Percent Fog { get; set; }        
        [XmlElement("dewpointTemperature")]
        public Value DewPoint { get; set; }
        [XmlElement("humidity")]
        public Value Humidity { get; set; }
        [XmlElement("lowClouds")]
        public Value LowClouds { get; set; }
        [XmlElement("mediumClouds")]
        public Value MediumClouds { get; set; }
        [XmlElement("highClouds")]
        public Value HighClouds { get; set; }
    }
    
}