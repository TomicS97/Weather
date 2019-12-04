using System.Collections.Generic;
using System.Xml.Serialization;

namespace weatherApp.ViewModels
{
    public class Product
    {
        [XmlElement("time")]
        public List<Time> ForeCasts { get; set; }
    }
}