using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="wind_data")]
public class WindData { 

    [XmlElement(ElementName="level")] 
    public List<Level> Level { get; set; } 
}