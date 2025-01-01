using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="level")]
public class Level { 

    [XmlElement(ElementName="altitude")] 
    public int Altitude { get; set; } 

    [XmlElement(ElementName="wind_dir")] 
    public int WindDir { get; set; } 

    [XmlElement(ElementName="wind_spd")] 
    public int WindSpd { get; set; } 

    [XmlElement(ElementName="oat")] 
    public int Oat { get; set; } 
}