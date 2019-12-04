using System;
using System.Xml.Serialization;

namespace weatherApp.ViewModels
{
    public class Time { 
    [XmlAttribute("from")]
    public DateTime From { get; set; }
    [XmlAttribute("to")]
    public DateTime To { get; set; }
    [XmlElement("location")]
    public Location Location { get; set; }
}
}